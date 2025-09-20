using System.ComponentModel;
using System.Data;
using GestionVentasCel.controller.categoria;
using GestionVentasCel.enumerations.modoForms;
using GestionVentasCel.models.categoria;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.categoria
{
    public partial class CategoriaMainMenuForm : Form
    {
        private readonly CategoriaController _categoriaController;
        private BindingList<Categoria> _categorias;
        private BindingSource _bindingSource;
        public CategoriaMainMenuForm(CategoriaController categoriaController)
        {
            InitializeComponent();
            _categoriaController = categoriaController;
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            var listaCategorias = _categoriaController.ObtenerCategorias().ToList();
            _categorias = new BindingList<Categoria>(listaCategorias);

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _categorias;

            AplicarFiltro();

            dgvListarCategorias.DataSource = _bindingSource;

            dgvListarCategorias.DataBindingComplete += (s, e) =>
            {
                // Ocultar Id y Articulos
                dgvListarCategorias.Columns["Id"].Visible = false;
                dgvListarCategorias.Columns["Articulos"].Visible = false;

                // Ordenarlas 
                dgvListarCategorias.Columns["Nombre"].DisplayIndex = 1;
                dgvListarCategorias.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dgvListarCategorias.Columns["Descripcion"].DisplayIndex = 2;
                dgvListarCategorias.Columns["Activo"].DisplayIndex = 3;
                dgvListarCategorias.Columns["Activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            };
        }

        private void chkInactivos_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnToggleEstado_Click(object sender, EventArgs e)
        {
            if (dgvListarCategorias.CurrentRow != null)
            {
                int id = (int)dgvListarCategorias.CurrentRow.Cells["Id"].Value;

                var result = MessageBox.Show(
                    "¿Seguro que desea Habilitar/Deshabilitar esta Categoria?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No) return;

                // Actualizo en la BD
                _categoriaController.ToggleActivo(id);

                // Actualizo en memoria
                var categoria = _categorias.FirstOrDefault(u => u.Id == id);
                if (categoria != null)
                    categoria.Activo = !categoria.Activo;

                // Reaplico el filtro inmediatamente
                AplicarFiltro();
            }
        }

        private void AplicarFiltro()
        {

            // punto de partida: todos los usuarios
            IEnumerable<Categoria> filtrados = _categorias;

            // filtro por Activo
            if (!chkInactivos.Checked)
                filtrados = filtrados.Where(u => u.Activo);

            // filtro por búsqueda
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filtro))
            {
                filtrados = filtrados.Where(u =>
                    u.Nombre.ToLower().Contains(filtro));
            }

            // asignar al BindingSource
            _bindingSource.DataSource = new BindingList<Categoria>(filtrados.ToList());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var agregarCategoria = new AgregarEditarCategoriaForm(_categoriaController))
            {
                agregarCategoria.Modo = ModoFormulario.Agregar;
                //si el usuario apreta guardar, muestra el msj y actualiza el binding
                if (agregarCategoria.ShowDialog() == DialogResult.OK)
                {

                    MessageBox.Show("La categoria se guardó correctamente",
                    "Categoria Guardada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                    CargarCategorias();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvListarCategorias.CurrentRow != null)
            {
                int id = (int)dgvListarCategorias.CurrentRow.Cells["Id"].Value;

                var categoria = _categoriaController.GetById(id);
                if (categoria == null)
                {
                    MessageBox.Show("La Categoria no fue encontrada",
                        "Categoria no encontrada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                using (var editarCategoria = new AgregarEditarCategoriaForm(_categoriaController))
                {
                    editarCategoria.Modo = ModoFormulario.Editar;
                    editarCategoria.CategoriaActual = categoria;
                    //si el usuario apreta guardar, muestra el msj y actualiza el binding
                    if (editarCategoria.ShowDialog() == DialogResult.OK)
                    {

                        MessageBox.Show("La categoria se actualizó correctamente",
                        "Categoria Guardada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                        CargarCategorias();
                    }
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
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
            dgvListarCategorias.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvListarCategorias.GridColor = dgvListarCategorias.BackgroundColor;

            // Eliminar divisores entre columnas del header
            dgvListarCategorias.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // Cambiar el color de fondo, de la letra y el tamaño de fuente de la fila del header
            dgvListarCategorias.EnableHeadersVisualStyles = false;
            dgvListarCategorias.ColumnHeadersDefaultCellStyle.BackColor = Tema.ColorFondo;
            dgvListarCategorias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvListarCategorias.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Colorear alternando las filas
            dgvListarCategorias.RowsDefaultCellStyle.BackColor = Color.White;
            dgvListarCategorias.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Eliminar la columna de seleccion y configurar los modos de seleccion
            dgvListarCategorias.RowHeadersVisible = false;
            dgvListarCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListarCategorias.MultiSelect = false;
            dgvListarCategorias.ColumnHeadersDefaultCellStyle.SelectionBackColor = Tema.ColorFondo;
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
                    btnActualizar.PerformClick();
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

        private void CategoriaMainMenuForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
            this.ConfigurarAtajos();
        }
    }
}
