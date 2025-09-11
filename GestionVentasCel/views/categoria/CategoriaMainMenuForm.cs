using System.ComponentModel;
using System.Data;
using GestionVentasCel.controller.categoria;
using GestionVentasCel.enumerations.modoForms;
using GestionVentasCel.models.categoria;

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
            dgvListarCategorias.Columns["Id"].Visible = false;
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
    }
}
