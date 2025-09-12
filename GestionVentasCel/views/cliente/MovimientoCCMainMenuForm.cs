using System.ComponentModel;
using System.Data;
using System.Globalization;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.enumerations.cuentaCorriente;
using GestionVentasCel.models.CuentaCorreinte;

namespace GestionVentasCel.views.usuario_empleado
{


    public partial class MovimientosCCMainMenuForm : Form
    {
        private readonly ClienteController _clienteController;
        private BindingList<MovimientoCuentaCorriente> _movimientos;
        private readonly CuentaCorriente _cuentaCorriente;
        private BindingSource _bindingSource;
        public MovimientosCCMainMenuForm(ClienteController clienteController, CuentaCorriente CuentaCorriente)
        {
            InitializeComponent();
            _clienteController = clienteController;
            _cuentaCorriente = CuentaCorriente;

            this.Text = $"Movimientos de CC de: {_cuentaCorriente.Cliente}";
            CargarMovimientos();

        }

        //Se crea un bindingList de cliente y se lo agrega al DGV
        //El BindingList a diferencia del List, actualiza el DGV si hay un cambio en los Objetos
        //Se crea un bindingSource para poder filtrar entre usuarios activos e inactivos
        private void CargarMovimientos()
        {

            _movimientos = new BindingList<MovimientoCuentaCorriente>(_cuentaCorriente.Movimientos.ToList());

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _movimientos;

            AplicarFiltro();
            ConfigurarDGVySaldoTotal();

        }

        public void ConfigurarDGVySaldoTotal()
        {
            // Setear el valor de la cuenta actual. Esto es feo, pero funciona
            lblSaldoActual.Text = $"Saldo actual: {_clienteController
                .ObtenerSaldoCuentaCorriente(_cuentaCorriente)
                .ToString("C2", new CultureInfo("es-AR"))}";

            // Se agregan las columnas de "Saldo", se ocultan "Movimientos",
            // Se agrega la columna "Fecha del ultimo movimiento"
            dgvListarCuentas.DataSource = _bindingSource;
            dgvListarCuentas.Columns["Id"].Visible = false;
            dgvListarCuentas.Columns["CuentaCorrienteId"].Visible = false;
            dgvListarCuentas.Columns["CuentaCorriente"].Visible = false;
            dgvListarCuentas.Columns["Tipo"].Visible = false;
            dgvListarCuentas.Columns["Monto"].Visible = false;



            if (dgvListarCuentas.Columns["MontoFormateado"] == null)
            {
                dgvListarCuentas.Columns.Add("MontoFormateado", "Monto");
            }

            // Organizar las columnas
            dgvListarCuentas.Columns["Fecha"].DisplayIndex = 0;
            dgvListarCuentas.Columns["MontoFormateado"].DisplayIndex = 1;

            // Establecer el formato de la celda del monto, esto no se puede hacer de otra forma
            // porque el dgv espera un decimal. De esta forma, el formato se aplcia automaticamente

            dgvListarCuentas.Columns["MontoFormateado"].DefaultCellStyle.Format = "C2"; // Como moneda con dos decimales
            dgvListarCuentas.Columns["MontoFormateado"].DefaultCellStyle.FormatProvider = new CultureInfo("es-AR"); // Como pesos



            dgvListarCuentas.DataBindingComplete += (s, e) =>
            {
                // Como no se muestra el campo Tipo de movimiento, el campo MontoFormateado debería tener negativo o positivo según
                // corresponda
                foreach (DataGridViewRow row in dgvListarCuentas.Rows)
                {
                    if (row.DataBoundItem is MovimientoCuentaCorriente movimiento)
                    {
                        var monto = movimiento.Tipo == TipoMovimiento.Aumento
                            ? movimiento.Monto
                            : -movimiento.Monto;

                        row.Cells["MontoFormateado"].Value = monto;

                    }
                }
            };

        }

        private void AplicarFiltro()
        {

            // punto de partida: todos los usuarios
            IEnumerable<MovimientoCuentaCorriente> filtrados = _movimientos;

            // filtro por búsqueda
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filtro))
            {
                filtrados = filtrados.Where(u =>
                    u.Fecha.ToString().Contains(filtro)
                );
            }

            // asignar al BindingSource
            _bindingSource.DataSource = new BindingList<MovimientoCuentaCorriente>(filtrados.ToList());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CargarMovimientos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

    }
}
