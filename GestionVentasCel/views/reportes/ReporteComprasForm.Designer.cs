using System.Windows.Forms.DataVisualization.Charting;

namespace GestionVentasCel.views.reportes
{
    partial class ReporteComprasForm
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
            lblTituloCompras = new Label();
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
            panelFiltrosCompras.SuspendLayout();
            panelResumenCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartCompras).BeginInit();
            SuspendLayout();
            // 
            // lblTituloCompras
            // 
            lblTituloCompras.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTituloCompras.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTituloCompras.ForeColor = Color.FromArgb(46, 204, 113);
            lblTituloCompras.Location = new Point(11, 13);
            lblTituloCompras.Name = "lblTituloCompras";
            lblTituloCompras.Size = new Size(1520, 40);
            lblTituloCompras.TabIndex = 0;
            lblTituloCompras.Text = "REPORTES DE COMPRAS";
            lblTituloCompras.TextAlign = ContentAlignment.MiddleCenter;
            lblTituloCompras.Click += lblTituloCompras_Click;
            // 
            // panelFiltrosCompras
            // 
            panelFiltrosCompras.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            panelFiltrosCompras.Location = new Point(11, 57);
            panelFiltrosCompras.Margin = new Padding(3, 4, 3, 4);
            panelFiltrosCompras.Name = "panelFiltrosCompras";
            panelFiltrosCompras.Size = new Size(1520, 106);
            panelFiltrosCompras.TabIndex = 0;
            // 
            // lblComprasFiltros
            // 
            lblComprasFiltros.AutoSize = true;
            lblComprasFiltros.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblComprasFiltros.Location = new Point(11, 13);
            lblComprasFiltros.Name = "lblComprasFiltros";
            lblComprasFiltros.Size = new Size(198, 28);
            lblComprasFiltros.TabIndex = 0;
            lblComprasFiltros.Text = "Filtros de Búsqueda";
            // 
            // lblComprasDesde
            // 
            lblComprasDesde.AutoSize = true;
            lblComprasDesde.Location = new Point(11, 60);
            lblComprasDesde.Name = "lblComprasDesde";
            lblComprasDesde.Size = new Size(54, 20);
            lblComprasDesde.TabIndex = 1;
            lblComprasDesde.Text = "Desde:";
            // 
            // dtpComprasDesde
            // 
            dtpComprasDesde.Format = DateTimePickerFormat.Short;
            dtpComprasDesde.Location = new Point(69, 56);
            dtpComprasDesde.Margin = new Padding(3, 4, 3, 4);
            dtpComprasDesde.Name = "dtpComprasDesde";
            dtpComprasDesde.Size = new Size(137, 27);
            dtpComprasDesde.TabIndex = 2;
            // 
            // lblComprasHasta
            // 
            lblComprasHasta.AutoSize = true;
            lblComprasHasta.Location = new Point(217, 60);
            lblComprasHasta.Name = "lblComprasHasta";
            lblComprasHasta.Size = new Size(50, 20);
            lblComprasHasta.TabIndex = 3;
            lblComprasHasta.Text = "Hasta:";
            // 
            // dtpComprasHasta
            // 
            dtpComprasHasta.Format = DateTimePickerFormat.Short;
            dtpComprasHasta.Location = new Point(270, 56);
            dtpComprasHasta.Margin = new Padding(3, 4, 3, 4);
            dtpComprasHasta.Name = "dtpComprasHasta";
            dtpComprasHasta.Size = new Size(137, 27);
            dtpComprasHasta.TabIndex = 4;
            // 
            // btnComprasFiltrar
            // 
            btnComprasFiltrar.BackColor = Color.FromArgb(52, 152, 219);
            btnComprasFiltrar.FlatStyle = FlatStyle.Flat;
            btnComprasFiltrar.ForeColor = Color.White;
            btnComprasFiltrar.Location = new Point(423, 53);
            btnComprasFiltrar.Margin = new Padding(3, 4, 3, 4);
            btnComprasFiltrar.Name = "btnComprasFiltrar";
            btnComprasFiltrar.Size = new Size(114, 37);
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
            btnComprasLimpiar.Location = new Point(549, 53);
            btnComprasLimpiar.Margin = new Padding(3, 4, 3, 4);
            btnComprasLimpiar.Name = "btnComprasLimpiar";
            btnComprasLimpiar.Size = new Size(114, 37);
            btnComprasLimpiar.TabIndex = 6;
            btnComprasLimpiar.Text = "Limpiar";
            btnComprasLimpiar.UseVisualStyleBackColor = false;
            btnComprasLimpiar.Click += btnComprasLimpiar_Click;
            // 
            // btnExportarCompras
            // 
            btnExportarCompras.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportarCompras.BackColor = Color.FromArgb(46, 204, 113);
            btnExportarCompras.FlatStyle = FlatStyle.Flat;
            btnExportarCompras.ForeColor = Color.White;
            btnExportarCompras.Location = new Point(1370, 51);
            btnExportarCompras.Margin = new Padding(3, 4, 3, 4);
            btnExportarCompras.Name = "btnExportarCompras";
            btnExportarCompras.Size = new Size(137, 37);
            btnExportarCompras.TabIndex = 7;
            btnExportarCompras.Text = "📄 Exportar";
            btnExportarCompras.UseVisualStyleBackColor = false;
            btnExportarCompras.Click += btnExportarCompras_Click;
            // 
            // panelResumenCompras
            // 
            panelResumenCompras.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelResumenCompras.BackColor = Color.FromArgb(46, 204, 113);
            panelResumenCompras.BorderStyle = BorderStyle.FixedSingle;
            panelResumenCompras.Controls.Add(lblComprasResumen);
            panelResumenCompras.Controls.Add(lblComprasTotalTexto);
            panelResumenCompras.Controls.Add(lblComprasTotalGeneral);
            panelResumenCompras.Controls.Add(lblComprasCantidadTexto);
            panelResumenCompras.Controls.Add(lblComprasCantidad);
            panelResumenCompras.Controls.Add(lblComprasPromedioTexto);
            panelResumenCompras.Controls.Add(lblComprasPromedio);
            panelResumenCompras.Location = new Point(11, 177);
            panelResumenCompras.Margin = new Padding(3, 4, 3, 4);
            panelResumenCompras.Name = "panelResumenCompras";
            panelResumenCompras.Size = new Size(1520, 133);
            panelResumenCompras.TabIndex = 1;
            // 
            // lblComprasResumen
            // 
            lblComprasResumen.AutoSize = true;
            lblComprasResumen.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblComprasResumen.ForeColor = Color.White;
            lblComprasResumen.Location = new Point(11, 13);
            lblComprasResumen.Name = "lblComprasResumen";
            lblComprasResumen.Size = new Size(256, 32);
            lblComprasResumen.TabIndex = 0;
            lblComprasResumen.Text = "Resumen del Período";
            // 
            // lblComprasTotalTexto
            // 
            lblComprasTotalTexto.AutoSize = true;
            lblComprasTotalTexto.Font = new Font("Segoe UI", 10F);
            lblComprasTotalTexto.ForeColor = Color.White;
            lblComprasTotalTexto.Location = new Point(11, 67);
            lblComprasTotalTexto.Name = "lblComprasTotalTexto";
            lblComprasTotalTexto.Size = new Size(114, 23);
            lblComprasTotalTexto.TabIndex = 1;
            lblComprasTotalTexto.Text = "Total General:";
            // 
            // lblComprasTotalGeneral
            // 
            lblComprasTotalGeneral.AutoSize = true;
            lblComprasTotalGeneral.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblComprasTotalGeneral.ForeColor = Color.White;
            lblComprasTotalGeneral.Location = new Point(11, 87);
            lblComprasTotalGeneral.Name = "lblComprasTotalGeneral";
            lblComprasTotalGeneral.Size = new Size(88, 37);
            lblComprasTotalGeneral.TabIndex = 2;
            lblComprasTotalGeneral.Text = "$0.00";
            // 
            // lblComprasCantidadTexto
            // 
            lblComprasCantidadTexto.AutoSize = true;
            lblComprasCantidadTexto.Font = new Font("Segoe UI", 10F);
            lblComprasCantidadTexto.ForeColor = Color.White;
            lblComprasCantidadTexto.Location = new Point(514, 67);
            lblComprasCantidadTexto.Name = "lblComprasCantidadTexto";
            lblComprasCantidadTexto.Size = new Size(207, 23);
            lblComprasCantidadTexto.TabIndex = 3;
            lblComprasCantidadTexto.Text = "Cantidad de Operaciones:";
            // 
            // lblComprasCantidad
            // 
            lblComprasCantidad.AutoSize = true;
            lblComprasCantidad.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblComprasCantidad.ForeColor = Color.White;
            lblComprasCantidad.Location = new Point(514, 87);
            lblComprasCantidad.Name = "lblComprasCantidad";
            lblComprasCantidad.Size = new Size(33, 37);
            lblComprasCantidad.TabIndex = 4;
            lblComprasCantidad.Text = "0";
            // 
            // lblComprasPromedioTexto
            // 
            lblComprasPromedioTexto.AutoSize = true;
            lblComprasPromedioTexto.Font = new Font("Segoe UI", 10F);
            lblComprasPromedioTexto.ForeColor = Color.White;
            lblComprasPromedioTexto.Location = new Point(971, 67);
            lblComprasPromedioTexto.Name = "lblComprasPromedioTexto";
            lblComprasPromedioTexto.Size = new Size(203, 23);
            lblComprasPromedioTexto.TabIndex = 5;
            lblComprasPromedioTexto.Text = "Promedio por Operación:";
            // 
            // lblComprasPromedio
            // 
            lblComprasPromedio.AutoSize = true;
            lblComprasPromedio.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblComprasPromedio.ForeColor = Color.White;
            lblComprasPromedio.Location = new Point(971, 87);
            lblComprasPromedio.Name = "lblComprasPromedio";
            lblComprasPromedio.Size = new Size(88, 37);
            lblComprasPromedio.TabIndex = 6;
            lblComprasPromedio.Text = "$0.00";
            // 
            // dgvCompras
            // 
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AllowUserToDeleteRows = false;
            dgvCompras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvCompras.BackgroundColor = Color.White;
            dgvCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompras.Location = new Point(11, 324);
            dgvCompras.Margin = new Padding(3, 4, 3, 4);
            dgvCompras.Name = "dgvCompras";
            dgvCompras.ReadOnly = true;
            dgvCompras.RowHeadersWidth = 51;
            dgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompras.Size = new Size(1029, 615);
            dgvCompras.TabIndex = 2;
            // 
            // chartCompras
            // 
            chartCompras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            chartCompras.Location = new Point(1057, 324);
            chartCompras.Margin = new Padding(3, 4, 3, 4);
            chartCompras.Name = "chartCompras";
            chartCompras.Size = new Size(476, 615);
            chartCompras.TabIndex = 3;
            chartCompras.Text = "chartCompras";
            // 
            // ReporteComprasForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1539, 940);
            Controls.Add(lblTituloCompras);
            Controls.Add(panelFiltrosCompras);
            Controls.Add(panelResumenCompras);
            Controls.Add(dgvCompras);
            Controls.Add(chartCompras);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ReporteComprasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reportes de Compras - SGVC";
            WindowState = FormWindowState.Maximized;
            panelFiltrosCompras.ResumeLayout(false);
            panelFiltrosCompras.PerformLayout();
            panelResumenCompras.ResumeLayout(false);
            panelResumenCompras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartCompras).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTituloCompras;
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
