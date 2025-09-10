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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            label2 = new Label();
            label1 = new Label();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            btnDescartar = new Button();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Verdana", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(119, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(323, 36);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Agregar Categoria";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 69);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 13;
            label2.Text = "Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(296, 68);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 14;
            label1.Text = "Descripcion";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(38, 92);
            txtNombre.MaxLength = 45;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(203, 27);
            txtNombre.TabIndex = 15;
            txtNombre.KeyPress += txtNombre_KeyPress;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(296, 92);
            txtDescripcion.MaxLength = 256;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(246, 104);
            txtDescripcion.TabIndex = 16;
            // 
            // btnDescartar
            // 
            btnDescartar.Location = new Point(38, 159);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(195, 38);
            btnDescartar.TabIndex = 17;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(38, 203);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(195, 38);
            btnGuardar.TabIndex = 18;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // AgregarEditarCategoriaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 253);
            Controls.Add(btnGuardar);
            Controls.Add(btnDescartar);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AgregarEditarCategoriaForm";
            FormClosing += AgregarEditarCategoriaForm_FormClosing;
            Load += AgregarEditarCategoriaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label label2;
        private Label label1;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private Button btnDescartar;
        private Button btnGuardar;
    }
}