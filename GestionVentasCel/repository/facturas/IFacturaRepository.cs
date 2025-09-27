using GestionVentasCel.models.ventas;

namespace GestionVentasCel.repository.facturas
{
    public interface IFacturaRepository
    {
        Factura? ObtenerPorId(int id);
        IEnumerable<Factura> ObtenerTodas();

        public void GenerarNumeroFactura(int id);
        void Agregar(Factura factura);
        bool Existe(int id);
    }
}
