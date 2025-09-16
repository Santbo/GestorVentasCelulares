using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.categoria;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.controller.usuario;
using GestionVentasCel.controller.proveedor;
using GestionVentasCel.controller.compra;
using GestionVentasCel.enumerations.usuarios;
using GestionVentasCel.views.articulo;
using GestionVentasCel.views.categoria;
using GestionVentasCel.views.usuario_empleado;
using GestionVentasCel.views.proveedor;
using GestionVentasCel.views.compra;

using Microsoft.Extensions.DependencyInjection;


namespace GestionVentasCel
{
    public partial class MainMenuForm : Form
    {
        //Depende el rol que se acceda se muestran los Menu Strip
        public RolEnum RolAccedido { get; set; }

        private readonly IServiceProvider _serviceProvider;

        public MainMenuForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

        }

        //Creamos un metodo para que la X del formulario funcione con un MessageBox
        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
            "�Seguro que desea salir?",
            "Confirmaci�n",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Cancela el cierre
            }
        }

        //Metodo para abrir formularios hijos y embeberlos en el MainMenu
        private void AbrirFormularioHijo(Form formularioHijo)
        {
            // Limpiar lo que ya est� en el panel
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);

            // Configurar el formulario hijo
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            // Agregar al panel
            this.panelContenedor.Controls.Add(formularioHijo);
            this.panelContenedor.Tag = formularioHijo;

            formularioHijo.Show();
        }

        private void UsuarioMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new UsuarioMainMenuForm(_serviceProvider.GetRequiredService<UsuarioController>()));
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            switch (RolAccedido)
            {
                case RolEnum.Admin:
                    // Todo visible
                    break;

                case RolEnum.Vendedor:
                    UsuarioMenuItem.Visible = false; // No puede ver usuarios
                    break;

                case RolEnum.Tecnico:
                    UsuarioMenuItem.Visible = false;

                    break;
            }
        }

        private void categoriasMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new CategoriaMainMenuForm(_serviceProvider.GetRequiredService<CategoriaController>()));
        }

        private void ArticulosMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new ArticuloMainMenuForm(_serviceProvider.GetRequiredService<ArticuloController>(), _serviceProvider.GetRequiredService<CategoriaController>()));
        }

        private void gestionarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new ClienteMainMenuForm(_serviceProvider.GetRequiredService<ClienteController>(), serviceProvider: _serviceProvider));
        }

        private void gestionarCuentasCorrientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new CuentaCorrienteMainMenuForm(_serviceProvider.GetRequiredService<ClienteController>(), serviceProvider: _serviceProvider));
        }

        private void proveedoresMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new ProveedorMainMenuForm(
                _serviceProvider.GetRequiredService<ProveedorController>(),
                _serviceProvider.GetRequiredService<CompraController>(),
                _serviceProvider.GetRequiredService<ArticuloController>()
                               ));
        }

        private void comprasMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new CompraMainMenuForm(
                            _serviceProvider.GetRequiredService<CompraController>(),
                _serviceProvider.GetRequiredService<ProveedorController>(),
                _serviceProvider.GetRequiredService<ArticuloController>()));
        }
    }
}
