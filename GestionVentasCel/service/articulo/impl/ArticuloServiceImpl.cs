using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.enumerations.usuarios;
using GestionVentasCel.exceptions.articulo;
using GestionVentasCel.exceptions.usuario;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.usuario;
using GestionVentasCel.repository.articulo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GestionVentasCel.service.articulo.impl
{
    public class ArticuloServiceImpl : IArticuloService
    {
        private readonly IArticuloRepository _repo;

        public ArticuloServiceImpl(IArticuloRepository repo)
        {
            _repo = repo;
        }

        public void CrearArticulo(string nombre, int aviso_stock, decimal precio, int stock, string marca, int categoriaId, string? descripcion = null)
        {
            var articulo = new Articulo
            {
                Nombre = nombre,
                Aviso_stock = aviso_stock,
                Precio = precio,
                Stock = stock,
                Marca = marca,
                CategoriaId = categoriaId,
                Descripcion = descripcion


            };

            _repo.Add(articulo);
        }

        public Articulo? GetById(int id)
        {
            return _repo.GetById(id);
        }

        public IEnumerable<Articulo> ListarArticulo() => _repo.GetAll();

        public void ToggleActivo(int id)
        {
            var articulo = _repo.GetById(id);

            if (articulo != null)
            {
                articulo.Activo = !articulo.Activo;
                _repo.Update(articulo);
            }
            else
            {
                throw new ArticuloNoEncontradoException("Articulo no encontrado.");
            }
        }

        public void UpdateArticulo(Articulo articulo)
        {
            if (_repo.Exist(articulo.Id))
            {

                _repo.Update(articulo);
            }
            else
            {

                throw new ArticuloNoEncontradoException("Articulo no encontrado.");
            }
        }
    }
}
