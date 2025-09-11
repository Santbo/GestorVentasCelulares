using GestionVentasCel.data;
using GestionVentasCel.models.categoria;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.categoria.impl
{
    public class CategoriaRepositoryImpl : ICategoriaRepository
    {

        private readonly AppDbContext _context;

        public CategoriaRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Categoria categoria)
        {

            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Categorias.Any(u => u.Id == id);
        }

        public IEnumerable<Categoria> GetAll() => _context.Categorias.AsNoTracking().ToList();

        public Categoria? GetById(int id) => _context.Categorias.Find(id);

        public bool NombreExist(string nombre)
        {
            return _context.Categorias.Any(c => c.Nombre == nombre);
        }

        public void Update(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }
    }
}
