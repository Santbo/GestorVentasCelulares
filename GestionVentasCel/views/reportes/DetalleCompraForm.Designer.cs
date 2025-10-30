using GestionVentasCel.temas;

namespace GestionVentasCel.views.reportes
{
    partial class DetalleCompraForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelInfo = new Panel();
            lblObservacionesValor = new Label();
            lblCondicionIvaValor = new Label();
            lblNumeroComprobanteValor = new Label();
            lblProveedorValor = new Label();
            lblFechaValor = new Label();
            lblNumeroCompraValor = new Label();
            lblObservaciones = new Label();
            lblCondicionIva = new Label();
            lblNumeroComprobante = new Label();
            lblProveedor = new Label();
            lblFecha = new Label();
            lblNumeroCompra = new Label();
            panelDetalles = new Panel();
            dgvDetalles = new DataGridView();
            lblDetalles = new Label();
            panelTotales = new Panel();
            lblTotalGeneralValor = new Label();
            lblTotalGeneral = new Label();
            panelInfo.SuspendLayout();
            panelDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            panelTotales.SuspendLayout();
            SuspendLayout();
            // 
            // panelInfo
            // 
            panelInfo.BackColor = Color.FromArgb(29, 53, 87);
            panelInfo.Controls.Add(lblObservacionesValor);
            panelInfo.Controls.Add(lblCondicionIvaValor);
            panelInfo.Controls.Add(lblNumeroComprobanteValor);
            panelInfo.Controls.Add(lblProveedorValor);
            panelInfo.Controls.Add(lblFechaValor);
            panelInfo.Controls.Add(lblNumeroCompraValor);
            panelInfo.Controls.Add(lblObservaciones);
            panelInfo.Controls.Add(lblCondicionIva);
            panelInfo.Controls.Add(lblNumeroComprobante);
            panelInfo.Controls.Add(lblProveedor);
            panelInfo.Controls.Add(lblFecha);
            panelInfo.Controls.Add(lblNumeroCompra);
            panelInfo.Dock = DockStyle.Top;
            panelInfo.Location = new Point(0, 0);
            panelInfo.Margin = new Padding(3, 4, 3, 4);
            panelInfo.Name = "panelInfo";
            panelInfo.Padding = new Padding(23, 27, 23, 27);
            panelInfo.Size = new Size(964, 160);
            panelInfo.TabIndex = 1;
            // 
            // lblObservacionesValor
            // 
            lblObservacionesValor.AutoSize = false;
            lblObservacionesValor.AutoEllipsis = true;
            lblObservacionesValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblObservacionesValor.ForeColor = Color.FromArgb(255, 255, 255);
            lblObservacionesValor.Location = new Point(575, 93);
            lblObservacionesValor.Name = "lblObservacionesValor";
            lblObservacionesValor.Size = new Size(366, 20);
            lblObservacionesValor.TabIndex = 11;
            // 
            // lblCondicionIvaValor
            // 
            lblCondicionIvaValor.AutoSize = false;
            lblCondicionIvaValor.AutoEllipsis = true;
            lblCondicionIvaValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCondicionIvaValor.ForeColor = Color.FromArgb(255, 255, 255);
            lblCondicionIvaValor.Location = new Point(571, 60);
            lblCondicionIvaValor.Name = "lblCondicionIvaValor";
            lblCondicionIvaValor.Size = new Size(370, 20);
            lblCondicionIvaValor.TabIndex = 10;
            // 
            // lblNumeroComprobanteValor
            // 
            lblNumeroComprobanteValor.AutoSize = false;
            lblNumeroComprobanteValor.AutoEllipsis = true;
            lblNumeroComprobanteValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNumeroComprobanteValor.ForeColor = Color.FromArgb(255, 255, 255);
            lblNumeroComprobanteValor.Location = new Point(591, 27);
            lblNumeroComprobanteValor.Name = "lblNumeroComprobanteValor";
            lblNumeroComprobanteValor.Size = new Size(350, 20);
            lblNumeroComprobanteValor.TabIndex = 9;
            // 
            // lblProveedorValor
            // 
            lblProveedorValor.AutoSize = false;
            lblProveedorValor.AutoEllipsis = true;
            lblProveedorValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProveedorValor.ForeColor = Color.FromArgb(255, 255, 255);
            lblProveedorValor.Location = new Point(112, 93);
            lblProveedorValor.Name = "lblProveedorValor";
            lblProveedorValor.Size = new Size(260, 20);
            lblProveedorValor.TabIndex = 8;
            // 
            // lblFechaValor
            // 
            lblFechaValor.AutoSize = false;
            lblFechaValor.AutoEllipsis = true;
            lblFechaValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFechaValor.ForeColor = Color.FromArgb(255, 255, 255);
            lblFechaValor.Location = new Point(79, 60);
            lblFechaValor.Name = "lblFechaValor";
            lblFechaValor.Size = new Size(260, 20);
            lblFechaValor.TabIndex = 7;
            // 
            // lblNumeroCompraValor
            // 
            lblNumeroCompraValor.AutoSize = false;
            lblNumeroCompraValor.AutoEllipsis = true;
            lblNumeroCompraValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNumeroCompraValor.ForeColor = Color.FromArgb(255, 255, 255);
            lblNumeroCompraValor.Location = new Point(177, 27);
            lblNumeroCompraValor.Name = "lblNumeroCompraValor";
            lblNumeroCompraValor.Size = new Size(260, 20);
            lblNumeroCompraValor.TabIndex = 6;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblObservaciones.ForeColor = Color.FromArgb(255, 255, 255);
            lblObservaciones.Location = new Point(457, 93);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(115, 20);
            lblObservaciones.TabIndex = 5;
            lblObservaciones.Text = "Observaciones:";
            // 
            // lblCondicionIva
            // 
            lblCondicionIva.AutoSize = true;
            lblCondicionIva.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCondicionIva.ForeColor = Color.FromArgb(255, 255, 255);
            lblCondicionIva.Location = new Point(457, 60);
            lblCondicionIva.Name = "lblCondicionIva";
            lblCondicionIva.Size = new Size(111, 20);
            lblCondicionIva.TabIndex = 4;
            lblCondicionIva.Text = "Condición IVA:";
            // 
            // lblNumeroComprobante
            // 
            lblNumeroComprobante.AutoSize = true;
            lblNumeroComprobante.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNumeroComprobante.ForeColor = Color.FromArgb(255, 255, 255);
            lblNumeroComprobante.Location = new Point(457, 27);
            lblNumeroComprobante.Name = "lblNumeroComprobante";
            lblNumeroComprobante.Size = new Size(131, 20);
            lblNumeroComprobante.TabIndex = 3;
            lblNumeroComprobante.Text = "N° Comprobante:";
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProveedor.ForeColor = Color.FromArgb(255, 255, 255);
            lblProveedor.Location = new Point(23, 93);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(86, 20);
            lblProveedor.TabIndex = 2;
            lblProveedor.Text = "Proveedor:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFecha.ForeColor = Color.FromArgb(255, 255, 255);
            lblFecha.Location = new Point(23, 60);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(53, 20);
            lblFecha.TabIndex = 1;
            lblFecha.Text = "Fecha:";
            // 
            // lblNumeroCompra
            // 
            lblNumeroCompra.AutoSize = true;
            lblNumeroCompra.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNumeroCompra.ForeColor = Color.FromArgb(255, 255, 255);
            lblNumeroCompra.Location = new Point(23, 27);
            lblNumeroCompra.Name = "lblNumeroCompra";
            lblNumeroCompra.Size = new Size(151, 20);
            lblNumeroCompra.TabIndex = 0;
            lblNumeroCompra.Text = "Número de Compra:";
            // 
            // panelDetalles
            // 
            panelDetalles.Controls.Add(dgvDetalles);
            panelDetalles.Controls.Add(lblDetalles);
            panelDetalles.Dock = DockStyle.Fill;
            panelDetalles.Location = new Point(0, 160);
            panelDetalles.Margin = new Padding(3, 4, 3, 4);
            panelDetalles.Name = "panelDetalles";
            panelDetalles.Padding = new Padding(23, 27, 23, 27);
            panelDetalles.Size = new Size(964, 301);
            panelDetalles.TabIndex = 2;
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToResizeColumns = false;
            dgvDetalles.AllowUserToResizeRows = false;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.BackgroundColor = Color.FromArgb(241, 250, 238);
            dgvDetalles.BorderStyle = BorderStyle.None;
            dgvDetalles.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Dock = DockStyle.Fill;
            dgvDetalles.GridColor = Color.FromArgb(29, 53, 87);
            dgvDetalles.Location = new Point(23, 27);
            dgvDetalles.Margin = new Padding(3, 4, 3, 4);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.RowHeadersVisible = false;
            dgvDetalles.RowHeadersWidth = 51;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(918, 247);
            dgvDetalles.TabIndex = 1;
            // 
            // lblDetalles
            // 
            lblDetalles.AutoSize = true;
            lblDetalles.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDetalles.ForeColor = Color.FromArgb(29, 53, 87);
            lblDetalles.Location = new Point(23, 13);
            lblDetalles.Name = "lblDetalles";
            lblDetalles.Size = new Size(0, 23);
            lblDetalles.TabIndex = 0;
            // 
            // panelTotales
            // 
            panelTotales.BackColor = Color.FromArgb(29, 53, 87);
            panelTotales.Controls.Add(lblTotalGeneralValor);
            panelTotales.Controls.Add(lblTotalGeneral);
            panelTotales.Dock = DockStyle.Bottom;
            panelTotales.Location = new Point(0, 461);
            panelTotales.Margin = new Padding(3, 4, 3, 4);
            panelTotales.Name = "panelTotales";
            panelTotales.Padding = new Padding(23, 27, 23, 27);
            panelTotales.Size = new Size(964, 157);
            panelTotales.TabIndex = 3;
            // 
            // lblTotalGeneralValor
            // 
            lblTotalGeneralValor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalGeneralValor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalGeneralValor.ForeColor = Color.FromArgb(255, 255, 255);
            lblTotalGeneralValor.Location = new Point(736, 27);
            lblTotalGeneralValor.Name = "lblTotalGeneralValor";
            lblTotalGeneralValor.Size = new Size(206, 28);
            lblTotalGeneralValor.TabIndex = 1;
            lblTotalGeneralValor.Text = "$0,00";
            lblTotalGeneralValor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalGeneral
            // 
            lblTotalGeneral.AutoSize = true;
            lblTotalGeneral.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalGeneral.ForeColor = Color.FromArgb(255, 255, 255);
            lblTotalGeneral.Location = new Point(23, 27);
            lblTotalGeneral.Name = "lblTotalGeneral";
            lblTotalGeneral.Size = new Size(143, 28);
            lblTotalGeneral.TabIndex = 0;
            lblTotalGeneral.Text = "Total General:";
            // 
            // DetalleCompraForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 618);
            Controls.Add(panelDetalles);
            Controls.Add(panelTotales);
            Controls.Add(panelInfo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DetalleCompraForm";
            Text = "Detalle de Compra";
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            panelDetalles.ResumeLayout(false);
            panelDetalles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            panelTotales.ResumeLayout(false);
            panelTotales.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelInfo;
        private Label lblNumeroCompra;
        private Label lblFecha;
        private Label lblProveedor;
        private Label lblNumeroComprobante;
        private Label lblCondicionIva;
        private Label lblObservaciones;
        private Label lblNumeroCompraValor;
        private Label lblFechaValor;
        private Label lblProveedorValor;
        private Label lblNumeroComprobanteValor;
        private Label lblCondicionIvaValor;
        private Label lblObservacionesValor;
        private Panel panelDetalles;
        private Label lblDetalles;
        private DataGridView dgvDetalles;
        private Panel panelTotales;
        private Label lblTotalGeneral;
        private Label lblTotalGeneralValor;
    }
}

