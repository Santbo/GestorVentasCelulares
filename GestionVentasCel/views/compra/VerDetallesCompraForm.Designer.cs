namespace GestionVentasCel.views.compra
{
    partial class VerDetallesCompraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerDetallesCompraForm));
            lblProveedor = new Label();
            lblFecha = new Label();
            lblTotal = new Label();
            lblObservaciones = new Label();
            dgvDetalles = new DataGridView();
            btnCerrar = new Button();
            btnEditar = new Button();
            btnSalir = new Button();
            imageList1 = new ImageList(components);
            lblTituloForm = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProveedor.Location = new Point(18, 89);
            lblProveedor.Margin = new Padding(4, 0, 4, 0);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(121, 28);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor: ";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFecha.Location = new Point(18, 138);
            lblFecha.Margin = new Padding(4, 0, 4, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(77, 28);
            lblFecha.TabIndex = 1;
            lblFecha.Text = "Fecha: ";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(571, 89);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(84, 32);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total: ";
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblObservaciones.Location = new Point(18, 185);
            lblObservaciones.Margin = new Padding(4, 0, 4, 0);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(161, 28);
            lblObservaciones.TabIndex = 3;
            lblObservaciones.Text = "Observaciones: ";
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(18, 240);
            dgvDetalles.Margin = new Padding(4, 5, 4, 5);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.RowHeadersWidth = 51;
            dgvDetalles.RowTemplate.Height = 25;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(858, 500);
            dgvDetalles.TabIndex = 4;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(768, 753);
            btnCerrar.Margin = new Padding(4, 5, 4, 5);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(108, 50);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(651, 753);
            btnEditar.Margin = new Padding(4, 5, 4, 5);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(108, 50);
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
            btnSalir.Location = new Point(844, 12);
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
            lblTituloForm.Size = new Size(891, 77);
            lblTituloForm.TabIndex = 38;
            lblTituloForm.Text = "Detalles de la compra";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // VerDetallesCompraForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCerrar;
            ClientSize = new Size(891, 813);
            Controls.Add(btnSalir);
            Controls.Add(lblTituloForm);
            Controls.Add(btnCerrar);
            Controls.Add(btnEditar);
            Controls.Add(dgvDetalles);
            Controls.Add(lblObservaciones);
            Controls.Add(lblTotal);
            Controls.Add(lblFecha);
            Controls.Add(lblProveedor);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VerDetallesCompraForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalles de Compra";
            Load += VerDetallesCompraForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        private Label lblProveedor;
        private Label lblFecha;
        private Label lblTotal;
        private Label lblObservaciones;
        private DataGridView dgvDetalles;
        private Button btnCerrar;
        private Button btnEditar;
        private Button btnSalir;
        private Label lblTituloForm;
        private ImageList imageList1;
    }
}
