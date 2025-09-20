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
            lblProveedor.Location = new Point(14, 20);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(80, 20);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor:";
            // 
            // cmbProveedor
            // 
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(14, 44);
            cmbProveedor.Margin = new Padding(3, 4, 3, 4);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(285, 28);
            cmbProveedor.TabIndex = 1;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(306, 20);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(50, 20);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(306, 44);
            dtpFecha.Margin = new Padding(3, 4, 3, 4);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(228, 27);
            dtpFecha.TabIndex = 3;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(14, 93);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(108, 20);
            lblObservaciones.TabIndex = 4;
            lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(14, 117);
            txtObservaciones.Margin = new Padding(3, 4, 3, 4);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(521, 105);
            txtObservaciones.TabIndex = 5;
            // 
            // lblArticulo
            // 
            lblArticulo.AutoSize = true;
            lblArticulo.Location = new Point(14, 240);
            lblArticulo.Name = "lblArticulo";
            lblArticulo.Size = new Size(64, 20);
            lblArticulo.TabIndex = 6;
            lblArticulo.Text = "Artículo:";
            // 
            // cmbArticulo
            // 
            cmbArticulo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbArticulo.FormattingEnabled = true;
            cmbArticulo.Location = new Point(14, 264);
            cmbArticulo.Margin = new Padding(3, 4, 3, 4);
            cmbArticulo.Name = "cmbArticulo";
            cmbArticulo.Size = new Size(285, 28);
            cmbArticulo.TabIndex = 7;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(306, 240);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(72, 20);
            lblCantidad.TabIndex = 8;
            lblCantidad.Text = "Cantidad:";
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(306, 264);
            numCantidad.Margin = new Padding(3, 4, 3, 4);
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(114, 27);
            numCantidad.TabIndex = 9;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPrecioUnitario
            // 
            lblPrecioUnitario.AutoSize = true;
            lblPrecioUnitario.Location = new Point(427, 240);
            lblPrecioUnitario.Name = "lblPrecioUnitario";
            lblPrecioUnitario.Size = new Size(110, 20);
            lblPrecioUnitario.TabIndex = 10;
            lblPrecioUnitario.Text = "Precio Unitario:";
            // 
            // numPrecioUnitario
            // 
            numPrecioUnitario.DecimalPlaces = 2;
            numPrecioUnitario.Location = new Point(427, 264);
            numPrecioUnitario.Margin = new Padding(3, 4, 3, 4);
            numPrecioUnitario.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numPrecioUnitario.Name = "numPrecioUnitario";
            numPrecioUnitario.Size = new Size(114, 27);
            numPrecioUnitario.TabIndex = 11;
            numPrecioUnitario.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAgregarDetalle
            // 
            btnAgregarDetalle.Location = new Point(549, 264);
            btnAgregarDetalle.Margin = new Padding(3, 4, 3, 4);
            btnAgregarDetalle.Name = "btnAgregarDetalle";
            btnAgregarDetalle.Size = new Size(114, 31);
            btnAgregarDetalle.TabIndex = 12;
            btnAgregarDetalle.Text = "Agregar Detalle";
            btnAgregarDetalle.UseVisualStyleBackColor = true;
            btnAgregarDetalle.Click += btnAgregarDetalle_Click;
            // 
            // btnEliminarDetalle
            // 
            btnEliminarDetalle.Location = new Point(670, 264);
            btnEliminarDetalle.Margin = new Padding(3, 4, 3, 4);
            btnEliminarDetalle.Name = "btnEliminarDetalle";
            btnEliminarDetalle.Size = new Size(114, 31);
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
            dgvDetalles.Location = new Point(14, 303);
            dgvDetalles.Margin = new Padding(3, 4, 3, 4);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.RowHeadersWidth = 51;
            dgvDetalles.RowTemplate.Height = 25;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(770, 267);
            dgvDetalles.TabIndex = 14;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(571, 580);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(64, 28);
            lblTotal.TabIndex = 15;
            lblTotal.Text = "Total:";
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtTotal.Location = new Point(626, 577);
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
            btnGuardar.Location = new Point(571, 640);
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
            btnDescartar.Location = new Point(681, 640);
            btnDescartar.Margin = new Padding(3, 4, 3, 4);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(103, 40);
            btnDescartar.TabIndex = 18;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // AgregarEditarCompraForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 696);
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
