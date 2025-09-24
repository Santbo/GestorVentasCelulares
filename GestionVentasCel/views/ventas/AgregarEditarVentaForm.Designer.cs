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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEditarVentaForm));
            btnAgregarCliente = new Button();
            imageList1 = new ImageList(components);
            comboCliente = new ComboBox();
            lblCliente = new Label();
            btnSalir = new Button();
            lblTituloForm = new Label();
            panel8 = new Panel();
            btnDescartar = new Button();
            btnGuardar = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAgregarCliente);
            panel1.Controls.Add(comboCliente);
            panel1.Controls.Add(lblCliente);
            panel1.Location = new Point(12, 80);
            panel1.Name = "panel1";
            panel1.Size = new Size(338, 68);
            panel1.TabIndex = 0;
            // 
            // btnAgregarCliente
            // 
            btnAgregarCliente.ImageKey = "plus-solid.png";
            btnAgregarCliente.ImageList = imageList1;
            btnAgregarCliente.Location = new Point(288, 25);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(47, 43);
            btnAgregarCliente.TabIndex = 2;
            btnAgregarCliente.TabStop = false;
            btnAgregarCliente.UseVisualStyleBackColor = true;
            btnAgregarCliente.Click += btnAgregarCliente_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "xmark-solid-full.png");
            imageList1.Images.SetKeyName(1, "plus-solid.png");
            // 
            // comboCliente
            // 
            comboCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboCliente.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboCliente.FormattingEnabled = true;
            comboCliente.Location = new Point(0, 26);
            comboCliente.Margin = new Padding(3, 3, 3, 0);
            comboCliente.Name = "comboCliente";
            comboCliente.Size = new Size(285, 40);
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
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ImageKey = "xmark-solid-full.png";
            btnSalir.ImageList = imageList1;
            btnSalir.Location = new Point(1027, 12);
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
            lblTituloForm.Size = new Size(1071, 77);
            lblTituloForm.TabIndex = 99999;
            lblTituloForm.Text = "Agregar venta";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel8.Controls.Add(btnDescartar);
            panel8.Controls.Add(btnGuardar);
            panel8.Location = new Point(659, 728);
            panel8.Margin = new Padding(2);
            panel8.Name = "panel8";
            panel8.Size = new Size(400, 46);
            panel8.TabIndex = 36;
            // 
            // btnDescartar
            // 
            btnDescartar.Location = new Point(0, 3);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(195, 38);
            btnDescartar.TabIndex = 9;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(202, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(195, 38);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // AgregarEditarVentaForm
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnDescartar;
            ClientSize = new Size(1071, 785);
            Controls.Add(panel1);
            Controls.Add(btnSalir);
            Controls.Add(lblTituloForm);
            Controls.Add(panel8);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AgregarEditarVentaForm";
            Text = "AgregarEditarVentaForm";
            Load += AgregarEditarVentaForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel8.ResumeLayout(false);
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
        private Button btnAgregarCliente;
    }
}