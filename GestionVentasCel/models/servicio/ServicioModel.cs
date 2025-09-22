using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionVentasCel.models.servicio
{
    public class Servicio
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(45)]
        public string Nombre { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Precio { get; set; }

        [MaxLength(256)]
        public string Descripcion { get; set; }

        public bool Activo { get; set; } = true;
        public ICollection<ServicioArticulo> ArticulosUsados { get; set; }
    }
}
