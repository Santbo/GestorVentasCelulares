using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DateTime? FechaEgreso { get; set; }

        [MaxLength(255)]
        public string? Diagnostico { get; set; }

        [MaxLength(255), Display(Name = "Fallas Reportadas")]
        public string? FallasReportadas { get; set; }

        [Required]
        public EstadoReparacionEnum Estado { get; set; } = EstadoReparacionEnum.Ingresado;

        public Dispositivo? Dispositivo { get; set; }
        public int DispositivoId { get; set; }
        public ICollection<ReparacionServicio> ReparacionServicios { get; set; }

        public bool Activo { get; set; } = true;

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }
    }
}
