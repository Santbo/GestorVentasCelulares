using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.usuario;

namespace GestionVentasCel.service.articulo
{
    public interface IArticuloService
    {
        void CrearArticulo(string nombre,
                                int aviso_stock,
                                decimal precio,
                                int stock,
                                string marca,
                                int categoriaId,
                                string? descripcion = null
                                 );
        IEnumerable<Articulo> ListarArticulo();
        void UpdateArticulo(Articulo articulo);

        void ToggleActivo(int id);

        Articulo? GetById(int id);
    }
}
