using GestionVentasCel.controller.cliente;
using GestionVentasCel.enumerations.cuentaCorriente;
using GestionVentasCel.exceptions.cliente;
using GestionVentasCel.models.CuentaCorreinte;

namespace GestionVentasCel.views.usuario_empleado
{
    public partial class AgregarEditarMovimientoCCForm : Form
    {
        private readonly ClienteController _clienteController;
        private readonly bool _editando;

        private CuentaCorriente _cuenta { get; set; }
        private MovimientoCuentaCorriente _movimientoEditable { get; set; }
        private MovimientoCuentaCorriente _movimientoOriginal { get; set; }

        private BindingSource _movimientoBinding;
        public AgregarEditarMovimientoCCForm(
            ClienteController clienteController,
            CuentaCorriente cuentaCorriente,
            MovimientoCuentaCorriente? movimiento = null
        )
        {
            InitializeComponent();

            this.CancelButton = btnDescartar;


            _clienteController = clienteController;
            _cuenta = cuentaCorriente;
            _editando = movimiento != null;

            _movimientoOriginal = _editando ? movimiento : new MovimientoCuentaCorriente { CuentaCorriente = _cuenta };

            // Usado para descartar cambios
            _movimientoEditable = new MovimientoCuentaCorriente
            {
                Id = _movimientoOriginal.Id,
                CuentaCorrienteId = _movimientoOriginal.CuentaCorrienteId,
                CuentaCorriente = _movimientoOriginal.CuentaCorriente,
                Fecha = _movimientoOriginal.Fecha,
                Monto = _movimientoOriginal.Monto,
                Tipo = _movimientoOriginal.Tipo,
                Descripcion = _movimientoOriginal.Descripcion
            };

            CrearBindings();

        }

        private void CrearBindings()
        {
            // Inicializar BindingSource
            _movimientoBinding = new BindingSource();
            _movimientoBinding.DataSource = _movimientoEditable;

            // Monto
            nMonto.DataBindings.Add("Value", _movimientoBinding, "Monto", true);

            // Fecha
            dtpFecha.DataBindings.Add("Value", _movimientoBinding, "Fecha", true);

            if (!_editando)
            {
                // Setear por defecto a Now, porque si no, al guardar un movimiento, el valor queda vacío
                dtpFecha.Value = DateTime.Now;
                _movimientoEditable.Fecha = dtpFecha.Value;
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (CamposValidos())
            {
                // Antes había un bug que, debido a que se hacian bindings directo sobre el modelo
                // entonces cualquier cambio se propagaba por todo el modelo de CuentaCorriente e incluso el de 
                // cliente.El tener un modelo original y uno editable asegura que solamente se cambien
                // los datos si se presiona guardar, porque antes se cambiaban incluso si se ponía descartar.
                _movimientoOriginal.Fecha = _movimientoEditable.Fecha;
                _movimientoOriginal.Monto = _movimientoEditable.Monto;
                _movimientoOriginal.Tipo = _movimientoEditable.Tipo;
                _movimientoOriginal.Descripcion = _movimientoEditable.Descripcion;

                try
                {
                    if (_editando)
                    {
                        _clienteController.ActualizarMovimientoCuentaCorriente(movimiento: _movimientoOriginal);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        _clienteController.RegistrarMovimientoCuentaCorriente(movimiento: _movimientoOriginal);
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

            // Fecha: Entre el 1 de enero del 2000 y mañana. No se por qué se usarían valores distintos a estos
            DateTime fecha = dtpFecha.Value;
            if (fecha < new DateTime(2000, 1, 1) || fecha > DateTime.Today.AddDays(1))
            {
                MessageBox.Show("La fecha debe estar entre el 01/01/2000 y mañana.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFecha.Focus();
                return false;
            }

            // Monto: > 0 y < 10,000,000
            decimal monto = nMonto.Value;
            if (monto <= 0 || monto >= 10000000)
            {
                MessageBox.Show("El monto debe ser mayor que 0 y menor que 10.000.000.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nMonto.Focus();
                return false;
            }

            // Descripción: max 255 caracteres
            string descripcion = txtDescripcion.Text;
            if (descripcion.Length > 255)
            {
                MessageBox.Show("La descripción no puede tener más de 255 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            return true;


        }
    }
}
