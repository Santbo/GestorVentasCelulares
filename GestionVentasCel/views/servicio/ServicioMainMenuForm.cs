using System.ComponentModel;
using System.Data;
using System.Globalization;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.servicio;
using GestionVentasCel.exceptions.servicio;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.servicio;
using GestionVentasCel.temas;
using GestionVentasCel.views.compra;


namespace GestionVentasCel.views.servicio
{
    public partial class ServicioMainMenuForm : Form
    {
        private readonly ServicioController _servicioController;
        private readonly ArticuloController _articuloController;
        private BindingList<Servicio> _servicios;
        private BindingSource _bindingSource;
        public ServicioMainMenuForm(ServicioController servicioController, ArticuloController articuloController)
        {
            InitializeComponent();
            _servicioController = servicioController;
            _articuloController = articuloController;
            CargarServicios();
        }

        private void CargarServicios()
        {
            var listaServicios = _servicioController.GetAll().ToList();
            _servicios = new BindingList<Servicio>(listaServicios);

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _servicios;

            AplicarFiltro();

            dgvListar.DataSource = _bindingSource;

            dgvListar.DataBindingComplete += (s, e) =>
            {

                if (dgvListar.Columns["PrecioFormateado"] == null)
                {
                    dgvListar.Columns.Add("PrecioFormateado", "Precio");
                }
                // Ocultar Id y Articulos
                dgvListar.Columns["Id"].Visible = false;
                dgvListar.Columns["ArticulosUsados"].Visible = false;
                dgvListar.Columns["Precio"].Visible = false;


                // Ordenarlas 
                dgvListar.Columns["Nombre"].DisplayIndex = 1;
                dgvListar.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvListar.Columns["PrecioFormateado"].DisplayIndex = 2;

                dgvListar.Columns["Descripcion"].DisplayIndex = 3;
                dgvListar.Columns["Activo"].DisplayIndex = 4;
                dgvListar.Columns["Activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                foreach (DataGridViewRow row in dgvListar.Rows)
                {
                    if (row.DataBoundItem is Servicio servicio)
                    {
                        // formatear el precio como moneda
                        row.Cells["PrecioFormateado"].Value = servicio.Precio.ToString("C2", new CultureInfo("es-AR"));
                    }
                    ;
                }
                ;

            };
        }

        private void AplicarFiltro()
        {

            // punto de partida: todos los usuarios
            IEnumerable<Servicio> filtrados = _servicios;

            // filtro por Activo
            if (!chkInactivos.Checked)
                filtrados = filtrados.Where(u => u.Activo);

            // filtro por búsqueda
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filtro))
            {
                filtrados = filtrados.Where(u =>
                    u.Nombre.ToLower().Contains(filtro));
            }

            // asignar al BindingSource
            _bindingSource.DataSource = new BindingList<Servicio>(filtrados.ToList());
        }

        private void chkInactivos_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (dgvListar.CurrentRow != null)
            {
                int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;

                var result = MessageBox.Show(
                    "¿Seguro que desea Habilitar/Deshabilitar este Servicio?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No) return;

                // Actualizo en la BD
                _servicioController.CambiarEstado(id);

                // Actualizo en memoria
                var servicio = _servicios.FirstOrDefault(u => u.Id == id);
                if (servicio != null)
                    servicio.Activo = !servicio.Activo;

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

            List<Articulo> listaArticulo = _articuloController.ObtenerArticulos().ToList();
            using (var agregarServicio = new AgregarEditarServicioForm(_servicioController, listaArticulo))
            {
                //si el usuario apreta guardar, muestra el msj y actualiza el binding
                if (agregarServicio.ShowDialog() == DialogResult.OK)
                {

                    MessageBox.Show("El servicio se guardó correctamente",
                    "Servicio Guardado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                    CargarServicios();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            List<Articulo> listaArticulo = _articuloController.ObtenerArticulos().ToList();
            if (dgvListar.CurrentRow != null)
            {
                int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;
                try
                {

                    var servicio = _servicioController.GetServicioConArticulos(id);

                    using (var editarServicio = new AgregarEditarServicioForm(_servicioController, listaArticulo))
                    {

                        editarServicio.ServicioActual = servicio;
                        //si el usuario apreta guardar, muestra el msj y actualiza el binding
                        if (editarServicio.ShowDialog() == DialogResult.OK)
                        {

                            MessageBox.Show("El Servicio se actualizó correctamente",
                            "Servicio Guardado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                            CargarServicios();
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
                MessageBox.Show("Primero debe Seleccionar un Servicio",
                        "Seleccione un Servicio",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
        }

        private void btnArticulosAsociados_Click(object sender, EventArgs e)
        {
            List<Articulo> listaArticulo = _articuloController.ObtenerArticulos().ToList();
            if (dgvListar.CurrentRow != null)
            {
                int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;
                try
                {

                    var servicio = _servicioController.GetServicioConArticulos(id);

                    using (var verArticulosAsociados = new VerArticulosAsociadosForm(_servicioController, servicio, listaArticulo))
                    {

                        //si el usuario apreta guardar, muestra el msj y actualiza el binding
                        if (verArticulosAsociados.ShowDialog() == DialogResult.OK)
                        {

                            CargarServicios();
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
                MessageBox.Show("Primero debe Seleccionar un Servicio",
                        "Seleccione un Servicio",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
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
                    btnArticulosAsociados.PerformClick();
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
    }
}
