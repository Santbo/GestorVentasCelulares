namespace GestionVentasCel.views.compra
{
    partial class VerDetallesReparacionForm
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



        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerDetallesReparacionForm));
            lblCliente = new Label();
            lblFechaIngreso = new Label();
            lblTotal = new Label();
            lblFechaEgreso = new Label();
            dgvDetalles = new DataGridView();
            btnCerrar = new Button();
            btnSalir = new Button();
            imageList1 = new ImageList(components);
            lblTituloForm = new Label();
            lblDispositivo = new Label();
            lblFallasReportadas = new Label();
            lblDiagnostico = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCliente.Location = new Point(14, 71);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(71, 23);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            // 
            // lblFechaIngreso
            // 
            lblFechaIngreso.AutoSize = true;
            lblFechaIngreso.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFechaIngreso.Location = new Point(389, 71);
            lblFechaIngreso.Name = "lblFechaIngreso";
            lblFechaIngreso.Size = new Size(129, 23);
            lblFechaIngreso.TabIndex = 1;
            lblFechaIngreso.Text = "Fecha Ingreso: ";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(414, 205);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(70, 28);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total: ";
            // 
            // lblFechaEgreso
            // 
            lblFechaEgreso.AutoSize = true;
            lblFechaEgreso.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFechaEgreso.Location = new Point(389, 110);
            lblFechaEgreso.Name = "lblFechaEgreso";
            lblFechaEgreso.Size = new Size(118, 23);
            lblFechaEgreso.TabIndex = 3;
            lblFechaEgreso.Text = "Fecha Egreso:";
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(14, 274);
            dgvDetalles.Margin = new Padding(3, 4, 3, 4);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.RowHeadersWidth = 51;
            dgvDetalles.RowTemplate.Height = 25;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(686, 318);
            dgvDetalles.TabIndex = 4;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(614, 602);
            btnCerrar.Margin = new Padding(3, 4, 3, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(86, 40);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ImageKey = "xmark-solid-full.png";
            btnSalir.ImageList = imageList1;
            btnSalir.Location = new Point(675, 10);
            btnSalir.Margin = new Padding(2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(26, 26);
            btnSalir.TabIndex = 39;
            btnSalir.TabStop = false;
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "xmark-solid-full.png");
            // 
            // lblTituloForm
            // 
            lblTituloForm.Dock = DockStyle.Top;
            lblTituloForm.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloForm.Location = new Point(0, 0);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Padding = new Padding(7, 0, 7, 0);
            lblTituloForm.Size = new Size(713, 62);
            lblTituloForm.TabIndex = 38;
            lblTituloForm.Text = "Detalles de la Reparacion";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDispositivo
            // 
            lblDispositivo.AutoSize = true;
            lblDispositivo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDispositivo.Location = new Point(14, 110);
            lblDispositivo.Name = "lblDispositivo";
            lblDispositivo.Size = new Size(129, 28);
            lblDispositivo.TabIndex = 40;
            lblDispositivo.Text = "Dispositivo: ";
            // 
            // lblFallasReportadas
            // 
            lblFallasReportadas.AutoSize = true;
            lblFallasReportadas.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFallasReportadas.Location = new Point(12, 159);
            lblFallasReportadas.Name = "lblFallasReportadas";
            lblFallasReportadas.Size = new Size(183, 28);
            lblFallasReportadas.TabIndex = 41;
            lblFallasReportadas.Text = "Fallas Reportadas:";
            // 
            // lblDiagnostico
            // 
            lblDiagnostico.AutoSize = true;
            lblDiagnostico.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDiagnostico.Location = new Point(14, 205);
            lblDiagnostico.Name = "lblDiagnostico";
            lblDiagnostico.Size = new Size(130, 28);
            lblDiagnostico.TabIndex = 42;
            lblDiagnostico.Text = "Diagnostico:";
            // 
            // VerDetallesReparacionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCerrar;
            ClientSize = new Size(713, 650);
            Controls.Add(lblDiagnostico);
            Controls.Add(lblFallasReportadas);
            Controls.Add(lblDispositivo);
            Controls.Add(btnSalir);
            Controls.Add(lblTituloForm);
            Controls.Add(btnCerrar);
            Controls.Add(dgvDetalles);
            Controls.Add(lblFechaEgreso);
            Controls.Add(lblTotal);
            Controls.Add(lblFechaIngreso);
            Controls.Add(lblCliente);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VerDetallesReparacionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalles de Compra";
            Load += VerDetallesCompraForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        private Label lblCliente;
        private Label lblFechaIngreso;
        private Label lblTotal;
        private Label lblFechaEgreso;
        private DataGridView dgvDetalles;
        private Button btnCerrar;
        private Button btnSalir;
        private Label lblTituloForm;
        private ImageList imageList1;
        private Label lblDispositivo;
        private Label lblFallasReportadas;
        private Label lblDiagnostico;
    }
}
