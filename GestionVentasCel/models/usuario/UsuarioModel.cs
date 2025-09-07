using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using GestionVentasCel.enumerations.usuarios;

namespace GestionVentasCel.models.usuario
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

        [Required, MaxLength (45)]
        public string Nombre { get; set; }

        [Required, MaxLength (45)]
        public string Apellido { get; set; }

        [Required, MaxLength(45)]
        public string Telefono { get; set; }

        [Required, MaxLength(45)]
        public string Dni { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public RolEnum Rol { get; set; } 

        public bool Activo { get; set; } = true;
    }
}
