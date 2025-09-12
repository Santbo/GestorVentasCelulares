using System.ComponentModel.DataAnnotations;
using GestionVentasCel.models.persona;

namespace GestionVentasCel.models.proveedor
{
    public class Proveedor : Persona
    {
        // Los campos básicos ya están heredados de Persona:
        // - Nombre, Apellido, TipoDocumento, Dni, CondicionIVA
        // - Telefono, Email, Calle, Ciudad, Activo

        [MaxLength(200)]
        public string? Observaciones { get; set; }
    }
}
