using System.ComponentModel.DataAnnotations;
using GestionVentasCel.models.clientes;

namespace GestionVentasCel.models.reparacion
{
    public class Dispositivo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public Cliente? Cliente { get; set; }
        public int ClienteId { get; set; }
    }
}
