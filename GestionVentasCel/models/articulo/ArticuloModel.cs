using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionVentasCel.models.categoria;

namespace GestionVentasCel.models.articulo
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(45)]
        public string Nombre { get; set; }

        [Required, DisplayName("Stock crítico")]
        public int Aviso_stock { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Precio { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required, MaxLength(45)]
        public string Marca { get; set; }

        [MaxLength(256), DisplayName("Descripción")]
        public string? Descripcion { get; set; }

        public bool Activo { get; set; } = true;

        [DisplayName("Categoría")]
        public Categoria? Categoria { get; set; }

        [Required]
        public int CategoriaId { get; set; }

    }
}
