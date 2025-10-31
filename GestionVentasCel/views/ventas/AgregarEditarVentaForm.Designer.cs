namespace GestionVentasCel.views.ventas
{
    partial class AgregarEditarVentaForm
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
            components = new System.ComponentModel.Container();
            Panel panel1;
            Panel panel4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEditarVentaForm));
            comboCliente = new ComboBox();
            lblCliente = new Label();
            dtpFechaCreacion = new DateTimePicker();
            lblFecha = new Label();
            imageList1 = new ImageList(components);
            btnSalir = new Button();
            lblTituloForm = new Label();
            panel8 = new Panel();
            btnDescartar = new Button();
            btnGuardar = new Button();
            panel2 = new Panel();
            comboTipoPago = new ComboBox();
            lblTipoPago = new Label();
            dgvListarDetalles = new DataGridView();
            panel3 = new Panel();
            panel10 = new Panel();
            btnAgregarDetalle = new Button();
            btnEliminarDetalle = new Button();
            panel9 = new Panel();
            nupIVA = new NumericUpDown();
            lblIVA = new Label();
            panel7 = new Panel();
            nupCantidad = new NumericUpDown();
            lblCantidad = new Label();
            panel6 = new Panel();
            lblNuevoItem = new Label();
            txtDescripcionDetalle = new TextBox();
            panel5 = new Panel();
            comboBoxTipoItem = new ComboBox();
            lblTipoItem = new Label();
            panel11 = new Panel();
            lblTotal = new Label();
            lblTotalIVA = new Label();
            lblSubtotalSinIVA = new Label();
            panelEstado = new Panel();
            comboEstado = new ComboBox();
            lblEstado = new Label();
            panel1 = new Panel();
            panel4 = new Panel();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel8.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarDetalles).BeginInit();
            panel3.SuspendLayout();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nupIVA).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nupCantidad).BeginInit();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel11.SuspendLayout();
            panelEstado.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(comboCliente);
            panel1.Controls.Add(lblCliente);
            panel1.Location = new Point(12, 80);
            panel1.Name = "panel1";
            panel1.Size = new Size(718, 68);
            panel1.TabIndex = 0;
            // 
            // comboCliente
            // 
            comboCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboCliente.Dock = DockStyle.Bottom;
            comboCliente.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboCliente.FormattingEnabled = true;
            comboCliente.Location = new Point(0, 28);
            comboCliente.Margin = new Padding(3, 3, 3, 0);
            comboCliente.Name = "comboCliente";
            comboCliente.Size = new Size(718, 40);
            comboCliente.TabIndex = 1;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Dock = DockStyle.Top;
            lblCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCliente.Location = new Point(0, 0);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(71, 25);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente";
            // 
            // panel4
            // 
            panel4.Controls.Add(dtpFechaCreacion);
            panel4.Controls.Add(lblFecha);
            panel4.Location = new Point(1132, 80);
            panel4.Name = "panel4";
            panel4.Size = new Size(300, 68);
            panel4.TabIndex = 100003;
            // 
            // dtpFechaCreacion
            // 
            dtpFechaCreacion.Dock = DockStyle.Bottom;
            dtpFechaCreacion.Enabled = false;
            dtpFechaCreacion.Font = new Font("Segoe UI", 12F);
            dtpFechaCreacion.Location = new Point(0, 29);
            dtpFechaCreacion.Name = "dtpFechaCreacion";
            dtpFechaCreacion.Size = new Size(300, 39);
            dtpFechaCreacion.TabIndex = 1;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Dock = DockStyle.Top;
            lblFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFecha.Location = new Point(0, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(61, 25);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fecha";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "xmark-solid-full.png");
            imageList1.Images.SetKeyName(1, "plus-solid.png");
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
            btnSalir.Location = new Point(1404, 12);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(32, 32);
            btnSalir.TabIndex = 38;
            btnSalir.TabStop = false;
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblTituloForm
            // 
            lblTituloForm.Dock = DockStyle.Top;
            lblTituloForm.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloForm.Location = new Point(0, 0);
            lblTituloForm.Margin = new Padding(4, 0, 4, 0);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Padding = new Padding(9, 0, 9, 0);
            lblTituloForm.Size = new Size(1448, 77);
            lblTituloForm.TabIndex = 99999;
            lblTituloForm.Text = "Agregar venta";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel8.Controls.Add(btnDescartar);
            panel8.Controls.Add(btnGuardar);
            panel8.Location = new Point(1029, 728);
            panel8.Margin = new Padding(2);
            panel8.Name = "panel8";
            panel8.Size = new Size(407, 46);
            panel8.TabIndex = 3;
            // 
            // btnDescartar
            // 
            btnDescartar.Location = new Point(3, 3);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(195, 38);
            btnDescartar.TabIndex = 0;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Visible = false;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.Location = new Point(208, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(195, 38);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(comboTipoPago);
            panel2.Controls.Add(lblTipoPago);
            panel2.Location = new Point(781, 80);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 68);
            panel2.TabIndex = 1;
            // 
            // comboTipoPago
            // 
            comboTipoPago.Dock = DockStyle.Bottom;
            comboTipoPago.Font = new Font("Segoe UI", 12F);
            comboTipoPago.FormattingEnabled = true;
            comboTipoPago.Location = new Point(0, 28);
            comboTipoPago.Name = "comboTipoPago";
            comboTipoPago.Size = new Size(300, 40);
            comboTipoPago.TabIndex = 0;
            // 
            // lblTipoPago
            // 
            lblTipoPago.AutoSize = true;
            lblTipoPago.Dock = DockStyle.Top;
            lblTipoPago.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTipoPago.Location = new Point(0, 0);
            lblTipoPago.Name = "lblTipoPago";
            lblTipoPago.Size = new Size(124, 25);
            lblTipoPago.TabIndex = 0;
            lblTipoPago.Text = "Tipo de pago";
            // 
            // dgvListarDetalles
            // 
            dgvListarDetalles.AllowUserToAddRows = false;
            dgvListarDetalles.AllowUserToDeleteRows = false;
            dgvListarDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListarDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListarDetalles.Dock = DockStyle.Bottom;
            dgvListarDetalles.Location = new Point(0, 165);
            dgvListarDetalles.Margin = new Padding(4);
            dgvListarDetalles.Name = "dgvListarDetalles";
            dgvListarDetalles.ReadOnly = true;
            dgvListarDetalles.RowHeadersWidth = 51;
            dgvListarDetalles.Size = new Size(1421, 326);
            dgvListarDetalles.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(panel10);
            panel3.Controls.Add(panel9);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(dgvListarDetalles);
            panel3.Location = new Point(12, 165);
            panel3.Name = "panel3";
            panel3.Size = new Size(1421, 491);
            panel3.TabIndex = 2;
            // 
            // panel10
            // 
            panel10.Controls.Add(btnAgregarDetalle);
            panel10.Controls.Add(btnEliminarDetalle);
            panel10.Location = new Point(0, 110);
            panel10.Name = "panel10";
            panel10.Size = new Size(442, 48);
            panel10.TabIndex = 8;
            // 
            // btnAgregarDetalle
            // 
            btnAgregarDetalle.Dock = DockStyle.Left;
            btnAgregarDetalle.Location = new Point(0, 0);
            btnAgregarDetalle.Name = "btnAgregarDetalle";
            btnAgregarDetalle.Size = new Size(195, 48);
            btnAgregarDetalle.TabIndex = 6;
            btnAgregarDetalle.Text = "Agregar";
            btnAgregarDetalle.UseVisualStyleBackColor = true;
            btnAgregarDetalle.Click += btnAgregarDetalle_Click;
            // 
            // btnEliminarDetalle
            // 
            btnEliminarDetalle.Dock = DockStyle.Right;
            btnEliminarDetalle.Location = new Point(201, 0);
            btnEliminarDetalle.Name = "btnEliminarDetalle";
            btnEliminarDetalle.Size = new Size(241, 48);
            btnEliminarDetalle.TabIndex = 7;
            btnEliminarDetalle.Text = "Eliminar seleccionado";
            btnEliminarDetalle.UseVisualStyleBackColor = true;
            btnEliminarDetalle.Click += btnEliminarDetalle_Click;
            // 
            // panel9
            // 
            panel9.Controls.Add(nupIVA);
            panel9.Controls.Add(lblIVA);
            panel9.Location = new Point(1247, 6);
            panel9.Name = "panel9";
            panel9.Size = new Size(173, 73);
            panel9.TabIndex = 5;
            // 
            // nupIVA
            // 
            nupIVA.Dock = DockStyle.Bottom;
            nupIVA.Enabled = false;
            nupIVA.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nupIVA.Location = new Point(0, 34);
            nupIVA.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nupIVA.Name = "nupIVA";
            nupIVA.ReadOnly = true;
            nupIVA.Size = new Size(173, 39);
            nupIVA.TabIndex = 1;
            // 
            // lblIVA
            // 
            lblIVA.AutoSize = true;
            lblIVA.Dock = DockStyle.Top;
            lblIVA.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIVA.Location = new Point(0, 0);
            lblIVA.Name = "lblIVA";
            lblIVA.Size = new Size(163, 25);
            lblIVA.TabIndex = 0;
            lblIVA.Text = "Porcentaje de IVA";
            // 
            // panel7
            // 
            panel7.Controls.Add(nupCantidad);
            panel7.Controls.Add(lblCantidad);
            panel7.Location = new Point(1052, 6);
            panel7.Name = "panel7";
            panel7.Size = new Size(167, 73);
            panel7.TabIndex = 4;
            // 
            // nupCantidad
            // 
            nupCantidad.Dock = DockStyle.Bottom;
            nupCantidad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nupCantidad.Location = new Point(0, 34);
            nupCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nupCantidad.Name = "nupCantidad";
            nupCantidad.Size = new Size(167, 39);
            nupCantidad.TabIndex = 1;
            nupCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Dock = DockStyle.Top;
            lblCantidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidad.Location = new Point(0, 0);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(88, 25);
            lblCantidad.TabIndex = 0;
            lblCantidad.Text = "Cantidad";
            // 
            // panel6
            // 
            panel6.Controls.Add(lblNuevoItem);
            panel6.Controls.Add(txtDescripcionDetalle);
            panel6.Location = new Point(295, 6);
            panel6.Name = "panel6";
            panel6.Size = new Size(733, 73);
            panel6.TabIndex = 3;
            // 
            // lblNuevoItem
            // 
            lblNuevoItem.AutoSize = true;
            lblNuevoItem.Dock = DockStyle.Top;
            lblNuevoItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNuevoItem.Location = new Point(0, 0);
            lblNuevoItem.Name = "lblNuevoItem";
            lblNuevoItem.Size = new Size(108, 25);
            lblNuevoItem.TabIndex = 3;
            lblNuevoItem.Text = "Item actual";
            // 
            // txtDescripcionDetalle
            // 
            txtDescripcionDetalle.Dock = DockStyle.Bottom;
            txtDescripcionDetalle.Font = new Font("Segoe UI", 12F);
            txtDescripcionDetalle.Location = new Point(0, 34);
            txtDescripcionDetalle.Name = "txtDescripcionDetalle";
            txtDescripcionDetalle.ReadOnly = true;
            txtDescripcionDetalle.Size = new Size(733, 39);
            txtDescripcionDetalle.TabIndex = 2;
            txtDescripcionDetalle.TabStop = false;
            // 
            // panel5
            // 
            panel5.Controls.Add(comboBoxTipoItem);
            panel5.Controls.Add(lblTipoItem);
            panel5.Location = new Point(12, 171);
            panel5.Name = "panel5";
            panel5.Size = new Size(271, 73);
            panel5.TabIndex = 9;
            // 
            // comboBoxTipoItem
            // 
            comboBoxTipoItem.Dock = DockStyle.Bottom;
            comboBoxTipoItem.Font = new Font("Segoe UI", 12F);
            comboBoxTipoItem.FormattingEnabled = true;
            comboBoxTipoItem.Items.AddRange(new object[] { "Artículo", "Reparación" });
            comboBoxTipoItem.Location = new Point(0, 33);
            comboBoxTipoItem.Name = "comboBoxTipoItem";
            comboBoxTipoItem.Size = new Size(271, 40);
            comboBoxTipoItem.TabIndex = 1;
            comboBoxTipoItem.SelectionChangeCommitted += comboBoxTipoItem_SelectionChangeCommitted;
            // 
            // lblTipoItem
            // 
            lblTipoItem.AutoSize = true;
            lblTipoItem.Dock = DockStyle.Top;
            lblTipoItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTipoItem.Location = new Point(0, 0);
            lblTipoItem.Name = "lblTipoItem";
            lblTipoItem.Size = new Size(119, 25);
            lblTipoItem.TabIndex = 0;
            lblTipoItem.Text = "Tipo de ítem";
            // 
            // panel11
            // 
            panel11.Controls.Add(lblTotal);
            panel11.Controls.Add(lblTotalIVA);
            panel11.Controls.Add(lblSubtotalSinIVA);
            panel11.Location = new Point(666, 661);
            panel11.Name = "panel11";
            panel11.Size = new Size(766, 62);
            panel11.TabIndex = 100004;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(580, 16);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(59, 25);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total:";
            // 
            // lblTotalIVA
            // 
            lblTotalIVA.AutoSize = true;
            lblTotalIVA.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalIVA.Location = new Point(322, 16);
            lblTotalIVA.Name = "lblTotalIVA";
            lblTotalIVA.Size = new Size(97, 25);
            lblTotalIVA.TabIndex = 1;
            lblTotalIVA.Text = "IVA total: ";
            // 
            // lblSubtotalSinIVA
            // 
            lblSubtotalSinIVA.AutoSize = true;
            lblSubtotalSinIVA.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtotalSinIVA.Location = new Point(3, 16);
            lblSubtotalSinIVA.Name = "lblSubtotalSinIVA";
            lblSubtotalSinIVA.Size = new Size(158, 25);
            lblSubtotalSinIVA.TabIndex = 0;
            lblSubtotalSinIVA.Text = "Subtotal sin IVA: ";
            // 
            // panelEstado
            // 
            panelEstado.Controls.Add(comboEstado);
            panelEstado.Controls.Add(lblEstado);
            panelEstado.Location = new Point(12, 663);
            panelEstado.Name = "panelEstado";
            panelEstado.Size = new Size(300, 68);
            panelEstado.TabIndex = 100005;
            // 
            // comboEstado
            // 
            comboEstado.Dock = DockStyle.Bottom;
            comboEstado.Font = new Font("Segoe UI", 12F);
            comboEstado.FormattingEnabled = true;
            comboEstado.Location = new Point(0, 28);
            comboEstado.Name = "comboEstado";
            comboEstado.Size = new Size(300, 40);
            comboEstado.TabIndex = 0;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Dock = DockStyle.Top;
            lblEstado.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstado.Location = new Point(0, 0);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(148, 25);
            lblEstado.TabIndex = 0;
            lblEstado.Text = "Estado de venta";
            // 
            // AgregarEditarVentaForm
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1448, 785);
            Controls.Add(panelEstado);
            Controls.Add(panel11);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnSalir);
            Controls.Add(lblTituloForm);
            Controls.Add(panel8);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AgregarEditarVentaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AgregarEditarVentaForm";
            Load += AgregarEditarVentaForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel8.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarDetalles).EndInit();
            panel3.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nupIVA).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nupCantidad).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panelEstado.ResumeLayout(false);
            panelEstado.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalir;
        private Label lblTituloForm;
        private Panel panel8;
        private Button btnDescartar;
        private Button btnGuardar;
        private ImageList imageList1;
        private Label lblCliente;
        private ComboBox comboCliente;
        private Panel panel2;
        private ComboBox comboTipoPago;
        private Label lblTipoPago;
        private DataGridView dgvListarDetalles;
        private Panel panel3;
        private Panel panel4;
        private Label lblFecha;
        private DateTimePicker dtpFechaCreacion;
        private TextBox txtDescripcionDetalle;
        private Panel panel6;
        private Label lblNuevoItem;
        private Panel panel7;
        private NumericUpDown nupCantidad;
        private Label lblCantidad;
        private Panel panel9;
        private NumericUpDown nupIVA;
        private Label lblIVA;
        private Button btnAgregarDetalle;
        private Panel panel10;
        private Button btnEliminarDetalle;
        private Panel panel5;
        private Label lblTipoItem;
        private ComboBox comboBoxTipoItem;
        private Panel panel11;
        private Label lblSubtotalSinIVA;
        private Label lblTotalIVA;
        private Label lblTotal;
        private Panel panelEstado;
        private ComboBox comboEstado;
        private Label lblEstado;
    }
}