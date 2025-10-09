using System.ComponentModel;
using System.Data;
using System.Globalization;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.models.ventas;
using GestionVentasCel.service.factura;
using GestionVentasCel.service.usuario;
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

            this.btnVerFactura.Visible = false;

        }

        //Se crea un bindingList de cliente y se lo agrega al DGV
        //El BindingList a diferencia del List, actualiza el DGV si hay un cambio en los Objetos
        //Se crea un bindingSource para poder filtrar entre usuarios activos e inactivos
        private void CargarVentas()
        {
            var listaVentas = _ventaService.ListarVentasConDetalles().ToList();

            _ventas = new BindingList<Venta>(listaVentas);

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _ventas;
            this.dgvListar.ClearSelection();


            AplicarFiltro();

        }

        private void ConfigurarDGV()
        {
            dgvListar.DataSource = _bindingSource;
            this.dgvListar.ClearSelection();

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

            if (dgvListar.Columns["TotalConIvaFormateado"] == null)
            {
                dgvListar.Columns.Add("TotalConIvaFormateado", "Total con IVA");
            }
            dgvListar.Columns["TotalConIvaFormateado"].Visible = true;



            dgvListar.DataBindingComplete += (s, e) =>
            {

                // Organizar el orden de las columnas despues de que se hayan bindeado todos los datos
                dgvListar.Columns["FechaCreacion"].DisplayIndex = 0;
                dgvListar.Columns["FechaVenta"].DisplayIndex = 1;
                dgvListar.Columns["EstadoVenta"].DisplayIndex = 2;
                dgvListar.Columns["Cliente"].DisplayIndex = 3;
                dgvListar.Columns["TipoPago"].DisplayIndex = 4;
                dgvListar.Columns["TotalConIvaFormateado"].DisplayIndex = 5;

                foreach (DataGridViewRow row in dgvListar.Rows)
                {
                    if (row.DataBoundItem is Venta venta)
                    {
                        row.Cells["TotalConIvaFormateado"].Value = venta.TotalConIva.ToString("C2", new CultureInfo("es-AR"));
                    }
                }

                this.dgvListar.ClearSelection();
            };


        }

        private void chkMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }


        private void AplicarFiltro()
        {

            // punto de partida: todos los usuarios
            IEnumerable<Venta> filtrados = _ventas;

            // filtro por Activo
            if (chkMostrarInactivos.Checked)
            {
                filtrados = filtrados.Where(u => u.EstadoVenta == enumerations.ventas.EstadoVentaEnum.Anulada);
            }
            else
            {
                filtrados = filtrados.Where(u => u.EstadoVenta != enumerations.ventas.EstadoVentaEnum.Anulada);
            }


            string filtro = txtBuscar.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filtro))
            {
                filtrados = filtrados.Where(u =>
                    u.Cliente.Nombre.ToLower().Contains(filtro)
                    || u.FechaCreacion.ToString().ToLower().Contains(filtro)
                    || (u.FechaVenta.HasValue && u.FechaVenta.Value.ToString().ToLower().Contains(filtro))

                );
            }

            // asignar al BindingSource
            _bindingSource.DataSource = new BindingList<Venta>(filtrados.ToList());
            this.dgvListar.ClearSelection();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var form = new AgregarEditarVentaForm(
                clienteController: _serviceProvider.GetRequiredService<ClienteController>(),
                ventaService: _serviceProvider.GetRequiredService<IVentaService>(),
                sesionUsuario: _serviceProvider.GetRequiredService<SesionUsuario>(),
                serviceProvider: _serviceProvider
            ))
            {

                // OK => Venta guardada, ya sea por edición o por guardado, pero NO CONFIRMADA
                // Retry => Venta guardada como borrador, porque no estaba abierta la caja
                // YES => Venta confirmada, ya sea por guardado o por edición.
                // Cancel => Se canceló el guardado, no hace falta hacer nada

                var resultado = form.ShowDialog();

                if (resultado == DialogResult.Yes) // Si la venta se guardó, pero no se confirmó.
                {

                    Factura fac = _serviceProvider.GetRequiredService<IFacturaService>().EmitirFactura(form._venta);
                    var mostrarFactura = MessageBox.Show(
                        "Se emitió la factura de la venta. ¿Desea verla?",
                        "Factura emitida",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    ) == DialogResult.Yes;

                    if (mostrarFactura)
                    {
                        using (VerDetalleFacturaForm detalleFactura = new VerDetalleFacturaForm(fac))
                        {
                            detalleFactura.ShowDialog();
                        }
                    }
                }
            }
            CargarVentas();
            ConfigurarDGV();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (dgvListar.CurrentRow != null)
            {
                int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;

                // Asegurarse de que no haya tracking, porque el actualizar se va a romper si no
                var venta = _ventaService.ObtenerVentaPorIdConDetallesNoTracking(id);
                if (venta == null)
                {
                    MessageBox.Show("La venta no fue encontrada",
                        "Venta no encontrada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (venta.EstadoVenta == enumerations.ventas.EstadoVentaEnum.Facturada)
                {
                    MessageBox.Show("No puede editarse una venta que esté facturada.",
                        "Venta ya facturada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                using (var editarVenta = new AgregarEditarVentaForm(
                    serviceProvider: _serviceProvider,
                    ventaService: _serviceProvider.GetRequiredService<IVentaService>(),
                    clienteController: _serviceProvider.GetRequiredService<ClienteController>(),
                    sesionUsuario: _serviceProvider.GetRequiredService<SesionUsuario>(),
                    venta: venta
                ))
                {
                    var resultado = editarVenta.ShowDialog();
                    //si el usuario apreta guardar, muestra el msj y actualiza el binding
                    if (resultado == DialogResult.OK)
                    {

                        MessageBox.Show("La venta se actualizó correctamente",
                        "Venta guardada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    else if (resultado == DialogResult.Yes)
                    {
                        Factura fac = _serviceProvider.GetRequiredService<IFacturaService>().EmitirFactura(venta);
                        var mostrarFactura = MessageBox.Show(
                            "Se emitió la factura de la venta. ¿Desea verla?",
                            "Factura emitida",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        ) == DialogResult.Yes;

                        if (mostrarFactura)
                        {
                            using (VerDetalleFacturaForm detalleFactura = new VerDetalleFacturaForm(fac))
                            {
                                detalleFactura.ShowDialog();
                            }
                        }
                    }
                }
                CargarVentas();
                ConfigurarDGV();
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
                if (e.Control && e.KeyCode == Keys.D)
                {
                    // Control D para ver detalles
                    btnVerDetalles.PerformClick();
                }

                if (e.Control && e.KeyCode == Keys.F)
                {
                    // Control F para buscar usuarios
                    txtBuscar.Focus();
                }
            };
        }

        private void VentaMianMenu_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
            this.ConfigurarAtajos();
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            if (dgvListar.CurrentRow != null)
            {
                int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;

                // Asegurarse de que no haya tracking, porque el actualizar se va a romper si no
                var venta = _ventaService.ObtenerVentaPorIdConDetallesNoTracking(id);
                if (venta == null)
                {
                    MessageBox.Show("La venta no fue encontrada",
                        "Venta no encontrada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                using (var formDetalle = new VerDetalleVentaForm(venta))
                {
                    formDetalle.ShowDialog();
                }
            }
        }

        private void btnVerFactura_Click(object sender, EventArgs e)
        {
            if (dgvListar.CurrentRow != null)
            {
                int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;

                // Asegurarse de que no haya tracking, porque el actualizar se va a romper si no
                var venta = _ventaService.ObtenerVentaPorIdConDetallesNoTracking(id);
                if (venta == null)
                {
                    MessageBox.Show("La venta no fue encontrada",
                        "Venta no encontrada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                var factura = _ventaService.ObtenerFacturaDeVenta(venta);
                if (factura == null)
                {
                    MessageBox.Show("La factura no fue encontrada",
                        "Factura no encontrada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
                using (var formDetalle = new VerDetalleFacturaForm(factura))
                {
                    formDetalle.ShowDialog();
                }
            }
        }

        private void dgvListar_SelectionChanged(object sender, EventArgs e)
        {
            // Ver si la venta seleccionada está facturada, y mostrar el botón de ver factura
            this.btnVerFactura.Visible = ((Venta)this.dgvListar.CurrentRow.DataBoundItem).EstadoVenta == EstadoVentaEnum.Facturada;
        }
    }
}
