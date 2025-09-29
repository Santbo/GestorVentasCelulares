using System.ComponentModel;
using System.Globalization;
using GestionVentasCel.controller.servicio;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.servicio;
using GestionVentasCel.temas;
using GestionVentasCel.views.servicio;

namespace GestionVentasCel.views.compra
{
    public partial class VerArticulosAsociadosForm : Form
    {
        private readonly ServicioController _servicioController;
        private BindingList<ServicioArticulo> _listaArticulosAgregados = new BindingList<ServicioArticulo>();
        private Servicio _servicio;
        private List<Articulo> _listaArticulos;

        public VerArticulosAsociadosForm(ServicioController servicioController, Servicio servicio, List<Articulo> listaArticulo)
        {
            InitializeComponent();
            _servicioController = servicioController;
            _servicio = servicio;
            _listaArticulos = listaArticulo;
            CargarDatos();
        }

        private void CargarDatos()
        {

            lblServicio.Text = $"Servicio: {_servicio.Nombre}";
            lblPrecio.Text = $"Precio Mano de Obra: {_servicio.Precio.ToString("C2", new CultureInfo("es-AR"))}";
            lblDescripcion.Text = $"Descripcion: {_servicio.Descripcion}";


            var listaArticulosUsados = _servicio.ArticulosUsados.ToList();
            foreach (var servicioArticulo in listaArticulosUsados)
            {
                var articulo = _listaArticulos.FirstOrDefault(a => a.Id == servicioArticulo.ArticuloId);
                servicioArticulo.Detalle = articulo.Detalle;
            }

            _listaArticulosAgregados = new BindingList<ServicioArticulo>(listaArticulosUsados);

            dgvDetalles.DataSource = _listaArticulosAgregados;
            dgvDetalles.Columns["Id"].Visible = false;
            dgvDetalles.Columns["ServicioId"].Visible = false;
            dgvDetalles.Columns["Servicio"].Visible = false;
            dgvDetalles.Columns["ArticuloId"].Visible = false;
            dgvDetalles.Columns["Articulo"].Visible = false;


        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {


            var formEditar = new AgregarEditarServicioForm(_servicioController, _listaArticulos);
            formEditar.ServicioActual = _servicio;

            if (formEditar.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("El Servicio se actualizó correctamente",
                            "Servicio Guardado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                CargarDatos();
            }


        }

        private void ConfigurarEstilosVisuales()
        {
            this.BackColor = Tema.ColorSuperficie;


            this.lblTituloForm.ForeColor = Tema.ColorTextoPrimario;
            this.lblTituloForm.BackColor = Tema.ColorFondo;
            this.btnSalir.BackColor = Tema.ColorFondo;


            this.BackColor = Tema.ColorSuperficie;

            // Cambiar los colores de los labels y el fondo de los inputs
            this.lblServicio.ForeColor = Tema.ColorFondo;
            this.lblPrecio.ForeColor = Tema.ColorFondo;
            this.lblDescripcion.ForeColor = Tema.ColorFondo;

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
