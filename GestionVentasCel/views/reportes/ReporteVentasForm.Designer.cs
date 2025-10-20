using System.Windows.Forms.DataVisualization.Charting;

namespace GestionVentasCel.views.reportes
{
    partial class ReporteVentasForm
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
            lblTituloVentas = new Label();
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
            panelFiltrosVentas.SuspendLayout();
            panelResumenVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartVentas).BeginInit();
            SuspendLayout();
            // 
            // lblTituloVentas
            // 
            lblTituloVentas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTituloVentas.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTituloVentas.ForeColor = Color.FromArgb(52, 152, 219);
            lblTituloVentas.Location = new Point(11, 7);
            lblTituloVentas.Margin = new Padding(2, 0, 2, 0);
            lblTituloVentas.Name = "lblTituloVentas";
            lblTituloVentas.Size = new Size(1520, 38);
            lblTituloVentas.TabIndex = 0;
            lblTituloVentas.Text = "REPORTES DE VENTAS";
            lblTituloVentas.TextAlign = ContentAlignment.MiddleCenter;
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
            panelFiltrosVentas.Location = new Point(11, 48);
            panelFiltrosVentas.Margin = new Padding(3, 4, 3, 4);
            panelFiltrosVentas.Name = "panelFiltrosVentas";
            panelFiltrosVentas.Size = new Size(1520, 106);
            panelFiltrosVentas.TabIndex = 0;
            // 
            // lblVentasFiltros
            // 
            lblVentasFiltros.AutoSize = true;
            lblVentasFiltros.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblVentasFiltros.Location = new Point(11, 13);
            lblVentasFiltros.Name = "lblVentasFiltros";
            lblVentasFiltros.Size = new Size(198, 28);
            lblVentasFiltros.TabIndex = 0;
            lblVentasFiltros.Text = "Filtros de Búsqueda";
            // 
            // lblVentasDesde
            // 
            lblVentasDesde.AutoSize = true;
            lblVentasDesde.Location = new Point(11, 60);
            lblVentasDesde.Name = "lblVentasDesde";
            lblVentasDesde.Size = new Size(54, 20);
            lblVentasDesde.TabIndex = 1;
            lblVentasDesde.Text = "Desde:";
            // 
            // dtpVentasDesde
            // 
            dtpVentasDesde.Format = DateTimePickerFormat.Short;
            dtpVentasDesde.Location = new Point(69, 56);
            dtpVentasDesde.Margin = new Padding(3, 4, 3, 4);
            dtpVentasDesde.Name = "dtpVentasDesde";
            dtpVentasDesde.Size = new Size(137, 27);
            dtpVentasDesde.TabIndex = 2;
            // 
            // lblVentasHasta
            // 
            lblVentasHasta.AutoSize = true;
            lblVentasHasta.Location = new Point(217, 60);
            lblVentasHasta.Name = "lblVentasHasta";
            lblVentasHasta.Size = new Size(50, 20);
            lblVentasHasta.TabIndex = 3;
            lblVentasHasta.Text = "Hasta:";
            // 
            // dtpVentasHasta
            // 
            dtpVentasHasta.Format = DateTimePickerFormat.Short;
            dtpVentasHasta.Location = new Point(270, 56);
            dtpVentasHasta.Margin = new Padding(3, 4, 3, 4);
            dtpVentasHasta.Name = "dtpVentasHasta";
            dtpVentasHasta.Size = new Size(137, 27);
            dtpVentasHasta.TabIndex = 4;
            // 
            // btnVentasFiltrar
            // 
            btnVentasFiltrar.BackColor = Color.FromArgb(52, 152, 219);
            btnVentasFiltrar.FlatStyle = FlatStyle.Flat;
            btnVentasFiltrar.ForeColor = Color.White;
            btnVentasFiltrar.Location = new Point(423, 53);
            btnVentasFiltrar.Margin = new Padding(3, 4, 3, 4);
            btnVentasFiltrar.Name = "btnVentasFiltrar";
            btnVentasFiltrar.Size = new Size(114, 37);
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
            btnVentasLimpiar.Location = new Point(549, 53);
            btnVentasLimpiar.Margin = new Padding(3, 4, 3, 4);
            btnVentasLimpiar.Name = "btnVentasLimpiar";
            btnVentasLimpiar.Size = new Size(114, 37);
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
            btnExportarVentas.Location = new Point(1370, 51);
            btnExportarVentas.Margin = new Padding(3, 4, 3, 4);
            btnExportarVentas.Name = "btnExportarVentas";
            btnExportarVentas.Size = new Size(137, 37);
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
            panelResumenVentas.Location = new Point(11, 168);
            panelResumenVentas.Margin = new Padding(3, 4, 3, 4);
            panelResumenVentas.Name = "panelResumenVentas";
            panelResumenVentas.Size = new Size(1520, 133);
            panelResumenVentas.TabIndex = 1;
            // 
            // lblVentasResumen
            // 
            lblVentasResumen.AutoSize = true;
            lblVentasResumen.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblVentasResumen.ForeColor = Color.White;
            lblVentasResumen.Location = new Point(11, 13);
            lblVentasResumen.Name = "lblVentasResumen";
            lblVentasResumen.Size = new Size(256, 32);
            lblVentasResumen.TabIndex = 0;
            lblVentasResumen.Text = "Resumen del Período";
            // 
            // lblVentasTotalTexto
            // 
            lblVentasTotalTexto.AutoSize = true;
            lblVentasTotalTexto.Font = new Font("Segoe UI", 10F);
            lblVentasTotalTexto.ForeColor = Color.White;
            lblVentasTotalTexto.Location = new Point(11, 67);
            lblVentasTotalTexto.Name = "lblVentasTotalTexto";
            lblVentasTotalTexto.Size = new Size(114, 23);
            lblVentasTotalTexto.TabIndex = 1;
            lblVentasTotalTexto.Text = "Total General:";
            // 
            // lblVentasTotalGeneral
            // 
            lblVentasTotalGeneral.AutoSize = true;
            lblVentasTotalGeneral.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblVentasTotalGeneral.ForeColor = Color.White;
            lblVentasTotalGeneral.Location = new Point(11, 87);
            lblVentasTotalGeneral.Name = "lblVentasTotalGeneral";
            lblVentasTotalGeneral.Size = new Size(88, 37);
            lblVentasTotalGeneral.TabIndex = 2;
            lblVentasTotalGeneral.Text = "$0.00";
            // 
            // lblVentasCantidadTexto
            // 
            lblVentasCantidadTexto.AutoSize = true;
            lblVentasCantidadTexto.Font = new Font("Segoe UI", 10F);
            lblVentasCantidadTexto.ForeColor = Color.White;
            lblVentasCantidadTexto.Location = new Point(514, 67);
            lblVentasCantidadTexto.Name = "lblVentasCantidadTexto";
            lblVentasCantidadTexto.Size = new Size(207, 23);
            lblVentasCantidadTexto.TabIndex = 3;
            lblVentasCantidadTexto.Text = "Cantidad de Operaciones:";
            // 
            // lblVentasCantidad
            // 
            lblVentasCantidad.AutoSize = true;
            lblVentasCantidad.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblVentasCantidad.ForeColor = Color.White;
            lblVentasCantidad.Location = new Point(514, 87);
            lblVentasCantidad.Name = "lblVentasCantidad";
            lblVentasCantidad.Size = new Size(33, 37);
            lblVentasCantidad.TabIndex = 4;
            lblVentasCantidad.Text = "0";
            // 
            // lblVentasPromedioTexto
            // 
            lblVentasPromedioTexto.AutoSize = true;
            lblVentasPromedioTexto.Font = new Font("Segoe UI", 10F);
            lblVentasPromedioTexto.ForeColor = Color.White;
            lblVentasPromedioTexto.Location = new Point(971, 67);
            lblVentasPromedioTexto.Name = "lblVentasPromedioTexto";
            lblVentasPromedioTexto.Size = new Size(203, 23);
            lblVentasPromedioTexto.TabIndex = 5;
            lblVentasPromedioTexto.Text = "Promedio por Operación:";
            // 
            // lblVentasPromedio
            // 
            lblVentasPromedio.AutoSize = true;
            lblVentasPromedio.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblVentasPromedio.ForeColor = Color.White;
            lblVentasPromedio.Location = new Point(971, 87);
            lblVentasPromedio.Name = "lblVentasPromedio";
            lblVentasPromedio.Size = new Size(88, 37);
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
            dgvVentas.Location = new Point(11, 315);
            dgvVentas.Margin = new Padding(3, 4, 3, 4);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(1029, 615);
            dgvVentas.TabIndex = 2;
            // 
            // chartVentas
            // 
            chartVentas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            chartVentas.Location = new Point(1057, 315);
            chartVentas.Margin = new Padding(3, 4, 3, 4);
            chartVentas.Name = "chartVentas";
            chartVentas.Size = new Size(476, 615);
            chartVentas.TabIndex = 3;
            chartVentas.Text = "chartVentas";
            // 
            // ReporteVentasForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1539, 940);
            Controls.Add(lblTituloVentas);
            Controls.Add(panelFiltrosVentas);
            Controls.Add(panelResumenVentas);
            Controls.Add(dgvVentas);
            Controls.Add(chartVentas);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ReporteVentasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reportes de Ventas - SGVC";
            WindowState = FormWindowState.Maximized;
            panelFiltrosVentas.ResumeLayout(false);
            panelFiltrosVentas.PerformLayout();
            panelResumenVentas.ResumeLayout(false);
            panelResumenVentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartVentas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTituloVentas;
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
    }
}
