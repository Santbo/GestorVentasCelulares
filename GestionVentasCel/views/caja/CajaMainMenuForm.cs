using System.ComponentModel;
using System.Data;
using System.Globalization;
using GestionVentasCel.controller.caja;
using GestionVentasCel.controller.categoria;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.enumerations.caja;
using GestionVentasCel.enumerations.modoForms;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.exceptions.caja;
using GestionVentasCel.exceptions.venta;
using GestionVentasCel.models.caja;
using GestionVentasCel.models.ventas;
using GestionVentasCel.service.factura;
using GestionVentasCel.service.usuario;
using GestionVentasCel.service.venta;
using GestionVentasCel.temas;
using GestionVentasCel.views.caja;
using GestionVentasCel.views.categoria;
using GestionVentasCel.views.ventas;
using Microsoft.Extensions.DependencyInjection;

namespace GestionVentasCel.views.usuario_empleado
{


    public partial class CajaMainMenuForm : Form
    {
        private readonly CajaController _cajaController;
        private BindingList<Caja> _cajas;
        private BindingSource _bindingSource;
        private SesionUsuario _usuario;
        public CajaMainMenuForm(CajaController cajaController, SesionUsuario sesionUsuario)
        {
            InitializeComponent();
            _cajaController = cajaController;
            _usuario = sesionUsuario;
            CargarCajas();
            ConfigurarDGV();


        }

        //Se crea un bindingList de cliente y se lo agrega al DGV
        //El BindingList a diferencia del List, actualiza el DGV si hay un cambio en los Objetos
        //Se crea un bindingSource para poder filtrar entre usuarios activos e inactivos
        private void CargarCajas()
        {
            var listarCajas = _cajaController.ListarCajas().ToList();

            _cajas = new BindingList<Caja>(listarCajas);

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _cajas;
            this.dgvListar.ClearSelection();


            AplicarFiltro();

        }

        private void ConfigurarDGV()
        {
            dgvListar.DataSource = _bindingSource;
            this.dgvListar.ClearSelection();

            // Es más facil ocultar todas las columnas y mostrar, que al revés

            foreach (DataGridViewColumn col in dgvListar.Columns)
            {
                col.Visible = false;
            }

            dgvListar.Columns["Usuario"].Visible = true;
            dgvListar.Columns["FechaApertura"].Visible = true;
            dgvListar.Columns["FechaCierre"].Visible = true;
            dgvListar.Columns["Estado"].Visible = true;

            if (dgvListar.Columns["MontoAperturaFormateado"] == null)
            {
                dgvListar.Columns.Add("MontoAperturaFormateado", "Monto De Apertura");
            }
            dgvListar.Columns["MontoAperturaFormateado"].Visible = true;

            if (dgvListar.Columns["MontoCierreFormateado"] == null)
            {
                dgvListar.Columns.Add("MontoCierreFormateado", "Monto De Cierre");
            }
            dgvListar.Columns["MontoCierreFormateado"].Visible = true;



            dgvListar.DataBindingComplete += (s, e) =>
            {

                // Organizar el orden de las columnas despues de que se hayan bindeado todos los datos
                dgvListar.Columns["Usuario"].DisplayIndex = 0;
                dgvListar.Columns["FechaApertura"].DisplayIndex = 1;
                dgvListar.Columns["MontoAperturaFormateado"].DisplayIndex = 2;
                dgvListar.Columns["FechaCierre"].DisplayIndex = 3;
                dgvListar.Columns["MontoCierreFormateado"].DisplayIndex = 4;

                foreach (DataGridViewRow row in dgvListar.Rows)
                {
                    if (row.DataBoundItem is Caja caja)
                    {
                        row.Cells["MontoAperturaFormateado"].Value = caja.MontoApertura.ToString("C2", new CultureInfo("es-AR"));
                        row.Cells["MontoCierreFormateado"].Value = caja.MontoCierre?.ToString("C2", new CultureInfo("es-AR"));
                    }

                }

                this.dgvListar.ClearSelection();
            };


        }

        private void chkMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }


        private void AplicarFiltro()
        {

            // punto de partida: todos los usuarios
            IEnumerable<Caja> filtrados = _cajas;

            // filtro por Activo
            if (!chkMostrarInactivos.Checked)
                filtrados = filtrados.Where(u => u.Estado == enumerations.caja.EstadoCajaEnum.Abierta);


            string filtro = txtBuscar.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filtro))
            {
                filtrados = filtrados.Where(u =>
                    u.FechaApertura.ToString().ToLower().Contains(filtro)
                    || u.FechaCierre.HasValue && u.FechaCierre.ToString().ToLower().Contains(filtro)
                    || u.Usuario.Nombre.ToString().ToLower().Contains(filtro)

                );
            }

            // asignar al BindingSource
            _bindingSource.DataSource = new BindingList<Caja>(filtrados.ToList());
            this.dgvListar.ClearSelection();
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            var usuario = _usuario.Id;

            using (var abrirCaja = new MontoAperturaForm(_cajaController, usuario))
            {
            
                if (abrirCaja.ShowDialog() == DialogResult.OK)
                {

                    MessageBox.Show("Caja abierta correctamente",
                    "Caja Abierta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                    CargarCajas();
                    ConfigurarDGV();
                }
            }
        }

        private void btnRetirarDinero_Click(object sender, EventArgs e)
        {

            if (dgvListar.CurrentRow != null)
            {
                int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;

                if (_cajaController.EstaCerrada(id))
                {
                    MessageBox.Show("Error: La caja se encuentra cerrada",
                       "Caja Cerrada",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning);
                    return;
                }

                using (var retiroCaja = new RetiroCajaForm(_cajaController, id))
                {

                    if (retiroCaja.ShowDialog() == DialogResult.OK)
                    {

                        MessageBox.Show("Se ha registrado el retiro correctamente",
                        "Registro realizado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                        CargarCajas();
                        ConfigurarDGV();
                    }
                }
            }

        }

        private void btnVerMovimientos_Click(object sender, EventArgs e)
        {
            if (dgvListar.CurrentRow != null)
            {
                int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;

                var caja = _cajaController.ObtenerConMovimientos(id);

                if (caja != null && caja.Movimientos.Any())
                {
                    var movimientoForm = new VerMovimientosForm(caja);
                    movimientoForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("La caja seleccionada no posee Movimientos aún",
                        "Caja sin Movimientos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            } else
            {
                MessageBox.Show("Debe seleccionar una caja",
                       "Seleccion",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
            }
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (dgvListar.CurrentRow != null)
            {
                int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;

                try
                {
                    var caja = _cajaController.ObtenerConMovimientos(id);

                    if (caja != null)
                    {
                        decimal totalCierre = 0;

                        foreach (var monto in caja.TotalesPorTipoPago)
                        {
                            if(monto.Key == TipoPagoEnum.Retiro)
                            {
                                totalCierre -= monto.Value;
                            }

                            totalCierre += monto.Value;
                        }
                        totalCierre += caja.MontoApertura;
                        _cajaController.CerrarCaja(caja.Id, totalCierre);
                    }
                } catch(CajaYaCerradaException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                CargarCajas();
                ConfigurarDGV();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
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
            dgvListar.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvListar.GridColor = dgvListar.BackgroundColor;

            // Eliminar divisores entre columnas del header
            dgvListar.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // Cambiar el color de fondo, de la letra y el tamaño de fuente de la fila del header
            dgvListar.EnableHeadersVisualStyles = false;
            dgvListar.ColumnHeadersDefaultCellStyle.BackColor = Tema.ColorFondo;
            dgvListar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvListar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Colorear alternando las filas
            dgvListar.RowsDefaultCellStyle.BackColor = Color.White;
            dgvListar.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Eliminar la columna de seleccion y configurar los modos de seleccion
            dgvListar.RowHeadersVisible = false;
            dgvListar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListar.MultiSelect = false;
            dgvListar.ColumnHeadersDefaultCellStyle.SelectionBackColor = Tema.ColorFondo;
        }

        private void ConfigurarAtajos()
        {
            // Hayq ue setear en true esto para que el formulario atrape los atajos antes que los controles
            // Si no, los atajos se tienen que bindear a cada control específico y solo funcionarían si 
            // tienen focus.
            this.KeyPreview = true;

            this.KeyDown += (s, e) =>
            {
                if (e.Control && e.KeyCode == Keys.N)
                {
                    // Control N para nuevo usuario
                    btnAbrirCaja.PerformClick();
                }

                if (e.Control && e.KeyCode == Keys.U)
                {
                    // Control U para actualizar el usuario
                    btnRetirarDinero.PerformClick();
                }
                if (e.Control && e.KeyCode == Keys.D)
                {
                    // Control D para ver detalles
                    btnVerMovimientos.PerformClick();
                }

                if (e.Control && e.KeyCode == Keys.F)
                {
                    // Control F para buscar usuarios
                    txtBuscar.Focus();
                }
            };
        }

        private void VentaMianMenu_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
            this.ConfigurarAtajos();
        }

        private void dgvListar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListar.CurrentRow != null)
            {

                // Ver si la caja seleccionada está abierta, y mostrar el botón de cerrar caja
                this.btnCerrarCaja.Visible = ((Caja)this.dgvListar.CurrentRow.DataBoundItem).Estado == EstadoCajaEnum.Abierta;
            }
        }
    }
}
