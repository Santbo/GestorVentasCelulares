using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionVentasCel.models.configPrecios
{
    public class ConfiguracionPrecios
    {
        public int Id { get; set; }
        public decimal MargenAumento { get; set; } // ej: 1.30 (30%)
        public DateTime UltimaActualizacion { get; set; } = DateTime.Now;

    }
}
