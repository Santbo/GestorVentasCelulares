using System.ComponentModel.DataAnnotations;
using GestionVentasCel.models.articulo;

namespace GestionVentasCel.models.categoria
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(45)]
        public string Nombre { get; set; }

        [MaxLength(256)]
        public string Descripcion { get; set; }

        public bool Activo { get; set; } = true;

        public override string ToString()
        {
            return Nombre;
        }

    }
}
