using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.enumerations.persona;
using GestionVentasCel.exceptions.cliente;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.persona;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.usuario_empleado
{
    public partial class AgregarEditarClienteForm : Form
    {
        private readonly ClienteController _clienteController;
        private readonly bool _editando;

        public Cliente ClienteCreado { get; private set; }

        public Cliente _cliente { get; set; }
        private BindingSource _clienteBinding;
        public AgregarEditarClienteForm(ClienteController clienteController, Cliente? cliente = null, Persona? persona = null)
        {
            InitializeComponent();
            _clienteController = clienteController;
            _editando = cliente != null;

            // Si se recibió una persona, es porque se tienen que usar esos datos para crear el nuevo cliente
            // Si no, entonces es crear un cliente nuevo, o usar el que pasaron.
            if (persona != null)
            {
                _cliente = _editando
                    ? cliente!
                    : new Cliente
                    {
                        Nombre = persona.Nombre,
                        Apellido = persona.Apellido,
                        TipoDocumento = persona.TipoDocumento,
                        Dni = persona.Dni,
                        Telefono = persona.Telefono,
                        Email = persona.Email,
                        Calle = persona.Calle,
                        Ciudad = persona.Ciudad,
                        Activo = true
                    };
            }
            else
            {
                _cliente = _editando ? cliente! : new Cliente();
            }

            CrearBindings();

        }

        private void CrearBindings()
        {
            // Inicializar BindingSource
            _clienteBinding = new BindingSource();
            _clienteBinding.DataSource = _cliente;

            // TextBoxes
            txtNombre.DataBindings.Add("Text", _clienteBinding, "Nombre", true);
            txtApellido.DataBindings.Add("Text", _clienteBinding, "Apellido", true);
            txtDni.DataBindings.Add("Text", _clienteBinding, "Dni", true);
            txtEmail.DataBindings.Add("Text", _clienteBinding, "Email", true);
            txtTelefono.DataBindings.Add("Text", _clienteBinding, "Telefono", true);
            txtCalle.DataBindings.Add("Text", _clienteBinding, "Calle", true);
            txtCiudad.DataBindings.Add("Text", _clienteBinding, "Ciudad", true);

            // ComboBoxes con enums

            // Setear el item inicial y el tipo DNI a mano, porque si no se la toma como null aunque
            // visualmente esté una seleccionada
            comboTipoDoc.DataSource = Enum.GetValues(typeof(TipoDocumentoEnum));
            comboTipoDoc.SelectedItem = TipoDocumentoEnum.DNI;
            _cliente.TipoDocumento = (TipoDocumentoEnum)comboTipoDoc.SelectedItem;
            comboTipoDoc.DataBindings.Add("SelectedItem", _clienteBinding, "TipoDocumento", true);

            // Setear el item inicial y la condición a mano, porque si no se la toma como null aunque
            // visualmente esté una seleccionada
            comboIVA.DataSource = Enum.GetValues(typeof(CondicionIVAEnum));
            comboIVA.SelectedItem = CondicionIVAEnum.ConsumidorFinal;

            _cliente.CondicionIVA = (CondicionIVAEnum)comboIVA.SelectedItem;
            comboIVA.DataBindings.Add("SelectedItem", _clienteBinding, "CondicionIVA", true);
        }

        private void AgregarEditarEmpleadoForm_FormClosing(object sender, FormClosingEventArgs e)
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
                try
                {
                    if (_editando)
                    {
                        _clienteController.ActualizarCliente(_cliente);
                        this.DialogResult = DialogResult.OK;
                        // Setear el cliente creado, porque el formulario para agregar cuenta corriente necesita su Id
                        this.ClienteCreado = _cliente;
                        this.Close();
                    }
                    else
                    {
                        _clienteController.CrearCliente(_cliente);
                        this.DialogResult = DialogResult.OK;
                        // Setear el cliente creado, porque el formulario para agregar cuenta corriente necesita su Id
                        this.ClienteCreado = _cliente;
                        this.Close();
                    }

                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Error de campos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                catch (ClienteInexistenteException ex)
                {
                    MessageBox.Show("Error de base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                catch (DNIDuplicadoException)
                {
                    MessageBox.Show(
                        "El número de documento ya está cargado en el sistema.",
                        "Número de documento duplicado.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }
            }

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
            if (apellido.Length > 45 || !Regex.IsMatch(apellido, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9 ]*$"))
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
            if (!Regex.IsMatch(telefono, @"^\+?[0-9]{10,13}$"))
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
            if (calle.Length > 45 || !Regex.IsMatch(calle, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9\. ]{5,}$"))
            {
                MessageBox.Show("La calle debe tener hasta 45 caracteres, solo letras y números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCalle.Focus();
                return false;
            }

            // Ciudad: Entre 2 y 45 caracteres, letras y numeros
            string ciudad = txtCiudad.Text.Trim();
            if (ciudad.Length > 45 || !Regex.IsMatch(ciudad, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]{2,}$"))
            {
                MessageBox.Show("La ciudad debe estar vacía o tener hasta 45 letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            this.lblTituloForm.Text = this._editando ?
                "Editar cliente" : "Agregar cliente";

            this.lblTituloForm.ForeColor = Tema.ColorTextoPrimario;
            this.lblTituloForm.BackColor = Tema.ColorFondo;
            this.btnSalir.BackColor = Tema.ColorFondo;


            this.BackColor = Tema.ColorSuperficie;

            // Cambiar los colores de los labels y el fondo de los inputs
            this.lblNombre.ForeColor = Tema.ColorFondo;
            this.lblApellido.ForeColor = Tema.ColorFondo;
            this.lblEmail.ForeColor = Tema.ColorFondo;
            this.lblTipoDni.ForeColor = Tema.ColorFondo;
            this.lblDni.ForeColor = Tema.ColorFondo;
            this.lblCalle.ForeColor = Tema.ColorFondo;
            this.lblCondicionIva.ForeColor = Tema.ColorFondo;
            this.lblTelefono.ForeColor = Tema.ColorFondo;
            this.lblCiudad.ForeColor = Tema.ColorFondo;


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.btnDescartar.PerformClick();
        }

        private void AgregarEditarClienteForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
        }
    }
}
