using GestionVentasCel.enumerations.usuarios;

namespace GestionVentasCel.service.usuario
{
    public class SesionUsuario
    {
        public string Username { get; private set; } = string.Empty;
        public RolEnum? Rol { get; private set; }
        public int Id { get; private set; }
        public bool EstaAutenticado => !string.IsNullOrEmpty(Username) && Rol.HasValue;

        // Constructor público (para DI)
        public SesionUsuario() { }

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

        // Métodos para verificar permisos según los casos de uso
        public bool PuedeAccederAUsuarios()
        {
            return Rol == RolEnum.Admin;
        }

        public bool PuedeAccederACaja()
        {
            return Rol == RolEnum.Admin || Rol == RolEnum.Vendedor;
        }

        public bool PuedeAccederAVentas()
        {
            return Rol == RolEnum.Admin || Rol == RolEnum.Vendedor;
        }

        public bool PuedeAccederAFacturas()
        {
            return Rol == RolEnum.Admin || Rol == RolEnum.Vendedor;
        }

        public bool PuedeAccederAClientes()
        {
            return Rol == RolEnum.Admin || Rol == RolEnum.Vendedor;
        }

        public bool PuedeAccederACompras()
        {
            return Rol == RolEnum.Admin || Rol == RolEnum.Vendedor;
        }

        public bool PuedeAccederAProveedores()
        {
            return Rol == RolEnum.Admin || Rol == RolEnum.Vendedor;
        }

        public bool PuedeAccederAConfiguracionPrecios()
        {
            return Rol == RolEnum.Admin;
        }

        public bool PuedeAccederAReparaciones()
        {
            return Rol == RolEnum.Admin || Rol == RolEnum.Tecnico;
        }

        public bool PuedeAccederAServicios()
        {
            return Rol == RolEnum.Admin || Rol == RolEnum.Tecnico;
        }

        public bool PuedeAccederAArticulos()
        {
            return Rol == RolEnum.Admin || Rol == RolEnum.Vendedor;
        }

        public bool PuedeAccederACategorias()
        {
            return Rol == RolEnum.Admin || Rol == RolEnum.Vendedor;
        }

        public bool PuedeAccederAReportes()
        {
            return Rol == RolEnum.Admin;
        }
    }
}
