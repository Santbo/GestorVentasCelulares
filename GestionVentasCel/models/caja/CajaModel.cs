using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.enumerations.caja;
using GestionVentasCel.models.usuario;
using GestionVentasCel.enumerations.ventas;

namespace GestionVentasCel.models.caja
{
    public class Caja
    {
        [Key]
        public int Id { get; set; }

        [Required, DisplayName("Empleado Responsable")]
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        [Required, DisplayName("Fecha de Apertura")]
        public DateTime FechaApertura { get; set; } = DateTime.Now;

        [DisplayName("Fecha de Cierre")]
        public DateTime? FechaCierre { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal MontoApertura { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MontoCierre { get; set; }

        [Required]
        public EstadoCajaEnum Estado { get; set; } = EstadoCajaEnum.Abierta;

        public ICollection<MovimientoCaja> Movimientos { get; set; } = new List<MovimientoCaja>();

        [NotMapped]
        public Dictionary<TipoPagoEnum, decimal> TotalesPorTipoPago =>
                    Movimientos
                        .GroupBy(m => m.TipoPago)
                        .ToDictionary(g => g.Key, g => g.Sum(m => m.Monto));
    }
}
