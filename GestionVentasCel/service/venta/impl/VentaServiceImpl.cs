using GestionVentasCel.enumerations.cuentaCorriente;
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

        private void GestionarVentaACuenta(Venta venta)
        {
            // 1. Si el cliente no tiene cuenta corriente:
            //      1.1 Crear una cuenta corriente
            // 2. Agregar un movimiento a la cuenta corriente con el monto de la venta.

            CuentaCorriente? cuentaCorriente = _cuentaCorrienteRepo.GetByClienteId( venta.ClienteId );
            bool tieneCuenta = cuentaCorriente != null;

            // 1. Si el cliente no tiene cuenta corriente
            if (cuentaCorriente == null )
            {
                // 1.1 Crear una cuenta corriente

                cuentaCorriente = new CuentaCorriente
                {
                    ClienteId = venta.ClienteId,
                    Activo = true
                };
            }

            // 2. Agregar un movimiento a la cuenta corriente con el monto de la venta.
            cuentaCorriente.Movimientos.Add(new MovimientoCuentaCorriente
            {
                Fecha = (DateTime) venta.FechaVenta!,
                Monto = venta.TotalConIva,
                VentaId = venta.Id,
                Tipo = TipoMovimiento.Aumento,
                Descripcion = $"Venta número {venta.Id} del {venta.FechaVenta}"

            });

            if (tieneCuenta)
            {
                _cuentaCorrienteRepo.Update(cuentaCorriente);
            } else
            {
                _cuentaCorrienteRepo.Add(cuentaCorriente);
            }
        }

        public void ActualizarVenta(Venta ventaActualizada)
        {
            
            _ventaRepo.Actualizar(ventaActualizada);
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
            foreach (var detalle in venta.Detalles)
            {
                if (detalle.EsArticulo && detalle.Articulo != null)
                {
                    detalle.Articulo.Stock -= detalle.Cantidad;
                }
                //TODO: Editar la venta y cambiar el tipo de pago no cambia nada

                if (detalle.EsReparacion && detalle.Reparacion != null)
                {
                    detalle.Reparacion.Estado = EstadoReparacionEnum.Terminado;

                }
            }

            venta.EstadoVenta = EstadoVentaEnum.Confirmada;
            venta.FechaVenta = DateTime.Now;

            if (venta.TipoPago == TipoPagoEnum.CuentaCorriente)
            {
                this.GestionarVentaACuenta(venta);
            }

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
