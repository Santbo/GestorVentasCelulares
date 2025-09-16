using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.compra;
using GestionVentasCel.controller.proveedor;
using GestionVentasCel.enumerations.modoForms;
using GestionVentasCel.exceptions.compra;
using GestionVentasCel.exceptions.configPrecios;
using GestionVentasCel.models.compra;

namespace GestionVentasCel.views.compra
{
    public partial class AgregarEditarCompraForm : Form
    {
        private readonly CompraController _compraController;
        private readonly ProveedorController _proveedorController;
        private readonly ArticuloController _articuloController;

        public ModoFormulario Modo { get; set; }
        public Compra CompraActual { get; set; } = null!;

        private List<DetalleCompra> _detalles = new List<DetalleCompra>();

        public AgregarEditarCompraForm(CompraController compraController,
                                      ProveedorController proveedorController,
                                      ArticuloController articuloController)
        {
            InitializeComponent();
            _compraController = compraController;
            _proveedorController = proveedorController;
            _articuloController = articuloController;

            CargarComboBoxes();
            ConfigurarValidaciones();
        }

        private void CargarComboBoxes()
        {
            try
            {
                // Validar que los controladores no sean null
                if (_proveedorController == null)
                {
                    MessageBox.Show("Error: Controlador de proveedores no inicializado.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_articuloController == null)
                {
                    MessageBox.Show("Error: Controlador de artículos no inicializado.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cargar proveedores activos
                var proveedores = _proveedorController.ObtenerProveedores()
                    .Where(p => p.Activo)
                    .OrderBy(p => p.Nombre)
                    .ToList();

                cmbProveedor.DataSource = proveedores;
                cmbProveedor.DisplayMember = "Nombre";
                cmbProveedor.ValueMember = "Id";

                // Cargar artículos activos
                var articulos = _articuloController.ObtenerArticulos()
                    .Where(a => a.Activo)
                    .OrderBy(a => a.Nombre)
                    .ToList();

                cmbArticulo.DataSource = articulos;
                cmbArticulo.DisplayMember = "Nombre";
                cmbArticulo.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarValidaciones()
        {
            // Configurar límites de caracteres según los atributos del modelo
            txtObservaciones.MaxLength = 500;

            // Configurar eventos de validación
            txtObservaciones.TextChanged += ValidarLongitudCampo;

            // Configurar validaciones para campos numéricos
            numCantidad.ValueChanged += ValidarCantidad;
            numPrecioUnitario.ValueChanged += ValidarPrecio;
        }

        private void AgregarEditarCompraForm_Load(object sender, EventArgs e)
        {
            if (Modo == ModoFormulario.Editar && CompraActual != null)
            {
                CargarDatosCompra();
                this.Text = "Editar Compra";
                btnGuardar.Text = "Actualizar";
            }
            else
            {
                this.Text = "Agregar Compra";
                btnGuardar.Text = "Guardar";
                dtpFecha.Value = DateTime.Now;
            }
        }

        private void CargarDatosCompra()
        {
            if (CompraActual == null)
            {
                MessageBox.Show("Error: No hay datos de compra para cargar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dtpFecha.Value = CompraActual.Fecha;
            cmbProveedor.SelectedValue = CompraActual.ProveedorId;
            txtObservaciones.Text = CompraActual.Observaciones ?? "";
            txtTotal.Text = CompraActual.Total.ToString("C");

            // Cargar detalles
            _detalles = CompraActual.Detalles?.ToList() ?? new List<DetalleCompra>();
            ActualizarGridDetalles();
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (ValidarDetalle())
            {
                // TODO: Obtener artículo seleccionado cuando se implemente la carga
                var detalle = new DetalleCompra
                {
                    ArticuloId = (int)cmbArticulo.SelectedValue,
                    Cantidad = (int)numCantidad.Value,
                    PrecioUnitario = numPrecioUnitario.Value,
                    Subtotal = (int)numCantidad.Value * numPrecioUnitario.Value
                };

                _detalles.Add(detalle);
                ActualizarGridDetalles();
                LimpiarCamposDetalle();
                ActualizarTotal();
            }
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow != null)
            {
                int index = dgvDetalles.CurrentRow.Index;
                _detalles.RemoveAt(index);
                ActualizarGridDetalles();
                ActualizarTotal();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un detalle de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ActualizarGridDetalles()
        {
            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = _detalles ?? new List<DetalleCompra>();

            if (dgvDetalles.Columns.Count > 0)
            {
                dgvDetalles.Columns["Id"].Visible = false;
                dgvDetalles.Columns["CompraId"].Visible = false;
                dgvDetalles.Columns["ArticuloId"].Visible = false;
                dgvDetalles.Columns["Compra"].Visible = false;
                dgvDetalles.Columns["Articulo"].Visible = true;
            }
        }

        private void ActualizarTotal()
        {
            decimal total = _detalles?.Sum(d => d.Subtotal) ?? 0;
            txtTotal.Text = total.ToString("C");
        }

        private void LimpiarCamposDetalle()
        {
            cmbArticulo.SelectedIndex = -1;
            numCantidad.Value = 1;
            numPrecioUnitario.Value = 0;
        }

        private bool ValidarDetalle()
        {
            if (cmbArticulo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un artículo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numPrecioUnitario.Value <= 0)
            {
                MessageBox.Show("El precio unitario debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCompra())
            {
                try
                {
                    if (Modo == ModoFormulario.Agregar)
                    {
                        CrearCompra();
                    }
                    else
                    {
                        ActualizarCompra();
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (CompraNoEncontradaException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CrearCompra()
        {
            var compra = new Compra
            {
                Fecha = dtpFecha.Value,
                ProveedorId = (int)cmbProveedor.SelectedValue,
                Observaciones = txtObservaciones.Text.Trim() != "" ? txtObservaciones.Text.Trim() : null,
                Total = _detalles.Sum(d => d.Subtotal),
                Activo = true
            };

            try
            {

                _compraController.CrearCompraConDetalles(compra, _detalles);
                MessageBox.Show("Compra creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (MargenNoAgregadoException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ActualizarCompra()
        {
            CompraActual.Fecha = dtpFecha.Value;
            CompraActual.ProveedorId = (int)cmbProveedor.SelectedValue;
            CompraActual.Observaciones = txtObservaciones.Text.Trim() != "" ? txtObservaciones.Text.Trim() : null;
            CompraActual.Total = _detalles.Sum(d => d.Subtotal);

            _compraController.ActualizarCompraConDetalles(CompraActual, _detalles);
            MessageBox.Show("Compra actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidarCompra()
        {
            if (cmbProveedor.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_detalles.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un detalle a la compra.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnDescartar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarEditarCompraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                var result = MessageBox.Show(
                    "¿Seguro que desea descartar los cambios?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        #region Métodos de Validación

        private void ValidarLongitudCampo(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                if (textBox.Text.Length > textBox.MaxLength)
                {
                    textBox.BackColor = Color.LightYellow;
                    MostrarError(textBox, $"Máximo {textBox.MaxLength} caracteres");
                }
                else
                {
                    textBox.BackColor = Color.White;
                    LimpiarError(textBox);
                }
            }
        }

        private void ValidarCantidad(object sender, EventArgs e)
        {
            var numericUpDown = sender as NumericUpDown;
            if (numericUpDown != null)
            {
                if (numericUpDown.Value <= 0)
                {
                    numericUpDown.BackColor = Color.LightPink;
                    MostrarError(numericUpDown, "La cantidad debe ser mayor a 0");
                }
                else
                {
                    numericUpDown.BackColor = Color.White;
                    LimpiarError(numericUpDown);
                }
            }
        }

        private void ValidarPrecio(object sender, EventArgs e)
        {
            var numericUpDown = sender as NumericUpDown;
            if (numericUpDown != null)
            {
                if (numericUpDown.Value <= 0)
                {
                    numericUpDown.BackColor = Color.LightPink;
                    MostrarError(numericUpDown, "El precio debe ser mayor a 0");
                }
                else if (numericUpDown.Value > 999999.99m)
                {
                    numericUpDown.BackColor = Color.LightYellow;
                    MostrarError(numericUpDown, "El precio no puede ser mayor a 999,999.99");
                }
                else
                {
                    numericUpDown.BackColor = Color.White;
                    LimpiarError(numericUpDown);
                }
            }
        }

        private void MostrarError(Control control, string mensaje)
        {
            // Crear o actualizar tooltip de error
            var toolTip = new ToolTip();
            toolTip.IsBalloon = true;
            toolTip.ToolTipIcon = ToolTipIcon.Warning;
            toolTip.Show(mensaje, control, 0, -50, 3000);
        }

        private void LimpiarError(Control control)
        {
            // Limpiar tooltips existentes
            var toolTip = new ToolTip();
            toolTip.Hide(control);
        }

        #endregion
    }
}
