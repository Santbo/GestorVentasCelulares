using System.ComponentModel;
using System.Data;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.compra;
using GestionVentasCel.controller.proveedor;
using GestionVentasCel.models.proveedor;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.proveedor
{
    public partial class ProveedorMainMenuForm : Form
    {
        private readonly ProveedorController _proveedorController;
        private readonly CompraController _compraController;
        private readonly ArticuloController _articuloController;
        private BindingList<Proveedor> _proveedores;
        private BindingSource _bindingSource;

        public ProveedorMainMenuForm(ProveedorController proveedorController,
                                   CompraController compraController,
                                   ArticuloController articuloController)
        {
            InitializeComponent();
            _proveedorController = proveedorController;
            _compraController = compraController;
            _articuloController = articuloController;
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            var listaProveedores = _proveedorController.ObtenerProveedores().ToList();
            _proveedores = new BindingList<Proveedor>(listaProveedores);

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _proveedores;

            AplicarFiltro();

            dgvListar.DataSource = _bindingSource;
            dgvListar.Columns["Id"].Visible = false;

            // Nombre, Apellido, Tipo de documento, Numero de documento, telefono, email, calle, ciudad, tipo proveedor, activo

            dgvListar.DataBindingComplete += (s, e) =>
            {

                dgvListar.Columns["Nombre"].DisplayIndex = 1;
                dgvListar.Columns["Apellido"].DisplayIndex = 2;
                dgvListar.Columns["TipoDocumento"].DisplayIndex = 3;
                dgvListar.Columns["Dni"].DisplayIndex = 4;
                dgvListar.Columns["Telefono"].DisplayIndex = 5;
                dgvListar.Columns["Email"].DisplayIndex = 6;
                dgvListar.Columns["Calle"].DisplayIndex = 7;
                dgvListar.Columns["Ciudad"].DisplayIndex = 8;
                dgvListar.Columns["Activo"].DisplayIndex = 9;
                dgvListar.Columns["Activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            };
        }

        private void chkInactivos_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnToggleEstado_Click(object sender, EventArgs e)
        {
            if (dgvListar.CurrentRow != null)
            {
                int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;
                var proveedor = _proveedorController.GetById(id);

                if (proveedor == null)
                {
                    MessageBox.Show("Proveedor no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool nuevoEstado = !proveedor.Activo;
                string accion = nuevoEstado ? "habilitar" : "deshabilitar";

                var result = MessageBox.Show(
                    $"¿Seguro que desea {accion} este Proveedor?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _proveedorController.CambiarEstadoProveedor(id, nuevoEstado);
                        CargarProveedores();
                        MessageBox.Show($"Proveedor {accion}do correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al actualizar el estado del proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un proveedor de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formAgregar = new AgregarEditarProveedorForm(_proveedorController);
            formAgregar.Modo = GestionVentasCel.enumerations.modoForms.ModoFormulario.Agregar;

            if (formAgregar.ShowDialog() == DialogResult.OK)
            {
                CargarProveedores();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvListar.CurrentRow != null)
            {
                int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;
                var proveedor = _proveedorController.GetById(id);

                if (proveedor != null)
                {
                    var formEditar = new AgregarEditarProveedorForm(_proveedorController);
                    formEditar.Modo = GestionVentasCel.enumerations.modoForms.ModoFormulario.Editar;
                    formEditar.ProveedorActual = proveedor;

                    if (formEditar.ShowDialog() == DialogResult.OK)
                    {
                        CargarProveedores();
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un proveedor de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(textoBusqueda))
            {
                AplicarFiltro();
                return;
            }

            // Punto de partida: todos los proveedores
            IEnumerable<Proveedor> filtrados = _proveedores;

            // Filtro por búsqueda
            filtrados = filtrados.Where(p =>
                p.Nombre.ToLower().Contains(textoBusqueda) ||
                (p.Apellido != null && p.Apellido.ToLower().Contains(textoBusqueda)) ||
                (p.Dni != null && p.Dni.Contains(textoBusqueda))
            );

            // Filtro por Activo: si el checkbox NO está marcado, mostrar solo activos
            if (!chkInactivos.Checked)
                filtrados = filtrados.Where(p => p.Activo);

            _bindingSource.DataSource = new BindingList<Proveedor>(filtrados.ToList());
        }

        private void AplicarFiltro()
        {
            // Punto de partida: todos los proveedores
            IEnumerable<Proveedor> filtrados = _proveedores;

            // Filtro por Activo: si el checkbox NO está marcado, mostrar solo activos
            if (!chkInactivos.Checked)
                filtrados = filtrados.Where(p => p.Activo);

            _bindingSource.DataSource = new BindingList<Proveedor>(filtrados.ToList());
        }

        private void btnVerCompras_Click(object sender, EventArgs e)
        {
            if (dgvListar.CurrentRow != null)
            {
                int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;
                var proveedor = _proveedorController.GetById(id);

                if (proveedor != null)
                {
                    var formCompras = new ComprasProveedorForm(_compraController, _proveedorController, _articuloController, proveedor);
                    formCompras.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un proveedor de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (e.Control && e.KeyCode == Keys.N)
                {
                    // Control N para nuevo usuario
                    btnAgregar.PerformClick();
                }

                if (e.Control && e.KeyCode == Keys.U)
                {
                    // Control U para actualizar el usuario
                    btnEditar.PerformClick();
                }


                if (e.Control && e.KeyCode == Keys.D)
                {
                    // Control D para ver detalles
                    btnVerCompras.PerformClick();
                }

                if (e.Control && e.KeyCode == Keys.F)
                {
                    // Control F para buscar usuarios
                    txtBuscar.Focus();
                }

                // Supr para habilitar/deshabilitar el usuario
                if (e.KeyCode == Keys.Delete)
                {
                    btnToggleActivo.PerformClick();
                }
            };
        }

        private void ProveedorMainMenuForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
            this.ConfigurarAtajos();
        }
    }
}
