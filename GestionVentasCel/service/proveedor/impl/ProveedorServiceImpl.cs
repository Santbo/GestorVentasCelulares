using GestionVentasCel.exceptions.proveedor;
using GestionVentasCel.models.proveedor;
using GestionVentasCel.repository.proveedor;

namespace GestionVentasCel.service.proveedor.impl
{
    public class ProveedorServiceImpl : IProveedorService
    {
        private readonly IProveedorRepository _repo;

        public ProveedorServiceImpl(IProveedorRepository repo)
        {
            _repo = repo;
        }

        public void AgregarProveedor(Proveedor proveedor)
        {
            if (_repo.DocumentoExist(proveedor.Dni ?? "", proveedor.TipoDocumento?.ToString() ?? ""))
            {
                throw new ProveedorExistenteException("Ya existe un proveedor con este documento.");
            }

            _repo.Add(proveedor);
        }

        public IEnumerable<Proveedor> ListarProveedores()
        {
            return _repo.GetAll();
        }

        public IEnumerable<Proveedor> ListarProveedoresActivos()
        {
            return _repo.GetAllActivos();
        }

        public void ActualizarProveedor(Proveedor proveedor)
        {
            if (!_repo.Exist(proveedor.Id))
            {
                throw new ProveedorNoEncontradoException("Proveedor no encontrado.");
            }

            _repo.Update(proveedor);
        }

        public void EliminarProveedor(int id)
        {
            if (!_repo.Exist(id))
            {
                throw new ProveedorNoEncontradoException("Proveedor no encontrado.");
            }

            _repo.Delete(id);
        }

        public void CambiarEstadoProveedor(int id, bool activo)
        {
            if (!_repo.Exist(id))
            {
                throw new ProveedorNoEncontradoException("Proveedor no encontrado.");
            }

            _repo.CambiarEstado(id, activo);
        }

        public Proveedor? GetById(int id)
        {
            return _repo.GetById(id);
        }

        public bool ExisteProveedor(int id)
        {
            return _repo.Exist(id);
        }

        public bool ExisteDocumento(string documento, string tipoDocumento)
        {
            return _repo.DocumentoExist(documento, tipoDocumento);
        }
    }
}
