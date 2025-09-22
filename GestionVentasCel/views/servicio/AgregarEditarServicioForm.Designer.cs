namespace GestionVentasCel.views.servicio
{
    partial class AgregarEditarServicioForm
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
            dgvListarArticulos = new DataGridView();
            lblTitulo = new Label();
            txtNombre = new TextBox();
            label1 = new Label();
            txtPrecio = new TextBox();
            label2 = new Label();
            cmbArticulos = new ComboBox();
            label3 = new Label();
            numCantidad = new NumericUpDown();
            label4 = new Label();
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnDescartar = new Button();
            txtDescripcion = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvListarArticulos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            SuspendLayout();
            // 
            // dgvListarArticulos
            // 
            dgvListarArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListarArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListarArticulos.Location = new Point(12, 197);
            dgvListarArticulos.Name = "dgvListarArticulos";
            dgvListarArticulos.RowHeadersWidth = 51;
            dgvListarArticulos.Size = new Size(779, 192);
            dgvListarArticulos.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(234, 41);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Agregar Servicio";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 76);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(217, 27);
            txtNombre.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 53);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 3;
            label1.Text = "Servicio";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(250, 76);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(217, 27);
            txtPrecio.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(250, 53);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 5;
            label2.Text = "Precio";
            // 
            // cmbArticulos
            // 
            cmbArticulos.FormattingEnabled = true;
            cmbArticulos.Location = new Point(12, 132);
            cmbArticulos.Name = "cmbArticulos";
            cmbArticulos.Size = new Size(620, 28);
            cmbArticulos.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 109);
            label3.Name = "label3";
            label3.Size = new Size(137, 20);
            label3.TabIndex = 7;
            label3.Text = "Articulos Utilizados";
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(638, 132);
            numCantidad.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(150, 27);
            numCantidad.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(638, 108);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 9;
            label4.Text = "Cantidad";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(594, 166);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(694, 166);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(673, 395);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(118, 43);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnDescartar
            // 
            btnDescartar.Location = new Point(549, 395);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(118, 43);
            btnDescartar.TabIndex = 13;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(490, 76);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "(Opcional)";
            txtDescripcion.Size = new Size(217, 27);
            txtDescripcion.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(490, 53);
            label5.Name = "label5";
            label5.Size = new Size(87, 20);
            label5.TabIndex = 15;
            label5.Text = "Descripcion";
            // 
            // AgregarEditarServicioForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(txtDescripcion);
            Controls.Add(btnDescartar);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(label4);
            Controls.Add(numCantidad);
            Controls.Add(label3);
            Controls.Add(cmbArticulos);
            Controls.Add(label2);
            Controls.Add(txtPrecio);
            Controls.Add(label1);
            Controls.Add(txtNombre);
            Controls.Add(lblTitulo);
            Controls.Add(dgvListarArticulos);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AgregarEditarServicioForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += AgregarEditarServicioForm_FormClosing;
            Load += AgregarEditarServicioForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListarArticulos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvListarArticulos;
        private Label lblTitulo;
        private TextBox txtNombre;
        private Label label1;
        private TextBox txtPrecio;
        private Label label2;
        private ComboBox cmbArticulos;
        private Label label3;
        private NumericUpDown numCantidad;
        private Label label4;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnGuardar;
        private Button btnDescartar;
        private TextBox txtDescripcion;
        private Label label5;
    }
}