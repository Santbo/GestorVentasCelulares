using GestionVentasCel.controller.cliente;
using GestionVentasCel.models.ventas;
using GestionVentasCel.service.venta;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.ventas
{
    public partial class AgregarEditarVentaForm : Form
    {
        public Venta _venta;
        private bool _editando;
        private readonly IVentaService _service;
        private readonly ClienteController _clienteController;
        public AgregarEditarVentaForm(IVentaService ventaService, ClienteController clienteController, Venta? venta = null)
        {
            InitializeComponent();
            _service = ventaService;
            _editando = venta != null;
            _venta = venta ?? new Venta();
            _clienteController = clienteController;

            this.CargarComboBoxCliente();

        }

        public void CargarComboBoxCliente()
        //TODO: Hacer que el listado de cleintes no muestre NombreCompleto
        {
            var clientes = _clienteController.ObtenerClientes().Where(c => c.Activo == true).ToList();

            comboCliente.DataSource = clientes;
            comboCliente.DisplayMember = "Nombre";
            comboCliente.ValueMember = "Id";
        }
        private void btnDescartar_Click(object sender, EventArgs e)
        {
            //TODO: Agregar confirmación de descartar, que pregunte si quiere descartar o guardar como borrador

            var accion = MessageBox.Show(
                "Está por descartar la venta, ¿Desea guardar un borrador para seguir más tarde?",
                "Descartando cambios",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Exclamation);

            if (accion == DialogResult.Yes)
            {
                //TODO: Implementar lógica de guardar como borrador la venta
                throw new NotImplementedException("Hay que implementar la lógica para guardar como borrador la venta");
            }
            else if (accion == DialogResult.No)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void ConfigurarEstilosVisuales()
        {
            this.BackColor = Tema.ColorSuperficie;
            this.lblTituloForm.Text = this._editando ?
                "Editar venta" : "Agregar venta";

            this.lblTituloForm.ForeColor = Tema.ColorTextoPrimario;
            this.lblTituloForm.BackColor = Tema.ColorFondo;
            this.btnSalir.BackColor = Tema.ColorFondo;


            this.BackColor = Tema.ColorSuperficie;


        }

        private void AgregarEditarVentaForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.btnDescartar.PerformClick();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // TODO: Hay que implementar la lógica de guardar la venta
            throw new NotImplementedException("Hay que implementar la lógica de guardar");
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            //TODO: Abrir el formulario de creación de cliente.
            throw new NotImplementedException("Hay que implementar la lógica para abrir el formulario de agregar cliente");
        }
    }
}
