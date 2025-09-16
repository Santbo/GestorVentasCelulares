using GestionVentasCel.models.articulo;
using GestionVentasCel.models.categoria;
using GestionVentasCel.models.persona;
using GestionVentasCel.models.usuario;
using GestionVentasCel.models.proveedor;
using GestionVentasCel.models.compra;
using GestionVentasCel.models.cliente;
using GestionVentasCel.enumerations.persona;
using GestionVentasCel.enumerations.usuarios;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().ToTable("Personas");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Proveedor>().ToTable("Proveedores");

            modelBuilder.Entity<Persona>()
                .Property(p => p.CondicionIVA)
                .HasConversion(
                    v => v == null ? null : v.ToString().Replace("ResponsableInscripto", "Responsable Inscripto")
                                                      .Replace("ResponsableNoInscripto", "Responsable No Inscripto")
                                                      .Replace("ConsumidorFinal", "Consumidor Final")
                                                      .Replace("NoResponsable", "No Responsable"),
                    v => v == null ? null : (CondicionIVA)Enum.Parse(typeof(CondicionIVA), v.Replace(" ", ""))
                );

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Rol)
                .HasConversion(
                    v => v.ToString().Replace("Admin", "Administrador")
                                      .Replace("Tecnico", "Técnico"),
                    v => v == "Cliente" ? RolEnum.Vendedor : 
                         (RolEnum)Enum.Parse(typeof(RolEnum), v.Replace("Administrador", "Admin")
                                                               .Replace("Técnico", "Tecnico"))
                );

            modelBuilder.Entity<Cliente>()
                .Property(c => c.TipoCliente)
                .HasConversion<string>();

            modelBuilder.Entity<Proveedor>()
                .Property(p => p.TipoProveedor)
                .HasConversion<string>();

            // Configurar relación Cliente - CuentaCorriente
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.CuentaCorriente)
                .WithOne(cc => cc.Cliente)
                .HasForeignKey<CuentaCorriente>(cc => cc.ClienteId)
                .IsRequired(false);

            modelBuilder.Entity<MovimientoCuentaCorriente>()
                .Property(m => m.Tipo)
                .HasConversion<string>();
        }

    }

}
