using System.ComponentModel.DataAnnotations;
using GestionVentasCel.enumerations.persona;

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

        public TipoDocumentoEnum? TipoDocumento { get; set; }

        [MaxLength(45)]
        // Esto debería llamarse de otra forma, pero cambiarlo require cambiar lógica d enegocios así que se queda en DNI
        public string? Dni { get; set; }

        public CondicionIVA? CondicionIVA { get; set; }

        [MaxLength(18)]
        public string? Telefono { get; set; }

        [MaxLength(200)]
        public string? Email { get; set; }

        [MaxLength(45)]
        public string? Calle { get; set; }

        [MaxLength(45)]
        public string? Ciudad { get; set; }

    }
}
