using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.data;
using GestionVentasCel.models.configPrecios;
using Microsoft.EntityFrameworkCore;

namespace GestionVentasCel.repository.configPrecios.impl
{
    public class ConfiguracionPreciosRepositoryImpl : IConfiguracionPreciosRepository
    {
        private readonly AppDbContext _context;
        public ConfiguracionPreciosRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }
        public void Add(ConfiguracionPrecios configuracionPrecios)
        {
            _context.ConfiguracionPrecios.Add(configuracionPrecios);
            _context.SaveChanges();
        }

        public ConfiguracionPrecios? GetById(int id) => _context.ConfiguracionPrecios.Find(id);

        public bool MargenExist(int id)
        {
            return _context.ConfiguracionPrecios.Any(u => u.Id == id);
        }

        public void Update(ConfiguracionPrecios configuracionPrecios)
        {
            _context.ConfiguracionPrecios.Update(configuracionPrecios);
            _context.SaveChanges();
        }
    }
}
