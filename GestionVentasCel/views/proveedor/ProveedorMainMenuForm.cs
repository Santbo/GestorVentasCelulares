using System.ComponentModel;
using System.Data;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.compra;
using GestionVentasCel.controller.proveedor;
using GestionVentasCel.models.proveedor;

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

            dgvListarProveedores.DataSource = _bindingSource;
            dgvListarProveedores.Columns["Id"].Visible = false;
        }

        private void chkInactivos_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnToggleEstado_Click(object sender, EventArgs e)
        {
            if (dgvListarProveedores.CurrentRow != null)
            {
                int id = (int)dgvListarProveedores.CurrentRow.Cells["Id"].Value;
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
            if (dgvListarProveedores.CurrentRow != null)
            {
                int id = (int)dgvListarProveedores.CurrentRow.Cells["Id"].Value;
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
            if (dgvListarProveedores.CurrentRow != null)
            {
                int id = (int)dgvListarProveedores.CurrentRow.Cells["Id"].Value;
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

    }
}
