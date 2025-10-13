namespace GestionVentasCel.views.caja
{
    partial class RetiroCajaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RetiroCajaForm));
            lblMonto = new Label();
            txtDescripcion = new TextBox();
            lblDesripcion = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            panel1 = new Panel();
            nupMonto = new NumericUpDown();
            btnSalir = new Button();
            imageList1 = new ImageList(components);
            lblTituloForm = new Label();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nupMonto).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Dock = DockStyle.Top;
            lblMonto.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMonto.Location = new Point(0, 0);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(56, 20);
            lblMonto.TabIndex = 0;
            lblMonto.Text = "Monto";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Dock = DockStyle.Bottom;
            txtDescripcion.Font = new Font("Segoe UI", 12F);
            txtDescripcion.Location = new Point(0, 23);
            txtDescripcion.MaxLength = 255;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "Escribe el motivo del retiro...";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(390, 151);
            txtDescripcion.TabIndex = 1;
            txtDescripcion.KeyPress += txtDescripcion_KeyPress;
            // 
            // lblDesripcion
            // 
            lblDesripcion.AutoSize = true;
            lblDesripcion.Dock = DockStyle.Top;
            lblDesripcion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDesripcion.Location = new Point(0, 0);
            lblDesripcion.Name = "lblDesripcion";
            lblDesripcion.Size = new Size(90, 20);
            lblDesripcion.TabIndex = 0;
            lblDesripcion.Text = "Descripcion";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(294, 371);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(133, 44);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(155, 371);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(133, 44);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(nupMonto);
            panel1.Controls.Add(lblMonto);
            panel1.Location = new Point(37, 94);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(240, 54);
            panel1.TabIndex = 0;
            // 
            // nupMonto
            // 
            nupMonto.DecimalPlaces = 2;
            nupMonto.Dock = DockStyle.Bottom;
            nupMonto.Font = new Font("Segoe UI", 12F);
            nupMonto.Location = new Point(0, 20);
            nupMonto.Margin = new Padding(2);
            nupMonto.Maximum = new decimal(new int[] { 1410065407, 2, 0, 0 });
            nupMonto.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nupMonto.Name = "nupMonto";
            nupMonto.Size = new Size(240, 34);
            nupMonto.TabIndex = 1;
            nupMonto.ThousandsSeparator = true;
            nupMonto.Value = new decimal(new int[] { 1, 0, 0, 0 });
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
            btnSalir.Location = new Point(419, 10);
            btnSalir.Margin = new Padding(2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(26, 26);
            btnSalir.TabIndex = 41;
            btnSalir.TabStop = false;
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click_1;
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
            lblTituloForm.Size = new Size(457, 62);
            lblTituloForm.TabIndex = 42;
            lblTituloForm.Text = "Retiro de efectivo";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblDesripcion);
            panel2.Controls.Add(txtDescripcion);
            panel2.Location = new Point(37, 170);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(390, 174);
            panel2.TabIndex = 1;
            // 
            // RetiroCajaForm
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(457, 428);
            Controls.Add(panel2);
            Controls.Add(btnSalir);
            Controls.Add(lblTituloForm);
            Controls.Add(panel1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RetiroCajaForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += RetiroCajaForm_FormClosing;
            Load += RetiroCajaForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nupMonto).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblMonto;
        private TextBox txtDescripcion;
        private Label lblDesripcion;
        private Button btnGuardar;
        private Button btnCancelar;
        private Panel panel1;
        private NumericUpDown nupMonto;
        private Button btnSalir;
        private ImageList imageList1;
        private Label lblTituloForm;
        private Panel panel2;
    }
}