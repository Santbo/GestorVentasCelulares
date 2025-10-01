using System.ComponentModel;
using System.Globalization;
using GestionVentasCel.models.ventas;
using GestionVentasCel.service.caja;
using GestionVentasCel.service.factura;
using GestionVentasCel.service.venta;
using GestionVentasCel.temas;
using GestionVentasCel.views.ventas;

namespace GestionVentasCel.views.usuario_empleado
{


    public partial class FacturaMainMenuForm : Form
    {
        private readonly IFacturaService _facturaService;
        private BindingList<Factura> _facturas;
        private BindingSource _bindingSource;
        public FacturaMainMenuForm(IFacturaService facturaService)
        {
            InitializeComponent();
            _facturaService = facturaService;
            CargarFacturas();
            ConfigurarDGV();

        }

        //Se crea un bindingList de cliente y se lo agrega al DGV
        //El BindingList a diferencia del List, actualiza el DGV si hay un cambio en los Objetos
        //Se crea un bindingSource para poder filtrar entre usuarios activos e inactivos
        private void CargarFacturas()
        {
            var listaFacturas = _facturaService.ObtenerTodas().ToList();

            _facturas = new BindingList<Factura>(listaFacturas);

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _facturas;

            AplicarFiltro();

        }

        private void ConfigurarDGV()
        {
            _bindingSource.DataSource = _facturas; // lista de Factura
            dgvListar.DataSource = _bindingSource;

            // Ocultar todas las columnas por defecto
            foreach (DataGridViewColumn col in dgvListar.Columns)
            {
                col.Visible = false;
            }

            // Mostrar solo las columnas necesarias
            dgvListar.Columns["FechaEmision"].Visible = true;
            dgvListar.Columns["NombreCliente"].Visible = true;
            dgvListar.Columns["NumeroFactura"].Visible = true;

            // Agregar columna formateada para el total con IVA
            if (dgvListar.Columns["TotalConIvaFormateado"] == null)
            {
                dgvListar.Columns.Add("TotalConIvaFormateado", "Total con IVA");
            }
            dgvListar.Columns["TotalConIvaFormateado"].Visible = true;

            // Configurar orden de columnas después del bind
            dgvListar.DataBindingComplete += (s, e) =>
            {
                dgvListar.Columns["FechaEmision"].DisplayIndex = 0;
                dgvListar.Columns["NombreCliente"].DisplayIndex = 1;
                dgvListar.Columns["TotalConIvaFormateado"].DisplayIndex = 2;

                // Formatear el total con IVA para cada fila
                foreach (DataGridViewRow row in dgvListar.Rows)
                {
                    if (row.DataBoundItem is Factura factura)
                    {
                        row.Cells["TotalConIvaFormateado"].Value = factura.Total.ToString("C2", new CultureInfo("es-AR"));
                    }
                }
            };
        }


        private void AplicarFiltro()
        {

            // punto de partida: todos los usuarios
            IEnumerable<Factura> filtrados = _facturas;


            // filtro por búsqueda
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filtro))
            {
                filtrados = filtrados.Where(u =>
                    u.NombreCliente.ToLower().Contains(filtro)
                    || u.FechaEmision.ToString().ToLower().Contains(filtro)
                );
            }

            // asignar al BindingSource
            _bindingSource.DataSource = new BindingList<Factura>(filtrados.ToList());
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

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvListar.CurrentRow != null)
            {
                int id = (int)dgvListar.CurrentRow.Cells["Id"].Value;

                // Asegurarse de que no haya tracking, porque el actualizar se va a romper si no
                var factura = _facturaService.ObtenerPorId(id);
                if (factura == null)
                {
                    MessageBox.Show("La factura no fue encontrada",
                        "Venta no encontrada",
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
    }
}
