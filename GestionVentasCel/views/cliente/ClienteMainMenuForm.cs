using System.ComponentModel;
using System.Data;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.exceptions.cliente;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.persona;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.usuario_empleado
{


    public partial class ClienteMainMenuForm : Form
    {
        private readonly ClienteController _clienteController;
        private BindingList<Cliente> _clientes;
        private readonly IServiceProvider _serviceProvider;
        private BindingSource _bindingSource;
        public ClienteMainMenuForm(ClienteController clienteController, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _clienteController = clienteController;
            _serviceProvider = serviceProvider;
            CargarClientes();
            ConfigurarDGV();

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

        }

        private void ConfigurarDGV()
        {
            dgvListarClientes.DataSource = _bindingSource;
            dgvListarClientes.Columns["Id"].Visible = false;
            dgvListarClientes.Columns["CuentaCorriente"].Visible = false;

            // Añadir la columna que establece el estado de la cuenta corriente
            if (dgvListarClientes.Columns["CuentaCorrienteTexto"] == null)
            {
                dgvListarClientes.Columns.Add(
                    "CuentaCorrienteTexto", "Cuenta corriente"
                );

            }



            dgvListarClientes.DataBindingComplete += (s, e) =>
            {

                // Organizar el orden de las columnas despues de que se hayan bindeado todos los datos
                dgvListarClientes.Columns["Nombre"].DisplayIndex = 0;
                dgvListarClientes.Columns["Apellido"].DisplayIndex = 1;
                dgvListarClientes.Columns["Email"].DisplayIndex = 2;
                dgvListarClientes.Columns["Telefono"].DisplayIndex = 3;
                dgvListarClientes.Columns["TipoDocumento"].DisplayIndex = 4;
                dgvListarClientes.Columns["Dni"].DisplayIndex = 5;
                dgvListarClientes.Columns["Calle"].DisplayIndex = 6;
                dgvListarClientes.Columns["Ciudad"].DisplayIndex = 7;
                dgvListarClientes.Columns["CondicionIVA"].DisplayIndex = 8;
                dgvListarClientes.Columns["CuentaCorrienteTexto"].DisplayIndex = 9;
                dgvListarClientes.Columns["Activo"].DisplayIndex = 10;


                foreach (DataGridViewRow row in dgvListarClientes.Rows)
                {
                    if (row.DataBoundItem is Cliente cliente)
                    {
                        row.Cells["CuentaCorrienteTexto"].Value = cliente.CuentaCorriente == null ?
                            "No tiene" : "Activa";
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
                    u.Nombre.ToLower().Contains(filtro)
                    || u.Dni.ToLower().Contains(filtro)   // Filtra por apellido y Dni, se puede agregar mas
                );
            }

            // asignar al BindingSource
            _bindingSource.DataSource = new BindingList<Cliente>(filtrados.ToList());
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

            using (var form = new AgregarEditarClienteForm(clienteController: _clienteController, cliente: cliente, persona: persona))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("El cliente se agregó correctamente", "Cliente agregado");
                    CargarClientes();
                    ConfigurarDGV();
                }

            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
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

                using (var editarCliente = new AgregarEditarClienteForm(_clienteController, cliente: cliente))
                {
                    //si el usuario apreta guardar, muestra el msj y actualiza el binding
                    if (editarCliente.ShowDialog() == DialogResult.OK)
                    {

                        MessageBox.Show("El cliente se actualizó correctamente",
                        "cliente Guardado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        CargarClientes();
                        ConfigurarDGV();
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
            dgvListarClientes.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvListarClientes.GridColor = dgvListarClientes.BackgroundColor;

            // Eliminar divisores entre columnas del header
            dgvListarClientes.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // Cambiar el color de fondo, de la letra y el tamaño de fuente de la fila del header
            dgvListarClientes.EnableHeadersVisualStyles = false;
            dgvListarClientes.ColumnHeadersDefaultCellStyle.BackColor = Tema.ColorFondo;
            dgvListarClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvListarClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Colorear alternando las filas
            dgvListarClientes.RowsDefaultCellStyle.BackColor = Color.White;
            dgvListarClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Eliminar la columna de seleccion y configurar los modos de seleccion
            dgvListarClientes.RowHeadersVisible = false;
            dgvListarClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListarClientes.MultiSelect = false;
            dgvListarClientes.ColumnHeadersDefaultCellStyle.SelectionBackColor = Tema.ColorFondo;
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

        private void ClienteMainMenuForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
            this.ConfigurarAtajos();
        }
    }
}
