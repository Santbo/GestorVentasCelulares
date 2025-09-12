namespace GestionVentasCel.views.compra
{
    partial class CompraMainMenuForm
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
            dgvListarCompras = new DataGridView();
            panelBtn = new Panel();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnVerDetalle = new Button();
            btnFiltrarPorFecha = new Button();
            btnLimpiarFiltros = new Button();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            panelBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarCompras).BeginInit();
            SuspendLayout();
            // 
            // dgvListarCompras
            // 
            dgvListarCompras.AllowUserToAddRows = false;
            dgvListarCompras.AllowUserToDeleteRows = false;
            dgvListarCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListarCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListarCompras.Dock = DockStyle.Fill;
            dgvListarCompras.Location = new Point(0, 0);
            dgvListarCompras.Name = "dgvListarCompras";
            dgvListarCompras.ReadOnly = true;
            dgvListarCompras.RowHeadersWidth = 51;
            dgvListarCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListarCompras.Size = new Size(800, 381);
            dgvListarCompras.TabIndex = 0;
            // 
            // panelBtn
            // 
            panelBtn.BackColor = SystemColors.ActiveCaption;
            panelBtn.Controls.Add(lblBuscar);
            panelBtn.Controls.Add(txtBuscar);
            panelBtn.Controls.Add(btnLimpiarFiltros);
            panelBtn.Controls.Add(btnFiltrarPorFecha);
            panelBtn.Controls.Add(btnVerDetalle);
            panelBtn.Controls.Add(btnEliminar);
            panelBtn.Controls.Add(btnEditar);
            panelBtn.Controls.Add(btnAgregar);
            panelBtn.Dock = DockStyle.Bottom;
            panelBtn.Location = new Point(0, 381);
            panelBtn.Name = "panelBtn";
            panelBtn.Size = new Size(800, 69);
            panelBtn.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Right;
            btnAgregar.Location = new Point(667, 3);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(128, 60);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Right;
            btnEditar.Location = new Point(533, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(128, 60);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Right;
            btnEliminar.Location = new Point(399, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(128, 60);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Anchor = AnchorStyles.Right;
            btnVerDetalle.Location = new Point(265, 3);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(128, 60);
            btnVerDetalle.TabIndex = 3;
            btnVerDetalle.Text = "Ver Detalle";
            btnVerDetalle.UseVisualStyleBackColor = true;
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // btnFiltrarPorFecha
            // 
            btnFiltrarPorFecha.Anchor = AnchorStyles.Right;
            btnFiltrarPorFecha.Location = new Point(131, 3);
            btnFiltrarPorFecha.Name = "btnFiltrarPorFecha";
            btnFiltrarPorFecha.Size = new Size(128, 60);
            btnFiltrarPorFecha.TabIndex = 4;
            btnFiltrarPorFecha.Text = "Filtrar por Fecha";
            btnFiltrarPorFecha.UseVisualStyleBackColor = true;
            btnFiltrarPorFecha.Click += btnFiltrarPorFecha_Click;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Anchor = AnchorStyles.Right;
            btnLimpiarFiltros.Location = new Point(3, 3);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(122, 60);
            btnLimpiarFiltros.TabIndex = 5;
            btnLimpiarFiltros.Text = "Limpiar Filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(80, 9);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar compras...";
            txtBuscar.Size = new Size(266, 27);
            txtBuscar.TabIndex = 6;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(12, 12);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(62, 20);
            lblBuscar.TabIndex = 7;
            lblBuscar.Text = "Buscar:";
            // 
            // CompraMainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvListarCompras);
            Controls.Add(panelBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CompraMainMenuForm";
            Text = "Gestión de Compras";
            panelBtn.ResumeLayout(false);
            panelBtn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarCompras).EndInit();
            ResumeLayout(false);
        }

          

        private DataGridView dgvListarCompras;
        private Panel panelBtn;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnVerDetalle;
        private Button btnFiltrarPorFecha;
        private Button btnLimpiarFiltros;
        private TextBox txtBuscar;
        private Label lblBuscar;
    }
}