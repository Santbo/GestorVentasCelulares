using System.ComponentModel;
using System.Data;
using System.Globalization;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.controller.reparaciones;
using GestionVentasCel.controller.servicio;
using GestionVentasCel.exceptions.reparacion;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.reparacion;
using GestionVentasCel.models.servicio;

namespace GestionVentasCel.views.reparacion
{
    public partial class AgregarEditarReparacionForm : Form
    {
        private readonly ClienteController _clienteController;
        private readonly ReparacionController _reparacionController;
        private readonly ServicioController _servicioController;
        private readonly ArticuloController _articuloController;
        private BindingList<Dispositivo> _listaDispositivo = new BindingList<Dispositivo>();
        private BindingList<ReparacionServicio> _listaServicioAgregado = new BindingList<ReparacionServicio>();
        private List<Servicio> serviciosAgregados = new List<Servicio>();
        public Reparacion reparacionActual { get; set; }
        private decimal _total { get; set; }
        public AgregarEditarReparacionForm(ReparacionController reparacionController,
                                          ClienteController clienteController,
                                          ServicioController servicioController,
                                          ArticuloController articuloController)
        {
            InitializeComponent();
            _clienteController = clienteController;
            _reparacionController = reparacionController;
            _servicioController = servicioController;
            _articuloController = articuloController;

            CargarCombobox();
            CargarGridServicios();
        }


        private void CargarCombobox()
        {
            var listaCliente = _clienteController.ObtenerClientes().Where(c => c.Activo == true).ToList();
            var listaServicio = _servicioController.GetAll().ToList();

            cmbCliente.DataSource = listaCliente;
            cmbCliente.DisplayMember = "NombreCompleto";
            cmbCliente.ValueMember = "Id";

            var sourceCliente = new AutoCompleteStringCollection();
            sourceCliente.AddRange(listaCliente.Select(c => c.NombreCompleto).ToArray());

            cmbCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbCliente.AutoCompleteCustomSource = sourceCliente;

            cmbServicio.DataSource = listaServicio;
            cmbServicio.DisplayMember = "Nombre";
            cmbServicio.ValueMember = "Id";

            var sourceServicio = new AutoCompleteStringCollection();
            sourceServicio.AddRange(listaServicio.Select(s => s.Nombre).ToArray());

            cmbServicio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbServicio.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbServicio.AutoCompleteCustomSource = sourceServicio;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDataGrid();
        }

        private void CargarDataGrid()
        {

            if (cmbCliente.SelectedItem is Cliente clienteSeleccionado)
            {
                var listaDispositivo = _reparacionController.ObtenerDispositivoPorCliente(clienteSeleccionado.Id).ToList();
                if (listaDispositivo == null)
                {
                    MessageBox.Show("El cliente no posee dispositivos vinculados. Agrega uno nuevo.", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _listaDispositivo = new BindingList<Dispositivo>(listaDispositivo);




                dgvListarDispositivos.DataSource = _listaDispositivo;
                dgvListarDispositivos.Columns["Id"].Visible = false;
                dgvListarDispositivos.Columns["ClienteId"].Visible = false;
                dgvListarDispositivos.Columns["Cliente"].Visible = false;
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {

            _total = 0;

            if (dgvListarServicios.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un servicio.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                return;
            }


            if (!ValidarCampos())
            {
                return;
            }
            foreach (var servicio in serviciosAgregados)
            {
                if (servicio is Servicio servicioSeleccionado)
                {
                    // Sumo artículos usados por el servicio
                    var articulosUsados = _servicioController.GetServicioConArticulos(servicioSeleccionado.Id);

                    foreach (var articulo in articulosUsados.ArticulosUsados)
                    {
                        var articuloSeleccionado = _articuloController.GetById(articulo.ArticuloId);
                        _total += articuloSeleccionado.Precio * articulo.Cantidad;
                    }

                    // Sumo el precio base del servicio
                    _total += servicioSeleccionado.Precio;
                }
            }

            lblTotal.Text = $"TOTAL: {_total.ToString("C2", new CultureInfo("es-AR"))}";
            btnGuardar.Enabled = true;



        }

        private bool ValidarCampos()
        {
            if (!_listaDispositivo.Any())
            {
                MessageBox.Show("Debes tener al menos un Dispositivo en la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void AgregarEditarReparacionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {

                var result = MessageBox.Show(
                "¿Seguro que desea descartar los cambios?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancela el cierre
                }
            }
        }

        private void btnDescartar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (!(cmbCliente.SelectedItem is Cliente clienteSeleccionado))
            {
                MessageBox.Show("Seleccione un cliente primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var agregarDispositivo = new AgregarEditarDispositivoForm(_reparacionController))
            {


                agregarDispositivo.ClienteUtilizado = clienteSeleccionado;

                //si el usuario apreta guardar, muestra el msj y actualiza el binding
                if (agregarDispositivo.ShowDialog() == DialogResult.OK)
                {

                    MessageBox.Show("El Dispositivo se guardó correctamente.",
                    "Dispoisitivo Guardado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    CargarDataGrid();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvListarDispositivos.CurrentRow != null)
            {
                int id = (int)dgvListarDispositivos.CurrentRow.Cells["Id"].Value;
                try
                {
                    if (!(cmbCliente.SelectedItem is Cliente clienteSeleccionado))
                    {
                        MessageBox.Show("Seleccione un cliente primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var dispositivo = _reparacionController.GetDispositivoById(id);

                    using (var editarDispositivo = new AgregarEditarDispositivoForm(_reparacionController))
                    {
                        editarDispositivo.ClienteUtilizado = clienteSeleccionado;
                        editarDispositivo._dispositivo = dispositivo;
                        //si el usuario apreta guardar, muestra el msj y actualiza el binding
                        if (editarDispositivo.ShowDialog() == DialogResult.OK)
                        {

                            MessageBox.Show("El Dispositivo se actualizó correctamente",
                            "Dispositivo Guardado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                            CargarDataGrid();
                        }
                    }
                }
                catch (DispositivoNoEncontradoException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show("Primero debe Seleccionar un Dispositivo",
                        "Seleccione un Dispositivo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
        }

        private void AgregarEditarReparacionForm_Load(object sender, EventArgs e)
        {
            if (reparacionActual != null)
            {
                // Seleccionar cliente en combo
                var clienteId = reparacionActual.Dispositivo.ClienteId;
                cmbCliente.SelectedValue = clienteId;
                cmbCliente.Enabled = false;

                // Cargar solo el dispositivo de la reparación
                _listaDispositivo = new BindingList<Dispositivo>(
                    new List<Dispositivo> { reparacionActual.Dispositivo }
                );

                dgvListarDispositivos.DataSource = _listaDispositivo;
                dgvListarDispositivos.Columns["Id"].Visible = false;
                dgvListarDispositivos.Columns["ClienteId"].Visible = false;
                dgvListarDispositivos.Columns["Cliente"].Visible = false;

                // Cargar todos los servicios de la reparación en el DataGridView
                if (reparacionActual.ReparacionServicios != null && reparacionActual.ReparacionServicios.Any())
                {
                    var listaServicios = new BindingList<ReparacionServicio>(reparacionActual.ReparacionServicios.ToList());
                    foreach (var rs in listaServicios)
                    {
                        // Buscar servicio desde el combo ya cargado
                        var servicio = ((List<Servicio>)cmbServicio.DataSource)
                                        .FirstOrDefault(s => s.Id == rs.ServicioId);

                        if (servicio != null)
                        {
                            rs.Detalle = servicio.detalleServicio;
                            serviciosAgregados.Add(servicio);
                        }
                    }
                    _listaServicioAgregado = listaServicios;
                    CargarGridServicios();

                }

                // Mostrar total, fallas y diagnóstico
                lblTotal.Text = $"TOTAL: {reparacionActual.Total.ToString("C2", new CultureInfo("es-AR"))}";
                txtFallasReportadas.Text = reparacionActual.FallasReportadas;
                txtDiagnostico.Text = reparacionActual.Diagnostico;
                btnAgregar.Visible = false;


            }

            btnGuardar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (dgvListarDispositivos.CurrentRow != null)
            {
                int id = (int)dgvListarDispositivos.CurrentRow.Cells["Id"].Value;

                foreach (var servicioReparacion in _listaServicioAgregado)
                {
                    servicioReparacion.Servicio = null;
                }
                if (reparacionActual != null)
                {

                    reparacionActual.DispositivoId = id;
                    reparacionActual.ReparacionServicios = _listaServicioAgregado;
                    reparacionActual.Total = _total;
                    reparacionActual.FallasReportadas = txtFallasReportadas.Text;
                    reparacionActual.Diagnostico = txtDiagnostico.Text;


                    _reparacionController.ActualizarReparacion(reparacionActual);
                    this.DialogResult = DialogResult.OK;
                    this.Close();


                }
                else // Nueva reparación
                {

                    var nuevaReparacion = new Reparacion
                    {

                        DispositivoId = id,
                        ReparacionServicios = _listaServicioAgregado,
                        Total = _total,
                        FallasReportadas = txtFallasReportadas.Text,
                        Diagnostico = txtDiagnostico.Text,

                    };


                    _reparacionController.CrearReparacion(nuevaReparacion);
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
            }
            else
            {
                MessageBox.Show("Primero debe Seleccionar un Dispositivo",
                        "Seleccione un Dispositivo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
        }

        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            if (cmbServicio.SelectedItem is Servicio servicioSeleccionado)
            {


                // Verificar si ya existe ese artículo en la lista
                var existente = _listaServicioAgregado.FirstOrDefault(rs => rs.ServicioId == servicioSeleccionado.Id);

                if (existente != null)
                {
                    MessageBox.Show("El Servicio ya se encuentra agregado",
                            "Servicio Existente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                }
                else
                {
                    serviciosAgregados.Add(servicioSeleccionado);
                    var nuevo = new ReparacionServicio
                    {

                        Detalle = servicioSeleccionado.detalleServicio,
                        ServicioId = servicioSeleccionado.Id
                    };
                    _listaServicioAgregado.Add(nuevo);
                }
            }
        }

        private void CargarGridServicios()
        {
            dgvListarServicios.DataSource = _listaServicioAgregado;

            dgvListarServicios.Columns["Id"].Visible = false;
            dgvListarServicios.Columns["Reparacion"].Visible = false;
            dgvListarServicios.Columns["ReparacionId"].Visible = false;
            dgvListarServicios.Columns["Servicio"].Visible = false;
            dgvListarServicios.Columns["ServicioId"].Visible = false;

        }

        private void btnEliminarServicio_Click(object sender, EventArgs e)
        {
            if (dgvListarServicios.CurrentRow?.DataBoundItem is ReparacionServicio seleccionado)
            {
                _listaServicioAgregado.Remove(seleccionado);
                var elemento = serviciosAgregados.FirstOrDefault(s => s.Id == seleccionado.ServicioId);
                serviciosAgregados.Remove(elemento);
            }
        }
    }

}
