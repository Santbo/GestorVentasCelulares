using GestionVentasCel.data;
using GestionVentasCel.models.clientes;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.ClienteCuentaCorriente.impl
{
    public class ClienteRepositoryImpl : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Clientes.Any(c => c.Id == id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _context.Clientes.AsNoTracking().ToList();
        }

        public Cliente? GetById(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }
    }
}
