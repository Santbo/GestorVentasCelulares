using System.Globalization;
using GestionVentasCel.controller.reportes;
using GestionVentasCel.models.reportes;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.reportes
{
    public partial class DetalleVentaForm : Form
    {
        private readonly ReporteVentaController _ventaController;
        private readonly int _ventaId;

        public DetalleVentaForm(ReporteVentaController ventaController, int ventaId)
        {
            InitializeComponent();
            _ventaController = ventaController;
            _ventaId = ventaId;
            ConfigurarFormulario();
            CargarDetalleVenta();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Detalle de Venta";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new Size(800, 600);

            // Aplicar tema
            this.BackColor = Tema.ColorSuperficie;
            this.ForeColor = Tema.ColorTextoPrimario;

            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dgvDetalles.AutoGenerateColumns = false;
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.ReadOnly = true;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.MultiSelect = false;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.RowHeadersVisible = false;
            dgvDetalles.EnableHeadersVisualStyles = false;
            dgvDetalles.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(29, 53, 87);
            dgvDetalles.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDetalles.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvDetalles.ColumnHeadersHeight = 40;
            dgvDetalles.RowTemplate.Height = 35;

            dgvDetalles.Columns.Clear();
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Articulo",
                DataPropertyName = "Articulo",
                HeaderText = "Artículo",
                MinimumWidth = 250,
                FillWeight = 35,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(29, 53, 87),
                    BackColor = Color.White,
                    SelectionBackColor = Color.FromArgb(230, 240, 255),
                    SelectionForeColor = Color.FromArgb(29, 53, 87)
                }
            });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cantidad",
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad",
                MinimumWidth = 100,
                FillWeight = 12,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(29, 53, 87),
                    BackColor = Color.White,
                    SelectionBackColor = Color.FromArgb(230, 240, 255),
                    SelectionForeColor = Color.FromArgb(29, 53, 87)
                }
            });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PrecioUnitario",
                DataPropertyName = "PrecioUnitario",
                HeaderText = "Precio Unitario",
                MinimumWidth = 150,
                FillWeight = 18,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C2",
                    FormatProvider = new CultureInfo("es-AR"),
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(29, 53, 87),
                    BackColor = Color.White,
                    SelectionBackColor = Color.FromArgb(230, 240, 255),
                    SelectionForeColor = Color.FromArgb(29, 53, 87)
                }
            });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SubtotalSinIva",
                DataPropertyName = "SubtotalSinIva",
                HeaderText = "Subtotal sin IVA",
                MinimumWidth = 150,
                FillWeight = 18,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C2",
                    FormatProvider = new CultureInfo("es-AR"),
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(29, 53, 87),
                    BackColor = Color.White,
                    SelectionBackColor = Color.FromArgb(230, 240, 255),
                    SelectionForeColor = Color.FromArgb(29, 53, 87)
                }
            });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PorcentajeIva",
                DataPropertyName = "PorcentajeIva",
                HeaderText = "% IVA",
                MinimumWidth = 100,
                FillWeight = 12,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "P0",
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(29, 53, 87),
                    BackColor = Color.White,
                    SelectionBackColor = Color.FromArgb(230, 240, 255),
                    SelectionForeColor = Color.FromArgb(29, 53, 87)
                }
            });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SubtotalConIva",
                DataPropertyName = "SubtotalConIva",
                HeaderText = "Subtotal con IVA",
                MinimumWidth = 150,
                FillWeight = 18,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C2",
                    FormatProvider = new CultureInfo("es-AR"),
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(29, 53, 87),
                    BackColor = Color.White,
                    SelectionBackColor = Color.FromArgb(230, 240, 255),
                    SelectionForeColor = Color.FromArgb(29, 53, 87)
                }
            });
        }

        private void CargarDetalleVenta()
        {
            try
            {
                // Obtener los detalles de la venta desde la base de datos
                var detalleVenta = _ventaController.ObtenerDetalleVenta(_ventaId);

                if (detalleVenta != null)
                {
                    // Mostrar información general de la venta
                    lblNumeroVentaValor.Text = $"Venta #{detalleVenta.Id}";
                    lblFechaValor.Text = detalleVenta.Fecha.ToString("dd/MM/yyyy HH:mm");
                    lblClienteValor.Text = detalleVenta.Cliente;
                    lblTipoPagoValor.Text = detalleVenta.TipoPagoDescripcion;
                    lblEstadoValor.Text = detalleVenta.EstadoDescripcion;
                    lblNumeroComprobanteValor.Text = detalleVenta.NumeroComprobante;
                    lblTipoComprobanteValor.Text = detalleVenta.TipoComprobante;

                    // Mostrar totales
                    lblSubtotalSinIvaValor.Text = detalleVenta.MontoSinIva.ToString("C2", new CultureInfo("es-AR"));
                    lblTotalIvaValor.Text = detalleVenta.MontoIva.ToString("C2", new CultureInfo("es-AR"));
                    lblTotalGeneralValor.Text = detalleVenta.MontoTotal.ToString("C2", new CultureInfo("es-AR"));

                    // Cargar detalles en el DataGridView
                    dgvDetalles.DataSource = detalleVenta.Detalles;
                }
                else
                {
                    MessageBox.Show("No se pudo cargar el detalle de la venta.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el detalle de la venta: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetalles_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
