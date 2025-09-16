using System.ComponentModel;
using System.Data;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.models.clientes;

namespace GestionVentasCel.views.usuario_empleado
{
    /// <summary>
    /// Permite mostrar una lista de clientes que NO TIENEN cuenta corriente, para poder seleccionar uno a la 
    /// hora de crear una nueva cuenta.
    /// </summary>
    public partial class SeleccionarClienteForm : Form
    {
        private readonly ClienteController _clienteController;
        private BindingList<Cliente> _cliente;
        private readonly IServiceProvider _serviceProvider;
        private BindingSource _bindingSource;

        // Se tiene que exponer publicamente a la persona que se seleccionó para que despues se pueda agarrar para crear el cliente
        public Cliente ClienteSeleccionado { get; private set; }
        public SeleccionarClienteForm(ClienteController clienteController)
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
            var listaClientes = _clienteController.ObtenerClientesSinCuentas().ToList();

            _cliente = new BindingList<Cliente>(listaClientes);

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _cliente;

            AplicarFiltro();

            dgvListarClientes.DataSource = _bindingSource;
            dgvListarClientes.Columns["Id"].Visible = false;
            dgvListarClientes.Columns["CuentaCorriente"].Visible = false;

            // Organizar el orden de las columnas
            dgvListarClientes.Columns["Nombre"].DisplayIndex = 0;
            dgvListarClientes.Columns["Apellido"].DisplayIndex = 1;
            dgvListarClientes.Columns["Email"].DisplayIndex = 2;
            dgvListarClientes.Columns["Telefono"].DisplayIndex = 3;
            dgvListarClientes.Columns["TipoDocumento"].DisplayIndex = 4;
            dgvListarClientes.Columns["Dni"].DisplayIndex = 5;
            dgvListarClientes.Columns["Calle"].DisplayIndex = 6;
            dgvListarClientes.Columns["Ciudad"].DisplayIndex = 7;
            dgvListarClientes.Columns["CondicionIVA"].DisplayIndex = 8;
            dgvListarClientes.Columns["Activo"].DisplayIndex = 10;
        }

        private void chkMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }


        private void AplicarFiltro()
        {

            // punto de partida: todos los usuarios
            IEnumerable<Cliente> filtrados = _cliente;

            // filtro por búsqueda
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filtro))
            {
                filtrados = filtrados.Where(u =>
                    u.Nombre.ToLower().Contains(filtro)
                    || u.Dni.ToLower().Contains(filtro)   // Filtra por apellido y Dni, se puede agregar mas
                );
            }

            // asignar al BindingSource
            _bindingSource.DataSource = new BindingList<Cliente>(filtrados.ToList());
        }



        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SeleccionarPersonaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                var result = MessageBox.Show(
                    "¿Estás seguro que querés salir sin seleccionar un cliente? Esto cancelará la creación de la cuenta corriente.",
                    "Confirmar salida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvListarClientes.CurrentRow != null)
            {
                int id = (int)dgvListarClientes.CurrentRow.Cells["Id"].Value;

                var cliente = _clienteController.GetById(id);
                if (cliente == null)
                {
                    MessageBox.Show("El Cliente no fue encontrado",
                        "Cliente no encontrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                ClienteSeleccionado = cliente;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
