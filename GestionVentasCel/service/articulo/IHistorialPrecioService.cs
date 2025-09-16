using GestionVentasCel.models.articulo;

namespace GestionVentasCel.service.articulo
{
    public interface IHistorialPrecioService
    {
        void RegistrarCambioPrecio(int articuloId, decimal precioAnterior, decimal precioNuevo, string motivo);
        HistorialPrecio? GetUltimoPrecio(int articuloId);
        IEnumerable<HistorialPrecio> GetHistorialPorArticulo(int articuloId);
    }
}
