namespace GestionVentasCel.views.categoria
{
    partial class AgregarEditarCategoriaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEditarCategoriaForm));
            lblNombre = new Label();
            lblDescripcion = new Label();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            btnDescartar = new Button();
            btnGuardar = new Button();
            btnSalir = new Button();
            imageList1 = new ImageList(components);
            lblTituloForm = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Dock = DockStyle.Top;
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(0, 0);
            lblNombre.Margin = new Padding(4, 0, 4, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(81, 25);
            lblNombre.TabIndex = 13;
            lblNombre.Text = "Nombre";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Dock = DockStyle.Top;
            lblDescripcion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescripcion.Location = new Point(0, 0);
            lblDescripcion.Margin = new Padding(4, 0, 4, 0);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(111, 25);
            lblDescripcion.TabIndex = 14;
            lblDescripcion.Text = "Descripción";
            // 
            // txtNombre
            // 
            txtNombre.Dock = DockStyle.Bottom;
            txtNombre.Font = new Font("Segoe UI", 12F);
            txtNombre.Location = new Point(0, 29);
            txtNombre.Margin = new Padding(4);
            txtNombre.MaxLength = 45;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(300, 39);
            txtNombre.TabIndex = 15;
            txtNombre.KeyPress += txtNombre_KeyPress;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Dock = DockStyle.Bottom;
            txtDescripcion.Location = new Point(0, 29);
            txtDescripcion.Margin = new Padding(4);
            txtDescripcion.MaxLength = 256;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(300, 164);
            txtDescripcion.TabIndex = 16;
            // 
            // btnDescartar
            // 
            btnDescartar.Location = new Point(13, 245);
            btnDescartar.Margin = new Padding(4);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(299, 48);
            btnDescartar.TabIndex = 17;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(13, 186);
            btnGuardar.Margin = new Padding(4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(299, 48);
            btnGuardar.TabIndex = 18;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
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
            btnSalir.Location = new Point(623, 12);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(32, 32);
            btnSalir.TabIndex = 34;
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
            lblTituloForm.Size = new Size(667, 77);
            lblTituloForm.TabIndex = 33;
            lblTituloForm.Text = "Agregar categoría";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblNombre);
            panel1.Controls.Add(txtNombre);
            panel1.Location = new Point(12, 100);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 68);
            panel1.TabIndex = 35;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblDescripcion);
            panel2.Controls.Add(txtDescripcion);
            panel2.Location = new Point(343, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 193);
            panel2.TabIndex = 36;
            // 
            // AgregarEditarCategoriaForm
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnDescartar;
            ClientSize = new Size(667, 316);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnSalir);
            Controls.Add(lblTituloForm);
            Controls.Add(btnGuardar);
            Controls.Add(btnDescartar);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "AgregarEditarCategoriaForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += AgregarEditarCategoriaForm_FormClosing;
            Load += AgregarEditarCategoriaForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }
        private Label lblNombre;
        private Label lblDescripcion;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private Button btnDescartar;
        private Button btnGuardar;
        private Button btnSalir;
        private Label lblTituloForm;
        private ImageList imageList1;
        private Panel panel1;
        private Panel panel2;
    }
}