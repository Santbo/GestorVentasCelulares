using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.models.servicio;

namespace GestionVentasCel.models.reparacion
{
    public class ReparacionServicio
    {
        [Key]
        public int Id { get; set; }

        public Reparacion? Reparacion { get; set; }
        public int ReparacionId { get; set; }

        public Servicio? Servicio { get; set; }

        public int ServicioId { get; set; }

        [NotMapped]
        public string? Detalle { get; set; }

    }
}
