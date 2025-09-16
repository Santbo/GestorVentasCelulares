using GestionVentasCel.data;
using GestionVentasCel.models.articulo;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.service.articulo.impl
{
    public class HistorialPrecioServiceImpl : IHistorialPrecioService
    {
        private readonly AppDbContext _context;

        public HistorialPrecioServiceImpl(AppDbContext context)
        {
            _context = context;
        }

        public void RegistrarCambioPrecio(int articuloId, decimal precioAnterior, decimal precioNuevo, string motivo)
        {
            var historial = new HistorialPrecio
            {
                ArticuloId = articuloId,
                PrecioAnterior = precioAnterior,
                PrecioNuevo = precioNuevo,
                FechaCambio = DateTime.Now,
                Motivo = motivo
            };

            _context.HistorialPrecios.Add(historial);
            _context.SaveChanges();
        }

        public HistorialPrecio? GetUltimoPrecio(int articuloId)
        {
            return _context.HistorialPrecios
                .Where(h => h.ArticuloId == articuloId)
                .OrderByDescending(h => h.FechaCambio)
                .FirstOrDefault();
        }

        public IEnumerable<HistorialPrecio> GetHistorialPorArticulo(int articuloId)
        {
            return _context.HistorialPrecios
                .Where(h => h.ArticuloId == articuloId)
                .OrderByDescending(h => h.FechaCambio)
                .ToList();
        }
    }
}
