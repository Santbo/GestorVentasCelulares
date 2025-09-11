using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.categoria;
using GestionVentasCel.controller.usuario;
using GestionVentasCel.enumerations.modoForms;
using GestionVentasCel.enumerations.usuarios;
using GestionVentasCel.exceptions.articulo;
using GestionVentasCel.exceptions.usuario;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.usuario;
using GestionVentasCel.views.categoria;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GestionVentasCel.views.articulo
{
    public partial class AgregarEditarArticuloForm : Form
    {
        private readonly ArticuloController _articuloController;
        //Sirve para el comportamiento del Formulario, tanto para agregar como editar

        //Agrego el controlador de categoria para poder cargar el combobox de las categorias disponibles
        //Se hace asi ya que si tenemos una categoria sin articulo no se va a mostrar si cargamos desde la 
        //lista de articulos. Ademas para cargar una categoria nueva desde la ventana de articulos, tenemos
        // que pasarselo como parametro
        private readonly CategoriaController _categoriaController;
        public ModoFormulario Modo { get; set; }
        //Se utiliza si el modo del Form es editar
        public Articulo ArticuloActual { get; set; }
        public AgregarEditarArticuloForm(ArticuloController articuloController, CategoriaController categoriaController)
        {
            InitializeComponent();
            _articuloController = articuloController;
            _categoriaController = categoriaController;

            CargarCategoriasCombo();
        }

        private void CargarCategoriasCombo()
        {
            var categorias = _categoriaController.ObtenerCategorias().ToList();
            cbxCategoria.DataSource = categorias;
            cbxCategoria.DisplayMember = "Nombre"; //lo que muestro
            cbxCategoria.ValueMember = "Id"; //lo que guardo
        }

        private void AgregarEditarArticuloForm_FormClosing(object sender, FormClosingEventArgs e)
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
            if (CamposValidos())
            {
                //Se ve en que modo se abrio el Form, si es en agregar se agrega, si no se edita
                if (Modo == ModoFormulario.Agregar)
                {

                    _articuloController.CrearArticulo(

                        txtNombre.Text.ToUpper(),
                        int.Parse(txtAvisoStock.Text),
                        Math.Round(decimal.Parse(txtPrecio.Text), 2),
                        int.Parse(txtStock.Text),
                        txtMarca.Text.ToUpper(),
                        (int)cbxCategoria.SelectedValue,
                        txtDescripcion.Text.ToUpper()

                    );

                    DialogResult = DialogResult.OK;
                    this.Close();

                }
                else if (Modo == ModoFormulario.Editar && ArticuloActual != null)
                {
                    try
                    {

                        ArticuloActual.Nombre = txtNombre.Text.ToUpper();
                        ArticuloActual.Aviso_stock = int.Parse(txtAvisoStock.Text);
                        ArticuloActual.Precio = decimal.Parse(txtPrecio.Text);
                        ArticuloActual.Stock = int.Parse(txtStock.Text);
                        ArticuloActual.Marca = txtMarca.Text.ToUpper();
                        ArticuloActual.CategoriaId = (int)cbxCategoria.SelectedValue;
                        ArticuloActual.Descripcion = txtDescripcion.Text.ToUpper();


                        _articuloController.UpdateArticulo(ArticuloActual);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (ArticuloNoEncontradoException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }



            }
        }

        private bool CamposValidos()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is System.Windows.Forms.TextBox txt
                    && string.IsNullOrWhiteSpace(txt.Text) && txt != txtDescripcion)
                {
                    MessageBox.Show("Por favor, completá todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt.Focus();
                    return false;
                }
            }

            return true;

        }

        private void AgregarEditarArticuloForm_Load(object sender, EventArgs e)
        {
            if (Modo == ModoFormulario.Editar && ArticuloActual != null)
            {
                lblTitulo.Text = "Editar Articulo";

                txtNombre.Text = ArticuloActual.Nombre;
                txtAvisoStock.Text = ArticuloActual.Aviso_stock.ToString();
                txtPrecio.Text = ArticuloActual.Precio.ToString();
                txtStock.Text = ArticuloActual.Stock.ToString();
                txtMarca.Text = ArticuloActual.Marca;
                cbxCategoria.SelectedValue = ArticuloActual.CategoriaId;
                txtDescripcion.Text = ArticuloActual.Descripcion;

            }
        }

        private void txtAvisoStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void addCategoria_Click(object sender, EventArgs e)
        {
            using (var agregarCategoria = new AgregarEditarCategoriaForm(_categoriaController))
            {
                agregarCategoria.Modo = ModoFormulario.Agregar;
                //si el usuario apreta guardar, muestra el msj y actualiza el binding
                if (agregarCategoria.ShowDialog() == DialogResult.OK)
                {

                    MessageBox.Show("La categoria se guardó correctamente",
                    "Categoria Guardada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                    CargarCategoriasCombo();
                }
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox txt = sender as System.Windows.Forms.TextBox;

            // Permitir control (Backspace, etc.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Permitir dígitos
            if (char.IsDigit(e.KeyChar))
            {
                // Si ya hay un punto/coma, verificar que no haya más de 2 decimales
                int indexSeparador = txt.Text.IndexOfAny(new char[] { '.', ',' });
                if (indexSeparador >= 0 && txt.SelectionStart > indexSeparador)
                {
                    if (txt.Text.Length - indexSeparador > 2)
                    {
                        e.Handled = true;
                    }
                }
                return;
            }

            // Permitir solo un punto o coma
            if ((e.KeyChar == '.' || e.KeyChar == ',') &&
                !txt.Text.Contains('.') &&
                !txt.Text.Contains(','))
            {
                return;
            }

            // Todo lo demás se bloquea
            e.Handled = true;

        }
    }
}
