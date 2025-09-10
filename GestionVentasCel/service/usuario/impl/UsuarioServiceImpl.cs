using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.enumerations.usuarios;
using GestionVentasCel.exceptions.usuario;
using GestionVentasCel.models.usuario;
using GestionVentasCel.repository.usuario;

namespace GestionVentasCel.service.usuario.impl
{
    public class UsuarioServiceImpl : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioServiceImpl(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        //Obtener todos los usuarios, IEnumerable te deja poder iterar por cada Usuario
        public IEnumerable<Usuario> ListarUsuarios() => _repo.GetAll();

        public Usuario? Login(string username, string password)
        {
            var usuario = _repo.GetByUsername(username);
            if (usuario == null) return null;

            //si el usuario no es activo, que no deje ingresar
            if (!usuario.Activo) return null;

            return String.Equals(password, usuario.Password) ? usuario : null;
        }

        public void RegistrarUsuario(string username, string password, string rol, string nombre, string apellido, string telefono, string dni, string email)
        {
            var usuarioExistente = _repo.GetByUsername(username);
            if (usuarioExistente != null) throw new UsuarioExistenteException("El usuario ya existe.");

            var usuario = new Usuario
            {
                Username = username,
                Password = password,
                Rol = (RolEnum)Enum.Parse(typeof(RolEnum), rol),
                Nombre = nombre,
                Apellido = apellido,
                Telefono = telefono,
                Dni = dni,
                Email = email


            };

            _repo.Add(usuario);
        }

        public void UpdateUsuario(Usuario usuario)
        {
            
            if( _repo.Exist(usuario.Id) )
            {

                _repo.Update(usuario); 
            } else
            {

                throw new UsuarioNoEncontradoException("Usuario no encontrado");
            }

            
        }

        //Borrado logico, alterna entre activo e inactivo
        public void ToggleActivo(int id)
        {   
            var usuario = _repo.GetById(id);

            if (usuario != null)
            {
                usuario.Activo = !usuario.Activo;
                _repo.Update(usuario);
            }
            else
            {
                throw new UsuarioNoEncontradoException("Usuario no encontrado");
            }
        }

        public Usuario? GetById(int id)
        {
            return _repo.GetById(id);
        }
    }
}
