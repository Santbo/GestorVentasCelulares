using System.ComponentModel;
using System.Data;
using System.Globalization;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.enumerations.cuentaCorriente;
using GestionVentasCel.models.CuentaCorreinte;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.usuario_empleado
{


    public partial class MovimientosCCMainMenuForm : Form
    {
        private readonly ClienteController _clienteController;
        private BindingList<MovimientoCuentaCorriente> _movimientos;
        private CuentaCorriente _cuentaCorriente;
        private BindingSource _bindingSource;
        public MovimientosCCMainMenuForm(ClienteController clienteController, CuentaCorriente CuentaCorriente)
        {
            InitializeComponent();
            _clienteController = clienteController;
            _cuentaCorriente = CuentaCorriente;

            this.lblTituloForm.Text = $"Movimientos de {_cuentaCorriente.Cliente}";
            CargarMovimientos();

        }

        //Se crea un bindingList de cliente y se lo agrega al DGV
        //El BindingList a diferencia del List, actualiza el DGV si hay un cambio en los Objetos
        //Se crea un bindingSource para poder filtrar entre usuarios activos e inactivos
        private void CargarMovimientos()
        {
            _movimientos = new BindingList<MovimientoCuentaCorriente>(_cuentaCorriente.Movimientos
                .OrderByDescending(m => m.Fecha)
                .ToList()
            );

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
            dgvListarMovimientos.DataSource = _bindingSource;
            dgvListarMovimientos.Columns["Id"].Visible = false;
            dgvListarMovimientos.Columns["CuentaCorrienteId"].Visible = false;
            dgvListarMovimientos.Columns["CuentaCorriente"].Visible = false;
            dgvListarMovimientos.Columns["Tipo"].Visible = false;
            dgvListarMovimientos.Columns["Monto"].Visible = false;



            if (dgvListarMovimientos.Columns["MontoFormateado"] == null)
            {
                dgvListarMovimientos.Columns.Add("MontoFormateado", "Monto");
            }

            // Organizar las columnas
            dgvListarMovimientos.Columns["Fecha"].DisplayIndex = 0;
            dgvListarMovimientos.Columns["MontoFormateado"].DisplayIndex = 1;

            // Establecer el formato de la celda del monto, esto no se puede hacer de otra forma
            // porque el dgv espera un decimal. De esta forma, el formato se aplcia automaticamente

            dgvListarMovimientos.Columns["MontoFormateado"].DefaultCellStyle.Format = "C2"; // Como moneda con dos decimales
            dgvListarMovimientos.Columns["MontoFormateado"].DefaultCellStyle.FormatProvider = new CultureInfo("es-AR"); // Como pesos



            dgvListarMovimientos.DataBindingComplete += (s, e) =>
            {
                // Como no se muestra el campo Tipo de movimiento, el campo MontoFormateado debería tener negativo o positivo según
                // corresponda
                foreach (DataGridViewRow row in dgvListarMovimientos.Rows)
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
            using (var form = new AgregarEditarMovimientoCCForm(_clienteController, _cuentaCorriente))
            {
                form.ShowDialog();
                CargarMovimientos();
            }
        }



        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MovimientoCuentaCorriente movimiento;

            if (dgvListarMovimientos.CurrentRow != null)
            {
                movimiento = (MovimientoCuentaCorriente)dgvListarMovimientos.CurrentRow.DataBoundItem;

            }
            else
            {
                MessageBox.Show("Debe seleccionar un movimiento para editar", "Seleccione un movimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var form = new AgregarEditarMovimientoCCForm(_clienteController, _cuentaCorriente, movimiento: movimiento))
            {
                form.ShowDialog();
                CargarMovimientos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MovimientoCuentaCorriente movimiento;

            if (dgvListarMovimientos.CurrentRow != null)
            {
                movimiento = (MovimientoCuentaCorriente)dgvListarMovimientos.CurrentRow.DataBoundItem;

                var dialogResult = MessageBox.Show("¿Está seguro que quiere eliminar el movimiento? Esta acción es irreversible", "Eliminando un movimiento", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                if (dialogResult == DialogResult.Yes)
                {
                    _clienteController.EliminarMovimientoCC(movimiento);
                    CargarMovimientos();

                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar un movimiento para borrar", "Seleccione un movimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ConfigurarEstilosVisuales()
        {
            this.panelHeader.BackColor = Tema.ColorSuperficie;
            this.splitContainer1.BackColor = Tema.ColorSuperficie;
            this.panelBtn.BackColor = Tema.ColorSuperficie;


            this.lblTituloForm.ForeColor = Tema.ColorTextoSecundario;

            this.splitContainer1.Panel2.BackColor = Tema.ColorSuperficie;

            // Configuración del DGV. Esto se puede hacer en el diseñador, pero acá queda mas visible el código

            // Eliminar divisores entre columnas y filas
            dgvListarMovimientos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvListarMovimientos.GridColor = dgvListarMovimientos.BackgroundColor;

            // Eliminar divisores entre columnas del header
            dgvListarMovimientos.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // Cambiar el color de fondo, de la letra y el tamaño de fuente de la fila del header
            dgvListarMovimientos.EnableHeadersVisualStyles = false;
            dgvListarMovimientos.ColumnHeadersDefaultCellStyle.BackColor = Tema.ColorFondo;
            dgvListarMovimientos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvListarMovimientos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Colorear alternando las filas
            dgvListarMovimientos.RowsDefaultCellStyle.BackColor = Color.White;
            dgvListarMovimientos.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Eliminar la columna de seleccion y configurar los modos de seleccion
            dgvListarMovimientos.RowHeadersVisible = false;
            dgvListarMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListarMovimientos.MultiSelect = false;
            dgvListarMovimientos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Tema.ColorFondo;
        }

        private void ConfigurarAtajos()
        {
            // Hayq ue setear en true esto para que el formulario atrape los atajos antes que los controles
            // Si no, los atajos se tienen que bindear a cada control específico y solo funcionarían si 
            // tienen focus.
            this.KeyPreview = true;

            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Delete)
                {
                    btnEliminar.PerformClick();
                }

                if (e.Control && e.KeyCode == Keys.N)
                {
                    // Control N para nuevo usuario
                    btnAgregar.PerformClick();
                }

                if (e.Control && e.KeyCode == Keys.U)
                {
                    // Control U para actualizar el usuario
                    btnEditar.PerformClick();
                }

                if (e.Control && e.KeyCode == Keys.F)
                {
                    // Control F para buscar usuarios
                    txtBuscar.Focus();
                }
            };
        }

        private void MovimientoCCMainMenuForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
            this.ConfigurarAtajos();
        }

        private void dgvListarMovimientos_SelectionChanged(object sender, EventArgs e)
        {
            // No hay que permitir eliminar/editar movimientos que hayan sido generados por una venta
            if (dgvListarMovimientos.CurrentRow == null)
                return;

            if (dgvListarMovimientos.CurrentRow.DataBoundItem is MovimientoCuentaCorriente movimiento)
            {
                bool generadoPorVenta = movimiento.VentaId != null;

                btnEliminar.Enabled = !generadoPorVenta;
                btnEditar.Enabled = !generadoPorVenta;
            }
        }
    }
}
