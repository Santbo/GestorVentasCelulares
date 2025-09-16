namespace GestionVentasCel.views.compra
{
    public partial class FiltroFechaForm : Form
    {
        public DateTime FechaDesde { get; private set; }
        public DateTime FechaHasta { get; private set; }

        public FiltroFechaForm()
        {
            InitializeComponent();
            dtpFechaDesde.Value = DateTime.Now.AddDays(-30);
            dtpFechaHasta.Value = DateTime.Now;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (dtpFechaDesde.Value > dtpFechaHasta.Value)
            {
                MessageBox.Show("La fecha desde no puede ser mayor a la fecha hasta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FechaDesde = dtpFechaDesde.Value.Date;
            FechaHasta = dtpFechaHasta.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
