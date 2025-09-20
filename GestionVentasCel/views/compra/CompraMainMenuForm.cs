using System.ComponentModel;
using System.Data;
using System.Globalization;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.compra;
using GestionVentasCel.controller.proveedor;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.compra;

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

                var listaCompras = _compraController.ObtenerCompras().ToList();
                _compras = new BindingList<Compra>(listaCompras);

                _bindingSource = new BindingSource();
                _bindingSource.DataSource = _compras;


                dgvListarCompras.DataSource = _bindingSource;

                dgvListarCompras.Columns["Id"].Visible = false;
                dgvListarCompras.Columns["ProveedorId"].Visible = false;
                dgvListarCompras.Columns["Detalles"].Visible = false;
                dgvListarCompras.Columns["Total"].Visible = false;

                if (dgvListarCompras.Columns["TotalFormateado"] == null)
                {
                    dgvListarCompras.Columns.Add("TotalFormateado", "Total");
                }

                dgvListarCompras.DataBindingComplete += (s, e) =>
                {
                    dgvListarCompras.Columns["Proveedor"].DisplayIndex = 1;
                    dgvListarCompras.Columns["Fecha"].DisplayIndex = 2;
                    dgvListarCompras.Columns["TotalFormateado"].DisplayIndex = 3;
                    dgvListarCompras.Columns["Observaciones"].DisplayIndex = 4;

                    foreach (DataGridViewRow row in dgvListarCompras.Rows)
                    {
                        if (row.DataBoundItem is Compra compra)
                        {
                            // formatear el precio como moneda
                            row.Cells["TotalFormateado"].Value = compra.Total.ToString("C2", new CultureInfo("es-AR"));
                        };
                        

                    };
                    

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
                if (dgvListarCompras.CurrentRow != null)
                {
                    int id = (int)dgvListarCompras.CurrentRow.Cells["Id"].Value;
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
                if (dgvListarCompras.CurrentRow != null)
                {
                    int id = (int)dgvListarCompras.CurrentRow.Cells["Id"].Value;

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
                if (dgvListarCompras.CurrentRow != null)
                {
                    int id = (int)dgvListarCompras.CurrentRow.Cells["Id"].Value;
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

    }
}