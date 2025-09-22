using System.ComponentModel.DataAnnotations;
using GestionVentasCel.enumerations.reparacion;
using GestionVentasCel.models.servicio;

namespace GestionVentasCel.models.reparacion
{
    public class Reparacion
    {

        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; } = DateTime.Now;

        [Display(Name = "Fecha de Egreso")]
        public DateTime? FechaEgreseo { get; set; }

        [MaxLength(255)]
        public string? Diagnostico { get; set; }

        [MaxLength(255), Display(Name = "Fallas Reportadas")]
        public string? FallasReportadas { get; set; }

        [Required]
        public EstadoReparacionEnum Estado { get; set; } = EstadoReparacionEnum.Ingresado;

        public Dispositivo? Dispositivo { get; set; }
        public int DispositivoId { get; set; }
        public ICollection<Servicio> Servicios { get; set; }

        public bool Activo { get; set; } = true;
    }
}
