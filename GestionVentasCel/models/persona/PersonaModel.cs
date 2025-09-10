using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVentasCel.models.persona
{
    public abstract class Persona
    {

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(45)]
        public string Nombre { get; set; }

        [MaxLength(45)]
        public string? Apellido { get; set; }

        [MaxLength(45)]
        public string? Telefono { get; set; }

        [MaxLength(45)]
        public string? Email { get; set; }

        [MaxLength(45)]
        public string? Calle {  get; set; }

        [MaxLength(45)]
        public string? Ciudad {  get; set; }

        public bool Activo { get; set; } = true;
    }
}
