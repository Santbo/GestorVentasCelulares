using System.ComponentModel;
using System.Data;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.controller.usuario;
using GestionVentasCel.enumerations.modoForms;
using GestionVentasCel.exceptions.cliente;
using GestionVentasCel.exceptions.usuario;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.usuario;

namespace GestionVentasCel.views.usuario_empleado
{


    public partial class ClienteMainMenuForm : Form
    {
        private readonly ClienteController _clienteController;
        private BindingList<Cliente> _clientes;
        private BindingSource _bindingSource;
        public ClienteMainMenuForm(ClienteController clienteController)
        {
            InitializeComponent();
            _clienteController = clienteController;
            CargarClientes();

        }

        //Se crea un bindingList de cliente y se lo agrega al DGV
        //El BindingList a diferencia del List, actualiza el DGV si hay un cambio en los Objetos
        //Se crea un bindingSource para poder filtrar entre usuarios activos e inactivos
        private void CargarClientes()
        {
            var listaClientes = _clienteController.ObtenerClientes().ToList();

            _clientes = new BindingList<Cliente>(listaClientes);

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _clientes;

            AplicarFiltro();

            dgvListarClientes.DataSource = _bindingSource;
            dgvListarClientes.Columns["Id"].Visible = false;
            //dgvListarUsuarios.Columns["Calle"].Visible = false;
            //dgvListarUsuarios.Columns["Ciudad"].Visible = false;
        }

        private void chkMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnToggleActivo_Click(object sender, EventArgs e)
        {

            if (dgvListarClientes.CurrentRow != null)
            {
                int id = (int)dgvListarClientes.CurrentRow.Cells["Id"].Value;

                var result = MessageBox.Show(
                    "¿Seguro que desea Habilitar/Deshabilitar este cliente?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No) return;

                try
                {

                    // Actualizo en la BD
                    _clienteController.ToggleActivo(id);

                    // Actualizo en memoria
                    var usuario = _clientes.FirstOrDefault(u => u.Id == id);
                    if (usuario != null)
                        usuario.Activo = !usuario.Activo;

                    // Reaplico el filtro inmediatamente
                    AplicarFiltro();
                }
                catch (ClienteInexistenteException ex)
                {

                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void AplicarFiltro()
        {

            // punto de partida: todos los usuarios
            IEnumerable<Cliente> filtrados = _clientes;

            // filtro por Activo
            if (!chkMostrarInactivos.Checked)
                filtrados = filtrados.Where(u => u.Activo);

            // filtro por búsqueda
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filtro))
            {
                filtrados = filtrados.Where(u =>
                    u.Apellido.ToLower().Contains(filtro)
                    || u.Dni.ToLower().Contains(filtro)   // Filtra por apellido y Dni, se puede agregar mas
                );
            }

            // asignar al BindingSource
            _bindingSource.DataSource = new BindingList<Cliente>(filtrados.ToList());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //using (var agregarUsuario = new AgregarEditarEmpleadoForm(_clienteController))
            //{
            //    agregarUsuario.Modo = ModoFormulario.Agregar;
            //    //si el usuario apreta guardar, muestra el msj y actualiza el binding
            //    if (agregarUsuario.ShowDialog() == DialogResult.OK)
            //    {

            //        MessageBox.Show("El empleado se guardó correctamente",
            //        "Empleado Guardado",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Information);

            //        CargarClientes();
            //    }
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvListarClientes.CurrentRow != null)
            {
                int id = (int)dgvListarClientes.CurrentRow.Cells["Id"].Value;

                var usuario = _clienteController.GetById(id);
                if (usuario == null)
                {
                    MessageBox.Show("El Cliente no fue encontrado",
                        "Cliente no encontrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                //using (var editarUsuario = new AgregarEditarEmpleadoForm(_clienteController))
                //{
                //    editarUsuario.Modo = ModoFormulario.Editar;
                //    editarUsuario.UsuarioActual = usuario;
                //    //si el usuario apreta guardar, muestra el msj y actualiza el binding
                //    if (editarUsuario.ShowDialog() == DialogResult.OK)
                //    {

                //        MessageBox.Show("El empleado se actualizó correctamente",
                //        "Empleado Guardado",
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Information);

                //        CargarClientes();
                //    }
                //}
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }
    }
}
