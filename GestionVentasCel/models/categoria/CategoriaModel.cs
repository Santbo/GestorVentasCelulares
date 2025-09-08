using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.enumerations.usuarios;

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
    }
}
