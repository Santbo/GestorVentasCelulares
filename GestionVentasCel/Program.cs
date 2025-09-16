using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.categoria;
using GestionVentasCel.controller.usuario;
using GestionVentasCel.controller.proveedor;
using GestionVentasCel.controller.compra;
using GestionVentasCel.data;
using GestionVentasCel.repository.articulo;
using GestionVentasCel.repository.articulo.impl;
using GestionVentasCel.repository.categoria;
using GestionVentasCel.repository.categoria.impl;
using GestionVentasCel.repository.usuario;
using GestionVentasCel.repository.usuario.impl;
using GestionVentasCel.repository.proveedor;
using GestionVentasCel.repository.proveedor.impl;
using GestionVentasCel.repository.compra;
using GestionVentasCel.repository.compra.impl;
using GestionVentasCel.service.articulo;
using GestionVentasCel.service.articulo.impl;
using GestionVentasCel.service.persona;
using GestionVentasCel.service.persona.impl;
using GestionVentasCel.service.categoria;
using GestionVentasCel.service.categoria.impl;
using GestionVentasCel.service.usuario;
using GestionVentasCel.service.usuario.impl;
using GestionVentasCel.service.proveedor;
using GestionVentasCel.service.proveedor.impl;
using GestionVentasCel.service.compra;
using GestionVentasCel.service.compra.impl;
using GestionVentasCel.views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            // Registrar DbContext como singleton o scoped seg�n tu necesidad
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 39)), 
                    mySqlOptions => mySqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(60),
                        errorNumbersToAdd: null)
                    .CommandTimeout(120))
            );

            // Registrar repositorios
            services.AddTransient<IUsuarioRepository, UsuarioRepositoryImpl>();
            services.AddTransient<ICategoriaRepository, CategoriaRepositoryImpl>();
            services.AddTransient<IArticuloRepository, ArticuloRepositoryImpl>();
            services.AddTransient<IProveedorRepository, ProveedorRepositoryImpl>();
            services.AddTransient<ICompraRepository, CompraRepositoryImpl>();
            services.AddTransient<IDetalleCompraRepository, DetalleCompraRepositoryImpl>();


            // Registrar servicios
            services.AddTransient<IUsuarioService, UsuarioServiceImpl>();
            services.AddTransient<ICategoriaService, CategoriaServiceImpl>();
            services.AddTransient<IArticuloService, ArticuloServiceImpl>();
            services.AddTransient<IHistorialPrecioService, HistorialPrecioServiceImpl>();
            services.AddTransient<ICuitValidationService, CuitValidationServiceImpl>();
            services.AddTransient<IProveedorService, ProveedorServiceImpl>();
            services.AddTransient<ICompraService, CompraServiceImpl>();

            // Registrar controllers
            services.AddTransient<UsuarioController>();
            services.AddTransient<CategoriaController>();
            services.AddTransient<ArticuloController>();
            services.AddTransient<ProveedorController>();
            services.AddTransient<CompraController>();

            // Registrar forms
            services.AddTransient<LoginForm>();

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