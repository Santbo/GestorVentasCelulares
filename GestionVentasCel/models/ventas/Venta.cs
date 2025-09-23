using System.ComponentModel.DataAnnotations;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.usuario;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GestionVentasCel.models.ventas
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name ="Fecha de creación")]
        // Fecha de creación de la venta/presupuesto
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Display(Name ="Fecha de venta")]
        // Fecha de venta real. Si este valor es null, entonces
        // se trata de un presupuesto y no de una venta.
        // Al realizar la venta, se pobla la fecha y hora con la fecha y hora actual,
        // convirtiendo el registro en una venta
        public DateTime? FechaRealizacion { get; set; }

        // El usuario que autorizó la venta
        public int UsuarioId {  get; set; }
        public Usuario? Usuario { get; set; }

        // El cliente al que se le hizo la venta.
        public int ClienteId {  get; set; }
        public Cliente? Cliente { get; set; }

        public TipoPagoEnum TipoPago { get; set; }


    }
}
