using System.ComponentModel;
using System.Globalization;
using GestionVentasCel.controller.servicio;
using GestionVentasCel.models.reparacion;
using GestionVentasCel.models.servicio;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.compra
{
    public partial class VerDetallesReparacionForm : Form
    {
        private Reparacion _reparacion;
        private readonly ServicioController _servicioController;
        private List<Servicio> _listaServicio = new List<Servicio>();
        private BindingList<Servicio> _detalleServicio = new BindingList<Servicio>();


        public VerDetallesReparacionForm(ServicioController servicioController, Reparacion reparacion)
        {
            InitializeComponent();
            _servicioController = servicioController;
            _reparacion = reparacion;
            CargarDatos();
        }


        private void CargarDatos()
        {
            lblCliente.Text = $"Cliente: {_reparacion.Dispositivo.Cliente}";
            lblFechaIngreso.Text = $"Fecha Ingreso: {_reparacion.FechaIngreso.ToString("dd/MM/yyyy HH:mm")}";
            lblFechaEgreso.Text = $"Fecha Egreso: {_reparacion.FechaEgreso?.ToString("dd/MM/yyyy HH:mm")}";
            lblFallasReportadas.Text = $"Fallas Reportadas: {_reparacion.FallasReportadas}";
            lblDispositivo.Text = $"Dispositivo: {_reparacion.Dispositivo}";
            lblDiagnostico.Text = $"Diagnostico: {_reparacion.Diagnostico}";
            lblTotal.Text = $"Total: {_reparacion.Total.ToString("C2", new CultureInfo("es-AR"))}";


            var _listaReparacion = _reparacion.ReparacionServicios.ToList();

            foreach (var reparacion in _listaReparacion)
            {
                _listaServicio.Add(_servicioController.GetById(reparacion.ServicioId));
            }



            _detalleServicio = new BindingList<Servicio>(_listaServicio);

            dgvDetalles.DataSource = _detalleServicio;
            dgvDetalles.Columns["Id"].Visible = false;
            dgvDetalles.Columns["Precio"].Visible = false;
            dgvDetalles.Columns["Activo"].Visible = false;
            dgvDetalles.Columns["ArticulosUsados"].Visible = false;
            dgvDetalles.Columns["DetalleServicio"].Visible = false;

            dgvDetalles.Columns["Nombre"].DisplayIndex = 1;
            dgvDetalles.Columns["Descripcion"].DisplayIndex = 2;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigurarEstilosVisuales()
        {
            this.BackColor = Tema.ColorSuperficie;


            this.lblTituloForm.ForeColor = Tema.ColorTextoPrimario;
            this.lblTituloForm.BackColor = Tema.ColorFondo;
            this.btnSalir.BackColor = Tema.ColorFondo;


            this.BackColor = Tema.ColorSuperficie;

            // Cambiar los colores de los labels y el fondo de los inputs
            this.lblCliente.ForeColor = Tema.ColorFondo;
            this.lblFechaIngreso.ForeColor = Tema.ColorFondo;
            this.lblFechaEgreso.ForeColor = Tema.ColorFondo;
            this.lblTotal.ForeColor = Tema.ColorFondo;

            // Configuración del DGV. Esto se puede hacer en el diseñador, pero acá queda mas visible el código

            // Eliminar divisores entre columnas y filas
            dgvDetalles.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvDetalles.GridColor = dgvDetalles.BackgroundColor;

            // Eliminar divisores entre columnas del header
            dgvDetalles.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // Cambiar el color de fondo, de la letra y el tamaño de fuente de la fila del header
            dgvDetalles.EnableHeadersVisualStyles = false;
            dgvDetalles.ColumnHeadersDefaultCellStyle.BackColor = Tema.ColorFondo;
            dgvDetalles.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDetalles.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Colorear alternando las filas
            dgvDetalles.RowsDefaultCellStyle.BackColor = Color.White;
            dgvDetalles.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Eliminar la columna de seleccion y configurar los modos de seleccion
            dgvDetalles.RowHeadersVisible = false;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.MultiSelect = false;
            dgvDetalles.ColumnHeadersDefaultCellStyle.SelectionBackColor = Tema.ColorFondo;



        }

        private void VerDetallesCompraForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.btnCerrar.PerformClick();
        }
    }
}
