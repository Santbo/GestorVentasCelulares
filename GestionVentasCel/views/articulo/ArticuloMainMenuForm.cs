using System.ComponentModel;
using System.Data;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.categoria;
using GestionVentasCel.enumerations.modoForms;
using GestionVentasCel.exceptions.articulo;
using GestionVentasCel.models.articulo;

namespace GestionVentasCel.views.articulo
{

    public partial class ArticuloMainMenuForm : Form
    {
        private readonly ArticuloController _articuloController;
        private readonly CategoriaController _categoriaController;
        private BindingList<Articulo> _articulos;
        private BindingSource _bindingSource;
        public ArticuloMainMenuForm(ArticuloController articuloController, CategoriaController categoriaController)
        {
            InitializeComponent();
            _articuloController = articuloController;
            _categoriaController = categoriaController;
            CargarArticulos();
        }

        //Se crea un bindingList de usuario y se lo agrega al DGV
        //El BindingList a diferencia del List, actualiza el DGV si hay un cambio en los Objetos
        //Se crea un bindingSource para poder filtrar entre usuarios activos e inactivos
        private void CargarArticulos()
        {
            var listaArticulos = _articuloController.ObtenerArticulos().ToList();

            _articulos = new BindingList<Articulo>(listaArticulos);

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _articulos;

            AplicarFiltro();

            dgvListarArticulos.DataSource = _bindingSource;
            dgvListarArticulos.Columns["Id"].Visible = false;
            dgvListarArticulos.Columns["CategoriaId"].Visible = false;
        }

        private void chckMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void bntToggleActivo_Click(object sender, EventArgs e)
        {
            if (dgvListarArticulos.CurrentRow != null)
            {
                int id = (int)dgvListarArticulos.CurrentRow.Cells["Id"].Value;

                var result = MessageBox.Show(
                    "¿Seguro que desea Habilitar/Deshabilitar este Articulo?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No) return;

                try
                {

                    // Actualizo en la BD
                    _articuloController.ToggleActivo(id);

                    // Actualizo en memoria
                    var articulo = _articulos.FirstOrDefault(u => u.Id == id);
                    if (articulo != null)
                        articulo.Activo = !articulo.Activo;

                    // Reaplico el filtro inmediatamente
                    AplicarFiltro();
                }
                catch (ArticuloNoEncontradoException ex)
                {

                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void AplicarFiltro()
        {

            // punto de partida: todos los usuarios
            IEnumerable<Articulo> filtrados = _articulos;

            // filtro por Activo
            if (!chkMostrarInactivos.Checked)
                filtrados = filtrados.Where(u => u.Activo);

            // filtro por búsqueda
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filtro))
            {
                filtrados = filtrados.Where(a =>
                    a.Nombre.ToLower().Contains(filtro)
                    || a.Marca.ToLower().Contains(filtro)
                    || a.Categoria.Nombre.ToLower().Contains(filtro)
                );
            }

            // asignar al BindingSource
            _bindingSource.DataSource = new BindingList<Articulo>(filtrados.ToList());
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var agregarArticulo = new AgregarEditarArticuloForm(_articuloController, _categoriaController))
            {
                agregarArticulo.Modo = ModoFormulario.Agregar;
                //si el usuario apreta guardar, muestra el msj y actualiza el binding
                if (agregarArticulo.ShowDialog() == DialogResult.OK)
                {

                    MessageBox.Show("El articulo se guardó correctamente",
                    "Articulo Guardado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                    CargarArticulos();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvListarArticulos.CurrentRow != null)
            {
                int id = (int)dgvListarArticulos.CurrentRow.Cells["Id"].Value;

                var articulo = _articuloController.GetById(id);
                if (articulo == null)
                {
                    MessageBox.Show("El articulo no fue encontrado",
                        "Articulo no encontrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                using (var editarArticulo = new AgregarEditarArticuloForm(_articuloController, _categoriaController))
                {
                    editarArticulo.Modo = ModoFormulario.Editar;
                    editarArticulo.ArticuloActual = articulo;
                    //si el usuario apreta guardar, muestra el msj y actualiza el binding
                    if (editarArticulo.ShowDialog() == DialogResult.OK)
                    {

                        MessageBox.Show("El articulo se actualizó correctamente",
                        "Articulo Guardado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                        CargarArticulos();
                    }
                }
            }
        }
    }
}
