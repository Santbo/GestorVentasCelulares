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
using GestionVentasCel.models.usuario;
using static System.Net.Mime.MediaTypeNames;

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
                if (!string.IsNullOrEmpty(txtMontoApertura.Text))
                {

                    _cajaController.AbrirCaja(_UsuarioId, decimal.Parse(txtMontoApertura.Text));
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Por favor, completá el campo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMontoApertura.Focus();
                }

            }
            catch (CajaYaAbiertaException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
        }

        private void txtMontoApertura_KeyPress(object sender, KeyPressEventArgs e)
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
