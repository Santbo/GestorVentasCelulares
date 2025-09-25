using GestionVentasCel.enumerations.reparacion;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.exceptions.venta;
using GestionVentasCel.models.CuentaCorreinte;
using GestionVentasCel.models.ventas;
using GestionVentasCel.repository.ClienteCuentaCorriente;
using GestionVentasCel.repository.ventas;
using GestionVentasCel.service.articulo;
using GestionVentasCel.service.reparacion;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GestionVentasCel.service.venta.impl
{
    public class VentaServiceImpl : IVentaService
    {
        private readonly IVentaRepository _ventaRepo;
        private readonly IArticuloService _articuloService;
        private readonly ICuentaCorrienteRepository _cuentaCorrienteRepo;
        private readonly IReparacionService _reparacionService;

        public VentaServiceImpl(
            IVentaRepository ventaRepo,
            IArticuloService articuloService,
            ICuentaCorrienteRepository cuentaCorrienteRepo,
            IReparacionService reparacionService
            )
        {
            _ventaRepo = ventaRepo;
            _articuloService = articuloService;
            _cuentaCorrienteRepo = cuentaCorrienteRepo;
            _reparacionService = reparacionService;
        }

        public void AgregarVenta(Venta venta)
        {
            _ventaRepo.Agregar(venta);
        }

        public void ActualizarVenta(Venta ventaActualizada)
        {
            // Como la venta, en teoría, siempre tiene no tracking, la ventaActualizada se usa para leer nomás
            // Todos los cambios se hacen sobre la original
            // Se tiene que:
            //  1. Traer la venta original de la DB
            //  2. Si la venta original estaba >= Confirmada:
            //      2.1 Revertir el stock de los articulos
            //      2.2 Revertir los estados de las reparaciones
            //      2.3 Poner FechaVenta en null
            //  3. Eliminar todos los detalles originales
            //  4. Agregar todos los detalles de la venta nueva
            //  5. Si la venta nueva está == Confirmada:
            //      5.1 Llamar a ConfirmarVenta()

            // 1. Traer la venta original de la db
            // TODO: Se rompe esto con tracking?
            Venta? ventaOriginal = _ventaRepo.ObtenerPorIdConDetalles(ventaActualizada.Id);
            if ( ventaOriginal == null )
            {
                throw new VentaNoEncontradaException("Se intentó actualizar una venta que no existe ne la DB");
            }

            // 2. si la venta está más que confirmada:
            if (ventaOriginal!.EstadoVenta >= EstadoVentaEnum.Confirmada)
            {
                foreach (DetalleVenta det in ventaOriginal.Detalles)
                {
                    // 2.1 Revertir el stock de los articulos
                    if (det.EsArticulo && det.Articulo != null)
                    {
                        det.Articulo.Stock += det.Cantidad;
                        //_articuloService.UpdateArticulo(det.Articulo); Esto capaz no es necsaio
                    }
                    // 2.2 Revertir los estados de las reparaciones
                    if (det.EsReparacion && det.Reparacion!= null)
                    {
                        det.Reparacion.Estado = EstadoReparacionEnum.Terminado;
                        //_reparacionService.ActualizarReparacion(det.Reparacion); Esto capaz no es necesario
                    }
                }

                // 2.3 Poner fechaVentaa en nulo
                ventaOriginal.FechaVenta = null;
            }

            // 3. Eliminar todos los detalles originales
            ventaOriginal.Detalles.Clear();

            // 4. Agregar todos los detalles de la venta nueva
            foreach (var nuevoDetalle in ventaActualizada.Detalles)
            {
                ventaOriginal.Detalles.Add(nuevoDetalle);
            }
            
            // 5. Si la venta nueva está confirmada
            if (ventaActualizada.EstadoVenta >= EstadoVentaEnum.Confirmada)
            {
                foreach (var detalle in ventaOriginal.Detalles)
                {
                    if (detalle.EsArticulo && detalle.Articulo != null)
                    {
                        detalle.Articulo.Stock -= detalle.Cantidad;
                    }

                    if (detalle.EsReparacion && detalle.Reparacion != null)
                    {
                        detalle.Reparacion.Estado = EstadoReparacionEnum.Entregado;
                    }
                }

                ventaOriginal.FechaVenta = DateTime.Now;
                ventaOriginal.EstadoVenta = ventaActualizada.EstadoVenta;
            }
            
            _ventaRepo.Actualizar(ventaOriginal);

        }

        public void EliminarVenta(int id)
        {
            // Obtener venta con detalles
            var venta = _ventaRepo.ObtenerPorIdConDetalles(id);
            if (venta == null)
                throw new VentaNoEncontradaException("Se intentó eliminar una venta que no existe en la DB");

            if (venta.EstadoVenta >= EstadoVentaEnum.Confirmada)
            {
                // Revertir stock de los artículos vendidos si se confirmó la vetna
                foreach (var detalle in venta.Detalles)
                {
                    if (detalle.EsArticulo && detalle.Articulo != null)
                    {
                        detalle.Articulo.Stock += detalle.Cantidad;
                        _articuloService.UpdateArticulo(detalle.Articulo);
                    }
                }

            }

            // Marcar la venta como anulada para borrado logico
            _ventaRepo.Eliminar(id);
        }


        public bool ExisteVenta(int id) => _ventaRepo.Existe(id);

        public IEnumerable<Venta> ListarVentas() => _ventaRepo.ObtenerTodas();

        public IEnumerable<Venta> ListarVentasConDetalles() => _ventaRepo.ObtenerTodasConDetalles();

        public Venta? ObtenerVentaPorId(int id) => _ventaRepo.ObtenerPorId(id);

        public Venta? ObtenerVentaPorIdConDetalles(int id) => _ventaRepo.ObtenerPorIdConDetalles(id);
        public Venta? ObtenerVentaPorIdConDetallesNoTracking(int id) => _ventaRepo.ObtenerPorIdConDetallesNoTracking(id);


        public void AgregarDetalle(int ventaId, DetalleVenta detalle)
        {
            _ventaRepo.AgregarDetalle(ventaId, detalle);
        }

        public void EliminarDetalle(int detalleId)
        {
            _ventaRepo.EliminarDetalle(detalleId);
        }

        /// <summary>
        /// Actualiza precios de un presupuesto
        /// </summary>
        public void ActualizarPrecios(int idVenta)
        {
            var venta = _ventaRepo.ObtenerPresupuestoPorId(idVenta);

            if (venta == null) { return; }

            if (venta.FechaVencimiento.HasValue && DateTime.Now > venta.FechaVencimiento.Value)
            {
                foreach (var detalle in venta.Detalles)
                {
                    if (detalle.EsArticulo && detalle.Articulo != null) //TODO: Actualizar si es una reparacion
                    {
                        detalle.PrecioUnitario = detalle.Articulo.Precio; // toma precio actualizado del artículo
                    }
                }
                _ventaRepo.Actualizar(venta);
            }
        }


        /// <summary>
        /// Realiza la venta: cambia estado a Confirmada y descuenta stock
        /// </summary>
        public void ConfirmarVenta(int ventaId, bool editando = false)
        {
            var venta = _ventaRepo.ObtenerPorIdConDetalles(ventaId);
            if (venta == null)
                throw new VentaNoEncontradaException("Se intentó confirmar una venta que no existe");

            if (venta.EstadoVenta == EstadoVentaEnum.Confirmada && !editando)
                throw new ConfirmacionVentaDupicadaException("Se intentó confirmar una venta que ya estaba confirmada");

            //TODO: Si es a cuenta corriente, se tiene que crear un movimiento, A MENOS QUE ESTÉ DESACTIVADA
            //TODO: Si no tiene cuenta corriente, se tiene que crear una
            //TODO: Modificar el singleton de inicio de sesión para que tenga también la ID del usuario registrado, para poder sacar de ahí la ID del usuario que creó la venta.
            foreach (var detalle in venta.Detalles)
            {
                if (detalle.EsArticulo && detalle.Articulo != null)
                {
                    detalle.Articulo.Stock -= detalle.Cantidad;
                }

                if (detalle.EsReparacion && detalle.Reparacion != null)
                {
                    detalle.Reparacion.Estado = EstadoReparacionEnum.Terminado;

                }
            }

            venta.EstadoVenta = EstadoVentaEnum.Confirmada;
            //TODO: Tiene sentido actualizar esto? 
            venta.FechaVenta = DateTime.Now;

            _ventaRepo.Actualizar(venta);
        }

        /// <summary>
        /// Obtener todas las ventas que SEAN PRESUPUESTOS
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Venta> ObtenerPresupuestos() => _ventaRepo.ObtenerPresupuestos();
        /// <summary>
        /// Obtener todas las ventas que NO sean presupuestos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Venta> ObtenerVentas() => _ventaRepo.ObtenerVentas();

        /// <summary>
        /// Obtener los medios de pago con los que el cliente puede pagar. ünicamente se 
        /// muestra Efectivo si el cliente tiene una cuenta corriente deshabilitada. Si no, se muestra todo el enum
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<string> ObtenerMediosDePagoDisponibles(int idCliente)
        {
            CuentaCorriente? cc = _cuentaCorrienteRepo.GetByClienteId(idCliente);

            var listaFiltrada = Enum.GetNames(typeof(TipoPagoEnum)).ToList();

            if (cc != null && !cc.Activo)
            {
                listaFiltrada.Remove(TipoPagoEnum.CuentaCorriente.ToString());
            }
            return listaFiltrada;
        }
    }

}
