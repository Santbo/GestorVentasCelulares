using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.caja;
using GestionVentasCel.models.categoria;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.compra;
using GestionVentasCel.models.configPrecios;
using GestionVentasCel.models.CuentaCorreinte;
using GestionVentasCel.models.persona;
using GestionVentasCel.models.proveedor;
using GestionVentasCel.models.reparacion;
using GestionVentasCel.models.servicio;
using GestionVentasCel.models.usuario;
using GestionVentasCel.models.ventas;
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

        public DbSet<Reparacion> Reparaciones { get; set; }
        public DbSet<ReparacionServicio> ReparacionServicios { get; set; }
        public DbSet<Dispositivo> Dispositivos { get; set; }

        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVenta { get; set; }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetallesFacturas { get; set; }

        public DbSet<Caja> Caja { get; set; }

        public DbSet<MovimientoCaja> MovimientosCaja { get; set; }


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

            modelBuilder.Entity<Reparacion>()
                .Property(r => r.Estado)
                .HasConversion<string>();
            // TODO: Solucionar error de servicio null

            //se define clave 
            modelBuilder.Entity<ReparacionServicio>()
                        .HasKey(rs => rs.Id);

            //Relacion Reparacion a ReparacionServicio
            modelBuilder.Entity<ReparacionServicio>()
                            .HasOne(rs => rs.Reparacion)
                            .WithMany(r => r.ReparacionServicios)
                            .HasForeignKey(rs => rs.ReparacionId);

            // Relación Servicio a ReparacionServicio
            modelBuilder.Entity<ReparacionServicio>()
                .HasOne(rs => rs.Servicio)
                .WithMany(); //Lo dejo aca para que no haya una tabla en Servicio.


            modelBuilder
                .Entity<Venta>()
                .Property(v => v.EstadoVenta)
                .HasConversion<string>();

            modelBuilder
                .Entity<Venta>()
                .Property(v => v.TipoPago)
                .HasConversion<string>();

            // Relación Venta - DetalleVenta
            modelBuilder.Entity<DetalleVenta>()
                .HasOne(d => d.Venta)
                .WithMany(v => v.Detalles)
                .HasForeignKey(d => d.VentaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<Factura>()
                .Property(f => f.TipoComprobante)
                .HasConversion<string>();

            modelBuilder
                .Entity<Empresa>()
                .Property(e => e.CondicionIVA)
                .HasConversion<string>();

            modelBuilder.Entity<Caja>()
                .Property(c => c.Estado)
                .HasConversion<string>();

            modelBuilder.Entity<MovimientoCaja>()
                .Property(m => m.TipoMovimiento)
                .HasConversion<string>();

        }


    }

}
