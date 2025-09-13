using GestionVentasCel.models.compra;
using GestionVentasCel.service.compra;

namespace GestionVentasCel.controller.compra
{
    public class CompraController
    {
        private readonly ICompraService _service;

        public CompraController(ICompraService service)
        {
            _service = service;
        }

        public void CrearCompra(Compra compra)
        {
            _service.AgregarCompra(compra);
        }

        public void CrearCompraConDetalles(Compra compra, List<DetalleCompra> detalles)
        {
            _service.AgregarCompraConDetalles(compra, detalles);
        }

        public void ActualizarCompra(Compra compra)
        {
            _service.ActualizarCompra(compra);
        }

        public void ActualizarCompraConDetalles(Compra compra, List<DetalleCompra> detalles)
        {
            _service.ActualizarCompraConDetalles(compra, detalles);
        }

        public void EliminarCompra(int id)
        {
            _service.EliminarCompra(id);
        }

        public IEnumerable<Compra> ObtenerCompras()
        {
            return _service.ListarCompras();
        }

        public IEnumerable<Compra> ObtenerComprasConDetalles()
        {
            return _service.ListarComprasConDetalles();
        }

        public IEnumerable<Compra> GetByProveedor(int proveedorId)
        {
            return _service.GetByProveedor(proveedorId);
        }

        public IEnumerable<Compra> GetByFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            return _service.GetByFecha(fechaDesde, fechaHasta);
        }

        public Compra? GetById(int id)
        {
            return _service.GetById(id);
        }

        public Compra? GetByIdWithDetails(int id)
        {
            return _service.GetByIdWithDetails(id);
        }

        public bool ExisteCompra(int id)
        {
            return _service.ExisteCompra(id);
        }

        public decimal CalcularTotal(List<DetalleCompra> detalles)
        {
            return _service.CalcularTotal(detalles);
        }
    }
}
