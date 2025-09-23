namespace GestionVentasCel.views.compra
{
    partial class VerArticulosAsociadosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerArticulosAsociadosForm));
            lblServicio = new Label();
            lblPrecio = new Label();
            lblDescripcion = new Label();
            dgvDetalles = new DataGridView();
            btnCerrar = new Button();
            btnEditar = new Button();
            btnSalir = new Button();
            imageList1 = new ImageList(components);
            lblTituloForm = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // lblServicio
            // 
            lblServicio.AutoSize = true;
            lblServicio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblServicio.Location = new Point(14, 71);
            lblServicio.Name = "lblServicio";
            lblServicio.Size = new Size(84, 23);
            lblServicio.TabIndex = 0;
            lblServicio.Text = "Servicio: ";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrecio.Location = new Point(14, 110);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(186, 23);
            lblPrecio.TabIndex = 1;
            lblPrecio.Text = "Precio Mano de obra: ";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDescripcion.Location = new Point(14, 148);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(113, 23);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripcion: ";
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(14, 192);
            dgvDetalles.Margin = new Padding(3, 4, 3, 4);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.RowHeadersWidth = 51;
            dgvDetalles.RowTemplate.Height = 25;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(686, 400);
            dgvDetalles.TabIndex = 4;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(614, 602);
            btnCerrar.Margin = new Padding(3, 4, 3, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(86, 40);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(521, 602);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(86, 40);
            btnEditar.TabIndex = 6;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
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
            btnSalir.Location = new Point(675, 10);
            btnSalir.Margin = new Padding(2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(26, 26);
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
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Padding = new Padding(7, 0, 7, 0);
            lblTituloForm.Size = new Size(713, 62);
            lblTituloForm.TabIndex = 38;
            lblTituloForm.Text = "Articulos Usados en Servicio";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // VerArticulosAsociadosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCerrar;
            ClientSize = new Size(713, 650);
            Controls.Add(btnSalir);
            Controls.Add(lblTituloForm);
            Controls.Add(btnCerrar);
            Controls.Add(btnEditar);
            Controls.Add(dgvDetalles);
            Controls.Add(lblDescripcion);
            Controls.Add(lblPrecio);
            Controls.Add(lblServicio);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VerArticulosAsociadosForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalles de Compra";
            Load += VerDetallesCompraForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        private Label lblServicio;
        private Label lblPrecio;
        private Label lblDescripcion;
        private DataGridView dgvDetalles;
        private Button btnCerrar;
        private Button btnEditar;
        private Button btnSalir;
        private Label lblTituloForm;
        private ImageList imageList1;
    }
}
