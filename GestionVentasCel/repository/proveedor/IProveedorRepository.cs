using GestionVentasCel.models.proveedor;

namespace GestionVentasCel.repository.proveedor
{
    public interface IProveedorRepository
    {
        Proveedor? GetById(int id);
        IEnumerable<Proveedor> GetAll();
        void Add(Proveedor proveedor);
        void Update(Proveedor proveedor);
        void CambiarEstado(int id, bool activo);
        bool Exist(int id);
        bool DocumentoExist(string documento, string tipoDocumento, int? idExcluir = null);
    }
}
