using System.ComponentModel;
using System.Globalization;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.compra;
using GestionVentasCel.controller.proveedor;
using GestionVentasCel.models.categoria;
using GestionVentasCel.models.compra;

namespace GestionVentasCel.views.compra
{
    public partial class VerDetallesCompraForm : Form
    {
        private readonly Compra _compra;
        private readonly CompraController _compraController;
        private readonly ProveedorController _proveedorController;
        private readonly ArticuloController _articuloController;
        private BindingList<DetalleCompra> _detalleCompra;

        public VerDetallesCompraForm(Compra compra)
        {
            InitializeComponent();
            _compra = compra;
            CargarDatos();
        }

        public VerDetallesCompraForm(Compra compra,
                                   CompraController compraController,
                                   ProveedorController proveedorController,
                                   ArticuloController articuloController)
        {
            InitializeComponent();
            _compra = compra;
            _compraController = compraController;
            _proveedorController = proveedorController;
            _articuloController = articuloController;
            CargarDatos();
        }

        private void CargarDatos()
        {
            this.Text = $"Detalles de Compra - {_compra.Fecha:dd/MM/yyyy}";

            lblProveedor.Text = _compra.Proveedor?.Nombre ?? "N/A";
            lblFecha.Text = _compra.Fecha.ToString("dd/MM/yyyy HH:mm");
            lblTotal.Text = _compra.Total.ToString("C2", new CultureInfo("es-AR"));
            lblObservaciones.Text = _compra.Observaciones ?? "Sin observaciones";

            
            var _listaDetalle = _compra.Detalles.ToList();

            _detalleCompra = new BindingList<DetalleCompra>(_listaDetalle);

            dgvDetalles.DataSource = _detalleCompra;
            dgvDetalles.Columns["Id"].Visible = false;
            dgvDetalles.Columns["Compra"].Visible = false;
            dgvDetalles.Columns["CompraId"].Visible = false;
            dgvDetalles.Columns["ArticuloId"].Visible = false;
            dgvDetalles.Columns["PrecioUnitario"].Visible = false;
            dgvDetalles.Columns["Subtotal"].Visible = false;

            if (dgvDetalles.Columns["PrecioUnitarioFormateado"] == null)
            {
                dgvDetalles.Columns.Add("PrecioUnitarioFormateado", "PrecioUnitario");
            }

            if (dgvDetalles.Columns["SubtotalFormateado"] == null)
            {
                dgvDetalles.Columns.Add("SubtotalFormateado", "Subtotal");
            }

            dgvDetalles.DataBindingComplete += (s, e) =>
            {
                dgvDetalles.Columns["Articulo"].DisplayIndex = 1;
                dgvDetalles.Columns["Cantidad"].DisplayIndex = 2;
                dgvDetalles.Columns["PrecioUnitarioFormateado"].DisplayIndex = 3;
                dgvDetalles.Columns["SubtotalFormateado"].DisplayIndex = 4;

                foreach (DataGridViewRow row in dgvDetalles.Rows)
                {
                    if (row.DataBoundItem is DetalleCompra detalle)
                    {
                        // formatear el precio como moneda
                        row.Cells["PrecioUnitarioFormateado"].Value = detalle.PrecioUnitario.ToString("C2", new CultureInfo("es-AR"));
                        row.Cells["SubtotalFormateado"].Value = detalle.Subtotal.ToString("C2", new CultureInfo("es-AR"));
                    }
                    ;


                }
                ;


            };


        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            var compraCompleta = _compraController.GetByIdWithDetails(_compra.Id);
            if (compraCompleta != null)
            {
                var formEditar = new AgregarEditarCompraForm(_compraController, _proveedorController, _articuloController);
                formEditar.Modo = GestionVentasCel.enumerations.modoForms.ModoFormulario.Editar;
                formEditar.CompraActual = compraCompleta;

                if (formEditar.ShowDialog() == DialogResult.OK)
                {
                    CargarDatos();
                }
            }
            
        }
    }
}
