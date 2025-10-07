using System.ComponentModel;
using System.Data;
using System.Globalization;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.compra;
using GestionVentasCel.controller.proveedor;
using GestionVentasCel.models.compra;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.compra
{
    public partial class CompraMainMenuForm : Form
    {
        private readonly CompraController _compraController;
        private readonly ProveedorController _proveedorController;
        private readonly ArticuloController _articuloController;
        private BindingList<Compra> _compras = null!;
        private BindingSource _bindingSource = null!;

        public CompraMainMenuForm(CompraController compraController,
                                 ProveedorController proveedorController,
                                 ArticuloController articuloController)
        {
            InitializeComponent();
            _compraController = compraController;
            _proveedorController = proveedorController;
            _articuloController = articuloController;
            CargarCompras();
        }

        private void CargarCompras()
        {
            try
            {

                var listaCompras = _compraController.ObtenerCompras(true).ToList();
                _compras = new BindingList<Compra>(listaCompras);

                _bindingSource = new BindingSource();
                _bindingSource.DataSource = _compras;


                dgvListar.DataSource = _bindingSource;

                dgvListar.Columns["Id"].Visible = false;
                dgvListar.Columns["ProveedorId"].Visible = false;
                dgvListar.Columns["Detalles"].Visible = false;
                dgvListar.Columns["Total"].Visible = false;

                if (dgvListar.Columns["TotalFormateado"] == null)
                {
                    dgvListar.Columns.Add("TotalFormateado", "Total");
                }

                dgvListar.DataBindingComplete += (s, e) =>
                {
                    dgvListar.Columns["Proveedor"].DisplayIndex = 1;
                    dgvListar.Columns["Fecha"].DisplayIndex = 2;
                    dgvListar.Columns["TotalFormateado"].DisplayIndex = 3;
                    dgvListar.Columns["Observaciones"].DisplayIndex = 4;

                    foreach (DataGridViewRow row in dgvListar.Rows)
                    {
                        if (row.DataBoundItem is Compra compra)
                        {
                            // formatear el precio como moneda
                            row.Cells["TotalFormateado"].Value = compra.Total.ToString("C2", new CultureInfo("es-AR"));
                        }
                        ;


                    }
                    ;


                };

            }


            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar compras: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var formAgregar = new AgregarEditarCompraForm(_compraController, _proveedorController, _articuloController);
                formAgregar.Modo = GestionVentasCel.enumerations.modoForms.ModoFormulario.Agregar;

                if (formAgregar.ShowDialog() == DialogResult.OK)
                {
                    CargarCompras();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario de agregar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListar.CurrentRow != null)
                {
                    int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;
                    var compra = _compraController.GetByIdWithDetails(id);

                    if (compra != null)
                    {
                        var formEditar = new AgregarEditarCompraForm(_compraController, _proveedorController, _articuloController);
                        formEditar.Modo = GestionVentasCel.enumerations.modoForms.ModoFormulario.Editar;
                        formEditar.CompraActual = compra;

                        if (formEditar.ShowDialog() == DialogResult.OK)
                        {
                            CargarCompras();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una compra de la lista.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar compra: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListar.CurrentRow != null)
                {
                    int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;

                    var result = MessageBox.Show(
                        "¿Seguro que desea eliminar esta compra?",
                        "Confirmación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        _compraController.EliminarCompra(id);
                        CargarCompras();
                        MessageBox.Show("Compra eliminada correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una compra de la lista.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar compra: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListar.CurrentRow != null)
                {
                    int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;
                    var compra = _compraController.GetByIdWithDetails(id);

                    if (compra != null)
                    {
                        var formDetalle = new VerDetallesCompraForm(compra, _compraController, _proveedorController, _articuloController);
                        formDetalle.ShowDialog();
                        CargarCompras();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una compra de la lista.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ver detalle: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textoBusqueda = txtBuscar.Text.Trim().ToLower();

                if (string.IsNullOrEmpty(textoBusqueda))
                {
                    _bindingSource.DataSource = _compras;
                    return;
                }

                var comprasFiltradas = _compras.Where(c =>
                    (c.Proveedor != null && c.Proveedor.Nombre.ToLower().Contains(textoBusqueda)) ||
                    (c.Observaciones != null && c.Observaciones.ToLower().Contains(textoBusqueda)) ||
                    c.Fecha.ToString("dd/MM/yyyy").Contains(textoBusqueda) ||
                    c.Total.ToString().Contains(textoBusqueda)
                ).ToList();

                _bindingSource.DataSource = new BindingList<Compra>(comprasFiltradas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dgvListar.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvListar.GridColor = dgvListar.BackgroundColor;

            // Eliminar divisores entre columnas del header
            dgvListar.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // Cambiar el color de fondo, de la letra y el tamaño de fuente de la fila del header
            dgvListar.EnableHeadersVisualStyles = false;
            dgvListar.ColumnHeadersDefaultCellStyle.BackColor = Tema.ColorFondo;
            dgvListar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvListar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Colorear alternando las filas
            dgvListar.RowsDefaultCellStyle.BackColor = Color.White;
            dgvListar.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Eliminar la columna de seleccion y configurar los modos de seleccion
            dgvListar.RowHeadersVisible = false;
            dgvListar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListar.MultiSelect = false;
            dgvListar.ColumnHeadersDefaultCellStyle.SelectionBackColor = Tema.ColorFondo;
        }

        private void ConfigurarAtajos()
        {
            // Hayq ue setear en true esto para que el formulario atrape los atajos antes que los controles
            // Si no, los atajos se tienen que bindear a cada control específico y solo funcionarían si 
            // tienen focus.
            this.KeyPreview = true;

            this.KeyDown += (s, e) =>
            {

                if (e.Control && e.KeyCode == Keys.U)
                {
                    // Control U para actualizar el usuario
                    btnEditar.PerformClick();
                }
                if (e.Control && e.KeyCode == Keys.N)
                {
                    // Control U para actualizar el usuario
                    btnAgregar.PerformClick();
                }

                if (e.Control && e.KeyCode == Keys.D)
                {
                    // Ver detalle
                    btnVerDetalle.PerformClick();
                }

                if (e.KeyCode == Keys.Delete)
                {
                    btnEliminar.PerformClick();
                }


                if (e.Control && e.KeyCode == Keys.F)
                {
                    // Control F para buscar usuarios
                    txtBuscar.Focus();
                }

            };
        }
        private void CompraMainMenuForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
            this.ConfigurarAtajos();
        }
    }
}