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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEditarArticuloForm));
            lblTitulo = new Label();
            label2 = new Label();
            txtNombre = new TextBox();
            label1 = new Label();
            txtAvisoStock = new TextBox();
            label3 = new Label();
            txtPrecio = new TextBox();
            label4 = new Label();
            txtStock = new TextBox();
            label5 = new Label();
            txtMarca = new TextBox();
            label6 = new Label();
            cbxCategoria = new ComboBox();
            label7 = new Label();
            txtDescripcion = new TextBox();
            btnDescartar = new Button();
            btnGuardar = new Button();
            addCategoria = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)addCategoria).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Verdana", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(253, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(292, 36);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Agregar Articulo";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 81);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 13;
            label2.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(68, 104);
            txtNombre.MaxLength = 45;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(203, 27);
            txtNombre.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 152);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 15;
            label1.Text = "Aviso de Stock";
            // 
            // txtAvisoStock
            // 
            txtAvisoStock.Location = new Point(68, 175);
            txtAvisoStock.MaxLength = 25;
            txtAvisoStock.Name = "txtAvisoStock";
            txtAvisoStock.Size = new Size(203, 27);
            txtAvisoStock.TabIndex = 16;
            txtAvisoStock.KeyPress += txtAvisoStock_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 229);
            label3.Name = "label3";
            label3.Size = new Size(118, 20);
            label3.TabIndex = 17;
            label3.Text = "Precio (Ej: 10.00)";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(68, 252);
            txtPrecio.MaxLength = 50;
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(203, 27);
            txtPrecio.TabIndex = 18;
            txtPrecio.KeyPress += txtPrecio_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 303);
            label4.Name = "label4";
            label4.Size = new Size(45, 20);
            label4.TabIndex = 19;
            label4.Text = "Stock";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(68, 326);
            txtStock.MaxLength = 50;
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(203, 27);
            txtStock.TabIndex = 20;
            txtStock.KeyPress += txtAvisoStock_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(389, 81);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 21;
            label5.Text = "Marca";
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(389, 104);
            txtMarca.MaxLength = 45;
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(203, 27);
            txtMarca.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(389, 152);
            label6.Name = "label6";
            label6.Size = new Size(74, 20);
            label6.TabIndex = 23;
            label6.Text = "Categoria";
            // 
            // cbxCategoria
            // 
            cbxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxCategoria.FormattingEnabled = true;
            cbxCategoria.Location = new Point(389, 174);
            cbxCategoria.Name = "cbxCategoria";
            cbxCategoria.Size = new Size(203, 28);
            cbxCategoria.TabIndex = 24;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(389, 229);
            label7.Name = "label7";
            label7.Size = new Size(87, 20);
            label7.TabIndex = 25;
            label7.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(389, 252);
            txtDescripcion.MaxLength = 256;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "(Opcional) Escribe una descripcion...";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(246, 104);
            txtDescripcion.TabIndex = 26;
            // 
            // btnDescartar
            // 
            btnDescartar.Location = new Point(397, 400);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(195, 38);
            btnDescartar.TabIndex = 27;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(598, 400);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(195, 38);
            btnGuardar.TabIndex = 28;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // addCategoria
            // 
            addCategoria.Image = (Image)resources.GetObject("addCategoria.Image");
            addCategoria.Location = new Point(598, 174);
            addCategoria.Name = "addCategoria";
            addCategoria.Size = new Size(37, 28);
            addCategoria.SizeMode = PictureBoxSizeMode.Zoom;
            addCategoria.TabIndex = 29;
            addCategoria.TabStop = false;
            addCategoria.Click += addCategoria_Click;
            // 
            // AgregarEditarArticuloForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(addCategoria);
            Controls.Add(btnGuardar);
            Controls.Add(btnDescartar);
            Controls.Add(txtDescripcion);
            Controls.Add(label7);
            Controls.Add(cbxCategoria);
            Controls.Add(label6);
            Controls.Add(txtMarca);
            Controls.Add(label5);
            Controls.Add(txtStock);
            Controls.Add(label4);
            Controls.Add(txtPrecio);
            Controls.Add(label3);
            Controls.Add(txtAvisoStock);
            Controls.Add(label1);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AgregarEditarArticuloForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += AgregarEditarArticuloForm_FormClosing;
            Load += AgregarEditarArticuloForm_Load;
            ((System.ComponentModel.ISupportInitialize)addCategoria).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

          

        private Label lblTitulo;
        private Label label2;
        private TextBox txtNombre;
        private Label label1;
        private TextBox txtAvisoStock;
        private Label label3;
        private TextBox txtPrecio;
        private Label label4;
        private TextBox txtStock;
        private Label label5;
        private TextBox txtMarca;
        private Label label6;
        private ComboBox cbxCategoria;
        private Label label7;
        private TextBox txtDescripcion;
        private Button btnDescartar;
        private Button btnGuardar;
        private PictureBox addCategoria;
    }
}