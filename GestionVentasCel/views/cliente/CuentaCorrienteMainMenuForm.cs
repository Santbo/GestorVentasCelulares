using System.ComponentModel;
using System.Data;
using System.Globalization;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.exceptions.cliente;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.CuentaCorreinte;
using GestionVentasCel.models.persona;

namespace GestionVentasCel.views.usuario_empleado
{


    public partial class CuentaCorrienteMainMenuForm : Form
    {
        private readonly ClienteController _clienteController;
        private BindingList<CuentaCorriente> _cuentas;
        private readonly IServiceProvider _serviceProvider;
        private BindingSource _bindingSource;
        public CuentaCorrienteMainMenuForm(ClienteController clienteController, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _clienteController = clienteController;
            _serviceProvider = serviceProvider;
            CargarClientes();

        }

        //Se crea un bindingList de cliente y se lo agrega al DGV
        //El BindingList a diferencia del List, actualiza el DGV si hay un cambio en los Objetos
        //Se crea un bindingSource para poder filtrar entre usuarios activos e inactivos
        private void CargarClientes()
        {
            var listaClientes = _clienteController.ObtenerCuentasCorrientes().ToList();

            _cuentas = new BindingList<CuentaCorriente>(listaClientes);

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _cuentas;

            AplicarFiltro();
            ConfigurarDGV();

        }

        public void ConfigurarDGV()
        {
            // Se agregan las columnas de "Saldo", se ocultan "Movimientos",
            // Se agrega la columna "Fecha del ultimo movimiento"
            dgvListarCuentas.DataSource = _bindingSource;
            dgvListarCuentas.Columns["Id"].Visible = false;
            dgvListarCuentas.Columns["ClienteId"].Visible = false;
            dgvListarCuentas.Columns["Movimientos"].Visible = false;

            // Añadir las dos columnas extra
            dgvListarCuentas.Columns.Add(
                "Saldo", "Saldo actual"
            );

            dgvListarCuentas.Columns.Add(
                "FechaUltimo", "Último movimiento"
            );
            // y organizarlas
            dgvListarCuentas.Columns["Cliente"].DisplayIndex = 0;
            dgvListarCuentas.Columns["Saldo"].DisplayIndex = 1;
            dgvListarCuentas.Columns["FechaUltimo"].DisplayIndex = 2;
            dgvListarCuentas.Columns["Activo"].DisplayIndex = 3;


            dgvListarCuentas.DataBindingComplete += (s, e) =>
            {
                foreach (DataGridViewRow row in dgvListarCuentas.Rows)
                {
                    if (row.DataBoundItem is CuentaCorriente cuenta)
                    {
                        var saldo = _clienteController.ObtenerSaldoCuentaCorriente(cuenta);
                        var ultimoMovimiento = _clienteController.ObtenerFechaUltimoMovimiento(cuenta);

                        row.Cells["Saldo"].Value = saldo != 0 ?
                            $"{saldo.ToString("C", new CultureInfo("es-AR"))}" : "No hay movimientos";

                        row.Cells["FechaUltimo"].Value = ultimoMovimiento != null ?
                            ultimoMovimiento : "No hay movimientos";
                    }
                }
            };

        }

        private void chkMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnToggleActivo_Click(object sender, EventArgs e)
        {

            if (dgvListarCuentas.CurrentRow != null)
            {
                int id = (int)dgvListarCuentas.CurrentRow.Cells["Id"].Value;

                var result = MessageBox.Show(
                    "¿Seguro que desea Habilitar/Deshabilitar esta cuenta corriente?",
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
                    var usuario = _cuentas.FirstOrDefault(u => u.Id == id);
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
            IEnumerable<CuentaCorriente> filtrados = _cuentas;

            // filtro por Activo
            if (!chkMostrarInactivos.Checked)
                filtrados = filtrados.Where(u => u.Activo);

            // filtro por búsqueda
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filtro))
            {
                filtrados = filtrados.Where(u =>
                    u.Cliente.Nombre.ToLower().Contains(filtro)
                );
            }

            // asignar al BindingSource
            _bindingSource.DataSource = new BindingList<CuentaCorriente>(filtrados.ToList());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿La persona ya existe en el sistema?", "Agregar un nuevo cliente",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.Cancel)
            {
                return;
            }

            Cliente? cliente = null;
            Persona? persona = null;

            if (resultado == DialogResult.Yes)
            {
                // La persona ya existe, entonces se debería mostrar el formulario con la lista de personas que no tengan 
                // asociado un cliente. Por tanto, Cliente debería no ser nulo al terminar esto. Si no, debería salirse de
                // esta función.

                using (var form = new SeleccionarPersonaForm(clienteController: _clienteController, persona: persona))
                {
                    if (form.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        persona = form.PersonaSeleccionada;
                    }
                }


            }

            // Esto tiene que cambiar, pero la lógica es literalmente igual que la de agregar cliente, salvo que el form debe 
            // devolver la cuenta corriente

            using (var form = new AgregarEditarClienteForm(clienteController: _clienteController, cliente: cliente, persona: persona))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    cliente = form.ClienteCreado;
                    MessageBox.Show("La cuenta corriente se agregó correctamente", "Cuenta agregada");
                    CargarClientes();
                }

            }

            _clienteController.CrearCuentaCorriente(cliente);



        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //if (dgvListarCuentas.CurrentRow != null)
            //{
            //    int id = (int)dgvListarCuentas.CurrentRow.Cells["Id"].Value;

            //    var cliente = _clienteController.GetById(id);
            //    if (cliente == null)
            //    {
            //        MessageBox.Show("El Cliente no fue encontrado",
            //            "Cliente no encontrado",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Warning);

            //        return;
            //    }

            //    using (var editarCliente = new AgregarEditarClienteForm(_clienteController, cliente: cliente))
            //    {
            //        //si el usuario apreta guardar, muestra el msj y actualiza el binding
            //        if (editarCliente.ShowDialog() == DialogResult.OK)
            //        {

            //            MessageBox.Show("El cliente se actualizó correctamente",
            //            "cliente Guardado",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);

            //            CargarClientes();
            //        }
            //    }
            //}
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }


    }
}
