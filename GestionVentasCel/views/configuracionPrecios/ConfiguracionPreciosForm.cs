using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionVentasCel.controller.configPrecios;
using GestionVentasCel.exceptions.configPrecios;
using GestionVentasCel.models.configPrecios;

namespace GestionVentasCel.views.configuracionPrecios
{
    public partial class ConfiguracionPreciosForm : Form
    {
        private readonly ConfiguracionPreciosController _configuracionPreciosController;
        public ConfiguracionPreciosForm(ConfiguracionPreciosController configuracionPreciosController)
        {
            InitializeComponent();
            _configuracionPreciosController = configuracionPreciosController;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                var margenActual = _configuracionPreciosController.GetById(1);
                var porcentaje = Math.Round(100 * (margenActual.MargenAumento - 1));
                MessageBox.Show($"Margen Actual: {porcentaje}%", "Margen", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MargenNoAgregadoException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ConfiguracionPreciosForm_FormClosing(object sender, FormClosingEventArgs e)
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

            if (_configuracionPreciosController.MargenExist(1))
            {
                var margenActual = _configuracionPreciosController.GetById(1);
                var factor = 1 + (decimal.Parse(txtAumento.Text) / 100);
                margenActual.MargenAumento = factor;
                margenActual.UltimaActualizacion = DateTime.Now;
                _configuracionPreciosController.UpdateMargen(margenActual);
                DialogResult = DialogResult.OK;
            }
            else
            {
                _configuracionPreciosController.AgregarMargen(txtAumento.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private void txtAumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir borrar (Backspace)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Permitir solo dígitos
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
                return;
            }

            // Previsualizar el texto con el nuevo carácter
            var txt = (TextBox)sender;
            string nuevoTexto = txt.Text.Insert(txt.SelectionStart, e.KeyChar.ToString());

            if (int.TryParse(nuevoTexto, out int valor))
            {
                // Validar rango 1 - 100
                if (valor < 1 || valor > 100)
                {
                    e.Handled = true; // Cancela si está fuera de rango
                }
            }
            else
            {
                e.Handled = true; // Si no es número válido
            }
        }
    }
}
