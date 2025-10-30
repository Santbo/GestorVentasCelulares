using System.ComponentModel;
using System.Data;
using System.Globalization;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.controller.reparaciones;
using GestionVentasCel.controller.servicio;
using GestionVentasCel.enumerations.reparacion;
using GestionVentasCel.enumerations.usuarios;
using GestionVentasCel.exceptions.servicio;
using GestionVentasCel.models.reparacion;
using GestionVentasCel.service.usuario;
using GestionVentasCel.temas;
using GestionVentasCel.views.compra;
using GestionVentasCel.views.reparacion;


namespace GestionVentasCel.views.servicio
{
    public partial class ReparacionMainMenuForm : Form
    {
        private readonly ReparacionController _reparacionController;
        private readonly ClienteController _clienteController;
        private readonly ServicioController _servicioController;
        private readonly ArticuloController _articuloController;

        private readonly SesionUsuario _sesionUsuario;

        private BindingList<Reparacion> _reparacion;
        private BindingSource _bindingSource;
        public ReparacionMainMenuForm(ReparacionController reparacionController,
                                        ClienteController clienteController,
                                        ServicioController servicioController,
                                        ArticuloController articuloController,
                                        SesionUsuario sesionUsuario
                                        )
        {
            InitializeComponent();
            _reparacionController = reparacionController;
            _clienteController = clienteController;
            _servicioController = servicioController;
            _articuloController = articuloController;
            _sesionUsuario = sesionUsuario;

            btnEditar.Enabled = _sesionUsuario.Rol == RolEnum.Admin || _sesionUsuario.Rol == RolEnum.Tecnico;
            btnEditar.Visible = _sesionUsuario.Rol == RolEnum.Admin || _sesionUsuario.Rol == RolEnum.Tecnico;

            btnCambiarEstado.Enabled = _sesionUsuario.Rol == RolEnum.Admin || _sesionUsuario.Rol == RolEnum.Tecnico;
            btnCambiarEstado.Visible = _sesionUsuario.Rol == RolEnum.Admin || _sesionUsuario.Rol == RolEnum.Tecnico;


            btnEstadoReparacion.Enabled = _sesionUsuario.Rol == RolEnum.Admin || _sesionUsuario.Rol == RolEnum.Tecnico;
            btnEstadoReparacion.Visible = _sesionUsuario.Rol == RolEnum.Admin || _sesionUsuario.Rol == RolEnum.Tecnico;

            btnEstadoReparacion.Enabled = _sesionUsuario.Rol == RolEnum.Admin || _sesionUsuario.Rol == RolEnum.Tecnico;
            btnEstadoReparacion.Visible = _sesionUsuario.Rol == RolEnum.Admin || _sesionUsuario.Rol == RolEnum.Tecnico;

            btnDetalle.Enabled = _sesionUsuario.Rol == RolEnum.Admin || _sesionUsuario.Rol == RolEnum.Tecnico;
            btnDetalle.Visible = _sesionUsuario.Rol == RolEnum.Admin || _sesionUsuario.Rol == RolEnum.Tecnico;


            CargarReparaciones();
        }

        private void CargarReparaciones()
        {
            var listaReparaciones = _reparacionController.ListarReparaciones().ToList();
            switch (_sesionUsuario.Rol)
            {
                case RolEnum.Tecnico:
                    listaReparaciones = listaReparaciones.Where(r => r.Estado < EstadoReparacionEnum.Terminado).ToList();
                    break;
                case RolEnum.Admin:
                    break;
                case RolEnum.Vendedor:
                    listaReparaciones = listaReparaciones
                        .Where(r => 
                            r.Estado == EstadoReparacionEnum.Ingresado ||
                            r.Estado == EstadoReparacionEnum.Terminado
                        ).ToList();
                    break;

            }
            _reparacion = new BindingList<Reparacion>(listaReparaciones);

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _reparacion;

            AplicarFiltro();

            dgvListar.DataSource = _bindingSource;

            dgvListar.DataBindingComplete += (s, e) =>
            {

                if (dgvListar.Columns["TotalFormateado"] == null)
                {
                    dgvListar.Columns.Add("TotalFormateado", "Total");
                }
                if (dgvListar.Columns["Cliente"] == null)
                {
                    dgvListar.Columns.Add("Cliente", "Cliente");
                }
                if (dgvListar.Columns["FechaVencimientoFormateado"] == null)
                {
                    dgvListar.Columns.Add("FechaVencimientoFormateado", "Fecha de vencimiento");
                }
                // Ocultar Id y Articulos
                dgvListar.Columns["Id"].Visible = false;
                dgvListar.Columns["DispositivoId"].Visible = false;
                dgvListar.Columns["ReparacionServicios"].Visible = false;
                dgvListar.Columns["Total"].Visible = false;
                dgvListar.Columns["FechaVencimiento"].Visible = false;
                dgvListar.Columns["EstaVencida"].Visible = false;
                dgvListar.Columns["Detalle"].Visible = false;


                // Ordenarlas 
                dgvListar.Columns["Dispositivo"].DisplayIndex = 1;
                dgvListar.Columns["Dispositivo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvListar.Columns["Cliente"].DisplayIndex = 2;
                dgvListar.Columns["FallasReportadas"].DisplayIndex = 3;

                dgvListar.Columns["Diagnostico"].DisplayIndex = 4;
                dgvListar.Columns["FechaIngreso"].DisplayIndex = 5;
                dgvListar.Columns["FechaEgreso"].DisplayIndex = 6;
                dgvListar.Columns["FechaVencimientoFormateado"].DisplayIndex = 7;
                dgvListar.Columns["TotalFormateado"].DisplayIndex = 8;
                dgvListar.Columns["Estado"].DisplayIndex = 9;
                dgvListar.Columns["Activo"].DisplayIndex = 10;
                dgvListar.Columns["Activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                foreach (DataGridViewRow row in dgvListar.Rows)
                {
                    if (row.DataBoundItem is Reparacion reparacion)
                    {
                        // formatear el precio como moneda
                        row.Cells["TotalFormateado"].Value = reparacion.Total.ToString("C2", new CultureInfo("es-AR"));
                        row.Cells["Cliente"].Value = reparacion.Dispositivo.Cliente.ToString();
                        row.Cells["FechaVencimientoFormateado"].Value = reparacion.FechaVencimiento?.ToString("dd/MM/yyyy");

                        if (reparacion.EstaVencida)
                        {

                            row.Cells["FechaVencimientoFormateado"].Value += "   ❗";
                            row.Cells["FechaVencimientoFormateado"].Style.ForeColor = Color.Red;

                        }
                    }

                    ;
                }
                ;

            };
        }

        private void AplicarFiltro()
        {

            // punto de partida: todos los usuarios
            IEnumerable<Reparacion> filtrados = _reparacion;

            // filtro por Activo
            if (!chkInactivos.Checked)
                filtrados = filtrados.Where(u => u.Activo);

            // filtro por búsqueda
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filtro))
            {
                filtrados = filtrados.Where(r =>
                                r.Estado.ToString().ToLower().Contains(filtro) ||
                                r.FechaIngreso.ToString().ToLower().Contains(filtro) ||
                                r.Dispositivo.Nombre.ToLower().Contains(filtro) ||
                                r.Dispositivo.Cliente.ToString().ToLower().Contains(filtro)
                            );
            }

            // asignar al BindingSource
            _bindingSource.DataSource = new BindingList<Reparacion>(filtrados.ToList());
        }

        private void chkInactivos_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (dgvListar.CurrentRow != null)
            {

                if (dgvListar.CurrentRow.DataBoundItem is Reparacion r)
                {
                    if (r.Activo == false)
                    {
                       MessageBox.Show(
                            "La reparación ya está cancelada",
                            "Confirmación",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error
                        );
                        return;
                    }

                    if (!(r.Estado == EstadoReparacionEnum.Ingresado || r.Estado == EstadoReparacionEnum.Reparando))
                    {
                        MessageBox.Show(
                             "Solo pueden cancelarse reparaciones que estén ingresadas o en reparación.",
                             "Confirmación",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error
                         );
                        return;
                    }
                }

                int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;

                var result = MessageBox.Show(
                    "¿Seguro que desea cancelar esta reparacion?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No) return;

                // Actualizo en la BD
                _reparacionController.Desactivar(id);

                // Actualizo en memoria
                var servicio = _reparacion.FirstOrDefault(u => u.Id == id);
                if (servicio != null)
                    servicio.Activo = false;

                // Reaplico el filtro inmediatamente
                AplicarFiltro();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            using (var agregarReparacion = new AgregarEditarReparacionForm(
                _reparacionController,
                _clienteController,
                _servicioController,
                _articuloController,
                _sesionUsuario
                ))
            {
                //si el usuario apreta guardar, muestra el msj y actualiza el binding
                if (agregarReparacion.ShowDialog() == DialogResult.OK)
                {

                    MessageBox.Show("La reparación se guardó correctamente",
                    "Reparacion Guardada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                    CargarReparaciones();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (dgvListar.CurrentRow != null)
            {
                int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;
                try
                {

                    var reparacion = _reparacionController.ObtenerPorId(id);

                    using (var editarReparacion = new AgregarEditarReparacionForm(
                        _reparacionController,
                        _clienteController,
                        _servicioController,
                        _articuloController,
                        _sesionUsuario
                        ))
                    {

                        editarReparacion.reparacionActual = reparacion;
                        //si el usuario apreta guardar, muestra el msj y actualiza el binding
                        if (editarReparacion.ShowDialog() == DialogResult.OK)
                        {

                            MessageBox.Show("La Reparacion se actualizó correctamente",
                            "Reparacion Guardada",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                            CargarReparaciones();
                        }
                    }
                }
                catch (ServicioNoEncontradoException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show("Primero debe Seleccionar una Reparacion",
                        "Seleccione una Reparacion",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
        }

        private void btnEstadoReparacion_Click(object sender, EventArgs e)
        {
            if (dgvListar.CurrentRow != null)
            {
                int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;

                var result = MessageBox.Show(
                    "¿Seguro que desea cambiar el Estado de esta Reparacion?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No) return;

                var reparacion = _reparacionController.ObtenerPorId(id);

                if (reparacion.Estado == EstadoReparacionEnum.Entregado)
                {
                    MessageBox.Show(
                    "No se puede cambiar el estado de un Dispositivo Entregado",
                    "Validacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );

                    return;
                }

                if (reparacion.EstaVencida)
                {
                    // Si está vencida, hay que avisarle al usuario que no se puede cambiar hasta que se actualicen los precios
                    var accion = MessageBox.Show(
                        "Esta reparación está vencida. Para cambiar de estado, deben recalcularse los precios. ¿Quiere recalcularlos?",
                        "Reparación vencida",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (accion == DialogResult.Yes)
                    {
                        // Esto no debería ser así, realmente debería haber un método en el service para hacer esto, 
                        // pero como la lógica de calcular está en la UI, es mas facil llamar a la ui
                        _reparacionController.RecalcularReparacion(reparacion.Id);
                        CargarReparaciones();
                    }
                }
                else
                {
                    // Actualizo en la BD
                    // Si se la está reparando, tambien se saca la fecha de vencimiento
                    var estadoActual = reparacion.Estado;
                    if (estadoActual != EstadoReparacionEnum.Entregado)
                    {
                        _reparacionController.CambiarEstado(id, reparacion.Estado + 1);
                    }
                }

                CargarReparaciones();
                AplicarFiltro();


            }
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

                if (e.Control && e.KeyCode == Keys.U)
                {
                    // Control U para actualizar el usuario
                    btnEditar.PerformClick();
                }
                if (e.Control && e.KeyCode == Keys.N)
                {
                    // Control U para actualizar el usuario
                    btnAdd.PerformClick();
                }

                if (e.Control && e.KeyCode == Keys.D)
                {
                    // Ver detalle
                    btnEstadoReparacion.PerformClick();
                }

                if (e.KeyCode == Keys.Delete)
                {
                    btnCambiarEstado.PerformClick();
                }


                if (e.Control && e.KeyCode == Keys.F)
                {
                    // Control F para buscar usuarios
                    txtBuscar.Focus();
                }

            };
        }

        private void ServicioMainMenuForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
            this.ConfigurarAtajos();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {

            if (dgvListar.CurrentRow != null)
            {
                int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;
                var reparacion = _reparacionController.ObtenerPorIdConCliente(id);
                var detalleReparacion = new VerDetallesReparacionForm(_servicioController, reparacion);
                detalleReparacion.ShowDialog();
            }
        }

        private void dgvListar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListar.CurrentRow != null && dgvListar.CurrentRow.DataBoundItem is Reparacion r)
            {
                btnEditar.Enabled = r.Estado == EstadoReparacionEnum.Ingresado;
            }
        }
    }
}
