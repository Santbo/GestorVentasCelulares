using System.Globalization;
using GestionVentasCel.controller.reportes;
using GestionVentasCel.models.reportes;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.reportes
{
    public partial class DetalleCompraForm : Form
    {
        private readonly ReporteCompraController _compraController;
        private readonly int _compraId;

        public DetalleCompraForm(ReporteCompraController compraController, int compraId)
        {
            InitializeComponent();
            _compraController = compraController;
            _compraId = compraId;
            ConfigurarFormulario();
            CargarDetalleCompra();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Detalle de Compra";
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
                DataPropertyName = "ArticuloNombre",
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
                Name = "Subtotal",
                DataPropertyName = "Subtotal",
                HeaderText = "Subtotal",
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

        private void CargarDetalleCompra()
        {
            try
            {
                // Obtener los detalles de la compra desde la base de datos
                var detalleCompra = _compraController.ObtenerDetalleCompra(_compraId);

                if (detalleCompra != null)
                {
                    // Mostrar información general de la compra
                    lblNumeroCompraValor.Text = $"Compra #{detalleCompra.Id}";
                    lblFechaValor.Text = detalleCompra.Fecha.ToString("dd/MM/yyyy HH:mm");
                    lblProveedorValor.Text = detalleCompra.Proveedor;
                    lblNumeroComprobanteValor.Text = detalleCompra.NumeroComprobante;
                    lblCondicionIvaValor.Text = detalleCompra.CondicionIVAProveedor;
                    lblObservacionesValor.Text = detalleCompra.Observaciones ?? "Sin observaciones";

                    // Mostrar total
                    lblTotalGeneralValor.Text = detalleCompra.MontoTotal.ToString("C2", new CultureInfo("es-AR"));

                    // Cargar detalles en el DataGridView
                    dgvDetalles.DataSource = detalleCompra.Detalles;
                }
                else
                {
                    MessageBox.Show("No se pudo cargar el detalle de la compra.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el detalle de la compra: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
