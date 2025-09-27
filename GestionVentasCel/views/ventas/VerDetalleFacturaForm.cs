using System.ComponentModel;
using System.Globalization;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.cliente;
using GestionVentasCel.controller.reparaciones;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.clientes;
using GestionVentasCel.models.reparacion;
using GestionVentasCel.models.ventas;
using GestionVentasCel.service.usuario;
using GestionVentasCel.service.venta;
using GestionVentasCel.temas;
using GestionVentasCel.views.usuario_empleado;
using Microsoft.Extensions.DependencyInjection;

namespace GestionVentasCel.views.ventas
{
    public partial class VerDetalleFacturaForm : Form
    {
        public Factura _factura;
        private BindingSource _bindingSource;
        public VerDetalleFacturaForm(
            Factura factura
        )
        {
            InitializeComponent();
            _factura = factura;

            // Siempre hay que guardar qué usuario autorizó la venta o la edición

            this.ConfigurarBindings();
            this.ConfigurarDGVDetalles();
            this.ConfigurarEstilosVisuales();

        }

        private void CargarDataSourceDGV()
        {
            _bindingSource.DataSource = new BindingList<DetalleFactura>(_factura.Detalles.ToList()); ;

            dgvListarDetalles.DataSource = _bindingSource;
        }

        private void ConfigurarDGVDetalles()
        {
            CargarDataSourceDGV();

            // Agregar todas las columnas formateadas
            if (dgvListarDetalles.Columns["Detalle"] == null)
            {
                dgvListarDetalles.Columns.Add("Detalle", "Detalle");
            }

            if (dgvListarDetalles.Columns["PrecioUnitarioFormateado"] == null)
            {
                dgvListarDetalles.Columns.Add("PrecioUnitarioFormateado", "Precio unitario");
            }

            if (dgvListarDetalles.Columns["Importe"] == null)
            {
                dgvListarDetalles.Columns.Add("Importe", "Importe");
            }

            if (dgvListarDetalles.Columns["PorcentajeIVAFormateado"] == null)
            {
                dgvListarDetalles.Columns.Add("PorcentajeIVAFormateado", "% IVA");
            }

            if (dgvListarDetalles.Columns["SubtotalConIVAFormateado"] == null)
            {
                dgvListarDetalles.Columns.Add("SubtotalConIVAFormateado", "Subtotal");
            }

            if (dgvListarDetalles.Columns["NumeroItem"] == null)
            {
                dgvListarDetalles.Columns.Add("NumeroItem", "#");
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


            dgvListarDetalles.Columns["NumeroItem"].Visible = true;
            dgvListarDetalles.Columns["Cantidad"].Visible = true;
            dgvListarDetalles.Columns["PrecioUnitarioFormateado"].Visible = true;
            dgvListarDetalles.Columns["Importe"].Visible = true;
            dgvListarDetalles.Columns["PorcentajeIVAFormateado"].Visible = true;
            dgvListarDetalles.Columns["SubtotalConIVAFormateado"].Visible = true;


            dgvListarDetalles.DataBindingComplete += (s, e) =>
            {
                // Una vez que se termine de bindear, hay que ordernar las columnas y formatearlas
                dgvListarDetalles.Columns["NumeroItem"].DisplayIndex = 0;
                dgvListarDetalles.Columns["Detalle"].DisplayIndex = 1;
                dgvListarDetalles.Columns["Cantidad"].DisplayIndex = 2;
                dgvListarDetalles.Columns["PrecioUnitarioFormateado"].DisplayIndex = 3;
                dgvListarDetalles.Columns["Importe"].DisplayIndex = 4;
                dgvListarDetalles.Columns["PorcentajeIVAFormateado"].DisplayIndex = 5;
                dgvListarDetalles.Columns["SubtotalConIvaFormateado"].DisplayIndex = 6;

                int numeroItem = 1;
                foreach (DataGridViewRow row in dgvListarDetalles.Rows)
                {
                    if (row.DataBoundItem is DetalleFactura detalle)
                    {
                        row.Cells["NumeroItem"].Value = numeroItem;
                        row.Cells["Detalle"].Value = detalle.Descripcion;

                        row.Cells["PrecioUnitarioFormateado"].Value = detalle.PrecioUnitario.ToString("C2", new CultureInfo("es-AR"));
                        row.Cells["Importe"].Value = detalle.SubtotalSinIVA.ToString("C2", new CultureInfo("es-AR"));
                        row.Cells["PorcentajeIVAFormateado"].Value = detalle.PorcentajeIVA.ToString("P2");
                        row.Cells["SubtotalConIVAFormateado"].Value = detalle.Subtotal.ToString("C2", new CultureInfo("es-AR"));

                        numeroItem++;
                    }
                }
            };

        }

        public void ConfigurarBindings()
        {
            // Inicializar BindingSource
            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _factura;


            switch (_factura.TipoComprobante)
            {
                case TipoFacturaEnum.FacturaA:
                    lblTipoFactura.Text = "A";
                    break;
                case TipoFacturaEnum.FacturaB:
                    lblTipoFactura.Text = "B";
                    break;
                    // Esto ni siquiera debería poder pasar, pero como ya está el enum, por qué no?
                case TipoFacturaEnum.FacturaC:
                    lblTipoFactura.Text= "C";
                    break;
            }

            //TODO: Cambiar numero dde factura y hacer que sea AI desde la ID
            lblValorRazonSocial.Text = _factura.Empresa.RazonSocial;
            lblCondicionIVA.Text = _factura.Empresa.CondicionIVA.ToString();
            lblDomicilio.Text = _factura.Empresa.DomicilioFiscal;
            lblFechaEmision.Text = _factura.FechaEmision.ToString("G", new CultureInfo("es-AR"));
            lblNumero.Text = _factura.NumeroFactura;
            lblCUIT.Text = _factura.Empresa.CUIT;
            lblIngresosBrutos.Text = _factura.Empresa.IngresosBrutos;
            lblInicioActividades.Text = _factura.Empresa.InicioActividades;

            lblNombreCliente.Text = _factura.NombreCliente;
            lblCuitCliente.Text = _factura.CUITCliente;
            lblCondicionIVACliente.Text = _factura.CondicionIVACliente;
            lblDomicilioCliente.Text = _factura.DomicilioCliente;



            this.lblSubtotalSinIVA.Text = $"Subtotal sin IVA: {_factura.Subtotal.ToString("C2", new CultureInfo("es-AR"))}";
            this.lblTotalIVA.Text = $"IVA total: {_factura.IVA.ToString("C2", new CultureInfo("es-AR"))}";
            this.lblTotal.Text = $"Total: {_factura.Total.ToString("C2", new CultureInfo("es-AR"))}";

        }


        private void ConfigurarEstilosVisuales()
        {
            this.BackColor = Tema.ColorSuperficie;

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
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
