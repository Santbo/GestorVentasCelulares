using GestionVentasCel.models.proveedor;

namespace GestionVentasCel.service.proveedor
{
    public interface IProveedorService
    {
        void AgregarProveedor(Proveedor proveedor);
        IEnumerable<Proveedor> ListarProveedores();
        IEnumerable<Proveedor> ListarProveedoresActivos();
        void ActualizarProveedor(Proveedor proveedor);
        void EliminarProveedor(int id);
        void CambiarEstadoProveedor(int id, bool activo);
        Proveedor? GetById(int id);
        bool ExisteProveedor(int id);
        bool ExisteDocumento(string documento, string tipoDocumento);
    }
}
