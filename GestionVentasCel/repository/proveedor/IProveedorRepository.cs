using GestionVentasCel.models.proveedor;

namespace GestionVentasCel.repository.proveedor
{
    public interface IProveedorRepository
    {
        Proveedor? GetById(int id);
        IEnumerable<Proveedor> GetAll();
        IEnumerable<Proveedor> GetAllActivos();
        void Add(Proveedor proveedor);
        void Update(Proveedor proveedor);
        void Delete(int id);
        void CambiarEstado(int id, bool activo);
        bool Exist(int id);
        bool NombreExist(string nombre);
        bool DocumentoExist(string documento, string tipoDocumento);
    }
}
