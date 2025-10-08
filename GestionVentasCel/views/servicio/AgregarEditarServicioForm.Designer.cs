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
            nudPrecio = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dgvListarArticulos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            SuspendLayout();
            // 
            // dgvListarArticulos
            // 
            dgvListarArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListarArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListarArticulos.Location = new Point(15, 246);
            dgvListarArticulos.Margin = new Padding(4, 4, 4, 4);
            dgvListarArticulos.Name = "dgvListarArticulos";
            dgvListarArticulos.RowHeadersWidth = 51;
            dgvListarArticulos.Size = new Size(974, 240);
            dgvListarArticulos.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(15, 11);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(282, 48);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Agregar Servicio";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(15, 95);
            txtNombre.Margin = new Padding(4, 4, 4, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(270, 31);
            txtNombre.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 66);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(73, 25);
            label1.TabIndex = 3;
            label1.Text = "Servicio";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(312, 66);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 5;
            label2.Text = "Precio";
            // 
            // cmbArticulos
            // 
            cmbArticulos.FormattingEnabled = true;
            cmbArticulos.Location = new Point(15, 165);
            cmbArticulos.Margin = new Padding(4, 4, 4, 4);
            cmbArticulos.Name = "cmbArticulos";
            cmbArticulos.Size = new Size(774, 33);
            cmbArticulos.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 136);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(163, 25);
            label3.TabIndex = 7;
            label3.Text = "Articulos Utilizados";
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(798, 165);
            numCantidad.Margin = new Padding(4, 4, 4, 4);
            numCantidad.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(188, 31);
            numCantidad.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(798, 135);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(83, 25);
            label4.TabIndex = 9;
            label4.Text = "Cantidad";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(742, 208);
            btnAgregar.Margin = new Padding(4, 4, 4, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(118, 36);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(868, 208);
            btnEliminar.Margin = new Padding(4, 4, 4, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(118, 36);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(841, 494);
            btnGuardar.Margin = new Padding(4, 4, 4, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(148, 54);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnDescartar
            // 
            btnDescartar.Location = new Point(686, 494);
            btnDescartar.Margin = new Padding(4, 4, 4, 4);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(148, 54);
            btnDescartar.TabIndex = 13;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(612, 95);
            txtDescripcion.Margin = new Padding(4, 4, 4, 4);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "(Opcional)";
            txtDescripcion.Size = new Size(270, 31);
            txtDescripcion.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(612, 66);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(104, 25);
            label5.TabIndex = 15;
            label5.Text = "Descripcion";
            // 
            // nudPrecio
            // 
            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Location = new Point(312, 96);
            nudPrecio.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPrecio.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(274, 31);
            nudPrecio.TabIndex = 16;
            nudPrecio.ThousandsSeparator = true;
            nudPrecio.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // AgregarEditarServicioForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(nudPrecio);
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
            Controls.Add(label1);
            Controls.Add(txtNombre);
            Controls.Add(lblTitulo);
            Controls.Add(dgvListarArticulos);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 4, 4, 4);
            Name = "AgregarEditarServicioForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += AgregarEditarServicioForm_FormClosing;
            Load += AgregarEditarServicioForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListarArticulos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvListarArticulos;
        private Label lblTitulo;
        private TextBox txtNombre;
        private Label label1;
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
        private NumericUpDown nudPrecio;
    }
}