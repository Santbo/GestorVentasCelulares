using GestionVentasCel.controller.caja;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.exceptions.caja;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.caja
{
    public partial class RetiroCajaForm : Form
    {
        private readonly CajaController _cajaController;
        private int _cajaId;
        public RetiroCajaForm(CajaController cajaController, int cajaId)
        {
            InitializeComponent();
            _cajaController = cajaController;
            _cajaId = cajaId;
        }

        private void RetiroCajaForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {

                var caja = _cajaController.ObtenerConMovimientos(_cajaId);
                var totalEfectivo = caja.TotalesPorTipoPago.GetValueOrDefault(TipoPagoEnum.Efectivo) + caja.MontoApertura;
                var totalCaja = totalEfectivo - caja.TotalesPorTipoPago.GetValueOrDefault(TipoPagoEnum.Retiro);
                try
                {
                    if (totalCaja >= nupMonto.Value)
                    {
                        _cajaController.RegistrarRetiro(_cajaId, nupMonto.Value, txtDescripcion.Text);
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {

                        MessageBox.Show("No se puede retirar mas dinero del disponible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                catch (CajaNoEncontradaException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                catch (CajaYaCerradaException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private bool validarCampos()
        {
            //valida textbox vacios
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is System.Windows.Forms.TextBox txt && string.IsNullOrWhiteSpace(txt.Text) && txt != txtDescripcion)
                {
                    MessageBox.Show("Por favor, completá todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt.Focus();
                    return false;
                }
            }

            return true;
        }

        private void RetiroCajaForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
            this.ActiveControl = nupMonto;
        }

        private void ConfigurarEstilosVisuales()
        {
            this.BackColor = Tema.ColorSuperficie;

            this.lblTituloForm.ForeColor = Tema.ColorTextoPrimario;
            this.lblTituloForm.BackColor = Tema.ColorFondo;
            this.btnSalir.BackColor = Tema.ColorFondo;


            this.BackColor = Tema.ColorSuperficie;

        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.btnCancelar.PerformClick();

        }
    }
}
