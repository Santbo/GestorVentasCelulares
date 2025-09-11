using GestionVentasCel.models.usuario;
using GestionVentasCel.service.usuario;

namespace GestionVentasCel.controller.usuario
{
    public class UsuarioController
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        public void CrearUsuario(string username,
                                string password,
                                string rol,
                                string nombre,
                                string apellido,
                                string telefono,
                                string dni,
                                string email) =>

            _service.RegistrarUsuario(username, password, rol, nombre, apellido, telefono, dni, email);

        public void UpdateUsuario(Usuario usuario)
        {
            _service.UpdateUsuario(usuario);
        }

        public IEnumerable<Usuario> ObtenerUsuarios() =>
            _service.ListarUsuarios();

        public Usuario? Login(string username, string password) =>
            _service.Login(username, password);

        //Alterna entre activo e inactivo
        public void ToggleActivo(int id)
        {
            _service?.ToggleActivo(id);
        }

        public Usuario? GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
