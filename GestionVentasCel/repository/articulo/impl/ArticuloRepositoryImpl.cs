using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.data;
using GestionVentasCel.models.articulo;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionVentasCel.repository.articulo.impl
{
    public class ArticuloRepositoryImpl : IArticuloRepository
    {
        private readonly AppDbContext _context;

        public ArticuloRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Articulos.Any(u => u.Id == id);
        }

        public IEnumerable<Articulo> GetAll()
        {
            //AsNoTracking mejora el rendimiento en consulta pero no se puede modificar y guardar
            //Haciendo saveChanges()
            return _context.Articulos
                        .Include(a => a.Categoria)
                        .AsNoTracking().ToList();
        }

            

        public Articulo? GetById(int id) => _context.Articulos.Find(id);

        public void Update(Articulo articulo)
        {
            _context.Articulos.Update(articulo);
            _context.SaveChanges();
        }
    }
}
