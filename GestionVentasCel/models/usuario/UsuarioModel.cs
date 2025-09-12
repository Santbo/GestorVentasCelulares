using System.ComponentModel.DataAnnotations;
using GestionVentasCel.enumerations.usuarios;
using GestionVentasCel.models.persona;

namespace GestionVentasCel.models.usuario
{
    public class Usuario : Persona
    {

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

        [Required]
        public RolEnum Rol { get; set; }

        public bool Activo { get; set; } = true;

    }
}
