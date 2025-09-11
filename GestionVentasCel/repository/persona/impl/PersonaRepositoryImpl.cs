using GestionVentasCel.data;
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
            return _context.Personas
                .Where(p => !_context.Clientes.Any(c => c.Id == p.Id))
                .ToList();
        }
    }
}
