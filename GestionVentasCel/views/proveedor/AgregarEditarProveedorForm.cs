using System.Text.RegularExpressions;
using GestionVentasCel.controller.proveedor;
using GestionVentasCel.enumerations.modoForms;
using GestionVentasCel.enumerations.persona;
using GestionVentasCel.exceptions.persona;
using GestionVentasCel.exceptions.proveedor;
using GestionVentasCel.models.proveedor;

namespace GestionVentasCel.views.proveedor
{
    public partial class AgregarEditarProveedorForm : Form
    {
        #region Campos y Propiedades

        private readonly ProveedorController _proveedorController;

        public ModoFormulario Modo { get; set; }
        public Proveedor ProveedorActual { get; set; } = null!;

        #endregion

        #region Constructor

        public AgregarEditarProveedorForm(ProveedorController proveedorController)
        {
            InitializeComponent();
            _proveedorController = proveedorController;
            CargarComboBoxes();
            
        }

        #endregion

        #region Métodos de Inicialización

        private void CargarComboBoxes()
        {
            // Cargar tipos de documento
            cmbTipoDocumento.DataSource = Enum.GetValues(typeof(TipoDocumentoEnum));
            cmbTipoDocumento.SelectedIndex = 0;

            // Cargar condiciones de IVA
            cmbCondicionIVA.DataSource = Enum.GetValues(typeof(CondicionIVAEnum));
            cmbCondicionIVA.SelectedIndex = 0;
        }

        #endregion

        #region Eventos del Formulario

        private void AgregarEditarProveedorForm_Load(object sender, EventArgs e)
        {
            if (Modo == ModoFormulario.Editar && ProveedorActual != null)
            {
                CargarDatosProveedor();
                this.Text = "Editar Proveedor";
                btnGuardar.Text = "Actualizar";
            }
            else
            {
                this.Text = "Agregar Proveedor";
                btnGuardar.Text = "Guardar";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    if (Modo == ModoFormulario.Agregar)
                    {
                        CrearProveedor();
                    }
                    else
                    {
                        ActualizarProveedor();
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (ProveedorExistenteException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DocumentoDuplicadoException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDescartar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarEditarProveedorForm_FormClosing(object sender, FormClosingEventArgs e)
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
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #region Métodos de Negocio

        private void CargarDatosProveedor()
        {
            txtNombre.Text = ProveedorActual.Nombre;
            txtApellido.Text = ProveedorActual.Apellido ?? "";
            cmbTipoDocumento.SelectedItem = ProveedorActual.TipoDocumento;
            txtDocumento.Text = ProveedorActual.Dni ?? "";
            cmbCondicionIVA.SelectedItem = ProveedorActual.CondicionIVA;
            txtTelefono.Text = ProveedorActual.Telefono ?? "";
            txtEmail.Text = ProveedorActual.Email ?? "";
            txtCalle.Text = ProveedorActual.Calle ?? "";
            txtCiudad.Text = ProveedorActual.Ciudad ?? "";
            txtObservaciones.Text = ProveedorActual.Observaciones ?? "";
        }

        private void CrearProveedor()
        {
            var proveedor = new Proveedor
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim() != "" ? txtApellido.Text.Trim() : null,
                TipoDocumento = (TipoDocumentoEnum)cmbTipoDocumento.SelectedItem,
                Dni = txtDocumento.Text.Trim() != "" ? txtDocumento.Text.Trim() : null,
                CondicionIVA = (CondicionIVAEnum)cmbCondicionIVA.SelectedItem,
                Telefono = txtTelefono.Text.Trim() != "" ? txtTelefono.Text.Trim() : null,
                Email = txtEmail.Text.Trim() != "" ? txtEmail.Text.Trim() : null,
                Calle = txtCalle.Text.Trim() != "" ? txtCalle.Text.Trim() : null,
                Ciudad = txtCiudad.Text.Trim() != "" ? txtCiudad.Text.Trim() : null,
                Observaciones = txtObservaciones.Text.Trim() != "" ? txtObservaciones.Text.Trim() : null,
                Activo = true
            };

            _proveedorController.CrearProveedor(proveedor);
            MessageBox.Show("Proveedor creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ActualizarProveedor()
        {
            ProveedorActual.Nombre = txtNombre.Text.Trim();
            ProveedorActual.Apellido = txtApellido.Text.Trim() != "" ? txtApellido.Text.Trim() : null;
            ProveedorActual.TipoDocumento = (TipoDocumentoEnum)cmbTipoDocumento.SelectedItem;
            ProveedorActual.Dni = txtDocumento.Text.Trim() != "" ? txtDocumento.Text.Trim() : null;
            ProveedorActual.CondicionIVA = (CondicionIVAEnum)cmbCondicionIVA.SelectedItem;
            ProveedorActual.Telefono = txtTelefono.Text.Trim() != "" ? txtTelefono.Text.Trim() : null;
            ProveedorActual.Email = txtEmail.Text.Trim() != "" ? txtEmail.Text.Trim() : null;
            ProveedorActual.Calle = txtCalle.Text.Trim() != "" ? txtCalle.Text.Trim() : null;
            ProveedorActual.Ciudad = txtCiudad.Text.Trim() != "" ? txtCiudad.Text.Trim() : null;
            ProveedorActual.Observaciones = txtObservaciones.Text.Trim() != "" ? txtObservaciones.Text.Trim() : null;

            _proveedorController.ActualizarProveedor(ProveedorActual);
            MessageBox.Show("Proveedor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            // DNI: Asegurarse de que esté entre 8 y 13 caracteres
            string dni = txtDocumento.Text.Trim();
            if (dni.Length < 8 || dni.Length > 13)
            {
                MessageBox.Show("El DNI debe tener entre 8 y 13 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return false;
            }

            // DNI: Si se seleccionó CUIT, entonces tiene que seguir el formato correcto
            if ((TipoDocumentoEnum)cmbTipoDocumento.SelectedItem != TipoDocumentoEnum.DNI)
            {
                // Tiene que empezar con dos digitos, seguido de un guion, ocho digitos, un guion y terminar con un digito
                if (!Regex.IsMatch(dni, @"^\d{2}-\d{8}-\d{1}$"))
                {
                    MessageBox.Show("El formato del CUIT/CUIL debe ser XX-XXXXXXXX-X.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDocumento.Focus();
                    return false;

                }
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !EsEmailValido(txtEmail.Text))
            {
                MessageBox.Show("El formato del email no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Métodos de Validación

        #endregion

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
    }
}
