using GestionVentasCel.exceptions.compra;
using GestionVentasCel.models.compra;
using GestionVentasCel.repository.compra;

namespace GestionVentasCel.service.compra.impl
{
    public class CompraServiceImpl : ICompraService
    {
        private readonly ICompraRepository _repo;
        private readonly IDetalleCompraRepository _detalleRepo;

        public CompraServiceImpl(ICompraRepository repo, IDetalleCompraRepository detalleRepo)
        {
            _repo = repo;
            _detalleRepo = detalleRepo;
        }

        public void AgregarCompra(Compra compra)
        {
            _repo.Add(compra);
        }

        public void AgregarCompraConDetalles(Compra compra, List<DetalleCompra> detalles)
        {
            // Calcular el total
            compra.Total = CalcularTotal(detalles);
            
            // Agregar la compra
            _repo.Add(compra);
            
            // Agregar los detalles
            foreach (var detalle in detalles)
            {
                detalle.CompraId = compra.Id;
                detalle.Subtotal = detalle.Cantidad * detalle.PrecioUnitario;
            }
            
            _detalleRepo.AddRange(detalles);
        }

        public IEnumerable<Compra> ListarCompras()
        {
            return _repo.GetAll();
        }

        public IEnumerable<Compra> ListarComprasConDetalles()
        {
            return _repo.GetAllWithDetails();
        }

        public IEnumerable<Compra> GetByProveedor(int proveedorId)
        {
            return _repo.GetByProveedor(proveedorId);
        }

        public IEnumerable<Compra> GetByFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            return _repo.GetByFecha(fechaDesde, fechaHasta);
        }

        public void ActualizarCompra(Compra compra)
        {
            if (!_repo.Exist(compra.Id))
            {
                throw new CompraNoEncontradaException("Compra no encontrada.");
            }

            _repo.Update(compra);
        }

        public void ActualizarCompraConDetalles(Compra compra, List<DetalleCompra> detalles)
        {
            if (!_repo.Exist(compra.Id))
            {
                throw new CompraNoEncontradaException("Compra no encontrada.");
            }

            // Actualizar la compra
            compra.Total = CalcularTotal(detalles);
            _repo.Update(compra);

            // Eliminar detalles existentes
            _detalleRepo.DeleteByCompraId(compra.Id);

            // Agregar nuevos detalles
            foreach (var detalle in detalles)
            {
                detalle.CompraId = compra.Id;
                detalle.Subtotal = detalle.Cantidad * detalle.PrecioUnitario;
            }
            
            _detalleRepo.AddRange(detalles);
        }

        public void EliminarCompra(int id)
        {
            if (!_repo.Exist(id))
            {
                throw new CompraNoEncontradaException("Compra no encontrada.");
            }

            _repo.Delete(id);
        }

        public Compra? GetById(int id)
        {
            return _repo.GetById(id);
        }

        public Compra? GetByIdWithDetails(int id)
        {
            return _repo.GetByIdWithDetails(id);
        }

        public bool ExisteCompra(int id)
        {
            return _repo.Exist(id);
        }

        public decimal CalcularTotal(List<DetalleCompra> detalles)
        {
            return detalles.Sum(d => d.Cantidad * d.PrecioUnitario);
        }
    }
}
