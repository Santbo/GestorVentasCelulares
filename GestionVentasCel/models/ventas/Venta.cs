using System.ComponentModel;
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

        // Fecha de creación de la venta/presupuesto
        [Required, DisplayName("Fecha de creación")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Required, DisplayName("Estado")]
        public EstadoVentaEnum EstadoVenta { get; set; } = EstadoVentaEnum.Borrador;

        // Fecha de venta real. Si este valor es null, entonces
        // se trata de un presupuesto y no de una venta.
        // Al realizar la venta, se pobla la fecha y hora con la fecha y hora actual,
        // convirtiendo el registro en una venta
        [DisplayName("Fecha de venta")]
        public DateTime? FechaVenta { get; set; }

        // De tratarse de un presupuesto, se tiene que establecer la fecha de vencimiento de la misma
        [DisplayName("Fecha de vencimiento")]
        public DateTime? FechaVencimiento { get; set; }

        // El usuario que autorizó la venta
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        // El cliente al que se le hizo la venta.
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [DisplayName("Tipo de pago")]
        public TipoPagoEnum TipoPago { get; set; }

        public ICollection<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
        [DisplayName("Total sin IVA")]
        public decimal TotalSinIva => Detalles.Sum(d => d.SubtotalSinIva);
        [DisplayName("Total con IVA")]
        public decimal TotalConIva => Detalles.Sum(d => d.SubtotalConIva);

        [DisplayName("IVA total")]
        public decimal IVATotal => Detalles.Sum(d => d.SubtotalSinIva * d.PorcentajeIva);



    }
}
