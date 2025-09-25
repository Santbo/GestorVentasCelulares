using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using GestionVentasCel.enumerations.reparacion;

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

        [DisplayName("Fecha de vencimiento")]
        public DateTime? FechaVencimiento { get; set; } = DateTime.Now.AddDays(7);
        [NotMapped]
        public bool EstaVencida => this.FechaVencimiento == null ? false : this.FechaVencimiento < DateTime.Now;

        [NotMapped]
        public String Detalle => $"Reparación N° {this.Id} del {this.FechaIngreso.ToString()} - {this.Dispositivo?.Nombre}";
    }
}
