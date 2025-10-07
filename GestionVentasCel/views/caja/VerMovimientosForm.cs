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
using GestionVentasCel.controller.caja;
using GestionVentasCel.enumerations.ventas;
using GestionVentasCel.models.caja;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.caja
{
    public partial class VerMovimientosForm : Form
    {

        private Caja _caja;
        private BindingList<MovimientoCaja> _movimientos = new BindingList<MovimientoCaja>();
        public VerMovimientosForm(Caja caja)
        {
            InitializeComponent();
            _caja = caja;
            CargarMovimientos();
            ConfigurarDGV();
        }

        private void CargarMovimientos()
        {

            var listaMovimientos = _caja.Movimientos.ToList();
            _movimientos = new BindingList<MovimientoCaja>(listaMovimientos);
            this.dgvListar.ClearSelection();


        }

        private void ConfigurarDGV()
        {
            dgvListar.DataSource = _movimientos;
            this.dgvListar.ClearSelection();

            // Es más facil ocultar todas las columnas y mostrar, que al revés

            foreach (DataGridViewColumn col in dgvListar.Columns)
            {
                col.Visible = false;
            }

            dgvListar.Columns["TipoMovimiento"].Visible = true;
            dgvListar.Columns["Descripcion"].Visible = true;
            dgvListar.Columns["TipoPago"].Visible = false;
            dgvListar.Columns["Fecha"].Visible = true;

            if (dgvListar.Columns["MontoFormateado"] == null)
            {
                dgvListar.Columns.Add("MontoFormateado", "Monto");
            }
            dgvListar.Columns["MontoFormateado"].Visible = true;

            if (dgvListar.Columns["TipoPagoFormateado"] == null)
            {
                dgvListar.Columns.Add("TipoPagoFormateado", "Tipo de pago");
            }
            dgvListar.Columns["TipoPagoFormateado"].Visible = true;





            dgvListar.DataBindingComplete += (s, e) =>
            {

                // Organizar el orden de las columnas despues de que se hayan bindeado todos los datos
                dgvListar.Columns["TipoMovimiento"].DisplayIndex = 0;
                dgvListar.Columns["MontoFormateado"].DisplayIndex = 1;
                dgvListar.Columns["TipoPagoFormateado"].DisplayIndex = 2;
                dgvListar.Columns["Fecha"].DisplayIndex = 3;
                dgvListar.Columns["Descripcion"].DisplayIndex = 4;

                foreach (DataGridViewRow row in dgvListar.Rows)
                {
                    if (row.DataBoundItem is MovimientoCaja movimiento)
                    {
                        row.Cells["MontoFormateado"].Value = movimiento.Monto.ToString("C2", new CultureInfo("es-AR"));

                        if (movimiento.TipoPago == TipoPagoEnum.Retiro)
                        {
                            row.Cells["TipoPagoFormateado"].Value = "-";

                        } else
                        {
                            row.Cells["TipoPagoFormateado"].Value = movimiento.TipoPago.ToString();
                        }
                    }

                }

                this.dgvListar.ClearSelection();
                CargarTotales();
            };
        }

        private void CargarTotales()
        {
            // Mapeo entre TipoPagoEnum y sus labels
            var labelsPorTipo = new Dictionary<TipoPagoEnum, Label>
{
            { TipoPagoEnum.Efectivo, lblEfectivo },
            { TipoPagoEnum.Transferencia, lblTransferencia },
            { TipoPagoEnum.BilleteraVirtual, lblBv },
            { TipoPagoEnum.TarjetaCredito, lblCredito },
            { TipoPagoEnum.TarjetaDebito, lblDebito },
            { TipoPagoEnum.Retiro, lblRetiro }
};
            decimal totales = 0;
            // Asignar valores a cada label
            foreach (var tipo in Enum.GetValues(typeof(TipoPagoEnum)).Cast<TipoPagoEnum>())
            {
                if (labelsPorTipo.TryGetValue(tipo, out var label))
                {
                    _caja.TotalesPorTipoPago.TryGetValue(tipo, out var monto);

                    if(tipo == TipoPagoEnum.Efectivo)
                    {
                        monto = monto + _caja.MontoApertura;
                        label.Text = monto.ToString("C", new CultureInfo("es-AR"));
                    }
                    else
                    {
                        label.Text = monto.ToString("C", new CultureInfo("es-AR"));

                    }

                    if (tipo != TipoPagoEnum.Retiro)
                    {
                        totales += monto;


                    }
                    else
                    {
                        totales -= monto;
                    }
                }
            }
           
            lblTotales.Text = totales.ToString("C", new CultureInfo("es-AR"));
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void VerMovimientosForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
        }
    }
}
