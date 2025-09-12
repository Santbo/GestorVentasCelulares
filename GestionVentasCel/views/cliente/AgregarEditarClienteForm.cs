using GestionVentasCel.controller.cliente;
using GestionVentasCel.enumerations.persona;
using GestionVentasCel.exceptions.cliente;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.persona;

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
                        Id = persona.Id,
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
            comboTipoDoc.SelectedItem = TipoDocumentoEnum.DNI;
            comboTipoDoc.DataSource = Enum.GetValues(typeof(TipoDocumentoEnum));
            comboTipoDoc.DataBindings.Add("SelectedItem", _clienteBinding, "TipoDocumento", true);

            comboIVA.SelectedItem = CondicionIVAEnum.ConsumidorFinal;
            comboIVA.DataSource = Enum.GetValues(typeof(CondicionIVAEnum));
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
            }

        }

        private bool CamposValidos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El Nombre es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("El Número de documento es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return false;
            }

            if (!txtDni.Text.All(char.IsDigit))
            {
                MessageBox.Show("El Número de documento solo puede contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return false;
            }

            if (comboTipoDoc.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un Tipo de Documento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboTipoDoc.Focus();
                return false;
            }

            if (comboIVA.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una Condición IVA.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboIVA.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("El Teléfono es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCalle.Text))
            {
                MessageBox.Show("La Calle es obligatoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCalle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCiudad.Text))
            {
                MessageBox.Show("La Ciudad es obligatoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCiudad.Focus();
                return false;
            }


            return true;



        }

        private void AgregarEditarEmpleadoForm_Load(object sender, EventArgs e)
        {
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo acepta dígitos y la tecla backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
