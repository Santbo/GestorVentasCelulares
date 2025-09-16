using System.ComponentModel;
using System.Data;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.compra;
using GestionVentasCel.controller.proveedor;
using GestionVentasCel.models.compra;
using GestionVentasCel.models.proveedor;
using GestionVentasCel.views.compra;

namespace GestionVentasCel.views.proveedor
{
    public partial class ComprasProveedorForm : Form
    {
        private readonly CompraController _compraController;
        private readonly ProveedorController _proveedorController;
        private readonly ArticuloController _articuloController;
        private readonly Proveedor _proveedor;
        private BindingList<Compra> _compras = null!;
        private BindingSource _bindingSource = null!;

        public ComprasProveedorForm(CompraController compraController,
                                   ProveedorController proveedorController,
                                   ArticuloController articuloController,
                                   Proveedor proveedor)
        {
            InitializeComponent();
            _compraController = compraController;
            _proveedorController = proveedorController;
            _articuloController = articuloController;
            _proveedor = proveedor;

            this.Text = $"Compras de {_proveedor.Nombre}";
            CargarCompras();
        }

        private void CargarCompras()
        {
            try
            {
                // Verificar que el controlador esté disponible
                if (_compraController == null)
                {
                    MessageBox.Show("Error: Controlador de compras no está inicializado.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar que el proveedor esté disponible
                if (_proveedor == null)
                {
                    MessageBox.Show("Error: Proveedor no está inicializado.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var listaCompras = _compraController.GetByProveedor(_proveedor.Id).ToList();
                _compras = new BindingList<Compra>(listaCompras);

                _bindingSource = new BindingSource();
                _bindingSource.DataSource = _compras;

                // Configurar DataGridView con generación automática deshabilitada
                dgvCompras.AutoGenerateColumns = false;
                ConfigurarColumnas();
                dgvCompras.DataSource = _bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar compras: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            try
            {
                // Limpiar columnas existentes
                dgvCompras.Columns.Clear();

                // Crear columna de ID (oculta)
                var columnaId = new DataGridViewTextBoxColumn
                {
                    Name = "Id",
                    HeaderText = "ID",
                    DataPropertyName = "Id",
                    Width = 50,
                    Visible = false
                };
                dgvCompras.Columns.Add(columnaId);

                // Crear columna de Fecha
                var columnaFecha = new DataGridViewTextBoxColumn
                {
                    Name = "Fecha",
                    HeaderText = "Fecha",
                    DataPropertyName = "Fecha",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
                };
                dgvCompras.Columns.Add(columnaFecha);

                // Crear columna de Total
                var columnaTotal = new DataGridViewTextBoxColumn
                {
                    Name = "Total",
                    HeaderText = "Total",
                    DataPropertyName = "Total",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                };
                dgvCompras.Columns.Add(columnaTotal);

                // Crear columna de Observaciones
                var columnaObservaciones = new DataGridViewTextBoxColumn
                {
                    Name = "Observaciones",
                    HeaderText = "Observaciones",
                    DataPropertyName = "Observaciones",
                    Width = 200
                };
                dgvCompras.Columns.Add(columnaObservaciones);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar columnas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvCompras.CurrentRow != null)
            {
                int id = (int)dgvCompras.CurrentRow.Cells["Id"].Value;
                var compra = _compraController.GetByIdWithDetails(id);

                if (compra != null)
                {
                    var formDetalle = new VerDetallesCompraForm(compra, _compraController, _proveedorController, _articuloController);
                    formDetalle.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una compra de la lista.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCompras.CurrentRow != null)
            {
                int id = (int)dgvCompras.CurrentRow.Cells["Id"].Value;
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(textoBusqueda))
            {
                _bindingSource.DataSource = _compras;
                return;
            }

            var comprasFiltradas = _compras.Where(c =>
                c.Observaciones != null && c.Observaciones.ToLower().Contains(textoBusqueda) ||
                c.Fecha.ToString("dd/MM/yyyy").Contains(textoBusqueda) ||
                c.Total.ToString().Contains(textoBusqueda)
            ).ToList();

            _bindingSource.DataSource = new BindingList<Compra>(comprasFiltradas);
        }
    }
}
