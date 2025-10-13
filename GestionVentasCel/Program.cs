using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.caja;
using GestionVentasCel.controller.categoria;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.controller.compra;
using GestionVentasCel.controller.configPrecios;
using GestionVentasCel.controller.proveedor;
using GestionVentasCel.controller.reparaciones;
using GestionVentasCel.controller.reportes;
using GestionVentasCel.controller.servicio;
using GestionVentasCel.controller.usuario;
using GestionVentasCel.data;
using GestionVentasCel.repository.articulo;
using GestionVentasCel.repository.articulo.impl;
using GestionVentasCel.repository.caja;
using GestionVentasCel.repository.caja.impl;
using GestionVentasCel.repository.categoria;
using GestionVentasCel.repository.categoria.impl;
using GestionVentasCel.repository.ClienteCuentaCorriente;
using GestionVentasCel.repository.ClienteCuentaCorriente.impl;
using GestionVentasCel.repository.compra;
using GestionVentasCel.repository.compra.impl;
using GestionVentasCel.repository.configPrecios;
using GestionVentasCel.repository.configPrecios.impl;
using GestionVentasCel.repository.facturas;
using GestionVentasCel.repository.facturas.impl;
using GestionVentasCel.repository.persona;
using GestionVentasCel.repository.persona.impl;
using GestionVentasCel.repository.proveedor;
using GestionVentasCel.repository.proveedor.impl;
using GestionVentasCel.repository.reparacion;
using GestionVentasCel.repository.reparacion.impl;
using GestionVentasCel.repository.reportes;
using GestionVentasCel.repository.reportes.impl;
using GestionVentasCel.repository.servicio;
using GestionVentasCel.repository.servicio.impl;
using GestionVentasCel.repository.usuario;
using GestionVentasCel.repository.usuario.impl;
using GestionVentasCel.repository.ventas;
using GestionVentasCel.repository.ventas.impl;
using GestionVentasCel.service;
using GestionVentasCel.service.articulo;
using GestionVentasCel.service.articulo.impl;
using GestionVentasCel.service.caja;
using GestionVentasCel.service.caja.impl;
using GestionVentasCel.service.categoria;
using GestionVentasCel.service.categoria.impl;
using GestionVentasCel.service.cliente;
using GestionVentasCel.service.cliente.impl;
using GestionVentasCel.service.compra;
using GestionVentasCel.service.compra.impl;
using GestionVentasCel.service.configPrecios;
using GestionVentasCel.service.configPrecios.impl;
using GestionVentasCel.service.factura;
using GestionVentasCel.service.proveedor;
using GestionVentasCel.service.proveedor.impl;
using GestionVentasCel.service.reparacion;
using GestionVentasCel.service.reparacion.impl;
using GestionVentasCel.service.servicio;
using GestionVentasCel.service.servicio.impl;
using GestionVentasCel.service.usuario;
using GestionVentasCel.service.usuario.impl;
using GestionVentasCel.service.venta;
using GestionVentasCel.service.venta.impl;
using GestionVentasCel.views;
using GestionVentasCel.views.usuario_empleado;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GestionVentasCel
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Inicializar WinForms
            ApplicationConfiguration.Initialize();

            // Cargar configuraci�n desde appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();

            // Guardar la connection string
            string connectionString = config.GetConnectionString("DefaultConnection");

            // Verificar que la connection string no esté vacía
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Error: No se encontró la cadena de conexión en appsettings.json", "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Configurar el contenedor de servicios
            var services = new ServiceCollection();

            // Registrar DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 39)),
                    mySqlOptions => mySqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(60),
                        errorNumbersToAdd: null)
                    .CommandTimeout(120))
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );

            // Registrar repositorios
            services.AddTransient<IUsuarioRepository, UsuarioRepositoryImpl>();
            services.AddTransient<ICategoriaRepository, CategoriaRepositoryImpl>();
            services.AddTransient<IArticuloRepository, ArticuloRepositoryImpl>();
            services.AddTransient<IProveedorRepository, ProveedorRepositoryImpl>();
            services.AddTransient<ICompraRepository, CompraRepositoryImpl>();
            services.AddTransient<IDetalleCompraRepository, DetalleCompraRepositoryImpl>();

            services.AddTransient<IClienteRepository, ClienteRepositoryImpl>();
            services.AddTransient<ICuentaCorrienteRepository, CuentaCorrienteRepositoryImpl>();
            services.AddTransient<IPersonaRepository, PersonaRepositoryImpl>();
            services.AddTransient<IConfiguracionPreciosRepository, ConfiguracionPreciosRepositoryImpl>();
            services.AddTransient<IServicioRepository, ServicioRepositoryImpl>();
            services.AddTransient<IReparacionRepository, ReparacionRepositoryImpl>();
            services.AddTransient<IVentaRepository, VentaRepositoryImpl>();
            services.AddTransient<IFacturaRepository, FacturaRepositoryImpl>();
            services.AddTransient<ICajaRepository, CajaRepositoryImpl>();
            services.AddTransient<IReporteCompraRepository, ReporteCompraRepositoryImpl>();
            services.AddTransient<IReporteVentaRepository, ReporteVentaRepositoryImpl>();





            // Registrar servicios
            services.AddTransient<IUsuarioService, UsuarioServiceImpl>();
            services.AddTransient<ICategoriaService, CategoriaServiceImpl>();
            services.AddTransient<IArticuloService, ArticuloServiceImpl>();
            services.AddTransient<IProveedorService, ProveedorServiceImpl>();
            services.AddTransient<ICompraService, CompraServiceImpl>();
            services.AddTransient<IClienteService, ClienteServiceImpl>();
            services.AddTransient<IHistorialPrecioService, HistorialPrecioServiceImpl>();
            services.AddTransient<IConfiguracionPreciosService, ConfiguracionPreciosServiceImpl>();
            services.AddTransient<IServicioService, ServicioServiceImpl>();
            services.AddTransient<IReparacionService, ReparacionServiceImpl>();
            services.AddTransient<IVentaService, VentaServiceImpl>();
            services.AddTransient<IFacturaService, FacturaServiceImpl>();
            services.AddTransient<ICajaService, CajaServiceImpl>();
            services.AddTransient<ReporteCompraService>();
            services.AddTransient<ReporteVentaService>();



            // Registrar controllers
            services.AddTransient<UsuarioController>();
            services.AddTransient<CategoriaController>();
            services.AddTransient<ArticuloController>();
            services.AddTransient<ProveedorController>();
            services.AddTransient<CompraController>();
            services.AddTransient<ClienteController>();
            services.AddTransient<ConfiguracionPreciosController>();
            services.AddTransient<ServicioController>();
            services.AddTransient<ReparacionController>();
            services.AddTransient<CajaController>();
            services.AddTransient<ReporteCompraController>();
            services.AddTransient<ReporteVentaController>();

            // Registrar forms
            services.AddTransient<LoginForm>();
            services.AddTransient<AgregarEditarMovimientoCCForm>();

            // Registrra el singleton para sesion de usuarios
            services.AddSingleton<SesionUsuario>();

            try
            {
                // Construir el proveedor de servicios
                var serviceProvider = services.BuildServiceProvider();

                // Verificar la conexión a la base de datos
                using (var scope = serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    context.Database.OpenConnection();
                    context.Database.CloseConnection();
                }

                // Obtener el form principal con todas las dependencias resueltas
                var loginForm = serviceProvider.GetRequiredService<LoginForm>();

                Application.Run(loginForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos:\n\n{ex.Message}\n\nVerifica que:\n- MySQL esté ejecutándose\n- La base de datos 'dbsistemaprogramacion' exista\n- Las credenciales sean correctas",
                    "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}