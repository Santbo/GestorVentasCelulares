using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.models.usuario;

namespace GestionVentasCel.service.usuario
{
    public interface IUsuarioService
    {
        void RegistrarUsuario(string username, 
                                string password, 
                                string rol, 
                                string nombre, 
                                string apellido, 
                                string telefono, 
                                string dni, 
                                string email);
        IEnumerable<Usuario> ListarUsuarios();
        Usuario? Login(string username, string password);

        void UpdateUsuario(Usuario usuario);

        void ToggleActivo(int id);

        Usuario? GetById(int id);
    }
}
