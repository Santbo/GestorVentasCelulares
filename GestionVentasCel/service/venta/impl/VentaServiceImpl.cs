using GestionVentasCel.enumerations.cuentaCorriente;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.exceptions.caja;
using GestionVentasCel.exceptions.venta;
using GestionVentasCel.models.CuentaCorreinte;
using GestionVentasCel.models.ventas;
using GestionVentasCel.repository.ClienteCuentaCorriente;
using GestionVentasCel.repository.ventas;
using GestionVentasCel.service.articulo;
using GestionVentasCel.service.caja;
using GestionVentasCel.service.reparacion;

namespace GestionVentasCel.service.venta.impl
{
    public class VentaServiceImpl : IVentaService
    {
        private readonly IVentaRepository _ventaRepo;
        private readonly IArticuloService _articuloService;
        private readonly ICuentaCorrienteRepository _cuentaCorrienteRepo;
        private readonly IReparacionService _reparacionService;
        private readonly ICajaService _cajaService;

        public VentaServiceImpl(
            IVentaRepository ventaRepo,
            IArticuloService articuloService,
            ICuentaCorrienteRepository cuentaCorrienteRepo,
            IReparacionService reparacionService,
            ICajaService cajaService
            )
        {
            _ventaRepo = ventaRepo;
            _articuloService = articuloService;
            _cuentaCorrienteRepo = cuentaCorrienteRepo;
            _reparacionService = reparacionService;
            _cajaService = cajaService;
        }

        public void AgregarVenta(Venta venta)
        {
            _ventaRepo.Agregar(venta);
        }


        public void ActualizarVenta(Venta ventaActualizada)
        {
            if (_cajaService.HayCajaAbierta())
            {

                _ventaRepo.Actualizar(ventaActualizada);

            }
            else
            {
                throw new CajaNoEncontradaException("Se intentó vender algo teniendo la caja cerrada");
            }
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



        public IEnumerable<Venta> ListarVentasConDetalles() => _ventaRepo.ObtenerTodasConDetalles();


        public Venta? ObtenerVentaPorIdConDetallesNoTracking(int id) => _ventaRepo.ObtenerPorIdConDetallesNoTracking(id);

        /// <summary>
        /// Realiza la venta: cambia estado a Confirmada y descuenta stock
        /// </summary>
        public void ConfirmarVenta(int ventaId, bool editando = false)
        {

            if (_cajaService.HayCajaAbierta())
            {

                _ventaRepo.ConfirmarVenta(ventaId);

            } else
            {
                throw new CajaNoEncontradaException("Se intentó vender algo teniendo la caja cerrada");
            }


        }

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
            listaFiltrada.Remove(TipoPagoEnum.Retiro.ToString());

            if (cc != null && !cc.Activo)
            {
                listaFiltrada.Remove(TipoPagoEnum.CuentaCorriente.ToString());
            }
            return listaFiltrada;
        }

        public Factura? ObtenerFacturaDeVenta(Venta venta)
        {
            return _ventaRepo.ObtenerFacturaDeVenta(venta);
        }
    }

}
