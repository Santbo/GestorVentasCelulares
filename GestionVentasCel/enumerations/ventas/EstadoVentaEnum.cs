using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVentasCel.enumerations.ventas
{
    public enum EstadoVentaEnum
    {
        /// <summary>
        /// La venta es un presupuesto todavía. No tiene fecha de venta pero si de vencimiento
        /// </summary>
        Presupuesto,
        /// <summary>
        /// La venta está por facturarse, ya sea porque pasó de un presupuesto a una venta o 
        /// porque se hizo una venta nueva
        /// </summary>
        Confirmada,
        /// <summary>
        /// Ya se emitió la factura de la venta
        /// </summary>
        Facturada,
        /// <summary>
        /// La venta se eliminó.
        /// </summary>
        Anulada
    }
}
