using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.exceptions.venta;
using GestionVentasCel.models.ventas;
using GestionVentasCel.repository.ventas;
using GestionVentasCel.service.articulo;

namespace GestionVentasCel.service.venta.impl
{
    public class VentaServiceImpl : IVentaService
    {
        private readonly IVentaRepository _ventaRepo;
        private readonly IArticuloService _articuloService;

        public VentaServiceImpl(IVentaRepository ventaRepo, IArticuloService articuloService)
        {
            _ventaRepo = ventaRepo;
            _articuloService = articuloService;
        }

        public void AgregarVenta(Venta venta)
        {
            _ventaRepo.Agregar(venta);
        }

        public void ActualizarVenta(Venta venta)
        {
            if (!_ventaRepo.Existe(venta.Id))
                throw new VentaNoEncontradaException("Se intentó actualizar una venta que no existe ne la DB");

            _ventaRepo.Actualizar(venta);
        }

        public void EliminarVenta(int id)
        {
            // Obtener venta con detalles
            var venta = _ventaRepo.ObtenerPorIdConDetalles(id);
            if (venta == null)
                throw new VentaNoEncontradaException("Se intentó eliminar una venta que no existe en la DB");

            if (venta.EstadoVenta == EstadoVentaEnum.Confirmada)
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
        public void ConfirmarVenta(int ventaId)
        {
            var venta = _ventaRepo.ObtenerPorIdConDetalles(ventaId);
            if (venta == null)
                throw new VentaNoEncontradaException("Se intentó confirmar una venta que no existe");

            if (venta.EstadoVenta == EstadoVentaEnum.Confirmada)
                throw new ConfirmacionVentaDupicadaException("Se intentó confirmar una venta que ya estaba confirmada");

            //TODO: Si es a cuenta corriente, se tiene que crear un movimiento, A MENOS QUE ESTÉ DESACTIVADA
            //TODO: Si no tiene cuenta corriente, se tiene que crear una
            //TODO: Modificar el singleton de inicio de sesión para que tenga también la ID del usuario registrado, para poder sacar de ahí la ID del usuario que creó la venta.
            foreach (var detalle in venta.Detalles)
            {
                if (detalle.EsArticulo && detalle.Articulo != null)
                {
                    detalle.Articulo.Stock -= detalle.Cantidad;
                    _articuloService.UpdateArticulo(detalle.Articulo);
                }
            }

            venta.EstadoVenta = EstadoVentaEnum.Confirmada;
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
    }

}
