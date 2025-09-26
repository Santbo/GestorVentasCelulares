using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.models.ventas;

namespace GestionVentasCel.service.factura
{
    public interface IFacturaService
    {
        Factura? ObtenerPorId(int id);
        IEnumerable<Factura> ObtenerTodas();
        Factura EmitirFactura(Venta venta, TipoFacturaEnum? tipoFactura = null);
    }
}
