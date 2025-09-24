using GestionVentasCel.controller.reparaciones;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.reparacion;

namespace GestionVentasCel.views.reparacion
{
    public partial class AgregarEditarDispositivoForm : Form
    {

        private readonly ReparacionController _reparacionController;
        public Cliente ClienteUtilizado { get; set; }
        public Dispositivo _dispositivo { get; set; }
        public AgregarEditarDispositivoForm(ReparacionController reparacionController)
        {
            InitializeComponent();
            _reparacionController = reparacionController;


        }

        private void CargarCliente()
        {
            txtCliente.Text = ClienteUtilizado.NombreCompleto;

        }

        private void AgregarEditarDispositivoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {

                var result = MessageBox.Show(
                "¿Seguro que desea descartar los cambios?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancela el cierre
                }
            }
        }

        private void btnDescartar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Seleccione un nombre del Dispositivo",
                      "Seleccione un Nombre",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);

                txtNombre.Focus();
                return;
            }

            if (_dispositivo != null)
            {
                _dispositivo.Nombre = txtNombre.Text;
                _reparacionController.ActualizarDispositivo(_dispositivo);

            }
            else
            {
                _reparacionController.AgregarDispositivo(txtNombre.Text, ClienteUtilizado.Id);

            }

            this.DialogResult = DialogResult.OK;
        }

        private void AgregarEditarDispositivoForm_Load(object sender, EventArgs e)
        {
            if (_dispositivo != null)
            {
                txtNombre.Text = _dispositivo.Nombre;
                lblTitulo.Text = "Editar Dispositivo";
            }

            CargarCliente();
        }
    }
}
