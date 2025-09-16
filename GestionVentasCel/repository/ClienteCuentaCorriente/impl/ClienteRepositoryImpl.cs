using GestionVentasCel.data;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.persona;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.ClienteCuentaCorriente.impl
{
    internal class PersonaProxy : Persona { }

    public class ClienteRepositoryImpl : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Cliente cliente)
        {
            if (cliente.Id == 0)
            {
                // Hay que agregar una nueva persona y un cliente si la id es 0, porque significa que se quiere crear uno nuevo
                _context.Clientes.Add(cliente);
            }
            else
            {
                // Actualizar la persona por separado, porque si no EF se vuelve loco con la id
                var persona = _context.Personas.FirstOrDefault(p => p.Id == cliente.Id);

                persona.Nombre = cliente.Nombre;
                persona.Apellido = cliente.Apellido;
                persona.Email = cliente.Email;
                persona.Ciudad = cliente.Ciudad;
                persona.Calle = cliente.Calle;

                persona.Telefono = cliente.Telefono;
                persona.TipoDocumento = cliente.TipoDocumento;
                persona.Dni = cliente.Dni;

                // Esta es literalmente la única forma de que se pueda insertar un cliente a una persona existente
                _context.Database.ExecuteSqlRaw("INSERT INTO clientes (Id, CondicionIVA) VALUES ({0}, {1})", persona.Id, cliente.CondicionIVA);

            }

            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Clientes.Any(c => c.Id == id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _context.Clientes
                .AsNoTracking()
                .Include(c => c.CuentaCorriente)
                .ToList();
        }

        public Cliente? GetById(int id)
        {
            return _context.Clientes
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Cliente> ObtenerClientesSinCuentas()
        {
            return _context.Clientes
                .Where(c => c.Activo && c.CuentaCorriente == null)
                .AsNoTracking()
                .ToList();
        }

        public void Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }
    }
}
