using System.ComponentModel;
using System.Data;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.compra;
using GestionVentasCel.controller.proveedor;
using GestionVentasCel.enumerations.usuarios;
using GestionVentasCel.models.compra;
using GestionVentasCel.models.proveedor;
using GestionVentasCel.service.usuario;
using GestionVentasCel.temas;
using GestionVentasCel.views.compra;

namespace GestionVentasCel.views.proveedor
{
    public partial class ComprasProveedorForm : Form
    {
        private readonly CompraController _compraController;
        private readonly ProveedorController _proveedorController;
        private readonly ArticuloController _articuloController;
        private readonly Proveedor _proveedor;
        private readonly SesionUsuario _sesionUsuario;
        private BindingList<Compra> _compras = null!;
        private BindingSource _bindingSource = null!;

        public ComprasProveedorForm(CompraController compraController,
                                   ProveedorController proveedorController,
                                   ArticuloController articuloController,
                                   Proveedor proveedor,
                                   SesionUsuario sesionUsuario)
        {
            InitializeComponent();
            _compraController = compraController;
            _proveedorController = proveedorController;
            _articuloController = articuloController;
            _proveedor = proveedor;
            _sesionUsuario = sesionUsuario;

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
                dgvListar.AutoGenerateColumns = false;
                ConfigurarColumnas();
                dgvListar.DataSource = _bindingSource;
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
                dgvListar.Columns.Clear();

                // Crear columna de ID (oculta)
                var columnaId = new DataGridViewTextBoxColumn
                {
                    Name = "Id",
                    HeaderText = "ID",
                    DataPropertyName = "Id",
                    Width = 50,
                    Visible = false
                };
                dgvListar.Columns.Add(columnaId);

                // Crear columna de Fecha
                var columnaFecha = new DataGridViewTextBoxColumn
                {
                    Name = "Fecha",
                    HeaderText = "Fecha",
                    DataPropertyName = "Fecha",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
                };
                dgvListar.Columns.Add(columnaFecha);

                // Crear columna de Total
                var columnaTotal = new DataGridViewTextBoxColumn
                {
                    Name = "Total",
                    HeaderText = "Total",
                    DataPropertyName = "Total",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                };
                dgvListar.Columns.Add(columnaTotal);

                // Crear columna de Observaciones
                var columnaObservaciones = new DataGridViewTextBoxColumn
                {
                    Name = "Observaciones",
                    HeaderText = "Observaciones",
                    DataPropertyName = "Observaciones",
                    Width = 200
                };
                dgvListar.Columns.Add(columnaObservaciones);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar columnas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvListar.CurrentRow != null)
            {
                int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;
                var compra = _compraController.GetByIdWithDetails(id);

                if (compra != null)
                {
                    var formDetalle = new VerDetallesCompraForm(compra, _compraController, _proveedorController, _articuloController, _sesionUsuario);
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

        private void ConfigurarEstilosVisuales()
        {
            this.lblTituloForm.Text = $"Compras a {_proveedor.Nombre}";

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


                if (e.Control && e.KeyCode == Keys.F)
                {
                    // Control F para buscar usuarios
                    txtBuscar.Focus();
                }

            };
        }

        private void ComprasProveedorForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
            this.ConfigurarAtajos();

            if (_sesionUsuario.Rol != RolEnum.Admin)
            {
                btnEditar.Visible = false;

            }
        }
    }
}
