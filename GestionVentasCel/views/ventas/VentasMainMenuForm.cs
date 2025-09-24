using System.ComponentModel;
using System.Data;
using System.Globalization;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.models.ventas;
using GestionVentasCel.service.venta;
using GestionVentasCel.temas;
using GestionVentasCel.views.ventas;
using Microsoft.Extensions.DependencyInjection;

namespace GestionVentasCel.views.usuario_empleado
{


    public partial class VentaMainMenuForm : Form
    {
        private readonly IVentaService _ventaService;
        private BindingList<Venta> _ventas;
        private readonly IServiceProvider _serviceProvider;
        private BindingSource _bindingSource;
        public VentaMainMenuForm(IVentaService ventaService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _ventaService = ventaService;
            _serviceProvider = serviceProvider;
            CargarVentas();
            ConfigurarDGV();

        }

        //Se crea un bindingList de cliente y se lo agrega al DGV
        //El BindingList a diferencia del List, actualiza el DGV si hay un cambio en los Objetos
        //Se crea un bindingSource para poder filtrar entre usuarios activos e inactivos
        private void CargarVentas()
        {
            var listaVentas = _ventaService.ObtenerVentas().ToList();

            _ventas = new BindingList<Venta>(listaVentas);

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _ventas;

            AplicarFiltro();

        }

        private void ConfigurarDGV()
        {
            dgvListar.DataSource = _bindingSource;
            // Es más facil ocultar todas las columnas y mostrar, que al revés

            foreach (DataGridViewColumn col in dgvListar.Columns)
            {
                col.Visible = false;
            }

            dgvListar.Columns["FechaCreacion"].Visible = true;
            dgvListar.Columns["FechaVenta"].Visible = true;
            dgvListar.Columns["EstadoVenta"].Visible = true;
            dgvListar.Columns["Cliente"].Visible = true;
            dgvListar.Columns["TipoPago"].Visible = true;
            dgvListar.Columns["TotalConIva"].Visible = true;

            if (dgvListar.Columns["TotalConIvaFormateado"] != null)
            {
                dgvListar.Columns.Add("TotalConIvaFormateado", "Total con IVA");
            }


            dgvListar.DataBindingComplete += (s, e) =>
            {

                // Organizar el orden de las columnas despues de que se hayan bindeado todos los datos
                dgvListar.Columns["FechaCreacion"].DisplayIndex = 0;
                dgvListar.Columns["FechaVenta"].DisplayIndex = 1;
                dgvListar.Columns["EstadoVenta"].DisplayIndex = 2;
                dgvListar.Columns["Cliente"].DisplayIndex = 3;
                dgvListar.Columns["TipoPago"].DisplayIndex = 4;
                dgvListar.Columns["TotalConIva"].DisplayIndex = 5;
                //TODO: Agregar código que cambie Anular/Desanular cuando se haga haga click en una fila del DGV

                foreach (DataGridViewRow row in dgvListar.Rows)
                {
                    if (row.DataBoundItem is Venta venta)
                    {
                        row.Cells["TotalConIVaFormateado"].Value = venta.TotalConIva.ToString("C2", new CultureInfo("es-AR"));
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
            throw new NotImplementedException("Hay que implementar el toggle de estado");
            //if (dgvListar.CurrentRow != null)
            //{
            //    int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;

            //    var result = MessageBox.Show(
            //        "¿Seguro que desea Habilitar/Deshabilitar este cliente?",
            //        "Confirmación",
            //        MessageBoxButtons.YesNo,
            //        MessageBoxIcon.Question
            //    );

            //    if (result == DialogResult.No) return;

            //    try
            //    {

            //        // Actualizo en la BD
            //        _ventaService.ToggleActivo(id);

            //        // Actualizo en memoria
            //        var usuario = _ventas.FirstOrDefault(u => u.Id == id);
            //        if (usuario != null)
            //            usuario.Activo = !usuario.Activo;

            //        // Reaplico el filtro inmediatamente
            //        AplicarFiltro();
            //    }
            //    catch (ClienteInexistenteException ex)
            //    {

            //        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
        }

        private void AplicarFiltro()
        {

            // punto de partida: todos los usuarios
            IEnumerable<Venta> filtrados = _ventas;

            // filtro por Activo
            if (!chkMostrarInactivos.Checked)
                filtrados = filtrados.Where(u => u.EstadoVenta != enumerations.ventas.EstadoVentaEnum.Anulada);

            // filtro por búsqueda
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filtro))
            {
                //TODO: Implementar filtros de ventas
                //filtrados = filtrados.Where(u =>
                //    u.Nombre.ToLower().Contains(filtro)
                //    || u.Dni.ToLower().Contains(filtro)   // Filtra por apellido y Dni, se puede agregar mas
                //);
            }

            // asignar al BindingSource
            _bindingSource.DataSource = new BindingList<Venta>(filtrados.ToList());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var form = new AgregarEditarVentaForm(
                clienteController: _serviceProvider.GetRequiredService<ClienteController>(),
                ventaService: _serviceProvider.GetRequiredService<IVentaService>()
            ))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    bool facturar = MessageBox.Show(
                        "La venta se agregó correctamente. ¿Desea emitir una factura?",
                        "Venta agregada",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.OK;

                    if (facturar)
                    {
                        throw new NotImplementedException("Hay que implementar la lógica para facturar");
                    }
                    CargarVentas();
                    ConfigurarDGV();
                }
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("Hay que implementar el actualizar una venta");
            //if (dgvListar.CurrentRow != null)
            //{
            //    int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;

            //    var cliente = _ventaService.GetById(id);
            //    if (cliente == null)
            //    {
            //        MessageBox.Show("El Cliente no fue encontrado",
            //            "Cliente no encontrado",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Warning);

            //        return;
            //    }

            //    using (var editarCliente = new AgregarEditarClienteForm(_ventaService, cliente: cliente))
            //    {
            //        //si el usuario apreta guardar, muestra el msj y actualiza el binding
            //        if (editarCliente.ShowDialog() == DialogResult.OK)
            //        {

            //            MessageBox.Show("El cliente se actualizó correctamente",
            //            "cliente Guardado",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);
            //            CargarVentas();
            //            ConfigurarDGV();
            //        }
            //    }
            //}
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
            dgvListar.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvListar.GridColor = dgvListar.BackgroundColor;

            // Eliminar divisores entre columnas del header
            dgvListar.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // Cambiar el color de fondo, de la letra y el tamaño de fuente de la fila del header
            dgvListar.EnableHeadersVisualStyles = false;
            dgvListar.ColumnHeadersDefaultCellStyle.BackColor = Tema.ColorFondo;
            dgvListar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvListar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Colorear alternando las filas
            dgvListar.RowsDefaultCellStyle.BackColor = Color.White;
            dgvListar.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Eliminar la columna de seleccion y configurar los modos de seleccion
            dgvListar.RowHeadersVisible = false;
            dgvListar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListar.MultiSelect = false;
            dgvListar.ColumnHeadersDefaultCellStyle.SelectionBackColor = Tema.ColorFondo;
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
                    btnEditar.PerformClick();
                }

                if (e.Control && e.KeyCode == Keys.F)
                {
                    // Control F para buscar usuarios
                    txtBuscar.Focus();
                }

                // Supr para habilitar/deshabilitar el usuario
                if (e.KeyCode == Keys.Delete)
                {
                    btnAnular.PerformClick();
                }
            };
        }

        private void VentaMianMenu_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
            this.ConfigurarAtajos();
        }
    }
}
