using GestionVentasCel.controller.usuario;
using GestionVentasCel.repository.usuario.impl;
using GestionVentasCel.service.usuario;
using GestionVentasCel.service.usuario.impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Extensions.DependencyInjection;
using GestionVentasCel.data;
using GestionVentasCel.repository.usuario;
using GestionVentasCel.views;
using GestionVentasCel.repository.categoria;
using GestionVentasCel.repository.categoria.impl;
using GestionVentasCel.service.categoria;
using GestionVentasCel.service.categoria.impl;
using GestionVentasCel.controller.categoria;

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

            // Registrar DbContext como singleton o scoped según tu necesidad
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 39)))
            );

            // Registrar repositorios
            services.AddTransient<IUsuarioRepository, UsuarioRepositoryImpl>();
            services.AddTransient<ICategoriaRepository, CategoriaRepositoryImpl>();

            // Registrar servicios
            services.AddTransient<IUsuarioService, UsuarioServiceImpl>();
            services.AddTransient<ICategoriaService, CategoriaServiceImpl>();

            // Registrar controllers
            services.AddTransient<UsuarioController>();
            services.AddTransient<CategoriaController>();

            // Registrar forms
            services.AddTransient<LoginForm>();

            // Construir el proveedor de servicios
            var serviceProvider = services.BuildServiceProvider();

            // Obtener el form principal con todas las dependencias resueltas
            var loginForm = serviceProvider.GetRequiredService<LoginForm>();

            Application.Run(loginForm);
        }
    }
}