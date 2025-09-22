using GestionVentasCel.models.articulo;
using GestionVentasCel.models.categoria;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.compra;
using GestionVentasCel.models.configPrecios;
using GestionVentasCel.models.CuentaCorreinte;
using GestionVentasCel.models.persona;
using GestionVentasCel.models.proveedor;
using GestionVentasCel.models.servicio;
using GestionVentasCel.models.usuario;
using Microsoft.EntityFrameworkCore;


namespace GestionVentasCel.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet por cada entidad de la BD

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Articulo> Articulos { get; set; }

        public DbSet<HistorialPrecio> HistorialPrecios { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetallesCompra { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CuentaCorriente> CuentasCorrientes { get; set; }
        public DbSet<MovimientoCuentaCorriente> MovimientosCuentasCorrientes { get; set; }

        public DbSet<ConfiguracionPrecios> ConfiguracionPrecios { get; set; }

        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<ServicioArticulo> ServicioArticulos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().ToTable("Personas");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Proveedor>().ToTable("Proveedores");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");

            modelBuilder.Entity<Cliente>()
                .Property(p => p.CondicionIVA)
                .HasConversion<string>();


            modelBuilder.Entity<Usuario>()
                .Property(u => u.Rol)
               .HasConversion<string>();


            // Hacher que cuenta corriente y cliente sean 1:1 opcional
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.CuentaCorriente) // Cliente tiene una cuenta corriente
                .WithOne(cc => cc.Cliente) // Con un cliente
                .HasForeignKey<CuentaCorriente>(cc => cc.ClienteId) // Se pone la fk
                .IsRequired(false); // y se hace opcional


            modelBuilder.Entity<MovimientoCuentaCorriente>()
                .Property(m => m.Tipo)
                .HasConversion<string>();

            //se define clave 
            modelBuilder.Entity<ServicioArticulo>()
                        .HasKey(sa => sa.Id);

            //Relacion Servicio a ServicioArticulo
            modelBuilder.Entity<ServicioArticulo>()
                            .HasOne(sa => sa.Servicio)
                            .WithMany(s => s.ArticulosUsados)
                            .HasForeignKey(sa => sa.ServicioId);

            // Relación Articulo a ServicioArticulo
            modelBuilder.Entity<ServicioArticulo>()
                .HasOne(sa => sa.Articulo)
                .WithMany(); //Lo dejo aca para que no haya una tabla en Articulo.
        }


    }

}
