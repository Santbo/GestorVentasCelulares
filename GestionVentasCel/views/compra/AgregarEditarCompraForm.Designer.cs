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
            lblProveedor.Margin = new Padding(4, 0, 4, 0);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(106, 25);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor:";
            // 
            // cmbProveedor
            // 
            cmbProveedor.Dock = DockStyle.Bottom;
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.Font = new Font("Segoe UI", 12F);
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(0, 25);
            cmbProveedor.Margin = new Padding(4, 5, 4, 5);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(355, 40);
            cmbProveedor.TabIndex = 1;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Dock = DockStyle.Top;
            lblFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFecha.Location = new Point(0, 0);
            lblFecha.Margin = new Padding(4, 0, 4, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(66, 25);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Dock = DockStyle.Bottom;
            dtpFecha.Font = new Font("Segoe UI", 12F);
            dtpFecha.Location = new Point(0, 26);
            dtpFecha.Margin = new Padding(4, 5, 4, 5);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(300, 39);
            dtpFecha.TabIndex = 3;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Dock = DockStyle.Top;
            lblObservaciones.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblObservaciones.Location = new Point(0, 0);
            lblObservaciones.Margin = new Padding(4, 0, 4, 0);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(142, 25);
            lblObservaciones.TabIndex = 4;
            lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Dock = DockStyle.Bottom;
            txtObservaciones.Font = new Font("Segoe UI", 12F);
            txtObservaciones.Location = new Point(0, 30);
            txtObservaciones.Margin = new Padding(4, 5, 4, 5);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(1050, 135);
            txtObservaciones.TabIndex = 5;
            // 
            // lblArticulo
            // 
            lblArticulo.AutoSize = true;
            lblArticulo.Dock = DockStyle.Top;
            lblArticulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblArticulo.Location = new Point(0, 0);
            lblArticulo.Margin = new Padding(4, 0, 4, 0);
            lblArticulo.Name = "lblArticulo";
            lblArticulo.Size = new Size(86, 25);
            lblArticulo.TabIndex = 6;
            lblArticulo.Text = "Artículo:";
            // 
            // cmbArticulo
            // 
            cmbArticulo.Dock = DockStyle.Bottom;
            cmbArticulo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbArticulo.Font = new Font("Segoe UI", 12F);
            cmbArticulo.FormattingEnabled = true;
            cmbArticulo.Location = new Point(0, 30);
            cmbArticulo.Margin = new Padding(4, 5, 4, 5);
            cmbArticulo.Name = "cmbArticulo";
            cmbArticulo.Size = new Size(357, 40);
            cmbArticulo.TabIndex = 7;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Dock = DockStyle.Top;
            lblCantidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidad.Location = new Point(0, 0);
            lblCantidad.Margin = new Padding(4, 0, 4, 0);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(93, 25);
            lblCantidad.TabIndex = 8;
            lblCantidad.Text = "Cantidad:";
            // 
            // numCantidad
            // 
            numCantidad.Dock = DockStyle.Bottom;
            numCantidad.Font = new Font("Segoe UI", 12F);
            numCantidad.Location = new Point(0, 31);
            numCantidad.Margin = new Padding(5, 6, 5, 6);
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(183, 39);
            numCantidad.TabIndex = 9;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPrecioUnitario
            // 
            lblPrecioUnitario.AutoSize = true;
            lblPrecioUnitario.Dock = DockStyle.Top;
            lblPrecioUnitario.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrecioUnitario.Location = new Point(0, 0);
            lblPrecioUnitario.Margin = new Padding(4, 0, 4, 0);
            lblPrecioUnitario.Name = "lblPrecioUnitario";
            lblPrecioUnitario.Size = new Size(144, 25);
            lblPrecioUnitario.TabIndex = 10;
            lblPrecioUnitario.Text = "Precio Unitario:";
            // 
            // numPrecioUnitario
            // 
            numPrecioUnitario.DecimalPlaces = 2;
            numPrecioUnitario.Dock = DockStyle.Bottom;
            numPrecioUnitario.Font = new Font("Segoe UI", 12F);
            numPrecioUnitario.Location = new Point(0, 31);
            numPrecioUnitario.Margin = new Padding(5, 6, 5, 6);
            numPrecioUnitario.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numPrecioUnitario.Name = "numPrecioUnitario";
            numPrecioUnitario.Size = new Size(202, 39);
            numPrecioUnitario.TabIndex = 11;
            numPrecioUnitario.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAgregarDetalle
            // 
            btnAgregarDetalle.Location = new Point(782, 366);
            btnAgregarDetalle.Margin = new Padding(4, 5, 4, 5);
            btnAgregarDetalle.Name = "btnAgregarDetalle";
            btnAgregarDetalle.Size = new Size(142, 40);
            btnAgregarDetalle.TabIndex = 12;
            btnAgregarDetalle.Text = "Agregar Detalle";
            btnAgregarDetalle.UseVisualStyleBackColor = true;
            btnAgregarDetalle.Click += btnAgregarDetalle_Click;
            // 
            // btnEliminarDetalle
            // 
            btnEliminarDetalle.Location = new Point(932, 366);
            btnEliminarDetalle.Margin = new Padding(4, 5, 4, 5);
            btnEliminarDetalle.Name = "btnEliminarDetalle";
            btnEliminarDetalle.Size = new Size(142, 40);
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
            dgvDetalles.Location = new Point(18, 417);
            dgvDetalles.Margin = new Padding(4, 5, 4, 5);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.RowHeadersWidth = 51;
            dgvDetalles.RowTemplate.Height = 25;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(1050, 332);
            dgvDetalles.TabIndex = 14;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(805, 763);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(77, 32);
            lblTotal.TabIndex = 15;
            lblTotal.Text = "Total:";
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtTotal.Location = new Point(873, 759);
            txtTotal.Margin = new Padding(4, 5, 4, 5);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(195, 39);
            txtTotal.TabIndex = 16;
            txtTotal.Text = "$0.00";
            txtTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(805, 802);
            btnGuardar.Margin = new Padding(4, 5, 4, 5);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(129, 50);
            btnGuardar.TabIndex = 17;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnDescartar
            // 
            btnDescartar.Location = new Point(942, 802);
            btnDescartar.Margin = new Padding(4, 5, 4, 5);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(129, 50);
            btnDescartar.TabIndex = 18;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(cmbProveedor);
            panel1.Controls.Add(lblProveedor);
            panel1.Location = new Point(18, 82);
            panel1.Name = "panel1";
            panel1.Size = new Size(355, 65);
            panel1.TabIndex = 19;
            // 
            // panel2
            // 
            panel2.Controls.Add(dtpFecha);
            panel2.Controls.Add(lblFecha);
            panel2.Location = new Point(768, 82);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 65);
            panel2.TabIndex = 20;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblObservaciones);
            panel3.Controls.Add(txtObservaciones);
            panel3.Location = new Point(18, 157);
            panel3.Name = "panel3";
            panel3.Size = new Size(1050, 165);
            panel3.TabIndex = 21;
            // 
            // panel4
            // 
            panel4.Controls.Add(lblArticulo);
            panel4.Controls.Add(cmbArticulo);
            panel4.Location = new Point(18, 336);
            panel4.Name = "panel4";
            panel4.Size = new Size(357, 70);
            panel4.TabIndex = 22;
            // 
            // panel5
            // 
            panel5.Controls.Add(lblCantidad);
            panel5.Controls.Add(numCantidad);
            panel5.Location = new Point(382, 336);
            panel5.Name = "panel5";
            panel5.Size = new Size(183, 70);
            panel5.TabIndex = 23;
            // 
            // panel6
            // 
            panel6.Controls.Add(lblPrecioUnitario);
            panel6.Controls.Add(numPrecioUnitario);
            panel6.Location = new Point(573, 336);
            panel6.Name = "panel6";
            panel6.Size = new Size(202, 70);
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
            btnSalir.Location = new Point(1036, 12);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(32, 32);
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
            lblTituloForm.Margin = new Padding(4, 0, 4, 0);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Padding = new Padding(9, 0, 9, 0);
            lblTituloForm.Size = new Size(1081, 77);
            lblTituloForm.TabIndex = 36;
            lblTituloForm.Text = "Agregar compra";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AgregarEditarCompraForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnDescartar;
            ClientSize = new Size(1081, 870);
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
            Margin = new Padding(4, 5, 4, 5);
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
