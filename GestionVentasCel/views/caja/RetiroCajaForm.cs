using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionVentasCel.controller.caja;
using GestionVentasCel.exceptions.caja;

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
                try
                {

                    _cajaController.RegistrarRetiro(_cajaId, decimal.Parse(txtMonto.Text), txtDescripcion.Text);
                    DialogResult = DialogResult.OK;
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

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Permitir teclas de control como Backspace
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Permitir dígitos
            if (char.IsDigit(e.KeyChar))
            {
                // Si ya hay un punto, verificar los decimales
                if (txt.Text.Contains("."))
                {
                    int index = txt.Text.IndexOf(".");
                    string decimals = txt.Text.Substring(index + 1);

                    // Si hay más de 1 decimal y el cursor está después del punto
                    if (txt.SelectionStart > index && decimals.Length >= 2)
                    {
                        e.Handled = true;
                        return;
                    }
                }

                e.Handled = false;
                return;
            }

            // Permitir solo un punto
            if (e.KeyChar == '.')
            {
                if (txt.Text.Contains("."))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
                return;
            }

            // Bloquear cualquier otro carácter
            e.Handled = true;
        }
    }
}
