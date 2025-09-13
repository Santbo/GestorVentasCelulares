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
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecioUnitario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(12, 15);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(59, 15);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor:";
            // 
            // cmbProveedor
            // 
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(12, 33);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(250, 23);
            cmbProveedor.TabIndex = 1;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(268, 15);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(38, 15);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(268, 33);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 23);
            dtpFecha.TabIndex = 3;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(12, 70);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(87, 15);
            lblObservaciones.TabIndex = 4;
            lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(12, 88);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(456, 80);
            txtObservaciones.TabIndex = 5;
            // 
            // lblArticulo
            // 
            lblArticulo.AutoSize = true;
            lblArticulo.Location = new Point(12, 180);
            lblArticulo.Name = "lblArticulo";
            lblArticulo.Size = new Size(51, 15);
            lblArticulo.TabIndex = 6;
            lblArticulo.Text = "Artículo:";
            // 
            // cmbArticulo
            // 
            cmbArticulo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbArticulo.FormattingEnabled = true;
            cmbArticulo.Location = new Point(12, 198);
            cmbArticulo.Name = "cmbArticulo";
            cmbArticulo.Size = new Size(250, 23);
            cmbArticulo.TabIndex = 7;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(268, 180);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(55, 15);
            lblCantidad.TabIndex = 8;
            lblCantidad.Text = "Cantidad:";
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(268, 198);
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(100, 23);
            numCantidad.TabIndex = 9;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPrecioUnitario
            // 
            lblPrecioUnitario.AutoSize = true;
            lblPrecioUnitario.Location = new Point(374, 180);
            lblPrecioUnitario.Name = "lblPrecioUnitario";
            lblPrecioUnitario.Size = new Size(88, 15);
            lblPrecioUnitario.TabIndex = 10;
            lblPrecioUnitario.Text = "Precio Unitario:";
            // 
            // numPrecioUnitario
            // 
            numPrecioUnitario.DecimalPlaces = 2;
            numPrecioUnitario.Location = new Point(374, 198);
            numPrecioUnitario.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numPrecioUnitario.Name = "numPrecioUnitario";
            numPrecioUnitario.Size = new Size(100, 23);
            numPrecioUnitario.TabIndex = 11;
            // 
            // btnAgregarDetalle
            // 
            btnAgregarDetalle.Location = new Point(480, 198);
            btnAgregarDetalle.Name = "btnAgregarDetalle";
            btnAgregarDetalle.Size = new Size(100, 23);
            btnAgregarDetalle.TabIndex = 12;
            btnAgregarDetalle.Text = "Agregar Detalle";
            btnAgregarDetalle.UseVisualStyleBackColor = true;
            btnAgregarDetalle.Click += btnAgregarDetalle_Click;
            // 
            // btnEliminarDetalle
            // 
            btnEliminarDetalle.Location = new Point(586, 198);
            btnEliminarDetalle.Name = "btnEliminarDetalle";
            btnEliminarDetalle.Size = new Size(100, 23);
            btnEliminarDetalle.TabIndex = 13;
            btnEliminarDetalle.Text = "Eliminar Detalle";
            btnEliminarDetalle.UseVisualStyleBackColor = true;
            btnEliminarDetalle.Click += btnEliminarDetalle_Click;
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(12, 227);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.RowTemplate.Height = 25;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(674, 200);
            dgvDetalles.TabIndex = 14;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotal.Location = new Point(500, 435);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(42, 21);
            lblTotal.TabIndex = 15;
            lblTotal.Text = "Total:";
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtTotal.Location = new Point(548, 433);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(138, 29);
            txtTotal.TabIndex = 16;
            txtTotal.Text = "$0.00";
            txtTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(500, 480);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 30);
            btnGuardar.TabIndex = 17;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnDescartar
            // 
            btnDescartar.Location = new Point(596, 480);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(90, 30);
            btnDescartar.TabIndex = 18;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // AgregarEditarCompraForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 522);
            Controls.Add(btnDescartar);
            Controls.Add(btnGuardar);
            Controls.Add(txtTotal);
            Controls.Add(lblTotal);
            Controls.Add(dgvDetalles);
            Controls.Add(btnEliminarDetalle);
            Controls.Add(btnAgregarDetalle);
            Controls.Add(numPrecioUnitario);
            Controls.Add(lblPrecioUnitario);
            Controls.Add(numCantidad);
            Controls.Add(lblCantidad);
            Controls.Add(cmbArticulo);
            Controls.Add(lblArticulo);
            Controls.Add(txtObservaciones);
            Controls.Add(lblObservaciones);
            Controls.Add(dtpFecha);
            Controls.Add(lblFecha);
            Controls.Add(cmbProveedor);
            Controls.Add(lblProveedor);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AgregarEditarCompraForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Agregar Compra";
            Load += AgregarEditarCompraForm_Load;
            FormClosing += AgregarEditarCompraForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecioUnitario).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
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
    }
}
