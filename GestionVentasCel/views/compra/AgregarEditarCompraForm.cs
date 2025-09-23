using System.ComponentModel;
using System.Globalization;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.compra;
using GestionVentasCel.controller.proveedor;
using GestionVentasCel.enumerations.modoForms;
using GestionVentasCel.exceptions.compra;
using GestionVentasCel.exceptions.configPrecios;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.compra;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.compra
{
    public partial class AgregarEditarCompraForm : Form
    {
        private readonly CompraController _compraController;
        private readonly ProveedorController _proveedorController;
        private readonly ArticuloController _articuloController;
        private IEnumerable<Articulo> articulo { get; set; }

        public ModoFormulario Modo { get; set; }
        public Compra CompraActual { get; set; } = null!;
        private BindingList<DetalleCompra> _listaDetalle = new BindingList<DetalleCompra>();


        public AgregarEditarCompraForm(CompraController compraController,
                                      ProveedorController proveedorController,
                                      ArticuloController articuloController)
        {
            InitializeComponent();
            _compraController = compraController;
            _proveedorController = proveedorController;
            _articuloController = articuloController;

            CargarComboBoxes();
        }

        private void CargarComboBoxes()
        {
            try
            {

                // Cargar proveedores activos
                var proveedores = _proveedorController.ObtenerProveedores()
                    .Where(p => p.Activo)
                    .OrderBy(p => p.Nombre)
                    .ToList();

                cmbProveedor.DataSource = proveedores;
                cmbProveedor.DisplayMember = "Nombre";
                cmbProveedor.ValueMember = "Id";

                // Cargar artículos activos
                articulo = _articuloController.ObtenerArticulos()
                    .Where(a => a.Activo)
                    .OrderBy(a => a.Nombre)
                    .ToList();

                cmbArticulo.DataSource = articulo;
                cmbArticulo.DisplayMember = "Nombre";
                cmbArticulo.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarEditarCompraForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();

            if (Modo == ModoFormulario.Editar && CompraActual != null)
            {
                CargarDatosCompra();
                btnGuardar.Text = "Actualizar";
            }
            else
            {
                btnGuardar.Text = "Guardar";
                dtpFecha.Value = DateTime.Now;

                AgregarDetalles();
            }

        }

        private void CargarDatosCompra()
        {

            //Si se edita, se carga los datos
            dtpFecha.Value = CompraActual.Fecha;
            cmbProveedor.SelectedValue = CompraActual.ProveedorId;
            txtObservaciones.Text = CompraActual.Observaciones ?? "";
            txtTotal.Text = CompraActual.Total.ToString("C2", new CultureInfo("es-AR"));

            // Cargar detalles
            var _detalles = CompraActual.Detalles?.ToList();
            _listaDetalle = new BindingList<DetalleCompra>(_detalles);

            AgregarDetalles();

        }

        private void AgregarDetalles()
        {
            dgvDetalles.DataSource = _listaDetalle;


            dgvDetalles.Columns["Id"].Visible = false;
            dgvDetalles.Columns["CompraId"].Visible = false;
            dgvDetalles.Columns["ArticuloId"].Visible = false;
            dgvDetalles.Columns["Compra"].Visible = false;
            dgvDetalles.Columns["PrecioUnitario"].Visible = false;
            dgvDetalles.Columns["Subtotal"].Visible = false;

            if (dgvDetalles.Columns["PrecioUnitarioFormateado"] == null)
            {
                dgvDetalles.Columns.Add("PrecioUnitarioFormateado", "Precio unitario");
            }

            if (dgvDetalles.Columns["SubtotalFormateado"] == null)
            {
                dgvDetalles.Columns.Add("SubtotalFormateado", "Subtotal");
            }

            dgvDetalles.CellFormatting += (s, e) =>
            {
                dgvDetalles.Columns["Articulo"].DisplayIndex = 1;
                dgvDetalles.Columns["Cantidad"].DisplayIndex = 2;
                dgvDetalles.Columns["PrecioUnitarioFormateado"].DisplayIndex = 3;
                dgvDetalles.Columns["SubtotalFormateado"].DisplayIndex = 4;

                foreach (DataGridViewRow row in dgvDetalles.Rows)
                {
                    if (row.DataBoundItem is DetalleCompra _detalleBinding)
                    {
                        // formatear el precio como moneda
                        row.Cells["PrecioUnitarioFormateado"].Value = _detalleBinding.PrecioUnitario.ToString("C2", new CultureInfo("es-AR"));
                        row.Cells["SubtotalFormateado"].Value = _detalleBinding.Subtotal.ToString("C2", new CultureInfo("es-AR"));
                    }
                    ;


                }
                ;
            };
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (ValidarDetalle())
            {
                // TODO: Si se agrego anteriormente el articulo se actualiza, si no se lo agrega

                var detalleArticulo = _listaDetalle.FirstOrDefault(d => d.ArticuloId == (int)cmbArticulo.SelectedValue);

                if (detalleArticulo != null)
                {
                    detalleArticulo.Cantidad += (int)numCantidad.Value;
                    detalleArticulo.PrecioUnitario = numPrecioUnitario.Value;
                    detalleArticulo.Subtotal = (int)numCantidad.Value * numPrecioUnitario.Value;
                }
                else
                {
                    var detalle = new DetalleCompra
                    {
                        ArticuloId = (int)cmbArticulo.SelectedValue,
                        Articulo = cmbArticulo.SelectedItem as Articulo,
                        Cantidad = (int)numCantidad.Value,
                        PrecioUnitario = numPrecioUnitario.Value,
                        Subtotal = (int)numCantidad.Value * numPrecioUnitario.Value
                    };

                    _listaDetalle.Add(detalle);
                }

                LimpiarCamposDetalle();
                ActualizarTotal();
            }
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow != null)
            {
                int index = dgvDetalles.CurrentRow.Index;
                _listaDetalle.RemoveAt(index);
                ActualizarTotal();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un detalle de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void ActualizarTotal()
        {
            decimal total = _listaDetalle?.Sum(d => d.Subtotal) ?? 0;
            txtTotal.Text = total.ToString("C", new CultureInfo("es-AR"));
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

                foreach (DetalleCompra detalle in _listaDetalle)
                {
                    detalle.Articulo = null;
                }
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
                Total = _listaDetalle.Sum(d => d.Subtotal),
            };

            try
            {

                _compraController.CrearCompraConDetalles(compra, _listaDetalle.ToList());
                MessageBox.Show("Compra creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MargenNoAgregadoException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ActualizarCompra()
        {
            CompraActual.Fecha = dtpFecha.Value;
            CompraActual.ProveedorId = (int)cmbProveedor.SelectedValue;
            CompraActual.Observaciones = txtObservaciones.Text.Trim() != "" ? txtObservaciones.Text.Trim() : null;
            CompraActual.Total = _listaDetalle.Sum(d => d.Subtotal);

            _compraController.ActualizarCompraConDetalles(CompraActual, _listaDetalle.ToList());
            MessageBox.Show("Compra actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidarCompra()
        {
            if (cmbProveedor.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_listaDetalle.Count == 0)
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

        private void ConfigurarEstilosVisuales()
        {
            this.BackColor = Tema.ColorSuperficie;
            this.lblTituloForm.Text = this.Modo == ModoFormulario.Editar ?
                "Editar compra" : "Agregar compra";

            this.lblTituloForm.ForeColor = Tema.ColorTextoPrimario;
            this.lblTituloForm.BackColor = Tema.ColorFondo;
            this.btnSalir.BackColor = Tema.ColorFondo;


            this.BackColor = Tema.ColorSuperficie;

            // Cambiar los colores de los labels y el fondo de los inputs
            this.lblProveedor.ForeColor = Tema.ColorFondo;
            this.lblFecha.ForeColor = Tema.ColorFondo;
            this.lblObservaciones.ForeColor = Tema.ColorFondo;
            this.lblArticulo.ForeColor = Tema.ColorFondo;
            this.lblCantidad.ForeColor = Tema.ColorFondo;
            this.lblPrecioUnitario.ForeColor = Tema.ColorFondo;
            this.lblTotal.ForeColor = Tema.ColorFondo;
            this.txtTotal.BackColor = Tema.ColorSuperficie;
            this.txtTotal.ForeColor = Tema.ColorFondo;

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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.btnDescartar.PerformClick();
        }

    }
}
