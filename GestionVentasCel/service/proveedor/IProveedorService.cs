using GestionVentasCel.models.proveedor;

namespace GestionVentasCel.service.proveedor
{
    public interface IProveedorService
    {
        void AgregarProveedor(Proveedor proveedor);
        IEnumerable<Proveedor> ListarProveedores();
        void ActualizarProveedor(Proveedor proveedor);
        void CambiarEstadoProveedor(int id, bool activo);
        Proveedor? GetById(int id);
    }
}
