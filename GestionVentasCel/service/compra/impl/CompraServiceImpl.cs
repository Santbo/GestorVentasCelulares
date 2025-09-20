using GestionVentasCel.exceptions.compra;
using GestionVentasCel.exceptions.configPrecios;
using GestionVentasCel.models.compra;
using GestionVentasCel.repository.compra;
using GestionVentasCel.repository.configPrecios;
using GestionVentasCel.service.articulo;
using GestionVentasCel.service.configPrecios;

namespace GestionVentasCel.service.compra.impl
{
    public class CompraServiceImpl : ICompraService
    {
        private readonly ICompraRepository _repo;
        private readonly IDetalleCompraRepository _detalleRepo;
        private readonly IArticuloService _articuloService;
        private readonly IHistorialPrecioService _historialPrecioService;
        private readonly IConfiguracionPreciosService _configuracionPreciosService;

        public CompraServiceImpl(ICompraRepository repo,
                                    IDetalleCompraRepository detalleRepo,
                                    IArticuloService articuloService,
                                    IHistorialPrecioService historialPrecioService,
                                    IConfiguracionPreciosService configuracionPreciosService)
        {
            _repo = repo;
            _detalleRepo = detalleRepo;
            _articuloService = articuloService;
            _historialPrecioService = historialPrecioService;
            _configuracionPreciosService = configuracionPreciosService;
        }


        public void AgregarCompraConDetalles(Compra compra, List<DetalleCompra> detalles)
        {


            if (!_configuracionPreciosService.MargenExist(1))
            {
                throw new MargenNoAgregadoException("Margen no agregado. Por favor agrega un margen de actualizacion de precios");

            }
            // Calcular el total
            compra.Total = CalcularTotal(detalles);

            // Agregar la compra
            _repo.Add(compra);

            // Agregar los detalles y actualizar stock
            foreach (var detalle in detalles)
            {
                detalle.CompraId = compra.Id;
                detalle.Subtotal = detalle.Cantidad * detalle.PrecioUnitario;

                // Actualizar stock del artículo
                ActualizarStockArticulo(detalle.ArticuloId, detalle.Cantidad, detalle.PrecioUnitario, "nueva");
            }

            _detalleRepo.AddRange(detalles);
        }

        public IEnumerable<Compra> ListarCompras() => _repo.GetAll();
        

        public IEnumerable<Compra> ListarComprasConDetalles() => _repo.GetAllWithDetails();
        public IEnumerable<Compra> GetByProveedor(int proveedorId) => _repo.GetByProveedor(proveedorId);
        public Compra? GetByIdWithDetails(int id) => _repo.GetByIdWithDetails(id);

        public void ActualizarCompraConDetalles(Compra compra, List<DetalleCompra> detalles)
        {
            if (!_repo.Exist(compra.Id))
            {
                throw new CompraNoEncontradaException("Compra no encontrada.");
            }

            // Obtener detalles existentes para revertir stock
            var detallesExistentes = _detalleRepo.GetByCompraId(compra.Id);

            // Revertir stock de detalles existentes
            foreach (var detalleExistente in detallesExistentes)
            {
                ActualizarStockArticulo(detalleExistente.ArticuloId, detalleExistente.Cantidad, detalleExistente.PrecioUnitario, "revertir");
            }

            // Actualizar la compra
            compra.Total = CalcularTotal(detalles);
            _repo.Update(compra);

            // Eliminar detalles existentes
            _detalleRepo.DeleteByCompraId(compra.Id);

            // Agregar nuevos detalles y actualizar stock
            foreach (var detalle in detalles)
            {
                detalle.CompraId = compra.Id;
                detalle.Subtotal = detalle.Cantidad * detalle.PrecioUnitario;

                // Actualizar stock del artículo
                ActualizarStockArticulo(detalle.ArticuloId, detalle.Cantidad, detalle.PrecioUnitario, "nueva");
            }

            _detalleRepo.AddRange(detalles);
        }

        public void EliminarCompra(int id)
        {
            if (!_repo.Exist(id))
            {
                throw new CompraNoEncontradaException("Compra no encontrada.");
            }

            // Obtener detalles para revertir stock
            var detalles = _detalleRepo.GetByCompraId(id);

            // Revertir stock de cada detalle
            foreach (var detalle in detalles)
            {
                ActualizarStockArticulo(detalle.ArticuloId, detalle.Cantidad, detalle.PrecioUnitario, "revertir");
            }

            _repo.Delete(id);
        }

        public decimal CalcularTotal(List<DetalleCompra> detalles)
        {
            return detalles.Sum(d => d.Cantidad * d.PrecioUnitario);
        }

        private void ActualizarStockArticulo(int articuloId, int cantidad, decimal precioUnitario, string tipoOperacion)
        {
            var articulo = _articuloService.GetById(articuloId);
            if (articulo == null) return;

            var margenAumento = _configuracionPreciosService.GetById(1);

            switch (tipoOperacion)
            {
                case "nueva":
                    articulo.Stock += cantidad;
                    if (articulo.Stock == cantidad || articulo.Precio == 0 || precioUnitario > articulo.Precio)
                    {
                        var nuevoPrecio = precioUnitario * margenAumento.MargenAumento;
                        _historialPrecioService.RegistrarCambioPrecio(articuloId, nuevoPrecio, articulo.Precio, "Compra nueva");
                        articulo.Precio = nuevoPrecio;
                    }
                    break;

                case "revertir":
                    articulo.Stock -= cantidad;

                    var ultimoPrecio = _historialPrecioService.GetUltimoPrecio(articuloId);
                    if (ultimoPrecio != null)
                    {
                        articulo.Precio = ultimoPrecio.PrecioAnterior;
                    }
                    break;
            }

            _articuloService.UpdateArticulo(articulo);
        }
    }
}
