using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [Required, MaxLength(45)]
        public string Dni { get; set; }

        [Required]
        public RolEnum Rol { get; set; } 

    }
}
