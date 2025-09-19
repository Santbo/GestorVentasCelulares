using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.enumerations.usuarios;

namespace GestionVentasCel.service.usuario
{
    public class SesionUsuario
    {
        public string Username { get; private set; } = string.Empty;
        public RolEnum? Rol { get; private set; } = RolEnum.Vendedor;


        public void IniciarSesion(string username, RolEnum rol)
        {
            Username = username;
            Rol = rol;
        }

        public void CerrarSesion()
        {
            Username = string.Empty;
            Rol = null;
        }
    }
}
