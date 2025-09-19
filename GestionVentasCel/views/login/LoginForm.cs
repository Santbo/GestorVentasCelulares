
using GestionVentasCel.controller.usuario;

using GestionVentasCel.data;
using GestionVentasCel.service.usuario;
using GestionVentasCel.temas;
using Humanizer;
using Microsoft.Extensions.DependencyInjection;

namespace GestionVentasCel.views
{
    public partial class LoginForm : Form
    {

        private readonly AppDbContext _context;
        private readonly UsuarioController _usuarioController;

        private readonly IServiceProvider _serviceProvider;
        private readonly SesionUsuario _sesionUsuario;
        public LoginForm(AppDbContext context,
                        IServiceProvider serviceProvider,
                        SesionUsuario sesionUSuario
                        )
        {
            InitializeComponent();
            _context = context;

            _serviceProvider = serviceProvider;
            _usuarioController = _serviceProvider.GetRequiredService<UsuarioController>();
            _sesionUsuario = sesionUSuario;


        }

        /// <summary>
        /// Establecer estilos visuales para el formulario. Para poder mantener los colores estandarizados y no tener
        /// que copiar y pegar en el diseñador, lamentablemente se tienen que poner a mano acá 
        /// </summary>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Tema.ColorFondo;
            this.panelContenedor.BackColor = Tema.ColorSuperficie;

            this.btnAcceso.BackColor = Tema.ColorFondo;
            this.btnAcceso.ForeColor = Tema.ColorTextoPrimario;

            this.lblTitulo.ForeColor = Tema.ColorFondo;
            this.lblContra.ForeColor = Tema.ColorFondo;
            this.lblUsuario.ForeColor = Tema.ColorFondo;

            this.txtPassword.BackColor = Tema.ColorSuperficie;
            this.txtUsuario.BackColor = Tema.ColorSuperficie;



        }
        private void btnAcceso_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show("No debe dejar campos vacíos", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var usuario = _usuarioController.Login(txtUsuario.Text, txtPassword.Text);

            if (usuario != null)
            {
                MessageBox.Show($"Bienvenido, {usuario.Nombre.ApplyCase(LetterCasing.Title)}.", "Inicio de sesión exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var main = new MainMenuForm(_serviceProvider);

                _sesionUsuario.IniciarSesion(usuario.Username, usuario.Rol);

                main.RolAccedido = usuario.Rol;

                // Suscribirse al evento de cerrado del MainMenu
                main.FormClosed += (s, args) =>
                {
                    _sesionUsuario.CerrarSesion();
                    this.Show(); // vuelve a mostrar el login
                    txtPassword.Clear();
                };

                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrectos", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
