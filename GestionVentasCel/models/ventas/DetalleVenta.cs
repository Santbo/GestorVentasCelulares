using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.models.articulo;

namespace GestionVentasCel.models.ventas
{
    public class DetalleVenta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VentaId { get; set; }
        [Required]
        public Venta Venta {  get; set; }

        public int Cantidad {  get; set; }

        // artículo o servicio
        public int? ArticuloId { get; set; }
        public Articulo? Articulo { get; set; }

        public int? ServicioId { get; set; }
        public Servicio? Servicio { get; set; }
    }
}
