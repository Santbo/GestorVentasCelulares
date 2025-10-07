using System.ComponentModel;
using System.Data;
using GestionVentasCel.controller.servicio;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.servicio;

namespace GestionVentasCel.views.servicio
{
    public partial class AgregarEditarServicioForm : Form
    {
        private readonly ServicioController _servicioController;
        private readonly List<Articulo> _listaArticulo;
        private BindingList<ServicioArticulo> _listaArticulosAgregados = new BindingList<ServicioArticulo>();
        public Servicio ServicioActual { get; set; }
        public AgregarEditarServicioForm(ServicioController servicioController, List<Articulo> listaArticulo)
        {
            InitializeComponent();
            _servicioController = servicioController;
            _listaArticulo = listaArticulo;
            CargarComboBox();

        }

        private void AgregarEditarServicioForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void CargarComboBox()
        {
            cmbArticulos.DataSource = _listaArticulo;
            cmbArticulos.DisplayMember = "Detalle"; // lo que se ve
            cmbArticulos.ValueMember = "Id";            // lo que se guarda

            var source = new AutoCompleteStringCollection();
            source.AddRange(_listaArticulo.Select(a => a.Detalle).ToArray());

            cmbArticulos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbArticulos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbArticulos.AutoCompleteCustomSource = source;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (cmbArticulos.SelectedItem is Articulo articuloSeleccionado)
            {
                int cantidad = (int)numCantidad.Value;

                if (cantidad <= 0)
                {
                    MessageBox.Show("La cantidad no puede ser menor a 1.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar si ya existe ese artículo en la lista
                var existente = _listaArticulosAgregados.FirstOrDefault(sa => sa.ArticuloId == articuloSeleccionado.Id);

                if (existente != null)
                {
                    // Sumar cantidad
                    existente.Cantidad += cantidad;
                    dgvListarArticulos.Refresh();
                }
                else
                {
                    // Crear nuevo
                    var nuevo = new ServicioArticulo
                    {
                        ArticuloId = articuloSeleccionado.Id,
                        Detalle = articuloSeleccionado.Detalle, // opcional, para mostrar en grilla
                        Cantidad = cantidad
                    };
                    _listaArticulosAgregados.Add(nuevo);
                }
            }

        }

        private void CargarDataGrid()
        {
            dgvListarArticulos.DataSource = _listaArticulosAgregados;

            dgvListarArticulos.Columns["Id"].Visible = false;
            dgvListarArticulos.Columns["ArticuloId"].Visible = false;
            dgvListarArticulos.Columns["ServicioId"].Visible = false;
            dgvListarArticulos.Columns["Servicio"].Visible = false;
            dgvListarArticulos.Columns["Articulo"].Visible = false;


            dgvListarArticulos.Columns["Detalle"].DisplayIndex = 1;
            dgvListarArticulos.Columns["Cantidad"].DisplayIndex = 2;


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListarArticulos.CurrentRow?.DataBoundItem is ServicioArticulo seleccionado)
            {
                _listaArticulosAgregados.Remove(seleccionado);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (ValidarCampos())
            {

                foreach (var sa in _listaArticulosAgregados)
                {
                    sa.Articulo = null;
                }

                if (ServicioActual != null)
                {
                    ServicioActual.Nombre = txtNombre.Text;
                    ServicioActual.Precio = decimal.Parse(txtPrecio.Text);
                    ServicioActual.Descripcion = txtDescripcion.Text;
                    ServicioActual.ArticulosUsados = _listaArticulosAgregados;

                    _servicioController.ActualizarServicio(ServicioActual);

                }
                else
                {

                    _servicioController.AgregarServicio(txtNombre.Text,
                                                    decimal.Parse(txtPrecio.Text),
                                                    _listaArticulosAgregados.ToList(),
                                                    txtDescripcion.Text);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private bool ValidarCampos()
        {

            //valida textbox vacios
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is System.Windows.Forms.TextBox txt && string.IsNullOrWhiteSpace(txt.Text) && txt != txtDescripcion)
                {
                    MessageBox.Show("Por favor, completá todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt.Focus();
                    return false;
                }
            }
            //TODO: Eliminar detalleServicio del listado de servicios

            return true;
        }

        private void AgregarEditarServicioForm_Load(object sender, EventArgs e)
        {
            if (ServicioActual != null)
            {
                lblTitulo.Text = "Editar Servicio";
                txtNombre.Text = ServicioActual.Nombre;
                txtPrecio.Text = ServicioActual.Precio.ToString();
                txtDescripcion.Text = ServicioActual.Descripcion;

                var listaArticulos = ServicioActual.ArticulosUsados.ToList();



                _listaArticulosAgregados = new BindingList<ServicioArticulo>(listaArticulos);

                foreach (var articulo in _listaArticulosAgregados)
                {
                    var detalle = _listaArticulo.FirstOrDefault(a => a.Id == articulo.ArticuloId);
                    articulo.Detalle = detalle?.Detalle ?? "Sin detalle";
                }
                CargarDataGrid();
            }
            else
            {
                CargarDataGrid();
            }
        }


    }


}
