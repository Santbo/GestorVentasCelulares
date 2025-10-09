using GestionVentasCel.controller.caja;
using GestionVentasCel.exceptions.caja;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.caja
{
    public partial class MontoAperturaForm : Form
    {

        private readonly CajaController _cajaController;
        private int _UsuarioId;
        public MontoAperturaForm(CajaController cajaController, int usuarioId)
        {
            InitializeComponent();
            _cajaController = cajaController;
            _UsuarioId = usuarioId;
        }

        private void MontoAperturaForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            try
            {
                // Realmente siempre debería ser mayor que cero pero por las dudas
                if (nupMonto.Value >= 0)
                {
                    _cajaController.AbrirCaja(_UsuarioId, nupMonto.Value);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un monto positivo",
                                    "Validación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    nupMonto.Focus();
                }
            }
            catch (CajaYaAbiertaException ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void ConfigurarEstilosVisuales()
        {
            this.BackColor = Tema.ColorSuperficie;

            this.lblTituloForm.ForeColor = Tema.ColorTextoPrimario;
            this.lblTituloForm.BackColor = Tema.ColorFondo;
            this.btnSalir.BackColor = Tema.ColorFondo;
            this.BackColor = Tema.ColorSuperficie;

        }

        private void MontoAperturaForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
            this.ActiveControl = nupMonto;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.btnCancelar.PerformClick();
        }
    }
}
