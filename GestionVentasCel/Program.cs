using GestionVentasCel.controller.usuario;
using GestionVentasCel.repository.usuario.impl;
using GestionVentasCel.service.usuario;
using GestionVentasCel.service.usuario.impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            // Cargar configuración desde appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();

            // Guardar la connection string
            string connectionString = config.GetConnectionString("DefaultConnection");

            // Acá podrías pasarla a tu DbContext
            var optionsBuilder = new DbContextOptionsBuilder<data.AppDbContext>();
            optionsBuilder.UseMySql(
            connectionString,
                new MySqlServerVersion(new Version(8, 0, 39)) // Ajustá la versión de MySQL
            );

            var context = new data.AppDbContext(optionsBuilder.Options);

            //Inicializar las clases para pasar el controller
            // Crear el repositorio
            var usuarioRepo = new UsuarioRepositoryImpl(context);

            // Crear el service (si lo tenés)
            var usuarioService = new UsuarioServiceImpl(usuarioRepo);

            // Crear el controller
            var usuarioController = new UsuarioController(usuarioService);

            // Inicializar WinForms
            ApplicationConfiguration.Initialize();
            Application.Run(new views.LoginForm(context, usuarioController));
        }
    }
}