using System.ComponentModel;
using System.Globalization;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.controller.reparaciones;
using GestionVentasCel.enumerations.persona;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.reparacion;
using GestionVentasCel.models.ventas;
using GestionVentasCel.service.usuario;
using GestionVentasCel.service.venta;
using GestionVentasCel.temas;
using GestionVentasCel.views.usuario_empleado;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GestionVentasCel.views.ventas
{
    public partial class AgregarEditarVentaForm : Form
    {
        public Venta _venta;
        private bool _editando;
        private BindingSource _bindingSource;
        private readonly IVentaService _service;
        private readonly IServiceProvider _serviceProvider;
        private readonly ClienteController _clienteController;
        private readonly SesionUsuario _sesionUsuario;
        private DetalleVenta _detalleActual;
        public AgregarEditarVentaForm(
            IVentaService ventaService,
            ClienteController clienteController,
            SesionUsuario sesionUsuario,
            IServiceProvider serviceProvider,
            Venta? venta = null
        )
        {
            InitializeComponent();
            _service = ventaService;
            _editando = venta != null;
            _venta = venta ?? new Venta();
            _clienteController = clienteController;
            _sesionUsuario = sesionUsuario;
            _serviceProvider = serviceProvider;

            // Siempre hay que guardar qué usuario autorizó la venta o la edición
            _venta.UsuarioId = _sesionUsuario.Id;

            this.ConfigurarBindings();
            this.InicializarCombos();
            this.ConfigurarDGVDetalles();
            this.ConfigurarEstilosVisuales();

            if (_editando)
            {
                // Hay que mostrar el selector de estado unicamente cuando se lo edita a la venta
                panelEstado.Visible = true;
                this.comboTipoPago.SelectedItem = _venta.TipoPago.ToString();
                this.CalcularTotales();
            } else
            {
                panelEstado.Visible = false;
            }

        }

        private void ConfigurarDGVDetalles()
        {
            _bindingSource.DataSource = _venta.Detalles;

            dgvListarDetalles.DataSource = _bindingSource;

            // Agregar todas las columnas formateadas
            if (dgvListarDetalles.Columns["Detalle"] == null)
            {
                dgvListarDetalles.Columns.Add("Detalle", "Detalle");
            }

            if (dgvListarDetalles.Columns["PrecioUnitarioFormateado"] == null)
            {
                dgvListarDetalles.Columns.Add("PrecioUnitarioFormateado", "Precio unitario");
            }

            if (dgvListarDetalles.Columns["SubtotalSinIVAFormateado"] == null)
            {
                dgvListarDetalles.Columns.Add("SubtotalSinIVAFormateado", "Subtotal sin IVA");
            }

            if (dgvListarDetalles.Columns["PorcentajeIVAFormateado"] == null)
            {
                dgvListarDetalles.Columns.Add("PorcentajeIVAFormateado", "Porcentaje IVA");
            }

            if (dgvListarDetalles.Columns["SubtotalConIVAFormateado"] == null)
            {
                dgvListarDetalles.Columns.Add("SubtotalConIVAFormateado", "Subtotal con IVA");
            }

            foreach (DataGridViewColumn col in dgvListarDetalles.Columns)
            {
                // tiene tantas columnas el modelo que es más facil ocultarlas todas
                // y despues mostrar las que se necesitan nomas
                col.Visible = false;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dgvListarDetalles.Columns["Detalle"].Visible = true;
            dgvListarDetalles.Columns["Detalle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvListarDetalles.Columns["Cantidad"].Visible = true;
            dgvListarDetalles.Columns["PrecioUnitarioFormateado"].Visible = true;
            dgvListarDetalles.Columns["SubtotalSinIVAFormateado"].Visible = true;
            dgvListarDetalles.Columns["PorcentajeIVAFormateado"].Visible = true;
            dgvListarDetalles.Columns["SubtotalConIVAFormateado"].Visible = true;


            dgvListarDetalles.DataBindingComplete += (s, e) =>
            {
                // Una vez que se termine de bindear, hay que ordernar las columnas y formatearlas
                dgvListarDetalles.Columns["Detalle"].DisplayIndex = 0;
                dgvListarDetalles.Columns["Cantidad"].DisplayIndex = 1;
                dgvListarDetalles.Columns["PrecioUnitarioFormateado"].DisplayIndex = 2;
                dgvListarDetalles.Columns["SubtotalSinIVAFormateado"].DisplayIndex = 3;
                dgvListarDetalles.Columns["PorcentajeIVAFormateado"].DisplayIndex = 4;
                dgvListarDetalles.Columns["SubtotalConIvaFormateado"].DisplayIndex = 5;

                foreach (DataGridViewRow row in dgvListarDetalles.Rows)
                {
                    if (row.DataBoundItem is DetalleVenta detalle)
                    {
                        row.Cells["Detalle"].Value = detalle.EsArticulo ?
                            detalle.Articulo!.Nombre.ToString() : detalle.Reparacion!.Detalle;

                        row.Cells["PrecioUnitarioFormateado"].Value = detalle.PrecioUnitario.ToString("C2", new CultureInfo("es-AR"));
                        row.Cells["SubtotalSinIVAFormateado"].Value = detalle.SubtotalSinIva.ToString("C2", new CultureInfo("es-AR"));
                        row.Cells["PorcentajeIVAFormateado"].Value = detalle.PorcentajeIva.ToString("P2");
                        row.Cells["SubtotalConIVAFormateado"].Value = detalle.SubtotalConIva.ToString("C2", new CultureInfo("es-AR"));
                    }
                }
            };

        }
        private void InicializarCombos()
        {

            // Cargar clientes
            var clientesActivos = _clienteController.ObtenerClientes().Where(c => c.Activo).ToList();
            comboCliente.DisplayMember = "DniNombre";
            comboCliente.ValueMember = "Id";
            comboCliente.DataSource = clientesActivos;
            comboCliente.SelectedIndex = 0;

            comboEstado.DataSource = Enum.GetValues(typeof(EstadoVentaEnum));
            comboEstado.SelectedItem = _venta.EstadoVenta;

            comboCliente.SelectedItem = _venta.Cliente;
            comboTipoPago.SelectedItem = _venta.TipoPago;


            // Binding al modelo
            comboEstado.DataBindings.Add("SelectedValue", _venta, "EstadoVenta", true, DataSourceUpdateMode.OnPropertyChanged);
            comboCliente.DataBindings.Add("SelectedValue", _venta, "ClienteId", true, DataSourceUpdateMode.OnPropertyChanged);
            comboTipoPago.DataBindings.Add("SelectedItem", _venta, "TipoPago", true, DataSourceUpdateMode.OnPropertyChanged);

            comboCliente.SelectedValueChanged += (s, e) =>
            {
                if (comboCliente.SelectedValue is int clienteId)
                {
                    comboTipoPago.DataSource = _service.ObtenerMediosDePagoDisponibles(clienteId);
                    comboTipoPago.SelectedItem = _venta.TipoPago;

                    //TODO: Recorrer los detalles y eliminar todas las reparaciones.
                }
            };

            if (comboCliente.SelectedValue is int primerClienteId)
            {
                comboTipoPago.DataSource = _service.ObtenerMediosDePagoDisponibles(primerClienteId);
                comboTipoPago.SelectedItem = _venta.TipoPago;

            }
        }

        public void ConfigurarBindings()
        {
            // Inicializar BindingSource
            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _venta;

        }
        private void btnDescartar_Click(object sender, EventArgs e)
        {
            var accion = MessageBox.Show(
                "Está por descartar la venta, ¿Desea guardar un borrador para seguir más tarde?",
                "Descartando cambios",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Exclamation);

            if (accion == DialogResult.Yes)
            {
                this.GuardarBorrador();
                this.DialogResult = DialogResult.Yes;
            }
            else if (accion == DialogResult.No)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                return;
            }
        }

        public void GuardarBorrador()
        {
            if (ValidarVenta())
            {
                _venta.EstadoVenta = EstadoVentaEnum.Borrador;
                _service.AgregarVenta(_venta);
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

            // Configuración del DGV. Esto se puede hacer en el diseñador, pero acá queda mas visible el código

            // Eliminar divisores entre columnas y filas
            dgvListarDetalles.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvListarDetalles.GridColor = dgvListarDetalles.BackgroundColor;

            // Eliminar divisores entre columnas del header
            dgvListarDetalles.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // Cambiar el color de fondo, de la letra y el tamaño de fuente de la fila del header
            dgvListarDetalles.EnableHeadersVisualStyles = false;
            dgvListarDetalles.ColumnHeadersDefaultCellStyle.BackColor = Tema.ColorFondo;
            dgvListarDetalles.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvListarDetalles.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Colorear alternando las filas
            dgvListarDetalles.RowsDefaultCellStyle.BackColor = Color.White;
            dgvListarDetalles.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Eliminar la columna de seleccion y configurar los modos de seleccion
            dgvListarDetalles.RowHeadersVisible = false;
            dgvListarDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListarDetalles.MultiSelect = false;
            dgvListarDetalles.ColumnHeadersDefaultCellStyle.SelectionBackColor = Tema.ColorFondo;


        }

        private void AgregarEditarVentaForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.btnDescartar.PerformClick();
        }

        private bool ValidarVenta()
        {
            if (comboCliente.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboCliente.Focus();
                return false;
            }

            if (comboTipoPago.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboTipoPago.Focus();
                return false;
            }


            if (_venta.Detalles == null || !_venta.Detalles.Any())
            {
                MessageBox.Show("Debe agregar al menos un detalle de venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _venta.TipoPago = (TipoPagoEnum)Enum.Parse(
                typeof(TipoPagoEnum),
                comboTipoPago.SelectedItem.ToString()
            );

            if (ValidarVenta())
            {
                if (_editando)
                {
                    _service.ActualizarVenta(_venta);
                    MessageBox.Show("La venta se actualizó correctamente", "Venta actualizada");

                    // Si se confirmó la venta, entonces hay que preguntar si facturarla, lo cual se encarga
                    // el form principal si el resultado de esta es YES
                    if (_venta.EstadoVenta == EstadoVentaEnum.Confirmada)
                    {
                        this.DialogResult = DialogResult.Yes;
                    }
                }
                else
                {
                    _service.AgregarVenta(_venta);
                    _service.ConfirmarVenta(_venta.Id);
                    MessageBox.Show("La venta se guardó correctamente", "Venta guardada");

                    this.DialogResult = DialogResult.OK;

                }
            }

        }

        private void AgregarArticulo()
        {
            _detalleActual = new DetalleVenta();
            Articulo? articuloSeleccionado = new Articulo();

            // Setear el IVA por defecto
            this.nupIVA.Value = _detalleActual.PorcentajeIva * 100;
            this.nupCantidad.Enabled = true;

            using (var form = new SeleccionarArticuloForm(_serviceProvider.GetRequiredService<ArticuloController>()))
            {
                var resultado = form.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    articuloSeleccionado = form._articuloSeleccionado!;

                    _detalleActual.Articulo = articuloSeleccionado;
                    _detalleActual.PrecioUnitario = articuloSeleccionado.Precio;

                    // Se tiene que mostrar también en el txtbox de detalle
                    this.txtDescripcionDetalle.Text = $"{articuloSeleccionado.Nombre} - {articuloSeleccionado.Precio.ToString("C2", new CultureInfo("es-AR"))}";
                }
            }
        }

        private void AgregarReparacion()
        {

            // Esta función no puede ejecutarse si no se ha seleccionado un cliente.

            if (comboCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un cliente antes de buscar sus reparaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.comboBoxTipoItem.SelectedIndex = -1;
                return;
            }

            _detalleActual = new DetalleVenta();
            Reparacion? reparacionSeleccionada = new Reparacion();

            // Setear el IVA por defecto
            this.nupIVA.Value = _detalleActual.PorcentajeIva * 100;
            // Deshabilitar la cantidad
            this.nupCantidad.Value = 1;
            this.nupCantidad.Enabled = false;

            using (var form = new SeleccionarReparacionForm(
                _serviceProvider.GetRequiredService<ReparacionController>(),
                idCliente: ((Cliente)this.comboCliente.SelectedItem).Id!))
            {
                var resultado = form.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    reparacionSeleccionada = form._reparacionSeleccionada!;

                    _detalleActual.Reparacion = reparacionSeleccionada;
                    _detalleActual.PrecioUnitario = reparacionSeleccionada.Total;

                    // Se tiene que mostrar también en el txtbox de detalle
                    this.txtDescripcionDetalle.Text = $"{reparacionSeleccionada.Detalle}";
                }
            }
        }

        private void comboBoxTipoItem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var seleccionado = comboBoxTipoItem.SelectedItem.ToString();

            if (seleccionado == "Artículo")
            {
                AgregarArticulo();
            }
            else
            {
                AgregarReparacion();
            }
        }

        private bool ValidarDetalle()
        {
            if (nupCantidad.Value < 1)
            {
                MessageBox.Show("La cantidad debe ser mayor o igual a 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nupCantidad.Focus();
                return false;
            }

            if (nupIVA.Value < 0)
            {
                MessageBox.Show("El IVA no puede ser negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nupIVA.Focus();
                return false;
            }

            if (_detalleActual == null)
            {
                MessageBox.Show("No ha seleccionado un item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool articuloAsignado = _detalleActual.Articulo != null;
            bool reparacionAsignada = _detalleActual.Reparacion != null;

            if ((!articuloAsignado && !reparacionAsignada) || (articuloAsignado && reparacionAsignada))
            {
                MessageBox.Show("Debe seleccionar un Artículo o una Reparación (solo uno).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (ValidarDetalle())
            {
                // Una vez obtenido el item, la cantidad y el IVA, se tienen que establecer IVA y Cantidad en el detalle,
                // porque el resto viene ya de los handlers de AgregarReparacion y AgregarArticulos

                _detalleActual.Cantidad = (int)nupCantidad.Value;
                _detalleActual.PorcentajeIva = nupIVA.Value / 100;
                DetalleVenta? detalleExistente = this._venta.Detalles
                    .FirstOrDefault(d =>
                        (d.Articulo != null && _detalleActual.Articulo != null && d.Articulo.Id == _detalleActual.Articulo.Id) ||
                        (d.Reparacion != null && _detalleActual.Reparacion != null && d.Reparacion.Id == _detalleActual.Reparacion.Id)
                    );


                if (detalleExistente != null)
                {
                    if (_detalleActual.EsArticulo)
                    {
                        // Ya existe el artículo, por lo que hayq ue sumarle nomás la cantidad
                        detalleExistente.Cantidad += _detalleActual.Cantidad;
                    }
                        
                    
                    detalleExistente.PorcentajeIva = _detalleActual.PorcentajeIva;
                }
                else
                {
                    this._venta.Detalles.Add(_detalleActual);
                }

            }

            this._bindingSource.ResetBindings(false);
            this.comboBoxTipoItem.SelectedIndex = -1;
            this.txtDescripcionDetalle.Text = String.Empty;
            this.nupCantidad.Value = 0;
            this.nupCantidad.Enabled = true;

            this.CalcularTotales();
        }

        private void CalcularTotales()
        {
            this.lblSubtotalSinIVA.Text = $"Subtotal sin IVA: {_venta.TotalSinIva.ToString("C2", new CultureInfo("es-AR"))}";
            this.lblTotalIVA.Text = $"IVA total: {_venta.IVATotal.ToString("C2", new CultureInfo("es-AR"))}";
            this.lblTotal.Text = $"Total: {_venta.TotalConIva.ToString("C2", new CultureInfo("es-AR"))}";
        }
        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvListarDetalles.CurrentRow == null)
                return;

            var detalle = dgvListarDetalles.CurrentRow.DataBoundItem as DetalleVenta;

            // Confirmación
            if (MessageBox.Show("Está seguro que quiere eliminar este detalle?",
                                "Confirmar eliminación",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) != DialogResult.Yes){
                return;
            }

            _venta.Detalles.Remove(detalle!);

            this._bindingSource.ResetBindings(false);
            this.CalcularTotales();
        }
    }
}
