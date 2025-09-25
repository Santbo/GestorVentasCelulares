using GestionVentasCel.models.ventas;

namespace GestionVentasCel.service.venta
{
    public interface IVentaService
    {
        // CRUD básico
        void AgregarVenta(Venta venta);
        void ActualizarVenta(Venta venta);
        void EliminarVenta(int id);
        bool ExisteVenta(int id);

        IEnumerable<Venta> ListarVentas();
        IEnumerable<Venta> ListarVentasConDetalles();
        Venta? ObtenerVentaPorId(int id);
        Venta? ObtenerVentaPorIdConDetalles(int id);
        Venta? ObtenerVentaPorIdConDetallesNoTracking(int id);

        // Presupuestos
        IEnumerable<Venta> ObtenerPresupuestos();
        IEnumerable<Venta> ObtenerVentas();

        void ConfirmarVenta(int ventaId, bool editando = true);

        List<string> ObtenerMediosDePagoDisponibles(int idCliente);
    }

}
