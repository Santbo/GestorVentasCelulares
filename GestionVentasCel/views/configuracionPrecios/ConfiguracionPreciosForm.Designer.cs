namespace GestionVentasCel.views.configuracionPrecios
{
    partial class ConfiguracionPreciosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfiguracionPreciosForm));
            txtAumento = new TextBox();
            lblMargen = new Label();
            btnGuardar = new Button();
            btnDescartar = new Button();
            lblPorcentaje = new Label();
            btnSalir = new Button();
            imageList1 = new ImageList(components);
            lblTituloForm = new Label();
            SuspendLayout();
            // 
            // txtAumento
            // 
            txtAumento.Location = new Point(233, 98);
            txtAumento.Margin = new Padding(4);
            txtAumento.MaxLength = 3;
            txtAumento.Name = "txtAumento";
            txtAumento.Size = new Size(80, 31);
            txtAumento.TabIndex = 1;
            txtAumento.KeyPress += txtAumento_KeyPress;
            // 
            // lblMargen
            // 
            lblMargen.AutoSize = true;
            lblMargen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMargen.Location = new Point(15, 101);
            lblMargen.Margin = new Padding(4, 0, 4, 0);
            lblMargen.Name = "lblMargen";
            lblMargen.Size = new Size(190, 25);
            lblMargen.TabIndex = 3;
            lblMargen.Text = "Margen de aumento:";
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnGuardar.Location = new Point(184, 171);
            btnGuardar.Margin = new Padding(4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(164, 55);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnDescartar
            // 
            btnDescartar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnDescartar.Location = new Point(15, 171);
            btnDescartar.Margin = new Padding(4);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(164, 55);
            btnDescartar.TabIndex = 5;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // lblPorcentaje
            // 
            lblPorcentaje.AutoSize = true;
            lblPorcentaje.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPorcentaje.Location = new Point(321, 101);
            lblPorcentaje.Margin = new Padding(4, 0, 4, 0);
            lblPorcentaje.Name = "lblPorcentaje";
            lblPorcentaje.Size = new Size(28, 25);
            lblPorcentaje.TabIndex = 6;
            lblPorcentaje.Text = "%";
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
            btnSalir.Location = new Point(324, 12);
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
            lblTituloForm.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblTituloForm.Location = new Point(0, 0);
            lblTituloForm.Margin = new Padding(4, 0, 4, 0);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Padding = new Padding(9, 0, 9, 0);
            lblTituloForm.Size = new Size(368, 77);
            lblTituloForm.TabIndex = 36;
            lblTituloForm.Text = "Margen de ganancia";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ConfiguracionPreciosForm
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnDescartar;
            ClientSize = new Size(368, 237);
            Controls.Add(btnSalir);
            Controls.Add(lblTituloForm);
            Controls.Add(lblPorcentaje);
            Controls.Add(btnDescartar);
            Controls.Add(btnGuardar);
            Controls.Add(lblMargen);
            Controls.Add(txtAumento);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "ConfiguracionPreciosForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += ConfiguracionPreciosForm_FormClosing;
            Load += ConfiguracionPreciosForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtAumento;
        private Label lblMargen;
        private Button btnGuardar;
        private Button btnDescartar;
        private Label lblPorcentaje;
        private Button btnSalir;
        private Label lblTituloForm;
        private ImageList imageList1;
    }
}