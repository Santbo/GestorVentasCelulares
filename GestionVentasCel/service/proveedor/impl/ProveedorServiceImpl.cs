using GestionVentasCel.exceptions.proveedor;
using GestionVentasCel.exceptions.persona;
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
            
            if (_repo.DocumentoExist(proveedor.Dni, proveedor.TipoDocumento.Value.ToString(), null))
            {
                throw new DocumentoDuplicadoException($"El {proveedor.TipoDocumento.Value.ToString()} ya existe.");
            }

            _repo.Add(proveedor);
        }

        public IEnumerable<Proveedor> ListarProveedores()
        {
            return _repo.GetAll();
        }

        public void ActualizarProveedor(Proveedor proveedor)
        {
            if (!_repo.Exist(proveedor.Id))
            {
                throw new ProveedorNoEncontradoException("Proveedor no encontrado.");
            }

            if (_repo.DocumentoExist(proveedor.Dni, proveedor.TipoDocumento.Value.ToString(), proveedor.Id))
            {
                throw new DocumentoDuplicadoException($"El {proveedor.TipoDocumento.Value.ToString()} ya existe.");
            }

            _repo.Update(proveedor);
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

    }
}
