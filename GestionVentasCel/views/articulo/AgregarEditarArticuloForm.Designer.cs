namespace GestionVentasCel.views.articulo
{
    partial class AgregarEditarArticuloForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEditarArticuloForm));
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblAvisoStock = new Label();
            txtAvisoStock = new TextBox();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            lblStock = new Label();
            txtStock = new TextBox();
            lblMarca = new Label();
            txtMarca = new TextBox();
            lblCategoria = new Label();
            cbxCategoria = new ComboBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            btnDescartar = new Button();
            btnGuardar = new Button();
            addCategoria = new PictureBox();
            btnSalir = new Button();
            imageList1 = new ImageList(components);
            lblTituloForm = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            ((System.ComponentModel.ISupportInitialize)addCategoria).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
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
            // txtNombre
            // 
            txtNombre.Dock = DockStyle.Bottom;
            txtNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(0, 29);
            txtNombre.Margin = new Padding(4);
            txtNombre.MaxLength = 45;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(300, 39);
            txtNombre.TabIndex = 14;
            // 
            // lblAvisoStock
            // 
            lblAvisoStock.AutoSize = true;
            lblAvisoStock.Dock = DockStyle.Top;
            lblAvisoStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvisoStock.Location = new Point(0, 0);
            lblAvisoStock.Margin = new Padding(4, 0, 4, 0);
            lblAvisoStock.Name = "lblAvisoStock";
            lblAvisoStock.Size = new Size(137, 25);
            lblAvisoStock.TabIndex = 15;
            lblAvisoStock.Text = "Aviso de Stock";
            // 
            // txtAvisoStock
            // 
            txtAvisoStock.Dock = DockStyle.Bottom;
            txtAvisoStock.Font = new Font("Segoe UI", 12F);
            txtAvisoStock.Location = new Point(0, 30);
            txtAvisoStock.Margin = new Padding(4);
            txtAvisoStock.MaxLength = 25;
            txtAvisoStock.Name = "txtAvisoStock";
            txtAvisoStock.Size = new Size(300, 39);
            txtAvisoStock.TabIndex = 16;
            txtAvisoStock.KeyPress += txtAvisoStock_KeyPress;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Dock = DockStyle.Top;
            lblPrecio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrecio.Location = new Point(0, 0);
            lblPrecio.Margin = new Padding(4, 0, 4, 0);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(154, 25);
            lblPrecio.TabIndex = 17;
            lblPrecio.Text = "Precio (Ej: 10.00)";
            // 
            // txtPrecio
            // 
            txtPrecio.Dock = DockStyle.Bottom;
            txtPrecio.Font = new Font("Segoe UI", 12F);
            txtPrecio.Location = new Point(0, 29);
            txtPrecio.Margin = new Padding(4);
            txtPrecio.MaxLength = 50;
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(300, 39);
            txtPrecio.TabIndex = 18;
            txtPrecio.KeyPress += txtPrecio_KeyPress;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Dock = DockStyle.Top;
            lblStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStock.Location = new Point(0, 0);
            lblStock.Margin = new Padding(4, 0, 4, 0);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(59, 25);
            lblStock.TabIndex = 19;
            lblStock.Text = "Stock";
            // 
            // txtStock
            // 
            txtStock.Dock = DockStyle.Bottom;
            txtStock.Font = new Font("Segoe UI", 12F);
            txtStock.Location = new Point(0, 29);
            txtStock.Margin = new Padding(4);
            txtStock.MaxLength = 50;
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(300, 39);
            txtStock.TabIndex = 20;
            txtStock.KeyPress += txtAvisoStock_KeyPress;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Dock = DockStyle.Top;
            lblMarca.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMarca.Location = new Point(0, 0);
            lblMarca.Margin = new Padding(4, 0, 4, 0);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(65, 25);
            lblMarca.TabIndex = 21;
            lblMarca.Text = "Marca";
            // 
            // txtMarca
            // 
            txtMarca.Dock = DockStyle.Bottom;
            txtMarca.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMarca.Location = new Point(0, 29);
            txtMarca.Margin = new Padding(4);
            txtMarca.MaxLength = 45;
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(300, 39);
            txtMarca.TabIndex = 22;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Dock = DockStyle.Top;
            lblCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCategoria.Location = new Point(0, 0);
            lblCategoria.Margin = new Padding(4, 0, 4, 0);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(94, 25);
            lblCategoria.TabIndex = 23;
            lblCategoria.Text = "Categoría";
            // 
            // cbxCategoria
            // 
            cbxCategoria.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cbxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxCategoria.Font = new Font("Segoe UI", 12F);
            cbxCategoria.FormattingEnabled = true;
            cbxCategoria.Location = new Point(0, 30);
            cbxCategoria.Margin = new Padding(4);
            cbxCategoria.Name = "cbxCategoria";
            cbxCategoria.Size = new Size(253, 40);
            cbxCategoria.TabIndex = 24;
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
            lblDescripcion.TabIndex = 25;
            lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Dock = DockStyle.Bottom;
            txtDescripcion.Location = new Point(0, 32);
            txtDescripcion.Margin = new Padding(4);
            txtDescripcion.MaxLength = 256;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "(Opcional) Escribe una descripcion...";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(300, 129);
            txtDescripcion.TabIndex = 26;
            // 
            // btnDescartar
            // 
            btnDescartar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDescartar.Location = new Point(182, 500);
            btnDescartar.Margin = new Padding(4);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(244, 48);
            btnDescartar.TabIndex = 27;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuardar.Location = new Point(434, 500);
            btnGuardar.Margin = new Padding(4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(244, 48);
            btnGuardar.TabIndex = 28;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // addCategoria
            // 
            addCategoria.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            addCategoria.Image = (Image)resources.GetObject("addCategoria.Image");
            addCategoria.Location = new Point(254, 34);
            addCategoria.Margin = new Padding(4);
            addCategoria.Name = "addCategoria";
            addCategoria.Size = new Size(46, 35);
            addCategoria.SizeMode = PictureBoxSizeMode.Zoom;
            addCategoria.TabIndex = 29;
            addCategoria.TabStop = false;
            addCategoria.Click += addCategoria_Click;
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
            btnSalir.Location = new Point(628, 23);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(32, 32);
            btnSalir.TabIndex = 32;
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
            lblTituloForm.Size = new Size(686, 77);
            lblTituloForm.TabIndex = 31;
            lblTituloForm.Text = "Agregar artículo";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblNombre);
            panel1.Controls.Add(txtNombre);
            panel1.Location = new Point(25, 101);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 68);
            panel1.TabIndex = 33;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtMarca);
            panel2.Controls.Add(lblMarca);
            panel2.Location = new Point(342, 101);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 68);
            panel2.TabIndex = 34;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblAvisoStock);
            panel3.Controls.Add(txtAvisoStock);
            panel3.Location = new Point(25, 176);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 69);
            panel3.TabIndex = 35;
            // 
            // panel4
            // 
            panel4.Controls.Add(lblPrecio);
            panel4.Controls.Add(txtPrecio);
            panel4.Location = new Point(25, 251);
            panel4.Name = "panel4";
            panel4.Size = new Size(300, 68);
            panel4.TabIndex = 36;
            // 
            // panel5
            // 
            panel5.Controls.Add(lblStock);
            panel5.Controls.Add(txtStock);
            panel5.Location = new Point(25, 344);
            panel5.Name = "panel5";
            panel5.Size = new Size(300, 68);
            panel5.TabIndex = 37;
            // 
            // panel6
            // 
            panel6.Controls.Add(lblCategoria);
            panel6.Controls.Add(cbxCategoria);
            panel6.Controls.Add(addCategoria);
            panel6.Location = new Point(342, 175);
            panel6.Name = "panel6";
            panel6.Size = new Size(300, 70);
            panel6.TabIndex = 38;
            // 
            // panel7
            // 
            panel7.Controls.Add(lblDescripcion);
            panel7.Controls.Add(txtDescripcion);
            panel7.Location = new Point(342, 251);
            panel7.Name = "panel7";
            panel7.Size = new Size(300, 161);
            panel7.TabIndex = 39;
            // 
            // AgregarEditarArticuloForm
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnDescartar;
            ClientSize = new Size(686, 562);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnSalir);
            Controls.Add(btnGuardar);
            Controls.Add(btnDescartar);
            Controls.Add(lblTituloForm);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "AgregarEditarArticuloForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += AgregarEditarArticuloForm_FormClosing;
            Load += AgregarEditarArticuloForm_Load;
            ((System.ComponentModel.ISupportInitialize)addCategoria).EndInit();
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
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ResumeLayout(false);
        }
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblAvisoStock;
        private TextBox txtAvisoStock;
        private Label lblPrecio;
        private TextBox txtPrecio;
        private Label lblStock;
        private TextBox txtStock;
        private Label lblMarca;
        private TextBox txtMarca;
        private Label lblCategoria;
        private ComboBox cbxCategoria;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Button btnDescartar;
        private Button btnGuardar;
        private PictureBox addCategoria;
        private Button btnSalir;
        private Label lblTituloForm;
        private ImageList imageList1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
    }
}