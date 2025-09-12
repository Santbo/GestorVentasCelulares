using System.ComponentModel;
using System.Data;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.models.persona;

namespace GestionVentasCel.views.usuario_empleado
{
    public partial class SeleccionarPersonaForm : Form
    {
        private readonly ClienteController _clienteController;
        private BindingList<Persona> _personas;
        private readonly IServiceProvider _serviceProvider;
        private readonly Persona? _persona;
        private BindingSource _bindingSource;

        // Se tiene que exponer publicamente a la persona que se seleccionó para que despues se pueda agarrar para crear el cliente
        public Persona PersonaSeleccionada { get; private set; }
        public SeleccionarPersonaForm(ClienteController clienteController, Persona? persona)
        {
            InitializeComponent();
            _clienteController = clienteController;
            _persona = persona;
            CargarPersonas();

        }

        //Se crea un bindingList de cliente y se lo agrega al DGV
        //El BindingList a diferencia del List, actualiza el DGV si hay un cambio en los Objetos
        //Se crea un bindingSource para poder filtrar entre usuarios activos e inactivos
        private void CargarPersonas()
        {
            var listaPersonas = _clienteController.ObtenerPersonasSinClientes().ToList();

            _personas = new BindingList<Persona>(listaPersonas);

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _personas;

            AplicarFiltro();

            dgvListarPersonas.DataSource = _bindingSource;
            dgvListarPersonas.Columns["Id"].Visible = false;
            dgvListarPersonas.Columns["Calle"].Visible = false;
            dgvListarPersonas.Columns["Ciudad"].Visible = false;
        }

        private void chkMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }


        private void AplicarFiltro()
        {

            // punto de partida: todos los usuarios
            IEnumerable<Persona> filtrados = _personas;

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
            _bindingSource.DataSource = new BindingList<Persona>(filtrados.ToList());
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
                    "¿Estás seguro que querés salir sin seleccionar una persona?",
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
            if (dgvListarPersonas.CurrentRow != null)
            {
                int id = (int)dgvListarPersonas.CurrentRow.Cells["Id"].Value;

                var persona = _clienteController.GetPersonaById(id);
                if (persona == null)
                {
                    MessageBox.Show("El Cliente no fue encontrado",
                        "Cliente no encontrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                PersonaSeleccionada = persona;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
