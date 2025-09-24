using System.ComponentModel;
using System.Data;
using System.Globalization;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.controller.reparaciones;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.reparacion;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.usuario_empleado
{
    /// <summary>
    /// Permite mostrar una lista de artículos
    /// </summary>
    public partial class SeleccionarReparacionForm : Form
    {
        private readonly ReparacionController _reparacionController;
        private BindingList<Reparacion> _reparaciones;
        public Reparacion? _reparacionSeleccionada;
        private BindingSource _bindingSource;
        private int _idCliente;

        public SeleccionarReparacionForm(ReparacionController reparacionController, int idCliente)
        {
            InitializeComponent();
            _reparacionController = reparacionController;
            _idCliente = idCliente;
            CargarReparaciones();
        }

        //Se crea un bindingList de cliente y se lo agrega al DGV
        //El BindingList a diferencia del List, actualiza el DGV si hay un cambio en los Objetos
        //Se crea un bindingSource para poder filtrar entre usuarios activos e inactivos
        private void CargarReparaciones()
        {
            var listaReparaciones = _reparacionController.ListarReparacionesTerminadasCliente(_idCliente).ToList();

            _reparaciones = new BindingList<Reparacion>(listaReparaciones);

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _reparaciones;

            AplicarFiltro();

            dgvListarReparaciones.DataSource = _bindingSource;

            dgvListarReparaciones.DataBindingComplete += (s, e) =>
            {

                if (dgvListarReparaciones.Columns["TotalFormateado"] == null)
                {
                    dgvListarReparaciones.Columns.Add("TotalFormateado", "Total");
                }
                if (dgvListarReparaciones.Columns["Cliente"] == null)
                {
                    dgvListarReparaciones.Columns.Add("Cliente", "Cliente");
                }
                // Ocultar Id y Articulos
                dgvListarReparaciones.Columns["Id"].Visible = false;
                dgvListarReparaciones.Columns["DispositivoId"].Visible = false;
                dgvListarReparaciones.Columns["Cliente"].Visible = false;
                dgvListarReparaciones.Columns["Estado"].Visible = false;
                dgvListarReparaciones.Columns["Activo"].Visible = false;
                dgvListarReparaciones.Columns["Detalle"].Visible = false;
                dgvListarReparaciones.Columns["ReparacionServicios"].Visible = false;
                dgvListarReparaciones.Columns["Total"].Visible = false;
                dgvListarReparaciones.Columns["Detalle"].Visible = false;


                // Ordenarlas 
                dgvListarReparaciones.Columns["Dispositivo"].DisplayIndex = 1;
                dgvListarReparaciones.Columns["Dispositivo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvListarReparaciones.Columns["FallasReportadas"].DisplayIndex = 3;

                dgvListarReparaciones.Columns["Diagnostico"].DisplayIndex = 4;
                dgvListarReparaciones.Columns["FechaIngreso"].DisplayIndex = 5;
                dgvListarReparaciones.Columns["FechaEgreso"].DisplayIndex = 6;
                dgvListarReparaciones.Columns["TotalFormateado"].DisplayIndex = 7;

                foreach (DataGridViewRow row in dgvListarReparaciones.Rows)
                {
                    if (row.DataBoundItem is Reparacion reparacion)
                    {
                        // formatear el precio como moneda
                        row.Cells["TotalFormateado"].Value = reparacion.Total.ToString("C2", new CultureInfo("es-AR"));
                        row.Cells["Cliente"].Value = reparacion.Dispositivo.Cliente.ToString();
                    }

                    ;
                }
                ;

            };
        }

        private void AplicarFiltro()
        {

            // punto de partida: todos los usuarios
            IEnumerable<Reparacion> filtrados = _reparaciones;

            // filtro por búsqueda
            // filtro por búsqueda
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filtro))
            {
                filtrados = filtrados.Where(r =>
                                r.FechaIngreso.ToString().ToLower().Contains(filtro) ||
                                r.Dispositivo.Nombre.ToLower().Contains(filtro)
                            );
            }

            // asignar al BindingSource
            _bindingSource.DataSource = new BindingList<Reparacion>(filtrados.ToList());
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SeleccionarPersonaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                var result = MessageBox.Show(
                    "¿Estás seguro que querés salir sin seleccionar una reparación? Esto cancelará la creación del detalle.",
                    "Confirmar salida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvListarReparaciones.CurrentRow != null)
            {
                int id = (int)dgvListarReparaciones.CurrentRow.Cells["Id"].Value;

                var reparacion = _reparacionController.ObtenerPorId(id);
                if (reparacion == null)
                {
                    MessageBox.Show("El artículo no fue encontrado",
                        "Cliente no encontrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                _reparacionSeleccionada = reparacion;

                this.DialogResult = DialogResult.OK;
                this.Close();
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
            dgvListarReparaciones.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvListarReparaciones.GridColor = dgvListarReparaciones.BackgroundColor;

            // Eliminar divisores entre columnas del header
            dgvListarReparaciones.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // Cambiar el color de fondo, de la letra y el tamaño de fuente de la fila del header
            dgvListarReparaciones.EnableHeadersVisualStyles = false;
            dgvListarReparaciones.ColumnHeadersDefaultCellStyle.BackColor = Tema.ColorFondo;
            dgvListarReparaciones.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvListarReparaciones.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Colorear alternando las filas
            dgvListarReparaciones.RowsDefaultCellStyle.BackColor = Color.White;
            dgvListarReparaciones.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Eliminar la columna de seleccion y configurar los modos de seleccion
            dgvListarReparaciones.RowHeadersVisible = false;
            dgvListarReparaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListarReparaciones.MultiSelect = false;
            dgvListarReparaciones.ColumnHeadersDefaultCellStyle.SelectionBackColor = Tema.ColorFondo;
        }


        private void ConfigurarAtajos()
        {
            // Hayq ue setear en true esto para que el formulario atrape los atajos antes que los controles
            // Si no, los atajos se tienen que bindear a cada control específico y solo funcionarían si 
            // tienen focus.
            this.KeyPreview = true;

            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.btnSeleccionar.PerformClick();
                }

                if (e.Control && e.KeyCode == Keys.F)
                {
                    this.txtBuscar.Focus();
                }
            };
        }
        private void SeleccionarClienteForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
            this.ConfigurarAtajos();

        }
    }
}
