namespace GestionVentasCel.views.usuario_empleado
{
    partial class MovimientosCCMainMenuForm
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
            panelBtn = new Panel();
            btnVerDetalleVenta = new Button();
            lblSaldoActual = new Label();
            txtBuscar = new TextBox();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnAgregar = new Button();
            panelContenedor = new Panel();
            splitContainer1 = new SplitContainer();
            panelHeader = new Panel();
            lblTituloForm = new Label();
            dgvListarMovimientos = new DataGridView();
            panelBtn.SuspendLayout();
            panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarMovimientos).BeginInit();
            SuspendLayout();
            // 
            // panelBtn
            // 
            panelBtn.BackColor = SystemColors.ActiveCaption;
            panelBtn.Controls.Add(btnVerDetalleVenta);
            panelBtn.Controls.Add(lblSaldoActual);
            panelBtn.Controls.Add(txtBuscar);
            panelBtn.Controls.Add(btnEliminar);
            panelBtn.Controls.Add(btnEditar);
            panelBtn.Controls.Add(btnAgregar);
            panelBtn.Dock = DockStyle.Bottom;
            panelBtn.Location = new Point(0, 476);
            panelBtn.Margin = new Padding(4);
            panelBtn.Name = "panelBtn";
            panelBtn.Size = new Size(1349, 86);
            panelBtn.TabIndex = 0;
            // 
            // btnVerDetalleVenta
            // 
            btnVerDetalleVenta.Anchor = AnchorStyles.Right;
            btnVerDetalleVenta.Location = new Point(593, 7);
            btnVerDetalleVenta.Margin = new Padding(4);
            btnVerDetalleVenta.Name = "btnVerDetalleVenta";
            btnVerDetalleVenta.Size = new Size(201, 75);
            btnVerDetalleVenta.TabIndex = 6;
            btnVerDetalleVenta.Text = "Ver venta";
            btnVerDetalleVenta.UseVisualStyleBackColor = true;
            btnVerDetalleVenta.Click += btnVerDetalleVenta_Click;
            // 
            // lblSaldoActual
            // 
            lblSaldoActual.AutoSize = true;
            lblSaldoActual.Location = new Point(13, 51);
            lblSaldoActual.Name = "lblSaldoActual";
            lblSaldoActual.Size = new Size(117, 25);
            lblSaldoActual.TabIndex = 5;
            lblSaldoActual.Text = "Saldo actual: ";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(15, 11);
            txtBuscar.Margin = new Padding(4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por fecha";
            txtBuscar.Size = new Size(332, 31);
            txtBuscar.TabIndex = 4;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Right;
            btnEliminar.Location = new Point(802, 8);
            btnEliminar.Margin = new Padding(4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(201, 75);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Right;
            btnEditar.Location = new Point(1011, 8);
            btnEditar.Margin = new Padding(4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(160, 75);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Right;
            btnAgregar.Location = new Point(1178, 8);
            btnAgregar.Margin = new Padding(4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(160, 75);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.Controls.Add(splitContainer1);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 0);
            panelContenedor.Margin = new Padding(4);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1349, 476);
            panelContenedor.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panelHeader);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvListarMovimientos);
            splitContainer1.Panel2.Padding = new Padding(11, 4, 11, 4);
            splitContainer1.Size = new Size(1349, 476);
            splitContainer1.SplitterDistance = 55;
            splitContainer1.TabIndex = 5;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(lblTituloForm);
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1349, 55);
            panelHeader.TabIndex = 1;
            // 
            // lblTituloForm
            // 
            lblTituloForm.Dock = DockStyle.Fill;
            lblTituloForm.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloForm.Location = new Point(0, 0);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Padding = new Padding(8, 0, 8, 0);
            lblTituloForm.Size = new Size(1349, 55);
            lblTituloForm.TabIndex = 0;
            lblTituloForm.Text = "Movimientos de";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvListarMovimientos
            // 
            dgvListarMovimientos.AllowUserToAddRows = false;
            dgvListarMovimientos.AllowUserToDeleteRows = false;
            dgvListarMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListarMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListarMovimientos.Dock = DockStyle.Fill;
            dgvListarMovimientos.Location = new Point(11, 4);
            dgvListarMovimientos.Margin = new Padding(4);
            dgvListarMovimientos.MultiSelect = false;
            dgvListarMovimientos.Name = "dgvListarMovimientos";
            dgvListarMovimientos.ReadOnly = true;
            dgvListarMovimientos.RowHeadersWidth = 51;
            dgvListarMovimientos.Size = new Size(1327, 409);
            dgvListarMovimientos.TabIndex = 0;
            dgvListarMovimientos.SelectionChanged += dgvListarMovimientos_SelectionChanged;
            // 
            // MovimientosCCMainMenuForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1349, 562);
            Controls.Add(panelContenedor);
            Controls.Add(panelBtn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MinimizeBox = false;
            Name = "MovimientosCCMainMenuForm";
            Load += MovimientoCCMainMenuForm_Load;
            panelBtn.ResumeLayout(false);
            panelBtn.PerformLayout();
            panelContenedor.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvListarMovimientos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBtn;
        private Panel panelContenedor;
        private DataGridView dgvListarMovimientos;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnAgregar;
        private TextBox txtBuscar;
        private Label lblSaldoActual;
        private SplitContainer splitContainer1;
        private Panel panelHeader;
        private Label lblTituloForm;
        private Button btnVerDetalleVenta;
    }
}