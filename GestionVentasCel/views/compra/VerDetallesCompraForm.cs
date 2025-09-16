using System.Globalization;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.compra;
using GestionVentasCel.controller.proveedor;
using GestionVentasCel.models.compra;

namespace GestionVentasCel.views.compra
{
    public partial class VerDetallesCompraForm : Form
    {
        private readonly Compra _compra;
        private readonly CompraController _compraController;
        private readonly ProveedorController _proveedorController;
        private readonly ArticuloController _articuloController;

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
            this.Text = $"Detalles de Compra - {_compra.Fecha:dd/MM/yyyy}";

            lblProveedor.Text = _compra.Proveedor?.Nombre ?? "N/A";
            lblFecha.Text = _compra.Fecha.ToString("dd/MM/yyyy HH:mm");
            lblTotal.Text = _compra.Total.ToString("C2", new CultureInfo("es-AR"));
            lblObservaciones.Text = _compra.Observaciones ?? "Sin observaciones";

            dgvDetalles.AutoGenerateColumns = false;
            // Cargar detalles en el grid
            dgvDetalles.DataSource = _compra.Detalles.ToList();

            
            // Configurar columnas para mostrar información relevante
            ConfigurarColumnasDetalle();

            // Mostrar botón de editar solo si se pasaron los controladores
            btnEditar.Visible = _compraController != null && _proveedorController != null && _articuloController != null;
        }

        private void ConfigurarColumnasDetalle()
        {
            try
            {
                // Limpiar columnas existentes
                dgvDetalles.Columns.Clear();

                // Crear columna de ID (oculta)
                var columnaId = new DataGridViewTextBoxColumn
                {
                    Name = "Id",
                    HeaderText = "ID",
                    DataPropertyName = "Id",
                    Width = 50,
                    Visible = false
                };
                dgvDetalles.Columns.Add(columnaId);

                // Crear columna de Producto (nombre del artículo)
                var columnaProducto = new DataGridViewTextBoxColumn
                {
                    Name = "NombreProducto",
                    HeaderText = "Producto",
                    Width = 200
                };
                dgvDetalles.Columns.Add(columnaProducto);

                // Crear columna de Cantidad
                var columnaCantidad = new DataGridViewTextBoxColumn
                {
                    Name = "Cantidad",
                    HeaderText = "Cantidad",
                    DataPropertyName = "Cantidad",
                    Width = 80
                };
                dgvDetalles.Columns.Add(columnaCantidad);

                // Crear columna de Precio Unitario
                var columnaPrecioUnitario = new DataGridViewTextBoxColumn
                {
                    Name = "PrecioUnitario",
                    HeaderText = "Precio Unitario",
                    DataPropertyName = "PrecioUnitario",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", FormatProvider = new CultureInfo("es-AR") }
                };
                dgvDetalles.Columns.Add(columnaPrecioUnitario);

                // Crear columna de Subtotal
                var columnaSubtotal = new DataGridViewTextBoxColumn
                {
                    Name = "Subtotal",
                    HeaderText = "Subtotal",
                    DataPropertyName = "Subtotal",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", FormatProvider = new CultureInfo("es-AR") }
                };
                dgvDetalles.Columns.Add(columnaSubtotal);

                // Configurar evento para llenar el nombre del producto
                dgvDetalles.CellFormatting += DgvDetalles_CellFormatting;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar columnas del detalle: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvDetalles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvDetalles.Columns["NombreProducto"].Index && e.RowIndex >= 0)
                {
                    var detalle = dgvDetalles.Rows[e.RowIndex].DataBoundItem as DetalleCompra;
                    if (detalle != null && detalle.Articulo != null)
                    {
                        e.Value = detalle.Articulo.Nombre;
                        e.FormattingApplied = true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Si hay error, mostrar mensaje genérico
                e.Value = "Error al cargar";
                e.FormattingApplied = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_compraController != null && _proveedorController != null && _articuloController != null)
            {
                var compraCompleta = _compraController.GetByIdWithDetails(_compra.Id);
                if (compraCompleta != null)
                {
                    var formEditar = new AgregarEditarCompraForm(_compraController, _proveedorController, _articuloController);
                    formEditar.Modo = GestionVentasCel.enumerations.modoForms.ModoFormulario.Editar;
                    formEditar.CompraActual = compraCompleta;

                    if (formEditar.ShowDialog() == DialogResult.OK)
                    {
                        // Recargar los datos de la compra
                        var compraActualizada = _compraController.GetByIdWithDetails(_compra.Id);
                        if (compraActualizada != null)
                        {
                            _compra.Fecha = compraActualizada.Fecha;
                            _compra.Total = compraActualizada.Total;
                            _compra.Observaciones = compraActualizada.Observaciones;
                            _compra.Proveedor = compraActualizada.Proveedor;
                            _compra.Detalles = compraActualizada.Detalles;
                            CargarDatos();
                        }
                    }
                }
            }
        }
    }
}
