using System.Windows.Forms.DataVisualization.Charting;

namespace GestionVentasCel.views.reportes
{
    partial class ReportesMainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabVentas = new TabPage();
            panelFiltrosVentas = new Panel();
            lblVentasFiltros = new Label();
            lblVentasDesde = new Label();
            dtpVentasDesde = new DateTimePicker();
            lblVentasHasta = new Label();
            dtpVentasHasta = new DateTimePicker();
            btnVentasFiltrar = new Button();
            btnVentasLimpiar = new Button();
            btnExportarVentas = new Button();
            panelResumenVentas = new Panel();
            lblVentasResumen = new Label();
            lblVentasTotalTexto = new Label();
            lblVentasTotalGeneral = new Label();
            lblVentasCantidadTexto = new Label();
            lblVentasCantidad = new Label();
            lblVentasPromedioTexto = new Label();
            lblVentasPromedio = new Label();
            dgvVentas = new DataGridView();
            chartVentas = new Chart();
            tabCompras = new TabPage();
            panelFiltrosCompras = new Panel();
            lblComprasFiltros = new Label();
            lblComprasDesde = new Label();
            dtpComprasDesde = new DateTimePicker();
            lblComprasHasta = new Label();
            dtpComprasHasta = new DateTimePicker();
            btnComprasFiltrar = new Button();
            btnComprasLimpiar = new Button();
            btnExportarCompras = new Button();
            panelResumenCompras = new Panel();
            lblComprasResumen = new Label();
            lblComprasTotalTexto = new Label();
            lblComprasTotalGeneral = new Label();
            lblComprasCantidadTexto = new Label();
            lblComprasCantidad = new Label();
            lblComprasPromedioTexto = new Label();
            lblComprasPromedio = new Label();
            dgvCompras = new DataGridView();
            chartCompras = new Chart();
            tabControl.SuspendLayout();
            tabVentas.SuspendLayout();
            panelFiltrosVentas.SuspendLayout();
            panelResumenVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartVentas).BeginInit();
            tabCompras.SuspendLayout();
            panelFiltrosCompras.SuspendLayout();
            panelResumenCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartCompras).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabVentas);
            tabControl.Controls.Add(tabCompras);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(4, 5, 4, 5);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1943, 1199);
            tabControl.TabIndex = 0;
            // 
            // tabVentas
            // 
            tabVentas.BackColor = Color.White;
            tabVentas.Controls.Add(panelFiltrosVentas);
            tabVentas.Controls.Add(panelResumenVentas);
            tabVentas.Controls.Add(dgvVentas);
            tabVentas.Controls.Add(chartVentas);
            tabVentas.Location = new Point(4, 34);
            tabVentas.Margin = new Padding(4, 5, 4, 5);
            tabVentas.Name = "tabVentas";
            tabVentas.Padding = new Padding(14, 16, 14, 16);
            tabVentas.Size = new Size(1935, 1161);
            tabVentas.TabIndex = 0;
            tabVentas.Text = "Reporte de Ventas";
            // 
            // panelFiltrosVentas
            // 
            panelFiltrosVentas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelFiltrosVentas.BackColor = Color.FromArgb(240, 240, 240);
            panelFiltrosVentas.BorderStyle = BorderStyle.FixedSingle;
            panelFiltrosVentas.Controls.Add(lblVentasFiltros);
            panelFiltrosVentas.Controls.Add(lblVentasDesde);
            panelFiltrosVentas.Controls.Add(dtpVentasDesde);
            panelFiltrosVentas.Controls.Add(lblVentasHasta);
            panelFiltrosVentas.Controls.Add(dtpVentasHasta);
            panelFiltrosVentas.Controls.Add(btnVentasFiltrar);
            panelFiltrosVentas.Controls.Add(btnVentasLimpiar);
            panelFiltrosVentas.Controls.Add(btnExportarVentas);
            panelFiltrosVentas.Location = new Point(14, 16);
            panelFiltrosVentas.Margin = new Padding(4, 5, 4, 5);
            panelFiltrosVentas.Name = "panelFiltrosVentas";
            panelFiltrosVentas.Size = new Size(1900, 132);
            panelFiltrosVentas.TabIndex = 0;
            // 
            // lblVentasFiltros
            // 
            lblVentasFiltros.AutoSize = true;
            lblVentasFiltros.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblVentasFiltros.Location = new Point(14, 16);
            lblVentasFiltros.Margin = new Padding(4, 0, 4, 0);
            lblVentasFiltros.Name = "lblVentasFiltros";
            lblVentasFiltros.Size = new Size(239, 32);
            lblVentasFiltros.TabIndex = 0;
            lblVentasFiltros.Text = "Filtros de Búsqueda";
            // 
            // lblVentasDesde
            // 
            lblVentasDesde.AutoSize = true;
            lblVentasDesde.Location = new Point(14, 75);
            lblVentasDesde.Margin = new Padding(4, 0, 4, 0);
            lblVentasDesde.Name = "lblVentasDesde";
            lblVentasDesde.Size = new Size(66, 25);
            lblVentasDesde.TabIndex = 1;
            lblVentasDesde.Text = "Desde:";
            // 
            // dtpVentasDesde
            // 
            dtpVentasDesde.Format = DateTimePickerFormat.Short;
            dtpVentasDesde.Location = new Point(86, 70);
            dtpVentasDesde.Margin = new Padding(4, 5, 4, 5);
            dtpVentasDesde.Name = "dtpVentasDesde";
            dtpVentasDesde.Size = new Size(170, 31);
            dtpVentasDesde.TabIndex = 2;
            // 
            // lblVentasHasta
            // 
            lblVentasHasta.AutoSize = true;
            lblVentasHasta.Location = new Point(271, 75);
            lblVentasHasta.Margin = new Padding(4, 0, 4, 0);
            lblVentasHasta.Name = "lblVentasHasta";
            lblVentasHasta.Size = new Size(61, 25);
            lblVentasHasta.TabIndex = 3;
            lblVentasHasta.Text = "Hasta:";
            // 
            // dtpVentasHasta
            // 
            dtpVentasHasta.Format = DateTimePickerFormat.Short;
            dtpVentasHasta.Location = new Point(338, 70);
            dtpVentasHasta.Margin = new Padding(4, 5, 4, 5);
            dtpVentasHasta.Name = "dtpVentasHasta";
            dtpVentasHasta.Size = new Size(170, 31);
            dtpVentasHasta.TabIndex = 4;
            // 
            // btnVentasFiltrar
            // 
            btnVentasFiltrar.BackColor = Color.FromArgb(52, 152, 219);
            btnVentasFiltrar.FlatStyle = FlatStyle.Flat;
            btnVentasFiltrar.ForeColor = Color.White;
            btnVentasFiltrar.Location = new Point(529, 66);
            btnVentasFiltrar.Margin = new Padding(4, 5, 4, 5);
            btnVentasFiltrar.Name = "btnVentasFiltrar";
            btnVentasFiltrar.Size = new Size(142, 46);
            btnVentasFiltrar.TabIndex = 5;
            btnVentasFiltrar.Text = "Filtrar";
            btnVentasFiltrar.UseVisualStyleBackColor = false;
            btnVentasFiltrar.Click += btnVentasFiltrar_Click;
            // 
            // btnVentasLimpiar
            // 
            btnVentasLimpiar.BackColor = Color.FromArgb(149, 165, 166);
            btnVentasLimpiar.FlatStyle = FlatStyle.Flat;
            btnVentasLimpiar.ForeColor = Color.White;
            btnVentasLimpiar.Location = new Point(686, 66);
            btnVentasLimpiar.Margin = new Padding(4, 5, 4, 5);
            btnVentasLimpiar.Name = "btnVentasLimpiar";
            btnVentasLimpiar.Size = new Size(142, 46);
            btnVentasLimpiar.TabIndex = 6;
            btnVentasLimpiar.Text = "Limpiar";
            btnVentasLimpiar.UseVisualStyleBackColor = false;
            btnVentasLimpiar.Click += btnVentasLimpiar_Click;
            // 
            // btnExportarVentas
            // 
            btnExportarVentas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportarVentas.BackColor = Color.FromArgb(46, 204, 113);
            btnExportarVentas.FlatStyle = FlatStyle.Flat;
            btnExportarVentas.ForeColor = Color.White;
            btnExportarVentas.Location = new Point(1713, 64);
            btnExportarVentas.Margin = new Padding(4, 5, 4, 5);
            btnExportarVentas.Name = "btnExportarVentas";
            btnExportarVentas.Size = new Size(171, 46);
            btnExportarVentas.TabIndex = 7;
            btnExportarVentas.Text = "📄 Exportar";
            btnExportarVentas.UseVisualStyleBackColor = false;
            btnExportarVentas.Click += btnExportarVentas_Click;
            // 
            // panelResumenVentas
            // 
            panelResumenVentas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelResumenVentas.BackColor = Color.FromArgb(52, 152, 219);
            panelResumenVentas.BorderStyle = BorderStyle.FixedSingle;
            panelResumenVentas.Controls.Add(lblVentasResumen);
            panelResumenVentas.Controls.Add(lblVentasTotalTexto);
            panelResumenVentas.Controls.Add(lblVentasTotalGeneral);
            panelResumenVentas.Controls.Add(lblVentasCantidadTexto);
            panelResumenVentas.Controls.Add(lblVentasCantidad);
            panelResumenVentas.Controls.Add(lblVentasPromedioTexto);
            panelResumenVentas.Controls.Add(lblVentasPromedio);
            panelResumenVentas.Location = new Point(14, 166);
            panelResumenVentas.Margin = new Padding(4, 5, 4, 5);
            panelResumenVentas.Name = "panelResumenVentas";
            panelResumenVentas.Size = new Size(1900, 166);
            panelResumenVentas.TabIndex = 1;
            // 
            // lblVentasResumen
            // 
            lblVentasResumen.AutoSize = true;
            lblVentasResumen.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblVentasResumen.ForeColor = Color.White;
            lblVentasResumen.Location = new Point(14, 16);
            lblVentasResumen.Margin = new Padding(4, 0, 4, 0);
            lblVentasResumen.Name = "lblVentasResumen";
            lblVentasResumen.Size = new Size(293, 38);
            lblVentasResumen.TabIndex = 0;
            lblVentasResumen.Text = "Resumen del Período";
            // 
            // lblVentasTotalTexto
            // 
            lblVentasTotalTexto.AutoSize = true;
            lblVentasTotalTexto.Font = new Font("Segoe UI", 10F);
            lblVentasTotalTexto.ForeColor = Color.White;
            lblVentasTotalTexto.Location = new Point(14, 84);
            lblVentasTotalTexto.Margin = new Padding(4, 0, 4, 0);
            lblVentasTotalTexto.Name = "lblVentasTotalTexto";
            lblVentasTotalTexto.Size = new Size(130, 28);
            lblVentasTotalTexto.TabIndex = 1;
            lblVentasTotalTexto.Text = "Total General:";
            // 
            // lblVentasTotalGeneral
            // 
            lblVentasTotalGeneral.AutoSize = true;
            lblVentasTotalGeneral.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblVentasTotalGeneral.ForeColor = Color.White;
            lblVentasTotalGeneral.Location = new Point(14, 109);
            lblVentasTotalGeneral.Margin = new Padding(4, 0, 4, 0);
            lblVentasTotalGeneral.Name = "lblVentasTotalGeneral";
            lblVentasTotalGeneral.Size = new Size(101, 45);
            lblVentasTotalGeneral.TabIndex = 2;
            lblVentasTotalGeneral.Text = "$0.00";
            // 
            // lblVentasCantidadTexto
            // 
            lblVentasCantidadTexto.AutoSize = true;
            lblVentasCantidadTexto.Font = new Font("Segoe UI", 10F);
            lblVentasCantidadTexto.ForeColor = Color.White;
            lblVentasCantidadTexto.Location = new Point(642, 84);
            lblVentasCantidadTexto.Margin = new Padding(4, 0, 4, 0);
            lblVentasCantidadTexto.Name = "lblVentasCantidadTexto";
            lblVentasCantidadTexto.Size = new Size(236, 28);
            lblVentasCantidadTexto.TabIndex = 3;
            lblVentasCantidadTexto.Text = "Cantidad de Operaciones:";
            // 
            // lblVentasCantidad
            // 
            lblVentasCantidad.AutoSize = true;
            lblVentasCantidad.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblVentasCantidad.ForeColor = Color.White;
            lblVentasCantidad.Location = new Point(642, 109);
            lblVentasCantidad.Margin = new Padding(4, 0, 4, 0);
            lblVentasCantidad.Name = "lblVentasCantidad";
            lblVentasCantidad.Size = new Size(38, 45);
            lblVentasCantidad.TabIndex = 4;
            lblVentasCantidad.Text = "0";
            // 
            // lblVentasPromedioTexto
            // 
            lblVentasPromedioTexto.AutoSize = true;
            lblVentasPromedioTexto.Font = new Font("Segoe UI", 10F);
            lblVentasPromedioTexto.ForeColor = Color.White;
            lblVentasPromedioTexto.Location = new Point(1214, 84);
            lblVentasPromedioTexto.Margin = new Padding(4, 0, 4, 0);
            lblVentasPromedioTexto.Name = "lblVentasPromedioTexto";
            lblVentasPromedioTexto.Size = new Size(234, 28);
            lblVentasPromedioTexto.TabIndex = 5;
            lblVentasPromedioTexto.Text = "Promedio por Operación:";
            // 
            // lblVentasPromedio
            // 
            lblVentasPromedio.AutoSize = true;
            lblVentasPromedio.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblVentasPromedio.ForeColor = Color.White;
            lblVentasPromedio.Location = new Point(1214, 109);
            lblVentasPromedio.Margin = new Padding(4, 0, 4, 0);
            lblVentasPromedio.Name = "lblVentasPromedio";
            lblVentasPromedio.Size = new Size(101, 45);
            lblVentasPromedio.TabIndex = 6;
            lblVentasPromedio.Text = "$0.00";
            // 
            // dgvVentas
            // 
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvVentas.BackgroundColor = Color.White;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(14, 350);
            dgvVentas.Margin = new Padding(4, 5, 4, 5);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(1286, 769);
            dgvVentas.TabIndex = 2;
            // 
            // chartVentas
            // 
            chartVentas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            chartVentas.Location = new Point(1321, 350);
            chartVentas.Margin = new Padding(4, 5, 4, 5);
            chartVentas.Name = "chartVentas";
            chartVentas.Size = new Size(595, 769);
            chartVentas.TabIndex = 3;
            chartVentas.Text = "chartVentas";
            // 
            // tabCompras
            // 
            tabCompras.BackColor = Color.White;
            tabCompras.Controls.Add(panelFiltrosCompras);
            tabCompras.Controls.Add(panelResumenCompras);
            tabCompras.Controls.Add(dgvCompras);
            tabCompras.Controls.Add(chartCompras);
            tabCompras.Location = new Point(4, 34);
            tabCompras.Margin = new Padding(4, 5, 4, 5);
            tabCompras.Name = "tabCompras";
            tabCompras.Padding = new Padding(14, 16, 14, 16);
            tabCompras.Size = new Size(1935, 1161);
            tabCompras.TabIndex = 1;
            tabCompras.Text = "Reporte de Compras";
            // 
            // panelFiltrosCompras
            // 
            panelFiltrosCompras.BackColor = Color.FromArgb(240, 240, 240);
            panelFiltrosCompras.BorderStyle = BorderStyle.FixedSingle;
            panelFiltrosCompras.Controls.Add(lblComprasFiltros);
            panelFiltrosCompras.Controls.Add(lblComprasDesde);
            panelFiltrosCompras.Controls.Add(dtpComprasDesde);
            panelFiltrosCompras.Controls.Add(lblComprasHasta);
            panelFiltrosCompras.Controls.Add(dtpComprasHasta);
            panelFiltrosCompras.Controls.Add(btnComprasFiltrar);
            panelFiltrosCompras.Controls.Add(btnComprasLimpiar);
            panelFiltrosCompras.Controls.Add(btnExportarCompras);
            panelFiltrosCompras.Location = new Point(14, 16);
            panelFiltrosCompras.Margin = new Padding(4, 5, 4, 5);
            panelFiltrosCompras.Name = "panelFiltrosCompras";
            panelFiltrosCompras.Size = new Size(1903, 132);
            panelFiltrosCompras.TabIndex = 0;
            // 
            // lblComprasFiltros
            // 
            lblComprasFiltros.AutoSize = true;
            lblComprasFiltros.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblComprasFiltros.Location = new Point(14, 16);
            lblComprasFiltros.Margin = new Padding(4, 0, 4, 0);
            lblComprasFiltros.Name = "lblComprasFiltros";
            lblComprasFiltros.Size = new Size(239, 32);
            lblComprasFiltros.TabIndex = 0;
            lblComprasFiltros.Text = "Filtros de Búsqueda";
            // 
            // lblComprasDesde
            // 
            lblComprasDesde.AutoSize = true;
            lblComprasDesde.Location = new Point(14, 75);
            lblComprasDesde.Margin = new Padding(4, 0, 4, 0);
            lblComprasDesde.Name = "lblComprasDesde";
            lblComprasDesde.Size = new Size(66, 25);
            lblComprasDesde.TabIndex = 1;
            lblComprasDesde.Text = "Desde:";
            // 
            // dtpComprasDesde
            // 
            dtpComprasDesde.Format = DateTimePickerFormat.Short;
            dtpComprasDesde.Location = new Point(86, 70);
            dtpComprasDesde.Margin = new Padding(4, 5, 4, 5);
            dtpComprasDesde.Name = "dtpComprasDesde";
            dtpComprasDesde.Size = new Size(170, 31);
            dtpComprasDesde.TabIndex = 2;
            // 
            // lblComprasHasta
            // 
            lblComprasHasta.AutoSize = true;
            lblComprasHasta.Location = new Point(271, 75);
            lblComprasHasta.Margin = new Padding(4, 0, 4, 0);
            lblComprasHasta.Name = "lblComprasHasta";
            lblComprasHasta.Size = new Size(61, 25);
            lblComprasHasta.TabIndex = 3;
            lblComprasHasta.Text = "Hasta:";
            // 
            // dtpComprasHasta
            // 
            dtpComprasHasta.Format = DateTimePickerFormat.Short;
            dtpComprasHasta.Location = new Point(338, 70);
            dtpComprasHasta.Margin = new Padding(4, 5, 4, 5);
            dtpComprasHasta.Name = "dtpComprasHasta";
            dtpComprasHasta.Size = new Size(170, 31);
            dtpComprasHasta.TabIndex = 4;
            // 
            // btnComprasFiltrar
            // 
            btnComprasFiltrar.BackColor = Color.FromArgb(52, 152, 219);
            btnComprasFiltrar.FlatStyle = FlatStyle.Flat;
            btnComprasFiltrar.ForeColor = Color.White;
            btnComprasFiltrar.Location = new Point(529, 66);
            btnComprasFiltrar.Margin = new Padding(4, 5, 4, 5);
            btnComprasFiltrar.Name = "btnComprasFiltrar";
            btnComprasFiltrar.Size = new Size(142, 46);
            btnComprasFiltrar.TabIndex = 5;
            btnComprasFiltrar.Text = "Filtrar";
            btnComprasFiltrar.UseVisualStyleBackColor = false;
            btnComprasFiltrar.Click += btnComprasFiltrar_Click;
            // 
            // btnComprasLimpiar
            // 
            btnComprasLimpiar.BackColor = Color.FromArgb(149, 165, 166);
            btnComprasLimpiar.FlatStyle = FlatStyle.Flat;
            btnComprasLimpiar.ForeColor = Color.White;
            btnComprasLimpiar.Location = new Point(686, 66);
            btnComprasLimpiar.Margin = new Padding(4, 5, 4, 5);
            btnComprasLimpiar.Name = "btnComprasLimpiar";
            btnComprasLimpiar.Size = new Size(142, 46);
            btnComprasLimpiar.TabIndex = 6;
            btnComprasLimpiar.Text = "Limpiar";
            btnComprasLimpiar.UseVisualStyleBackColor = false;
            btnComprasLimpiar.Click += btnComprasLimpiar_Click;
            // 
            // btnExportarCompras
            // 
            btnExportarCompras.BackColor = Color.FromArgb(46, 204, 113);
            btnExportarCompras.FlatStyle = FlatStyle.Flat;
            btnExportarCompras.ForeColor = Color.White;
            btnExportarCompras.Location = new Point(1714, 64);
            btnExportarCompras.Margin = new Padding(4, 5, 4, 5);
            btnExportarCompras.Name = "btnExportarCompras";
            btnExportarCompras.Size = new Size(171, 46);
            btnExportarCompras.TabIndex = 7;
            btnExportarCompras.Text = "📄 Exportar";
            btnExportarCompras.UseVisualStyleBackColor = false;
            btnExportarCompras.Click += btnExportarCompras_Click;
            // 
            // panelResumenCompras
            // 
            panelResumenCompras.BackColor = Color.FromArgb(46, 204, 113);
            panelResumenCompras.BorderStyle = BorderStyle.FixedSingle;
            panelResumenCompras.Controls.Add(lblComprasResumen);
            panelResumenCompras.Controls.Add(lblComprasTotalTexto);
            panelResumenCompras.Controls.Add(lblComprasTotalGeneral);
            panelResumenCompras.Controls.Add(lblComprasCantidadTexto);
            panelResumenCompras.Controls.Add(lblComprasCantidad);
            panelResumenCompras.Controls.Add(lblComprasPromedioTexto);
            panelResumenCompras.Controls.Add(lblComprasPromedio);
            panelResumenCompras.Location = new Point(14, 166);
            panelResumenCompras.Margin = new Padding(4, 5, 4, 5);
            panelResumenCompras.Name = "panelResumenCompras";
            panelResumenCompras.Size = new Size(1900, 166);
            panelResumenCompras.TabIndex = 1;
            // 
            // lblComprasResumen
            // 
            lblComprasResumen.AutoSize = true;
            lblComprasResumen.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblComprasResumen.ForeColor = Color.White;
            lblComprasResumen.Location = new Point(14, 16);
            lblComprasResumen.Margin = new Padding(4, 0, 4, 0);
            lblComprasResumen.Name = "lblComprasResumen";
            lblComprasResumen.Size = new Size(293, 38);
            lblComprasResumen.TabIndex = 0;
            lblComprasResumen.Text = "Resumen del Período";
            // 
            // lblComprasTotalTexto
            // 
            lblComprasTotalTexto.AutoSize = true;
            lblComprasTotalTexto.Font = new Font("Segoe UI", 10F);
            lblComprasTotalTexto.ForeColor = Color.White;
            lblComprasTotalTexto.Location = new Point(14, 84);
            lblComprasTotalTexto.Margin = new Padding(4, 0, 4, 0);
            lblComprasTotalTexto.Name = "lblComprasTotalTexto";
            lblComprasTotalTexto.Size = new Size(130, 28);
            lblComprasTotalTexto.TabIndex = 1;
            lblComprasTotalTexto.Text = "Total General:";
            // 
            // lblComprasTotalGeneral
            // 
            lblComprasTotalGeneral.AutoSize = true;
            lblComprasTotalGeneral.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblComprasTotalGeneral.ForeColor = Color.White;
            lblComprasTotalGeneral.Location = new Point(14, 109);
            lblComprasTotalGeneral.Margin = new Padding(4, 0, 4, 0);
            lblComprasTotalGeneral.Name = "lblComprasTotalGeneral";
            lblComprasTotalGeneral.Size = new Size(101, 45);
            lblComprasTotalGeneral.TabIndex = 2;
            lblComprasTotalGeneral.Text = "$0.00";
            // 
            // lblComprasCantidadTexto
            // 
            lblComprasCantidadTexto.AutoSize = true;
            lblComprasCantidadTexto.Font = new Font("Segoe UI", 10F);
            lblComprasCantidadTexto.ForeColor = Color.White;
            lblComprasCantidadTexto.Location = new Point(642, 84);
            lblComprasCantidadTexto.Margin = new Padding(4, 0, 4, 0);
            lblComprasCantidadTexto.Name = "lblComprasCantidadTexto";
            lblComprasCantidadTexto.Size = new Size(236, 28);
            lblComprasCantidadTexto.TabIndex = 3;
            lblComprasCantidadTexto.Text = "Cantidad de Operaciones:";
            // 
            // lblComprasCantidad
            // 
            lblComprasCantidad.AutoSize = true;
            lblComprasCantidad.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblComprasCantidad.ForeColor = Color.White;
            lblComprasCantidad.Location = new Point(642, 109);
            lblComprasCantidad.Margin = new Padding(4, 0, 4, 0);
            lblComprasCantidad.Name = "lblComprasCantidad";
            lblComprasCantidad.Size = new Size(38, 45);
            lblComprasCantidad.TabIndex = 4;
            lblComprasCantidad.Text = "0";
            // 
            // lblComprasPromedioTexto
            // 
            lblComprasPromedioTexto.AutoSize = true;
            lblComprasPromedioTexto.Font = new Font("Segoe UI", 10F);
            lblComprasPromedioTexto.ForeColor = Color.White;
            lblComprasPromedioTexto.Location = new Point(1214, 84);
            lblComprasPromedioTexto.Margin = new Padding(4, 0, 4, 0);
            lblComprasPromedioTexto.Name = "lblComprasPromedioTexto";
            lblComprasPromedioTexto.Size = new Size(234, 28);
            lblComprasPromedioTexto.TabIndex = 5;
            lblComprasPromedioTexto.Text = "Promedio por Operación:";
            // 
            // lblComprasPromedio
            // 
            lblComprasPromedio.AutoSize = true;
            lblComprasPromedio.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblComprasPromedio.ForeColor = Color.White;
            lblComprasPromedio.Location = new Point(1214, 109);
            lblComprasPromedio.Margin = new Padding(4, 0, 4, 0);
            lblComprasPromedio.Name = "lblComprasPromedio";
            lblComprasPromedio.Size = new Size(101, 45);
            lblComprasPromedio.TabIndex = 6;
            lblComprasPromedio.Text = "$0.00";
            // 
            // dgvCompras
            // 
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AllowUserToDeleteRows = false;
            dgvCompras.BackgroundColor = Color.White;
            dgvCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompras.Location = new Point(14, 350);
            dgvCompras.Margin = new Padding(4, 5, 4, 5);
            dgvCompras.Name = "dgvCompras";
            dgvCompras.ReadOnly = true;
            dgvCompras.RowHeadersWidth = 51;
            dgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompras.Size = new Size(1286, 769);
            dgvCompras.TabIndex = 2;
            // 
            // chartCompras
            // 
            chartCompras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            chartCompras.Location = new Point(1321, 350);
            chartCompras.Margin = new Padding(4, 5, 4, 5);
            chartCompras.Name = "chartCompras";
            chartCompras.Size = new Size(595, 769);
            chartCompras.TabIndex = 3;
            chartCompras.Text = "chartCompras";
            // 
            // ReportesMainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1943, 1199);
            Controls.Add(tabControl);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ReportesMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Reportes - Compras y Ventas";
            tabControl.ResumeLayout(false);
            tabVentas.ResumeLayout(false);
            panelFiltrosVentas.ResumeLayout(false);
            panelFiltrosVentas.PerformLayout();
            panelResumenVentas.ResumeLayout(false);
            panelResumenVentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartVentas).EndInit();
            tabCompras.ResumeLayout(false);
            panelFiltrosCompras.ResumeLayout(false);
            panelFiltrosCompras.PerformLayout();
            panelResumenCompras.ResumeLayout(false);
            panelResumenCompras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartCompras).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabVentas;
        private System.Windows.Forms.TabPage tabCompras;

        // Controles para pestaña de Ventas
        private System.Windows.Forms.Panel panelFiltrosVentas;
        private System.Windows.Forms.Label lblVentasFiltros;
        private System.Windows.Forms.Label lblVentasDesde;
        private System.Windows.Forms.DateTimePicker dtpVentasDesde;
        private System.Windows.Forms.Label lblVentasHasta;
        private System.Windows.Forms.DateTimePicker dtpVentasHasta;
        private System.Windows.Forms.Button btnVentasFiltrar;
        private System.Windows.Forms.Button btnVentasLimpiar;
        private System.Windows.Forms.Button btnExportarVentas;

        private System.Windows.Forms.Panel panelResumenVentas;
        private System.Windows.Forms.Label lblVentasResumen;
        private System.Windows.Forms.Label lblVentasTotalTexto;
        private System.Windows.Forms.Label lblVentasTotalGeneral;
        private System.Windows.Forms.Label lblVentasCantidadTexto;
        private System.Windows.Forms.Label lblVentasCantidad;
        private System.Windows.Forms.Label lblVentasPromedioTexto;
        private System.Windows.Forms.Label lblVentasPromedio;

        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentas;

        // Controles para pestaña de Compras
        private System.Windows.Forms.Panel panelFiltrosCompras;
        private System.Windows.Forms.Label lblComprasFiltros;
        private System.Windows.Forms.Label lblComprasDesde;
        private System.Windows.Forms.DateTimePicker dtpComprasDesde;
        private System.Windows.Forms.Label lblComprasHasta;
        private System.Windows.Forms.DateTimePicker dtpComprasHasta;
        private System.Windows.Forms.Button btnComprasFiltrar;
        private System.Windows.Forms.Button btnComprasLimpiar;
        private System.Windows.Forms.Button btnExportarCompras;

        private System.Windows.Forms.Panel panelResumenCompras;
        private System.Windows.Forms.Label lblComprasResumen;
        private System.Windows.Forms.Label lblComprasTotalTexto;
        private System.Windows.Forms.Label lblComprasTotalGeneral;
        private System.Windows.Forms.Label lblComprasCantidadTexto;
        private System.Windows.Forms.Label lblComprasCantidad;
        private System.Windows.Forms.Label lblComprasPromedioTexto;
        private System.Windows.Forms.Label lblComprasPromedio;

        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCompras;
    }
}

