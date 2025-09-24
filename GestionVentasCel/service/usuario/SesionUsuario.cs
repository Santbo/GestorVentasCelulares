using GestionVentasCel.enumerations.usuarios;

namespace GestionVentasCel.service.usuario
{
    public class SesionUsuario
    {
        public string Username { get; private set; } = string.Empty;
        public RolEnum? Rol { get; private set; } = RolEnum.Vendedor;
        public int Id { get; private set; }


        public void IniciarSesion(string username, RolEnum rol, int id)
        {
            Username = username;
            Rol = rol;
            Id = id;
        }

        public void CerrarSesion()
        {
            Username = string.Empty;
            Rol = null;
            Id = 0;
        }
    }
}
