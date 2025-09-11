using GestionVentasCel.data;
using GestionVentasCel.models.usuario;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.usuario.impl
{
    public class UsuarioRepositoryImpl : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public Usuario? GetById(int id) => _context.Usuarios.Find(id);

        public Usuario? GetByUsername(string username) =>
            _context.Usuarios.FirstOrDefault(u => u.Username == username);

        public IEnumerable<Usuario> GetAll() => _context.Usuarios.AsNoTracking().ToList();

        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

        }
        public void Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Usuarios.Any(u => u.Id == id);
        }
    }
}
