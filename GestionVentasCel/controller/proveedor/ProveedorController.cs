using GestionVentasCel.models.proveedor;
using GestionVentasCel.service.proveedor;

namespace GestionVentasCel.controller.proveedor
{
    public class ProveedorController
    {
        private readonly IProveedorService _service;

        public ProveedorController(IProveedorService service)
        {
            _service = service;
        }

        public void CrearProveedor(Proveedor proveedor)
        {
            _service.AgregarProveedor(proveedor);
        }

        public void ActualizarProveedor(Proveedor proveedor)
        {
            _service.ActualizarProveedor(proveedor);
        }

        public void CambiarEstadoProveedor(int id, bool activo)
        {
            _service.CambiarEstadoProveedor(id, activo);
        }

        public IEnumerable<Proveedor> ObtenerProveedores()
        {
            return _service.ListarProveedores();
        }

        public Proveedor? GetById(int id)
        {
            return _service.GetById(id);
        }

    }
}
