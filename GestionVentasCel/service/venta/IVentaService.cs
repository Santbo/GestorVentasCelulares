using GestionVentasCel.models.ventas;

namespace GestionVentasCel.service.venta
{
    public interface IVentaService
    {
        // CRUD básico
        void AgregarVenta(Venta venta);
        void ActualizarVenta(Venta venta);
        void EliminarVenta(int id);

        IEnumerable<Venta> ListarVentasConDetalles();
        Venta? ObtenerVentaPorIdConDetallesNoTracking(int id);

        Factura? ObtenerFacturaDeVenta(Venta venta);

        void ConfirmarVenta(int ventaId, bool editando = true);

        List<string> ObtenerMediosDePagoDisponibles(int idCliente);
    }

}
