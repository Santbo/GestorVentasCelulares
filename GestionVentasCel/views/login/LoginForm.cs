
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.categoria;
using GestionVentasCel.controller.usuario;
using GestionVentasCel.controller.proveedor;
using GestionVentasCel.controller.compra;
using GestionVentasCel.data;

namespace GestionVentasCel.views
{
    public partial class LoginForm : Form
    {

        private readonly AppDbContext _context;
        private readonly UsuarioController _usuarioController;
        private readonly CategoriaController _categoriaController;
        private readonly ArticuloController _articuloController;
        private readonly ProveedorController _proveedorController;
        private readonly CompraController _compraController;
        public LoginForm(AppDbContext context,
                        UsuarioController usuarioController,
                        CategoriaController categoriaController,
                        ArticuloController articuloController,
                        ProveedorController proveedorController,
                        CompraController compraController
                        )
        {
            InitializeComponent();
            _context = context;
            _usuarioController = usuarioController;
            _categoriaController = categoriaController;
            _articuloController = articuloController;
            _proveedorController = proveedorController;
            _compraController = compraController;
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
                var main = new MainMenuForm(_usuarioController, _categoriaController, _articuloController, _proveedorController, _compraController);
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
