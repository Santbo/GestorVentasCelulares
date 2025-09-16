using GestionVentasCel.exceptions.proveedor;
using GestionVentasCel.exceptions.persona;
using GestionVentasCel.models.proveedor;
using GestionVentasCel.repository.proveedor;
using GestionVentasCel.service.persona;

namespace GestionVentasCel.service.proveedor.impl
{
    public class ProveedorServiceImpl : IProveedorService
    {
        private readonly IProveedorRepository _repo;
        private readonly ICuitValidationService _cuitValidationService;

        public ProveedorServiceImpl(IProveedorRepository repo, ICuitValidationService cuitValidationService)
        {
            _repo = repo;
            _cuitValidationService = cuitValidationService;
        }

        public void AgregarProveedor(Proveedor proveedor)
        {
            // Validar CUIT si es CUIT
            if (proveedor.TipoDocumento?.ToString() == "CUIT")
            {
                if (!_cuitValidationService.ValidarCuit(proveedor.Dni ?? ""))
                {
                    throw new CuitDuplicadoException("El CUIT ingresado no es válido.");
                }

                if (_cuitValidationService.CuitExiste(proveedor.Dni ?? ""))
                {
                    throw new CuitDuplicadoException("Ya existe un proveedor con este CUIT.");
                }

                // Formatear el CUIT
                proveedor.Dni = _cuitValidationService.FormatearCuit(proveedor.Dni ?? "");
            }

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

            // Validar CUIT si es CUIT
            if (proveedor.TipoDocumento?.ToString() == "CUIT")
            {
                if (!_cuitValidationService.ValidarCuit(proveedor.Dni ?? ""))
                {
                    throw new CuitDuplicadoException("El CUIT ingresado no es válido.");
                }

                if (_cuitValidationService.CuitExiste(proveedor.Dni ?? "", proveedor.Id))
                {
                    throw new CuitDuplicadoException("Ya existe otro proveedor con este CUIT.");
                }

                // Formatear el CUIT
                proveedor.Dni = _cuitValidationService.FormatearCuit(proveedor.Dni ?? "");
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
