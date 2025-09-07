using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.models.usuario;
using Microsoft.EntityFrameworkCore;


namespace GestionVentasCel.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet por cada entidad de la BD
        public DbSet<Usuario> Usuarios { get; set; }


    }

}
