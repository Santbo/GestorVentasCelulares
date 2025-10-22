namespace GestionVentasCel.views.caja
{
    partial class MontoAperturaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MontoAperturaForm));
            lblMonto = new Label();
            label1 = new Label();
            btnAbrirCaja = new Button();
            btnCancelar = new Button();
            btnSalir = new Button();
            imageList1 = new ImageList(components);
            lblTituloForm = new Label();
            nupMonto = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nupMonto).BeginInit();
            SuspendLayout();
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMonto.Location = new Point(38, 108);
            lblMonto.Margin = new Padding(4, 0, 4, 0);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(173, 32);
            lblMonto.TabIndex = 3;
            lblMonto.Text = "Monto inicial:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(224, 108);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(27, 32);
            label1.TabIndex = 4;
            label1.Text = "$";
            // 
            // btnAbrirCaja
            // 
            btnAbrirCaja.Location = new Point(273, 195);
            btnAbrirCaja.Margin = new Padding(4);
            btnAbrirCaja.Name = "btnAbrirCaja";
            btnAbrirCaja.Size = new Size(135, 60);
            btnAbrirCaja.TabIndex = 1;
            btnAbrirCaja.Text = "Abrir Caja";
            btnAbrirCaja.UseVisualStyleBackColor = true;
            btnAbrirCaja.Click += btnAbrirCaja_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(130, 195);
            btnCancelar.Margin = new Padding(4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(135, 60);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
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
            btnSalir.Location = new Point(494, 11);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(32, 32);
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
            lblTituloForm.Margin = new Padding(4, 0, 4, 0);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Padding = new Padding(9, 0, 9, 0);
            lblTituloForm.Size = new Size(538, 77);
            lblTituloForm.TabIndex = 40;
            lblTituloForm.Text = "Monto de apertura";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nupMonto
            // 
            nupMonto.DecimalPlaces = 2;
            nupMonto.Location = new Point(258, 109);
            nupMonto.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nupMonto.Name = "nupMonto";
            nupMonto.Size = new Size(199, 31);
            nupMonto.TabIndex = 41;
            nupMonto.ThousandsSeparator = true;
            nupMonto.Leave += nupMonto_Leave;
            // 
            // MontoAperturaForm
            // 
            AcceptButton = btnAbrirCaja;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(538, 268);
            Controls.Add(nupMonto);
            Controls.Add(btnSalir);
            Controls.Add(btnCancelar);
            Controls.Add(btnAbrirCaja);
            Controls.Add(label1);
            Controls.Add(lblMonto);
            Controls.Add(lblTituloForm);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "MontoAperturaForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += MontoAperturaForm_FormClosing;
            Load += MontoAperturaForm_Load;
            ((System.ComponentModel.ISupportInitialize)nupMonto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblMonto;
        private Label label1;
        private Button btnAbrirCaja;
        private Button btnCancelar;
        private Button btnSalir;
        private ImageList imageList1;
        private Label lblTituloForm;
        private NumericUpDown nupMonto;
    }
}