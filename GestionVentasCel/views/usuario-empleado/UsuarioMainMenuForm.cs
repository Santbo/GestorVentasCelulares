using System.ComponentModel;
using System.Data;
using GestionVentasCel.controller.usuario;
using GestionVentasCel.enumerations.modoForms;
using GestionVentasCel.exceptions.usuario;
using GestionVentasCel.models.usuario;

namespace GestionVentasCel.views.usuario_empleado
{


    public partial class UsuarioMainMenuForm : Form
    {
        private readonly UsuarioController _usuarioController;
        private BindingList<Usuario> _usuarios;
        private BindingSource _bindingSource;
        public UsuarioMainMenuForm(UsuarioController usuarioController)
        {
            InitializeComponent();
            _usuarioController = usuarioController;
            CargarUsuarios();

        }

        //Se crea un bindingList de usuario y se lo agrega al DGV
        //El BindingList a diferencia del List, actualiza el DGV si hay un cambio en los Objetos
        //Se crea un bindingSource para poder filtrar entre usuarios activos e inactivos
        private void CargarUsuarios()
        {
            var listaUsuarios = _usuarioController.ObtenerUsuarios().ToList();

            _usuarios = new BindingList<Usuario>(listaUsuarios);

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _usuarios;

            AplicarFiltro();

            dgvListarUsuarios.DataSource = _bindingSource;
            dgvListarUsuarios.Columns["Id"].Visible = false;
            dgvListarUsuarios.Columns["Calle"].Visible = false;
            dgvListarUsuarios.Columns["Ciudad"].Visible = false;
            
        }

        private void chkMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnToggleActivo_Click(object sender, EventArgs e)
        {

            if (dgvListarUsuarios.CurrentRow != null)
            {
                int id = (int)dgvListarUsuarios.CurrentRow.Cells["Id"].Value;

                var result = MessageBox.Show(
                    "¿Seguro que desea Habilitar/Deshabilitar este usuario?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No) return;

                try
                {

                    // Actualizo en la BD
                    _usuarioController.ToggleActivo(id);

                    // Actualizo en memoria
                    var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
                    if (usuario != null)
                        usuario.Activo = !usuario.Activo;

                    // Reaplico el filtro inmediatamente
                    AplicarFiltro();
                }
                catch (UsuarioNoEncontradoException ex)
                {

                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void AplicarFiltro()
        {

            // punto de partida: todos los usuarios
            IEnumerable<Usuario> filtrados = _usuarios;

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
            _bindingSource.DataSource = new BindingList<Usuario>(filtrados.ToList());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var agregarUsuario = new AgregarEditarEmpleadoForm(_usuarioController))
            {
                agregarUsuario.Modo = ModoFormulario.Agregar;
                //si el usuario apreta guardar, muestra el msj y actualiza el binding
                if (agregarUsuario.ShowDialog() == DialogResult.OK)
                {

                    MessageBox.Show("El empleado se guardó correctamente",
                    "Empleado Guardado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                    CargarUsuarios();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvListarUsuarios.CurrentRow != null)
            {
                int id = (int)dgvListarUsuarios.CurrentRow.Cells["Id"].Value;

                var usuario = _usuarioController.GetById(id);
                if (usuario == null)
                {
                    MessageBox.Show("El Usuario no fue encontrado",
                        "Usuario no encontrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                using (var editarUsuario = new AgregarEditarEmpleadoForm(_usuarioController))
                {
                    editarUsuario.Modo = ModoFormulario.Editar;
                    editarUsuario.UsuarioActual = usuario;
                    //si el usuario apreta guardar, muestra el msj y actualiza el binding
                    if (editarUsuario.ShowDialog() == DialogResult.OK)
                    {

                        MessageBox.Show("El empleado se actualizó correctamente",
                        "Empleado Guardado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                        CargarUsuarios();
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
