using System.ComponentModel;
using System.Globalization;
using GestionVentasCel.models.ventas;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.ventas
{
    public partial class VerDetalleVentaForm : Form
    {
        public Venta _venta;
        private BindingSource _bindingSource;
        public VerDetalleVentaForm(
            Venta venta
        )
        {
            InitializeComponent();
            _venta = venta;

            // Siempre hay que guardar qué usuario autorizó la venta o la edición

            this.ConfigurarBindings();
            this.ConfigurarDGVDetalles();
            this.ConfigurarEstilosVisuales();

        }

        private void CargarDataSourceDGV()
        {
            _bindingSource.DataSource = new BindingList<DetalleVenta>(_venta.Detalles.ToList()); ;

            dgvListarDetalles.DataSource = _bindingSource;
        }

        private void ConfigurarDGVDetalles()
        {
            CargarDataSourceDGV();

            // Agregar todas las columnas formateadas
            if (dgvListarDetalles.Columns["Detalle"] == null)
            {
                dgvListarDetalles.Columns.Add("Detalle", "Detalle");
            }

            if (dgvListarDetalles.Columns["PrecioUnitarioFormateado"] == null)
            {
                dgvListarDetalles.Columns.Add("PrecioUnitarioFormateado", "Precio unitario");
            }

            if (dgvListarDetalles.Columns["SubtotalSinIVAFormateado"] == null)
            {
                dgvListarDetalles.Columns.Add("SubtotalSinIVAFormateado", "Subtotal sin IVA");
            }

            if (dgvListarDetalles.Columns["PorcentajeIVAFormateado"] == null)
            {
                dgvListarDetalles.Columns.Add("PorcentajeIVAFormateado", "Porcentaje IVA");
            }

            if (dgvListarDetalles.Columns["SubtotalConIVAFormateado"] == null)
            {
                dgvListarDetalles.Columns.Add("SubtotalConIVAFormateado", "Subtotal con IVA");
            }

            foreach (DataGridViewColumn col in dgvListarDetalles.Columns)
            {
                // tiene tantas columnas el modelo que es más facil ocultarlas todas
                // y despues mostrar las que se necesitan nomas
                col.Visible = false;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dgvListarDetalles.Columns["Detalle"].Visible = true;
            dgvListarDetalles.Columns["Detalle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvListarDetalles.Columns["Cantidad"].Visible = true;
            dgvListarDetalles.Columns["PrecioUnitarioFormateado"].Visible = true;
            dgvListarDetalles.Columns["SubtotalSinIVAFormateado"].Visible = true;
            dgvListarDetalles.Columns["PorcentajeIVAFormateado"].Visible = true;
            dgvListarDetalles.Columns["SubtotalConIVAFormateado"].Visible = true;


            dgvListarDetalles.DataBindingComplete += (s, e) =>
            {
                // Una vez que se termine de bindear, hay que ordernar las columnas y formatearlas
                dgvListarDetalles.Columns["Detalle"].DisplayIndex = 0;
                dgvListarDetalles.Columns["Cantidad"].DisplayIndex = 1;
                dgvListarDetalles.Columns["PrecioUnitarioFormateado"].DisplayIndex = 2;
                dgvListarDetalles.Columns["SubtotalSinIVAFormateado"].DisplayIndex = 3;
                dgvListarDetalles.Columns["PorcentajeIVAFormateado"].DisplayIndex = 4;
                dgvListarDetalles.Columns["SubtotalConIvaFormateado"].DisplayIndex = 5;

                foreach (DataGridViewRow row in dgvListarDetalles.Rows)
                {
                    if (row.DataBoundItem is DetalleVenta detalle)
                    {
                        row.Cells["Detalle"].Value = detalle.EsArticulo ?
                            detalle.Articulo!.Nombre.ToString() : detalle.Reparacion!.Detalle;

                        row.Cells["PrecioUnitarioFormateado"].Value = detalle.PrecioUnitario.ToString("C2", new CultureInfo("es-AR"));
                        row.Cells["SubtotalSinIVAFormateado"].Value = detalle.SubtotalSinIva.ToString("C2", new CultureInfo("es-AR"));
                        row.Cells["PorcentajeIVAFormateado"].Value = detalle.PorcentajeIva.ToString("P2");
                        row.Cells["SubtotalConIVAFormateado"].Value = detalle.SubtotalConIva.ToString("C2", new CultureInfo("es-AR"));
                    }
                }
            };

        }

        public void ConfigurarBindings()
        {
            // Inicializar BindingSource
            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _venta;

            lblValorCliente.Text = _venta.Cliente.DniNombre.ToString();
            lblValorTipoPago.Text = _venta.TipoPago.ToString();
            lblValorFecha.Text = _venta.FechaVenta.ToString();

            this.lblSubtotalSinIVA.Text = $"Subtotal sin IVA: {_venta.TotalSinIva.ToString("C2", new CultureInfo("es-AR"))}";
            this.lblTotalIVA.Text = $"IVA total: {_venta.IVATotal.ToString("C2", new CultureInfo("es-AR"))}";
            this.lblTotal.Text = $"Total: {_venta.TotalConIva.ToString("C2", new CultureInfo("es-AR"))}";

        }


        private void ConfigurarEstilosVisuales()
        {
            this.BackColor = Tema.ColorSuperficie;
            this.lblTituloForm.Text = "Detalles de la venta";

            this.lblTituloForm.ForeColor = Tema.ColorTextoPrimario;
            this.lblTituloForm.BackColor = Tema.ColorFondo;
            this.btnSalir.BackColor = Tema.ColorFondo;

            this.BackColor = Tema.ColorSuperficie;

            // Configuración del DGV. Esto se puede hacer en el diseñador, pero acá queda mas visible el código

            // Eliminar divisores entre columnas y filas
            dgvListarDetalles.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvListarDetalles.GridColor = dgvListarDetalles.BackgroundColor;

            // Eliminar divisores entre columnas del header
            dgvListarDetalles.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // Cambiar el color de fondo, de la letra y el tamaño de fuente de la fila del header
            dgvListarDetalles.EnableHeadersVisualStyles = false;
            dgvListarDetalles.ColumnHeadersDefaultCellStyle.BackColor = Tema.ColorFondo;
            dgvListarDetalles.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvListarDetalles.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Colorear alternando las filas
            dgvListarDetalles.RowsDefaultCellStyle.BackColor = Color.White;
            dgvListarDetalles.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Eliminar la columna de seleccion y configurar los modos de seleccion
            dgvListarDetalles.RowHeadersVisible = false;
            dgvListarDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListarDetalles.MultiSelect = false;
            dgvListarDetalles.ColumnHeadersDefaultCellStyle.SelectionBackColor = Tema.ColorFondo;


        }

        private void AgregarEditarVentaForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
