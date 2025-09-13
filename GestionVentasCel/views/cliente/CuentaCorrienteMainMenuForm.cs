using System.ComponentModel;
using System.Data;
using System.Globalization;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.exceptions.cliente;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.CuentaCorreinte;

namespace GestionVentasCel.views.usuario_empleado
{


    public partial class CuentaCorrienteMainMenuForm : Form
    {
        private readonly ClienteController _clienteController;
        private BindingList<CuentaCorriente> _cuentas;
        private readonly IServiceProvider _serviceProvider;
        private BindingSource _bindingSource;
        public CuentaCorrienteMainMenuForm(ClienteController clienteController, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _clienteController = clienteController;
            _serviceProvider = serviceProvider;
            CargarCuentas();

        }

        //Se crea un bindingList de cliente y se lo agrega al DGV
        //El BindingList a diferencia del List, actualiza el DGV si hay un cambio en los Objetos
        //Se crea un bindingSource para poder filtrar entre usuarios activos e inactivos
        private void CargarCuentas()
        {
            var listaClientes = _clienteController.ObtenerCuentasCorrientes().ToList();

            _cuentas = new BindingList<CuentaCorriente>(listaClientes);

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _cuentas;

            AplicarFiltro();
            ConfigurarDGV();

        }

        public void ConfigurarDGV()
        {
            // Se agregan las columnas de "Saldo", se ocultan "Movimientos",
            // Se agrega la columna "Fecha del ultimo movimiento"
            dgvListarCuentas.DataSource = _bindingSource;
            dgvListarCuentas.Columns["Id"].Visible = false;
            dgvListarCuentas.Columns["ClienteId"].Visible = false;
            dgvListarCuentas.Columns["Movimientos"].Visible = false;

            // Añadir las dos columnas extra si no existen ya
            if (dgvListarCuentas.Columns["Saldo"] == null)
            {
                dgvListarCuentas.Columns.Add(
                    "Saldo", "Saldo actual"
                );
            }

            if (dgvListarCuentas.Columns["FechaUltimo"] == null)
            {
                dgvListarCuentas.Columns.Add(
                    "FechaUltimo", "Último movimiento"
                );

            }
            // y organizarlas
            dgvListarCuentas.Columns["Cliente"].DisplayIndex = 0;
            dgvListarCuentas.Columns["Saldo"].DisplayIndex = 1;
            dgvListarCuentas.Columns["FechaUltimo"].DisplayIndex = 2;
            dgvListarCuentas.Columns["Activo"].DisplayIndex = 3;


            dgvListarCuentas.DataBindingComplete += (s, e) =>
            {
                foreach (DataGridViewRow row in dgvListarCuentas.Rows)
                {
                    if (row.DataBoundItem is CuentaCorriente cuenta)
                    {
                        var saldo = _clienteController.ObtenerSaldoCuentaCorriente(cuenta);
                        var ultimoMovimiento = _clienteController.ObtenerFechaUltimoMovimiento(cuenta);

                        row.Cells["Saldo"].Value = saldo != 0 ?
                            $"{saldo.ToString("C", new CultureInfo("es-AR"))}" : "No hay movimientos";

                        row.Cells["FechaUltimo"].Value = ultimoMovimiento != null ?
                            ultimoMovimiento : "No hay movimientos";
                    }
                }
            };

        }

        private void chkMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnToggleActivo_Click(object sender, EventArgs e)
        {

            if (dgvListarCuentas.CurrentRow != null)
            {
                int id = (int)dgvListarCuentas.CurrentRow.Cells["Id"].Value;

                var result = MessageBox.Show(
                    "¿Seguro que desea Habilitar/Deshabilitar esta cuenta corriente?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No) return;

                try
                {

                    // Actualizo en la BD
                    _clienteController.ToggleActivoCuentaCorriente(id);

                    CargarCuentas();
                    ConfigurarDGV();
                    AplicarFiltro();
                }
                catch (ClienteInexistenteException ex)
                {

                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        private void AplicarFiltro()
        {

            // punto de partida: todos los usuarios
            IEnumerable<CuentaCorriente> filtrados = _cuentas;

            // filtro por Activo
            if (!chkMostrarInactivos.Checked)
                filtrados = filtrados.Where(u => u.Activo);

            // filtro por búsqueda
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filtro))
            {
                filtrados = filtrados.Where(u =>
                    u.Cliente.Nombre.ToLower().Contains(filtro)
                );
            }

            // asignar al BindingSource
            _bindingSource.DataSource = new BindingList<CuentaCorriente>(filtrados.ToList());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿El cliente ya existe en el sistema?", "Agregar una nueva cuenta corriente",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.Cancel)
            {
                return;
            }

            // Crear un cliente nulo que va a ser utilizado despues para crear la cuenta
            // Ese cliente puede venir de dos lugares:
            //      Si existe ya el cliente, el form SeleccionarClienteForm lo va a seleccionar
            //      Si no existe ya el cliente, el form AgregarEditarClienteForm lo va a crear y se va a setear el cliente creado en ese cliente nulo
            Cliente? cliente = null;

            if (resultado == DialogResult.Yes)
            {
                // El cliente ya existe, por lo cual se abre un formulario para seleccionar, que solo muestra aquellos
                // clientes que no tienen una cuenta corriente asociada.

                using (var form = new SeleccionarClienteForm(clienteController: _clienteController))
                {
                    if (form.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        // Si se lo seleccionó correctamente, asignarlo al cliente nulo que se creó arriba
                        cliente = form.ClienteSeleccionado;
                    }
                }


            }
            else if (resultado == DialogResult.No)
            {

                // El cliente no existe, por lo que hay que abrir el formulario en modo de creación
                // Una vez creado, se asigna el cliente al cliente nulo que se tenía arriba

                using (var form = new AgregarEditarClienteForm(clienteController: _clienteController))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        cliente = form.ClienteCreado;

                    }
                    else
                    {
                        return;
                    }

                }
            }

            // Sea cual sea el camino que se tomó, ahora se tiene un cliente listo para ser usado para crear una cuenta.
            _clienteController.CrearCuentaCorriente(cliente!);
            MessageBox.Show("La cuenta corriente se agregó correctamente", "Cuenta agregada");
            CargarCuentas();
            ConfigurarDGV();
            AplicarFiltro();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnVerMovimientos_Click(object sender, EventArgs e)
        {
            if (dgvListarCuentas.CurrentRow != null)
            {
                CuentaCorriente cuenta = dgvListarCuentas.CurrentRow.DataBoundItem as CuentaCorriente;

                using (var form = new MovimientosCCMainMenuForm(_clienteController, CuentaCorriente: cuenta!))
                {
                    form.FormClosed += (s, e) =>
                    {
                        // Cuando se cierre la vista de movimientos hay que actualizar las cuentas
                        // por si cambió el valor del saldo
                        CargarCuentas();
                        ConfigurarDGV();
                        AplicarFiltro();
                    };
                    form.ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar una cuenta corriente para ver sus movimientos", "No seleccionó cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
