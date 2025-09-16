using GestionVentasCel.exceptions.compra;
using GestionVentasCel.models.compra;
using GestionVentasCel.repository.compra;
using GestionVentasCel.service.articulo;

namespace GestionVentasCel.service.compra.impl
{
    public class CompraServiceImpl : ICompraService
    {
        private readonly ICompraRepository _repo;
        private readonly IDetalleCompraRepository _detalleRepo;
        private readonly IArticuloService _articuloService;
        private readonly IHistorialPrecioService _historialPrecioService;

        public CompraServiceImpl(ICompraRepository repo, IDetalleCompraRepository detalleRepo, IArticuloService articuloService, IHistorialPrecioService historialPrecioService)
        {
            _repo = repo;
            _detalleRepo = detalleRepo;
            _articuloService = articuloService;
            _historialPrecioService = historialPrecioService;
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
            
            // Agregar los detalles y actualizar stock
            foreach (var detalle in detalles)
            {
                detalle.CompraId = compra.Id;
                detalle.Subtotal = detalle.Cantidad * detalle.PrecioUnitario;
                
                // Actualizar stock del artículo
                ActualizarStockArticulo(detalle.ArticuloId, detalle.Cantidad, detalle.PrecioUnitario, true);
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

            // Obtener detalles existentes para revertir stock
            var detallesExistentes = _detalleRepo.GetByCompraId(compra.Id);
            
            // Revertir stock de detalles existentes
            foreach (var detalleExistente in detallesExistentes)
            {
                ActualizarStockArticulo(detalleExistente.ArticuloId, detalleExistente.Cantidad, detalleExistente.PrecioUnitario, false);
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
                ActualizarStockArticulo(detalle.ArticuloId, detalle.Cantidad, detalle.PrecioUnitario, true);
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
                ActualizarStockArticulo(detalle.ArticuloId, detalle.Cantidad, detalle.PrecioUnitario, false);
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

        private void ActualizarStockArticulo(int articuloId, int cantidad, decimal precioUnitario, bool esCompra)
        {
            var articulo = _articuloService.GetById(articuloId);
            if (articulo != null)
            {
                if (esCompra)
                {
                    // Agregar stock al comprar
                    articulo.Stock += cantidad; 
                    
                    // Actualizar precio si no se tenía stock (articulo.Stock == cuantidad) o si no tenía precio (articulo.Precio == 0)
                    if (articulo.Stock == cantidad || articulo.Precio == 0)
                    {
                        // Registrar cambio de precio
                        _historialPrecioService.RegistrarCambioPrecio(articuloId, articulo.Precio, precioUnitario, "Compra");
                        articulo.Precio = precioUnitario;
                    } //TODO: Si no es la primera compra, entonces se tiene que actualizar el precio solamente si el nuevo precio es mayor al viejo
                      // sería un if precio * 1.51 > precio_actual then actualizar básicamente, aunque el 1.51 debería poder fijarse manualmente
                }
                else
                {
                    // Restar stock al eliminar compra
                    // Esto es todo un tema, porque si se editó el stock manualmente, o se vendió un poco de stock 
                    // y luego se eliminó una compra, se rompe la consistencia, porque el código elimina artículos que ya no existen
                    // Por ejemplo, si se compran 5 teléfonos, y se venden 4, entonces quedaría un solo teléfno
                    // Si luego de esa venta, se elimina la compra de los 5 teléfonos, el código restaría esa cantidad y quedaríamos con -4 teléfonos
                    // A dónde se fueron? Nadie lo sabe, pero ahora debemos 4 teléfonos a alguien que no conocemos.
                    // PD: El revertir el precio tampoco funciona, por lo menos en mis pruebas. 
                    articulo.Stock -= cantidad;
                    
                    // Si el stock llega a 0, mantener el precio actual
                    if (articulo.Stock > 0)
                    {
                        // Recuperar el precio anterior del historial
                        var ultimoPrecio = _historialPrecioService.GetUltimoPrecio(articuloId);
                        if (ultimoPrecio != null && ultimoPrecio.PrecioAnterior > 0)
                        {
                            // Registrar cambio de precio
                            _historialPrecioService.RegistrarCambioPrecio(articuloId, articulo.Precio, ultimoPrecio.PrecioAnterior, "EliminacionCompra");
                            articulo.Precio = ultimoPrecio.PrecioAnterior;
                        }
                    }
                }
                
                _articuloService.UpdateArticulo(articulo);
            }
        }
    }
}
