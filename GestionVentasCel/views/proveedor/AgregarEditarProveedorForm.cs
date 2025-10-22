using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using GestionVentasCel.controller.proveedor;
using GestionVentasCel.enumerations.modoForms;
using GestionVentasCel.enumerations.persona;
using GestionVentasCel.exceptions.persona;
using GestionVentasCel.exceptions.proveedor;
using GestionVentasCel.models.proveedor;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.proveedor
{
    public partial class AgregarEditarProveedorForm : Form
    {

        private readonly ProveedorController _proveedorController;

        public ModoFormulario Modo { get; set; }
        public Proveedor ProveedorActual { get; set; } = null!;




        public AgregarEditarProveedorForm(ProveedorController proveedorController)
        {
            InitializeComponent();
            _proveedorController = proveedorController;
            CargarComboBoxes();

        }




        private void CargarComboBoxes()
        {
            // Cargar tipos de documento
            comboTipoDoc.DataSource = Enum.GetValues(typeof(TipoDocumentoEnum));
            comboTipoDoc.SelectedIndex = 0;

            // Cargar condiciones de IVA
            comboCondicionIVA.DataSource = Enum.GetValues(typeof(CondicionIVAEnum));
            comboCondicionIVA.SelectedIndex = 0;
        }




        private void AgregarEditarProveedorForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
            if (Modo == ModoFormulario.Editar && ProveedorActual != null)
            {
                CargarDatosProveedor();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (CamposValidos())
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




        private void CargarDatosProveedor()
        {
            txtNombre.Text = ProveedorActual.Nombre;
            txtApellido.Text = ProveedorActual.Apellido ?? "";
            comboTipoDoc.SelectedItem = ProveedorActual.TipoDocumento;
            txtDni.Text = ProveedorActual.Dni ?? "";
            comboCondicionIVA.SelectedItem = ProveedorActual.CondicionIVA;
            txtTelefono.Text = ProveedorActual.Telefono ?? "";
            txtEmail.Text = ProveedorActual.Email ?? "";
            txtCalle.Text = ProveedorActual.Calle ?? "";
            txtCiudad.Text = ProveedorActual.Ciudad ?? "";
        }

        private void CrearProveedor()
        {
            var proveedor = new Proveedor
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim() != "" ? txtApellido.Text.Trim() : null,
                TipoDocumento = (TipoDocumentoEnum)comboTipoDoc.SelectedItem,
                Dni = txtDni.Text.Trim() != "" ? txtDni.Text.Trim() : null,
                CondicionIVA = (CondicionIVAEnum)comboCondicionIVA.SelectedItem,
                Telefono = txtTelefono.Text.Trim() != "" ? txtTelefono.Text.Trim() : null,
                Email = txtEmail.Text.Trim() != "" ? txtEmail.Text.Trim() : null,
                Calle = txtCalle.Text.Trim() != "" ? txtCalle.Text.Trim() : null,
                Ciudad = txtCiudad.Text.Trim() != "" ? txtCiudad.Text.Trim() : null,
                Activo = true
            };

            _proveedorController.CrearProveedor(proveedor);
            MessageBox.Show("Proveedor creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ActualizarProveedor()
        {
            ProveedorActual.Nombre = txtNombre.Text.Trim();
            ProveedorActual.Apellido = txtApellido.Text.Trim() != "" ? txtApellido.Text.Trim() : null;
            ProveedorActual.TipoDocumento = (TipoDocumentoEnum)comboTipoDoc.SelectedItem;
            ProveedorActual.Dni = txtDni.Text.Trim() != "" ? txtDni.Text.Trim() : null;
            ProveedorActual.CondicionIVA = (CondicionIVAEnum)comboCondicionIVA.SelectedItem;
            ProveedorActual.Telefono = txtTelefono.Text.Trim() != "" ? txtTelefono.Text.Trim() : null;
            ProveedorActual.Email = txtEmail.Text.Trim() != "" ? txtEmail.Text.Trim() : null;
            ProveedorActual.Calle = txtCalle.Text.Trim() != "" ? txtCalle.Text.Trim() : null;
            ProveedorActual.Ciudad = txtCiudad.Text.Trim() != "" ? txtCiudad.Text.Trim() : null;

            _proveedorController.ActualizarProveedor(ProveedorActual);
            MessageBox.Show("Proveedor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool CamposValidos()
        {
            // Nombre: No puede estar vacío, ser mas de 45 caracteres (porque asi está en la db), y debe estar compuesto por por lo menos 1 letra mayuscula, minuscula, numero o un punto
            string nombre = txtNombre.Text.Trim();
            if (string.IsNullOrEmpty(nombre) || nombre.Length > 45 || !Regex.IsMatch(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9. ]+$"))
            {
                MessageBox.Show("El nombre no puede estar vacío, tener más de 45 caracteres ni contener caracteres especiales (excepto '.').", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            // Apellido: Lo mismo que nombre, pero puede estar vacio (por eso se cambia + a * en la regex)
            string apellido = txtApellido.Text.Trim();
            if (apellido.Length > 45 || !Regex.IsMatch(apellido, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ]*$"))
            {
                MessageBox.Show("El apellido no puede tener más de 45 caracteres ni contener caracteres especiales.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }

            // DNI: Asegurarse de que esté entre 8 y 13 caracteres
            string dni = txtDni.Text.Trim();
            if (dni.Length < 8 || dni.Length > 13)
            {
                MessageBox.Show("El DNI debe tener entre 8 y 13 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return false;
            }

            // DNI: Si se seleccionó CUIT, entonces tiene que seguir el formato correcto
            if ((TipoDocumentoEnum)comboTipoDoc.SelectedItem != TipoDocumentoEnum.DNI)
            {
                // Tiene que empezar con dos digitos, seguido de un guion, ocho digitos, un guion y terminar con un digito
                if (!Regex.IsMatch(dni, @"^\d{2}-\d{8}-\d{1}$"))
                {
                    MessageBox.Show("El formato del CUIT/CUIL debe ser XX-XXXXXXXX-X.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDni.Focus();
                    return false;

                }
            }

            // Teléfono: Tiene el formato e.164 o entre 10 y 18 digitos
            string telefono = txtTelefono.Text.Trim();
            if (!string.IsNullOrEmpty(telefono) && !Regex.IsMatch(telefono, @"^\+?[0-9]{10,13}$"))
            {
                MessageBox.Show("El teléfono debe seguir el formato +549... o tener entre 10 y 13 dígitos sin caracteres especiales.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

            // Email: Que sea un email de máximo 200 caracteres
            string email = txtEmail.Text.Trim();
            if (email.Length > 200 || (!string.IsNullOrEmpty(email) && !(new EmailAddressAttribute().IsValid(email))))
            {
                MessageBox.Show("El email debe ser válido, tener como máximo 200 caracteres, o estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Calle: Entre 5 y 45 caracteres, letras y numeros
            string calle = txtCalle.Text.Trim();
            if (calle.Length > 45 || !Regex.IsMatch(calle, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9 ]{5,}$"))
            {
                MessageBox.Show("La calle debe tener hasta 45 caracteres, solo letras y números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCalle.Focus();
                return false;
            }

            // Ciudad: Entre 2 y 45 caracteres, letras y numeros
            string ciudad = txtCiudad.Text.Trim();
            if (ciudad.Length > 45 || !Regex.IsMatch(ciudad, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]{2,}$"))
            {
                MessageBox.Show("La ciudad debe tener hasta 45 letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCiudad.Focus();
                return false;
            }


            return true;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo acepta dígitos, el más y borrar
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir numeros, letras, puntos y guiones en el nombre
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '.' && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir unicamente números y guiones

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void ConfigurarEstilosVisuales()
        {
            this.BackColor = Tema.ColorSuperficie;
            this.lblTituloForm.Text = this.Modo == ModoFormulario.Editar ?
                "Editar proveedor" : "Agregar proveedor";

            this.lblTituloForm.ForeColor = Tema.ColorTextoPrimario;
            this.lblTituloForm.BackColor = Tema.ColorFondo;
            this.btnSalir.BackColor = Tema.ColorFondo;


            this.BackColor = Tema.ColorSuperficie;

            // Cambiar los colores de los labels y el fondo de los inputs
            this.lblNombre.ForeColor = Tema.ColorFondo;
            this.lblApellido.ForeColor = Tema.ColorFondo;
            this.lblEmail.ForeColor = Tema.ColorFondo;
            this.lblTipoDocumento.ForeColor = Tema.ColorFondo;
            this.lblDni.ForeColor = Tema.ColorFondo;
            this.lblCalle.ForeColor = Tema.ColorFondo;
            this.lblCondicionIVA.ForeColor = Tema.ColorFondo;
            this.lblTelefono.ForeColor = Tema.ColorFondo;
            this.lblCiudad.ForeColor = Tema.ColorFondo;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.btnDescartar.PerformClick();
        }

        private void comboTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se tiene que cambiar la longitud máxima cuando cambia el tipo de documento.
            // 8 para DNI, y 13 para CUIT

            switch (comboTipoDoc.SelectedItem?.ToString())
            {
                case "DNI":
                    txtDni.MaxLength = 8;
                    break;
                case "CUIT":
                case "CUIL":
                    txtDni.MaxLength = 13;
                    break;
            }

            // También hay que recortar el texto si es que se pasó de CUIT/CUIL -> DNI
            if (txtDni.Text.Length > txtDni.MaxLength)
                txtDni.Text = txtDni.Text.Substring(0, txtDni.MaxLength);
        }
    }
}
