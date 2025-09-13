
﻿using GestionVentasCel.controller.usuario;

using GestionVentasCel.data;
using Microsoft.Extensions.DependencyInjection;

namespace GestionVentasCel.views
{
    public partial class LoginForm : Form
    {

        private readonly AppDbContext _context;
        private readonly UsuarioController _usuarioController;

        private readonly IServiceProvider _serviceProvider;
        public LoginForm(AppDbContext context,
                        IServiceProvider serviceProvider

                        )
        {
            InitializeComponent();
            _context = context;

            _serviceProvider = serviceProvider;
            _usuarioController = _serviceProvider.GetRequiredService<UsuarioController>();


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
                MessageBox.Show($"Bienvenido {usuario.Username}");

                var main = new MainMenuForm(_serviceProvider);

                main.RolAccedido = usuario.Rol;

                // Suscribirse al evento de cerrado del MainMenu
                main.FormClosed += (s, args) =>
                {
                    this.Show(); // vuelve a mostrar el login
                    txtPassword.Clear();
                };

                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrectos");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
