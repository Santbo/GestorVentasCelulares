using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.categoria;
using GestionVentasCel.controller.servicio;
using GestionVentasCel.enumerations.modoForms;
using GestionVentasCel.exceptions.servicio;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.categoria;
using GestionVentasCel.models.compra;
using GestionVentasCel.models.servicio;
using GestionVentasCel.views.categoria;


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
    }
}
