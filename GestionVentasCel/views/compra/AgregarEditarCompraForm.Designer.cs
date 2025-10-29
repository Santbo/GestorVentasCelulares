namespace GestionVentasCel.views.compra
{
    partial class AgregarEditarCompraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEditarCompraForm));
            lblProveedor = new Label();
            cmbProveedor = new ComboBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblObservaciones = new Label();
            txtObservaciones = new TextBox();
            lblArticulo = new Label();
            cmbArticulo = new ComboBox();
            lblCantidad = new Label();
            numCantidad = new NumericUpDown();
            lblPrecioUnitario = new Label();
            numPrecioUnitario = new NumericUpDown();
            btnAgregarDetalle = new Button();
            btnEliminarDetalle = new Button();
            dgvDetalles = new DataGridView();
            lblTotal = new Label();
            txtTotal = new TextBox();
            btnGuardar = new Button();
            btnDescartar = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            btnSalir = new Button();
            imageList1 = new ImageList(components);
            lblTituloForm = new Label();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecioUnitario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Dock = DockStyle.Top;
            lblProveedor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProveedor.Location = new Point(0, 0);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(86, 20);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor:";
            // 
            // cmbProveedor
            // 
            cmbProveedor.Dock = DockStyle.Bottom;
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.Font = new Font("Segoe UI", 12F);
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(0, 16);
            cmbProveedor.Margin = new Padding(3, 4, 3, 4);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(284, 36);
            cmbProveedor.TabIndex = 1;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Dock = DockStyle.Top;
            lblFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFecha.Location = new Point(0, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(53, 20);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Dock = DockStyle.Bottom;
            dtpFecha.Font = new Font("Segoe UI", 12F);
            dtpFecha.Location = new Point(0, 18);
            dtpFecha.Margin = new Padding(3, 4, 3, 4);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(240, 34);
            dtpFecha.TabIndex = 3;
            dtpFecha.Value = new DateTime(2025, 10, 28, 0, 0, 0, 0);
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Dock = DockStyle.Top;
            lblObservaciones.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblObservaciones.Location = new Point(0, 0);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(115, 20);
            lblObservaciones.TabIndex = 4;
            lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Dock = DockStyle.Bottom;
            txtObservaciones.Font = new Font("Segoe UI", 12F);
            txtObservaciones.Location = new Point(0, 23);
            txtObservaciones.Margin = new Padding(3, 4, 3, 4);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(840, 109);
            txtObservaciones.TabIndex = 5;
            // 
            // lblArticulo
            // 
            lblArticulo.AutoSize = true;
            lblArticulo.Dock = DockStyle.Top;
            lblArticulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblArticulo.Location = new Point(0, 0);
            lblArticulo.Name = "lblArticulo";
            lblArticulo.Size = new Size(69, 20);
            lblArticulo.TabIndex = 6;
            lblArticulo.Text = "Artículo:";
            // 
            // cmbArticulo
            // 
            cmbArticulo.Dock = DockStyle.Bottom;
            cmbArticulo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbArticulo.Font = new Font("Segoe UI", 12F);
            cmbArticulo.FormattingEnabled = true;
            cmbArticulo.Location = new Point(0, 20);
            cmbArticulo.Margin = new Padding(3, 4, 3, 4);
            cmbArticulo.Name = "cmbArticulo";
            cmbArticulo.Size = new Size(286, 36);
            cmbArticulo.TabIndex = 7;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Dock = DockStyle.Top;
            lblCantidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidad.Location = new Point(0, 0);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(75, 20);
            lblCantidad.TabIndex = 8;
            lblCantidad.Text = "Cantidad:";
            // 
            // numCantidad
            // 
            numCantidad.Dock = DockStyle.Bottom;
            numCantidad.Font = new Font("Segoe UI", 12F);
            numCantidad.Location = new Point(0, 22);
            numCantidad.Margin = new Padding(4, 5, 4, 5);
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(146, 34);
            numCantidad.TabIndex = 9;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPrecioUnitario
            // 
            lblPrecioUnitario.AutoSize = true;
            lblPrecioUnitario.Dock = DockStyle.Top;
            lblPrecioUnitario.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrecioUnitario.Location = new Point(0, 0);
            lblPrecioUnitario.Name = "lblPrecioUnitario";
            lblPrecioUnitario.Size = new Size(117, 20);
            lblPrecioUnitario.TabIndex = 10;
            lblPrecioUnitario.Text = "Precio Unitario:";
            // 
            // numPrecioUnitario
            // 
            numPrecioUnitario.DecimalPlaces = 2;
            numPrecioUnitario.Dock = DockStyle.Bottom;
            numPrecioUnitario.Font = new Font("Segoe UI", 12F);
            numPrecioUnitario.Location = new Point(0, 22);
            numPrecioUnitario.Margin = new Padding(4, 5, 4, 5);
            numPrecioUnitario.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numPrecioUnitario.Name = "numPrecioUnitario";
            numPrecioUnitario.Size = new Size(162, 34);
            numPrecioUnitario.TabIndex = 11;
            numPrecioUnitario.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAgregarDetalle
            // 
            btnAgregarDetalle.Location = new Point(626, 293);
            btnAgregarDetalle.Margin = new Padding(3, 4, 3, 4);
            btnAgregarDetalle.Name = "btnAgregarDetalle";
            btnAgregarDetalle.Size = new Size(114, 32);
            btnAgregarDetalle.TabIndex = 12;
            btnAgregarDetalle.Text = "Agregar Detalle";
            btnAgregarDetalle.UseVisualStyleBackColor = true;
            btnAgregarDetalle.Click += btnAgregarDetalle_Click;
            // 
            // btnEliminarDetalle
            // 
            btnEliminarDetalle.Location = new Point(746, 293);
            btnEliminarDetalle.Margin = new Padding(3, 4, 3, 4);
            btnEliminarDetalle.Name = "btnEliminarDetalle";
            btnEliminarDetalle.Size = new Size(114, 32);
            btnEliminarDetalle.TabIndex = 13;
            btnEliminarDetalle.Text = "Eliminar Detalle";
            btnEliminarDetalle.UseVisualStyleBackColor = true;
            btnEliminarDetalle.Click += btnEliminarDetalle_Click;
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.BorderStyle = BorderStyle.None;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(14, 334);
            dgvDetalles.Margin = new Padding(3, 4, 3, 4);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.RowHeadersWidth = 51;
            dgvDetalles.RowTemplate.Height = 25;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(840, 266);
            dgvDetalles.TabIndex = 14;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(644, 610);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(64, 28);
            lblTotal.TabIndex = 15;
            lblTotal.Text = "Total:";
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtTotal.Location = new Point(698, 607);
            txtTotal.Margin = new Padding(3, 4, 3, 4);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(157, 34);
            txtTotal.TabIndex = 16;
            txtTotal.Text = "$0.00";
            txtTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(644, 642);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(103, 40);
            btnGuardar.TabIndex = 17;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnDescartar
            // 
            btnDescartar.Location = new Point(754, 642);
            btnDescartar.Margin = new Padding(3, 4, 3, 4);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(103, 40);
            btnDescartar.TabIndex = 18;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(cmbProveedor);
            panel1.Controls.Add(lblProveedor);
            panel1.Location = new Point(14, 66);
            panel1.Margin = new Padding(2, 2, 2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(284, 52);
            panel1.TabIndex = 19;
            // 
            // panel2
            // 
            panel2.Controls.Add(dtpFecha);
            panel2.Controls.Add(lblFecha);
            panel2.Location = new Point(614, 66);
            panel2.Margin = new Padding(2, 2, 2, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(240, 52);
            panel2.TabIndex = 20;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblObservaciones);
            panel3.Controls.Add(txtObservaciones);
            panel3.Location = new Point(14, 126);
            panel3.Margin = new Padding(2, 2, 2, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(840, 132);
            panel3.TabIndex = 21;
            // 
            // panel4
            // 
            panel4.Controls.Add(lblArticulo);
            panel4.Controls.Add(cmbArticulo);
            panel4.Location = new Point(14, 269);
            panel4.Margin = new Padding(2, 2, 2, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(286, 56);
            panel4.TabIndex = 22;
            // 
            // panel5
            // 
            panel5.Controls.Add(lblCantidad);
            panel5.Controls.Add(numCantidad);
            panel5.Location = new Point(306, 269);
            panel5.Margin = new Padding(2, 2, 2, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(146, 56);
            panel5.TabIndex = 23;
            // 
            // panel6
            // 
            panel6.Controls.Add(lblPrecioUnitario);
            panel6.Controls.Add(numPrecioUnitario);
            panel6.Location = new Point(458, 269);
            panel6.Margin = new Padding(2, 2, 2, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(162, 56);
            panel6.TabIndex = 24;
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
            btnSalir.Location = new Point(829, 10);
            btnSalir.Margin = new Padding(2, 2, 2, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(26, 26);
            btnSalir.TabIndex = 37;
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
            lblTituloForm.Size = new Size(865, 62);
            lblTituloForm.TabIndex = 36;
            lblTituloForm.Text = "Agregar compra";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AgregarEditarCompraForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnDescartar;
            ClientSize = new Size(865, 696);
            Controls.Add(btnSalir);
            Controls.Add(lblTituloForm);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnDescartar);
            Controls.Add(btnGuardar);
            Controls.Add(txtTotal);
            Controls.Add(lblTotal);
            Controls.Add(dgvDetalles);
            Controls.Add(btnEliminarDetalle);
            Controls.Add(btnAgregarDetalle);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AgregarEditarCompraForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Agregar Compra";
            FormClosing += AgregarEditarCompraForm_FormClosing;
            Load += AgregarEditarCompraForm_Load;
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecioUnitario).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        private Label lblProveedor;
        private ComboBox cmbProveedor;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblObservaciones;
        private TextBox txtObservaciones;
        private Label lblArticulo;
        private ComboBox cmbArticulo;
        private Label lblCantidad;
        private NumericUpDown numCantidad;
        private Label lblPrecioUnitario;
        private NumericUpDown numPrecioUnitario;
        private Button btnAgregarDetalle;
        private Button btnEliminarDetalle;
        private DataGridView dgvDetalles;
        private Label lblTotal;
        private TextBox txtTotal;
        private Button btnGuardar;
        private Button btnDescartar;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Button btnSalir;
        private Label lblTituloForm;
        private ImageList imageList1;
    }
}
