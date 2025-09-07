using GestionVentasCel.controller.usuario;
using GestionVentasCel.enumerations.usuarios;
using GestionVentasCel.service.usuario;
using GestionVentasCel.views.usuario_empleado;

namespace GestionVentasCel
{
    public partial class MainMenuForm : Form
    {
        //Depende el rol que se acceda se muestran los Menu Strip
        public RolEnum RolAccedido { get; set; }
        private readonly UsuarioController _usuarioController;
        public MainMenuForm(UsuarioController usuarioController)
        {
            InitializeComponent();
            _usuarioController = usuarioController;

        }

        //Creamos un metodo para que la X del formulario funcione con un MessageBox
        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
            "¿Seguro que desea salir?",
            "Confirmación",
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
            // Limpiar lo que ya esté en el panel
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
            AbrirFormularioHijo(new UsuarioMainMenuForm(_usuarioController));
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
    }
}
