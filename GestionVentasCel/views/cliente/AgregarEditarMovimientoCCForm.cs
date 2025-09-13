using GestionVentasCel.controller.cliente;
using GestionVentasCel.enumerations.cuentaCorriente;
using GestionVentasCel.enumerations.persona;
using GestionVentasCel.exceptions.cliente;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.CuentaCorreinte;
using GestionVentasCel.models.persona;

namespace GestionVentasCel.views.usuario_empleado
{
    public partial class AgregarEditarMovimientoCCForm : Form
    {
        private readonly ClienteController _clienteController;
        private readonly bool _editando;

        private CuentaCorriente _cuenta { get; set; }
        private MovimientoCuentaCorriente _movimiento { get; set; }

        private BindingSource _movimientoBinding;
        public AgregarEditarMovimientoCCForm(
            ClienteController clienteController,
            CuentaCorriente cuentaCorriente,
            MovimientoCuentaCorriente? movimiento = null
        )
        {
            InitializeComponent();
            _clienteController = clienteController;
            _cuenta = cuentaCorriente;
            _editando = movimiento != null;

            _movimiento = _editando ? movimiento : new MovimientoCuentaCorriente {  CuentaCorriente = _cuenta };
            
            CrearBindings();

        }

        private void CrearBindings()
        {
            // Inicializar BindingSource
            _movimientoBinding = new BindingSource();
            _movimientoBinding.DataSource = _movimiento;

            // Monto
            nMonto.DataBindings.Add("Value", _movimientoBinding, "Monto", true);

            // Fecha
            dtpFecha.DataBindings.Add("Value", _movimientoBinding, "Fecha", true);

            if (!_editando)
            {
                // Setear por defecto a Now, porque si no, al guardar un movimiento, el valor queda vacío
                dtpFecha.Value = DateTime.Now;
                _movimiento.Fecha = dtpFecha.Value;
            }

            // Descripcion
            txtDescripcion.DataBindings.Add("Text", _movimientoBinding, "Descripcion", true);

            // ComboBoxes con enums
            comboTipoMov.DataSource = Enum.GetValues(typeof(TipoMovimiento));
            comboTipoMov.DataBindings.Add("SelectedItem", _movimientoBinding, "Tipo", true);
            comboTipoMov.SelectedItem = TipoMovimiento.Aumento;

        }

        private void AgregarEditarMovimientoCCForm_FormClosing(object sender, FormClosingEventArgs e)
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
                        _clienteController.ActualizarMovimientoCuentaCorriente(movimiento: _movimiento);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        _clienteController.RegistrarMovimientoCuentaCorriente(movimiento: _movimiento);
                        this.DialogResult = DialogResult.OK;
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

            // Validar si el monto es mayor a 1000000 


            //if (string.IsNullOrWhiteSpace(txtNombre.Text))
            //{
            //    MessageBox.Show("El Nombre es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtNombre.Focus();
            //    return false;
            //}

            //if (string.IsNullOrWhiteSpace(txtDni.Text))
            //{
            //    MessageBox.Show("El Número de documento es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtDni.Focus();
            //    return false;
            //}

            //if (!txtDni.Text.All(char.IsDigit))
            //{
            //    MessageBox.Show("El Número de documento solo puede contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtDni.Focus();
            //    return false;
            //}

            //if (comboTipoMov.SelectedItem == null)
            //{
            //    MessageBox.Show("Debe seleccionar un Tipo de Documento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    comboTipoMov.Focus();
            //    return false;
            //}

            //if (comboIVA.SelectedItem == null)
            //{
            //    MessageBox.Show("Debe seleccionar una Condición IVA.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    comboIVA.Focus();
            //    return false;
            //}

            //if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            //{
            //    MessageBox.Show("El Teléfono es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtTelefono.Focus();
            //    return false;
            //}

            //if (string.IsNullOrWhiteSpace(txtCalle.Text))
            //{
            //    MessageBox.Show("La Calle es obligatoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtCalle.Focus();
            //    return false;
            //}

            //if (string.IsNullOrWhiteSpace(txtCiudad.Text))
            //{
            //    MessageBox.Show("La Ciudad es obligatoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtCiudad.Focus();
            //    return false;
            //}


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
