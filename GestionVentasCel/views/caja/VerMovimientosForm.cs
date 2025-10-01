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
            dgvListar.Columns["TipoPago"].Visible = true;
            dgvListar.Columns["Fecha"].Visible = true;

            if (dgvListar.Columns["MontoFormateado"] == null)
            {
                dgvListar.Columns.Add("MontoFormateado", "Monto");
            }
            dgvListar.Columns["MontoFormateado"].Visible = true;





            dgvListar.DataBindingComplete += (s, e) =>
            {

                // Organizar el orden de las columnas despues de que se hayan bindeado todos los datos
                dgvListar.Columns["TipoMovimiento"].DisplayIndex = 0;
                dgvListar.Columns["MontoFormateado"].DisplayIndex = 1;
                dgvListar.Columns["TipoPago"].DisplayIndex = 2;
                dgvListar.Columns["Fecha"].DisplayIndex = 3;
                dgvListar.Columns["Descripcion"].DisplayIndex = 4;

                foreach (DataGridViewRow row in dgvListar.Rows)
                {
                    if (row.DataBoundItem is MovimientoCaja movimiento)
                    {
                        row.Cells["MontoFormateado"].Value = movimiento.Monto.ToString("C2", new CultureInfo("es-AR"));
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
                    label.Text = monto.ToString("C", new CultureInfo("es-AR"));


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
    }
}
