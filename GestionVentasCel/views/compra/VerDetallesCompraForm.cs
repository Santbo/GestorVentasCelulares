using System.ComponentModel;
using System.Globalization;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.compra;
using GestionVentasCel.controller.proveedor;
using GestionVentasCel.enumerations.modoForms;
using GestionVentasCel.models.categoria;
using GestionVentasCel.models.compra;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.compra
{
    public partial class VerDetallesCompraForm : Form
    {
        private readonly Compra _compra;
        private readonly CompraController _compraController;
        private readonly ProveedorController _proveedorController;
        private readonly ArticuloController _articuloController;
        private BindingList<DetalleCompra> _detalleCompra;

        public VerDetallesCompraForm(Compra compra)
        {
            InitializeComponent();
            _compra = compra;
            CargarDatos();
        }

        public VerDetallesCompraForm(Compra compra,
                                   CompraController compraController,
                                   ProveedorController proveedorController,
                                   ArticuloController articuloController)
        {
            InitializeComponent();
            _compra = compra;
            _compraController = compraController;
            _proveedorController = proveedorController;
            _articuloController = articuloController;
            CargarDatos();
        }

        private void CargarDatos()
        {
            lblProveedor.Text += _compra.Proveedor.Nombre;
            lblFecha.Text += _compra.Fecha.ToString("dd/MM/yyyy HH:mm");
            lblTotal.Text += _compra.Total.ToString("C2", new CultureInfo("es-AR"));
            lblObservaciones.Text += _compra.Observaciones ?? "Sin observaciones";


            var _listaDetalle = _compra.Detalles.ToList();

            _detalleCompra = new BindingList<DetalleCompra>(_listaDetalle);

            dgvDetalles.DataSource = _detalleCompra;
            dgvDetalles.Columns["Id"].Visible = false;
            dgvDetalles.Columns["Compra"].Visible = false;
            dgvDetalles.Columns["CompraId"].Visible = false;
            dgvDetalles.Columns["ArticuloId"].Visible = false;
            dgvDetalles.Columns["PrecioUnitario"].Visible = false;
            dgvDetalles.Columns["Subtotal"].Visible = false;

            if (dgvDetalles.Columns["PrecioUnitarioFormateado"] == null)
            {
                dgvDetalles.Columns.Add("PrecioUnitarioFormateado", "PrecioUnitario");
            }

            if (dgvDetalles.Columns["SubtotalFormateado"] == null)
            {
                dgvDetalles.Columns.Add("SubtotalFormateado", "Subtotal");
            }

            dgvDetalles.DataBindingComplete += (s, e) =>
            {
                dgvDetalles.Columns["Articulo"].DisplayIndex = 1;
                dgvDetalles.Columns["Cantidad"].DisplayIndex = 2;
                dgvDetalles.Columns["PrecioUnitarioFormateado"].DisplayIndex = 3;
                dgvDetalles.Columns["SubtotalFormateado"].DisplayIndex = 4;

                foreach (DataGridViewRow row in dgvDetalles.Rows)
                {
                    if (row.DataBoundItem is DetalleCompra detalle)
                    {
                        // formatear el precio como moneda
                        row.Cells["PrecioUnitarioFormateado"].Value = detalle.PrecioUnitario.ToString("C2", new CultureInfo("es-AR"));
                        row.Cells["SubtotalFormateado"].Value = detalle.Subtotal.ToString("C2", new CultureInfo("es-AR"));
                    }
                    ;


                }
                ;


            };


        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            var compraCompleta = _compraController.GetByIdWithDetails(_compra.Id);
            if (compraCompleta != null)
            {
                var formEditar = new AgregarEditarCompraForm(_compraController, _proveedorController, _articuloController);
                formEditar.Modo = GestionVentasCel.enumerations.modoForms.ModoFormulario.Editar;
                formEditar.CompraActual = compraCompleta;

                if (formEditar.ShowDialog() == DialogResult.OK)
                {
                    CargarDatos();
                }
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
            this.lblProveedor.ForeColor = Tema.ColorFondo;
            this.lblFecha.ForeColor = Tema.ColorFondo;
            this.lblObservaciones.ForeColor = Tema.ColorFondo;
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
