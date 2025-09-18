using GestionVentasCel.data;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.persona;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.persona.impl
{
    public class PersonaRepositoryImpl : IPersonaRepository
    {
        private readonly AppDbContext _context;

        public PersonaRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public Persona? GetById(int id)
        {
            return _context.Personas
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }

        public Persona? GetByDni(string dni)
        {
            return _context.Personas
                .FirstOrDefault(p => p.Dni == dni);
        }

        public IEnumerable<Persona> GetAll()
        {
            return _context.Personas
                .AsNoTracking()
                .ToList();
        }

        public void Add(Persona persona)
        {
            _context.Personas.Add(persona);
            _context.SaveChanges();
        }

        public void Update(Persona persona)
        {
            _context.Personas.Update(persona);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Personas.Any(p => p.Id == id);
        }

        public IEnumerable<Persona> ObtenerPersonasSinClientes()
        {
            // Como Persona es abstracta y EF core se pone molesto,
            // hay que traer todos los usuarios y proveedores que existes
            // que no sean clientes, y castearlos a persona
            var usuarios = _context.Usuarios
                .Where(u => !_context.Clientes.Any(c => c.Id == u.Id || c.Dni == u.Dni))
                .ToList<Persona>();

            var proveedores = _context.Proveedores
                .Where(pr => !_context.Clientes.Any(c => c.Id == pr.Id || c.Dni == pr.Dni))
                .ToList<Persona>();

            return usuarios.Concat(proveedores).ToList();
        }
    }
}
