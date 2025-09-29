using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionVentasCel.models.articulo;

namespace GestionVentasCel.models.servicio
{
    public class ServicioArticulo
    {

        [Key]
        public int Id { get; set; }
        public int ServicioId { get; set; }

        public Servicio? Servicio { get; set; }

        public int ArticuloId { get; set; }
        public Articulo? Articulo { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [NotMapped]
        public string Detalle { get; set; }
    }
}
