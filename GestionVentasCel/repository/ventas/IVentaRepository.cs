using GestionVentasCel.models.ventas;

namespace GestionVentasCel.repository.ventas
{
    public interface IVentaRepository
    {
        // CRUD básico
        void Agregar(Venta venta);
        void Actualizar(Venta venta);
        void Eliminar(int id);
        bool Existe(int id);

        // Gets
        IEnumerable<Venta> ObtenerTodas();
        IEnumerable<Venta> ObtenerTodasConDetalles();
        Venta? ObtenerPorId(int id);
        Venta? ObtenerPorIdConDetalles(int id);
        Venta? ObtenerPorIdConDetallesNoTracking(int id);


        IEnumerable<Venta> ObtenerPresupuestos();
        IEnumerable<Venta> ObtenerVentas();
        Venta? ObtenerPresupuestoPorId(int idVenta);

        // Manejo de detalles
        void AgregarDetalle(int ventaId, DetalleVenta detalle);
        void EliminarDetalle(int detalleId);
    }
}
