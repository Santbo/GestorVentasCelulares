using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.categoria;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.controller.usuario;
using GestionVentasCel.data;
using GestionVentasCel.repository.articulo;
using GestionVentasCel.repository.articulo.impl;
using GestionVentasCel.repository.categoria;
using GestionVentasCel.repository.categoria.impl;
using GestionVentasCel.repository.ClienteCuentaCorriente;
using GestionVentasCel.repository.ClienteCuentaCorriente.impl;
using GestionVentasCel.repository.persona;
using GestionVentasCel.repository.persona.impl;
using GestionVentasCel.repository.usuario;
using GestionVentasCel.repository.usuario.impl;
using GestionVentasCel.service.articulo;
using GestionVentasCel.service.articulo.impl;
using GestionVentasCel.service.categoria;
using GestionVentasCel.service.categoria.impl;
using GestionVentasCel.service.cliente;
using GestionVentasCel.service.cliente.impl;
using GestionVentasCel.service.usuario;
using GestionVentasCel.service.usuario.impl;
using GestionVentasCel.views;
using GestionVentasCel.views.usuario_empleado;
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

            // Cargar configuración desde appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();

            // Guardar la connection string
            string connectionString = config.GetConnectionString("DefaultConnection");

            // Configurar el contenedor de servicios
            var services = new ServiceCollection();

            // Registrar DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 39)))
            );

            // Registrar repositorios
            services.AddTransient<IUsuarioRepository, UsuarioRepositoryImpl>();
            services.AddTransient<ICategoriaRepository, CategoriaRepositoryImpl>();
            services.AddTransient<IArticuloRepository, ArticuloRepositoryImpl>();
            services.AddTransient<IClienteRepository, ClienteRepositoryImpl>();
            services.AddTransient<ICuentaCorrienteRepository, CuentaCorrienteRepositoryImpl>();
            services.AddTransient<IMovimientoCuentaCorrienteRepository, MovimientoCuentaCorrienteRepositoryImpl>();
            services.AddTransient<IPersonaRepository, PersonaRepositoryImpl>();



            // Registrar servicios
            services.AddTransient<IUsuarioService, UsuarioServiceImpl>();
            services.AddTransient<ICategoriaService, CategoriaServiceImpl>();
            services.AddTransient<IArticuloService, ArticuloServiceImpl>();
            services.AddTransient<IClienteService, ClienteServiceImpl>();


            // Registrar controllers
            services.AddTransient<UsuarioController>();
            services.AddTransient<CategoriaController>();
            services.AddTransient<ArticuloController>();
            services.AddTransient<ClienteController>();

            // Registrar forms
            services.AddTransient<LoginForm>();
            services.AddTransient<AgregarEditarMovimientoCCForm>();

            // Construir el proveedor de servicios
            var serviceProvider = services.BuildServiceProvider();

            // Obtener el form principal con todas las dependencias resueltas
            var loginForm = serviceProvider.GetRequiredService<LoginForm>();

            Application.Run(loginForm);
        }
    }
}