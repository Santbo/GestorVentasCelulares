using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.enumerations.caja;

namespace GestionVentasCel.models.caja
{
    public class MovimientoCaja
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Caja Caja { get; set; }
        public int CajaId { get; set; }

        [Required]
        public TipoMovimientoEnum TipoMovimiento { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Monto { get; set; }
        
        [MaxLength(255)]
        public string? Descripcion { get; set; }

        [Required, DisplayName("Fecha")]
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
