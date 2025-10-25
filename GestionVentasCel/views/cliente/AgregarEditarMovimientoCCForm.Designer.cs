namespace GestionVentasCel.views.usuario_empleado
{
    partial class AgregarEditarMovimientoCCForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEditarMovimientoCCForm));
            btnDescartar = new Button();
            btnGuardar = new Button();
            lblMonto = new Label();
            lblTipoMovimiento = new Label();
            comboTipoMov = new ComboBox();
            lblFecha = new Label();
            panel1 = new Panel();
            nMonto = new NumericUpDown();
            panel2 = new Panel();
            dtpFecha = new DateTimePicker();
            panel3 = new Panel();
            panel8 = new Panel();
            panel11 = new Panel();
            panel4 = new Panel();
            txtDescripcion = new TextBox();
            lblDescripcion = new Label();
            btnSalir = new Button();
            imageList1 = new ImageList(components);
            lblTituloForm = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nMonto).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel8.SuspendLayout();
            panel11.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // btnDescartar
            // 
            btnDescartar.Location = new Point(0, 4);
            btnDescartar.Margin = new Padding(4);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(244, 48);
            btnDescartar.TabIndex = 9;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(252, 4);
            btnGuardar.Margin = new Padding(4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(244, 48);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Dock = DockStyle.Top;
            lblMonto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMonto.Location = new Point(0, 0);
            lblMonto.Margin = new Padding(4, 0, 4, 0);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(69, 25);
            lblMonto.TabIndex = 14;
            lblMonto.Text = "Monto";
            // 
            // lblTipoMovimiento
            // 
            lblTipoMovimiento.AutoSize = true;
            lblTipoMovimiento.Dock = DockStyle.Top;
            lblTipoMovimiento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTipoMovimiento.Location = new Point(0, 0);
            lblTipoMovimiento.Margin = new Padding(4, 0, 4, 0);
            lblTipoMovimiento.Name = "lblTipoMovimiento";
            lblTipoMovimiento.Size = new Size(184, 25);
            lblTipoMovimiento.TabIndex = 19;
            lblTipoMovimiento.Text = "Tipo de Movimiento";
            // 
            // comboTipoMov
            // 
            comboTipoMov.Dock = DockStyle.Bottom;
            comboTipoMov.Font = new Font("Segoe UI", 12F);
            comboTipoMov.FormattingEnabled = true;
            comboTipoMov.Location = new Point(0, 26);
            comboTipoMov.Margin = new Padding(4);
            comboTipoMov.Name = "comboTipoMov";
            comboTipoMov.Size = new Size(300, 40);
            comboTipoMov.TabIndex = 2;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Dock = DockStyle.Top;
            lblFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFecha.Location = new Point(0, 0);
            lblFecha.Margin = new Padding(4, 0, 4, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(61, 25);
            lblFecha.TabIndex = 21;
            lblFecha.Text = "Fecha";
            // 
            // panel1
            // 
            panel1.Controls.Add(nMonto);
            panel1.Controls.Add(lblMonto);
            panel1.Location = new Point(10, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 66);
            panel1.TabIndex = 0;
            // 
            // nMonto
            // 
            nMonto.DecimalPlaces = 2;
            nMonto.Dock = DockStyle.Bottom;
            nMonto.Font = new Font("Segoe UI", 12F);
            nMonto.Location = new Point(0, 27);
            nMonto.Maximum = new decimal(new int[] { -1486618625, 232830643, 0, 0 });
            nMonto.Name = "nMonto";
            nMonto.Size = new Size(300, 39);
            nMonto.TabIndex = 15;
            nMonto.ThousandsSeparator = true;
            nMonto.Leave += nMonto_Leave;
            // 
            // panel2
            // 
            panel2.Controls.Add(dtpFecha);
            panel2.Controls.Add(lblFecha);
            panel2.Location = new Point(660, 30);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 66);
            panel2.TabIndex = 4;
            // 
            // dtpFecha
            // 
            dtpFecha.Dock = DockStyle.Bottom;
            dtpFecha.Font = new Font("Segoe UI", 12F);
            dtpFecha.Location = new Point(0, 27);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(300, 39);
            dtpFecha.TabIndex = 22;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblTipoMovimiento);
            panel3.Controls.Add(comboTipoMov);
            panel3.Location = new Point(332, 30);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 66);
            panel3.TabIndex = 2;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel8.Controls.Add(btnDescartar);
            panel8.Controls.Add(btnGuardar);
            panel8.Location = new Point(461, 396);
            panel8.Name = "panel8";
            panel8.Size = new Size(500, 57);
            panel8.TabIndex = 30;
            // 
            // panel11
            // 
            panel11.Controls.Add(panel4);
            panel11.Controls.Add(panel3);
            panel11.Controls.Add(panel2);
            panel11.Controls.Add(panel1);
            panel11.Location = new Point(0, 80);
            panel11.Name = "panel11";
            panel11.Size = new Size(975, 301);
            panel11.TabIndex = 33;
            // 
            // panel4
            // 
            panel4.Controls.Add(txtDescripcion);
            panel4.Controls.Add(lblDescripcion);
            panel4.Location = new Point(10, 114);
            panel4.Name = "panel4";
            panel4.Size = new Size(953, 142);
            panel4.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Dock = DockStyle.Bottom;
            txtDescripcion.Font = new Font("Segoe UI", 12F);
            txtDescripcion.Location = new Point(0, 37);
            txtDescripcion.MaxLength = 255;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(953, 105);
            txtDescripcion.TabIndex = 15;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Dock = DockStyle.Top;
            lblDescripcion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDescripcion.Location = new Point(0, 0);
            lblDescripcion.Margin = new Padding(4, 0, 4, 0);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(111, 25);
            lblDescripcion.TabIndex = 14;
            lblDescripcion.Text = "Descripción";
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
            btnSalir.Location = new Point(931, 12);
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
            lblTituloForm.Size = new Size(975, 77);
            lblTituloForm.TabIndex = 36;
            lblTituloForm.Text = "Agregar movimiento";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AgregarEditarMovimientoCCForm
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnDescartar;
            ClientSize = new Size(975, 465);
            Controls.Add(btnSalir);
            Controls.Add(lblTituloForm);
            Controls.Add(panel11);
            Controls.Add(panel8);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AgregarEditarMovimientoCCForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += AgregarEditarMovimientoCCForm_FormClosing;
            Load += AgregarEditarMovimientoCCForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nMonto).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel8.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button btnDescartar;
        private Button btnGuardar;
        private TextBox txtNombre;
        private Label lblMonto;
        private Label lblTipoMovimiento;
        private ComboBox comboTipoMov;
        private Label lblFecha;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel8;
        private Panel panel11;
        private DateTimePicker dtpFecha;
        private NumericUpDown nMonto;
        private Panel panel4;
        private TextBox txtDescripcion;
        private Label lblDescripcion;
        private Button btnSalir;
        private Label lblTituloForm;
        private ImageList imageList1;
    }
}