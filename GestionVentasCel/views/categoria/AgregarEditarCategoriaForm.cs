using GestionVentasCel.controller.categoria;
using GestionVentasCel.enumerations.modoForms;
using GestionVentasCel.exceptions.categoria;
using GestionVentasCel.models.categoria;
using GestionVentasCel.temas;
using static System.Net.Mime.MediaTypeNames;




namespace GestionVentasCel.views.categoria
{
    public partial class AgregarEditarCategoriaForm : Form
    {
        private readonly CategoriaController _categoriaController;

        //Sirve para el comportamiento del Formulario, tanto para agregar como editar
        public ModoFormulario Modo { get; set; }
        //Se utiliza si el modo del Form es editar
        public Categoria CategoriaActual { get; set; }
        public AgregarEditarCategoriaForm(CategoriaController categoria)
        {
            InitializeComponent();
            _categoriaController = categoria;
        }

        private void AgregarEditarCategoriaForm_FormClosing(object sender, FormClosingEventArgs e)
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
                    try
                    {

                        _categoriaController.CrearCategoria(
                            txtNombre.Text.ToUpper(),
                            txtDescripcion.Text.ToUpper()
                        );

                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (CategoriaExistenteException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (Modo == ModoFormulario.Editar && CategoriaActual != null)
                {
                    try
                    {

                        CategoriaActual.Nombre = txtNombre.Text.ToUpper();
                        CategoriaActual.Descripcion = txtDescripcion.Text.ToUpper();


                        _categoriaController.UpdateCategoria(CategoriaActual);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (CategoriaNoEncontradaException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }


        private bool CamposValidos()
        {
            
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Por favor, completá el campo Nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private void AgregarEditarCategoriaForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
            if (Modo == ModoFormulario.Editar && CategoriaActual != null)
            {
                txtNombre.Text = CategoriaActual.Nombre;
                txtDescripcion.Text = CategoriaActual.Descripcion;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.btnDescartar.PerformClick();
        }

        private void ConfigurarEstilosVisuales()
        {

            this.lblTituloForm.Text = Modo == ModoFormulario.Editar ?
                "Editar categoría" : "Agregar categoría";

            this.lblTituloForm.ForeColor = Tema.ColorTextoPrimario;
            this.lblTituloForm.BackColor = Tema.ColorFondo;
            this.btnSalir.BackColor = Tema.ColorFondo;


            this.BackColor = Tema.ColorSuperficie;

            this.lblDescripcion.ForeColor = Tema.ColorFondo;
            this.lblNombre.ForeColor = Tema.ColorFondo;


        }
    }
}
