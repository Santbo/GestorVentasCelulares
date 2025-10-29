namespace GestionVentasCel.views.proveedor
{
    partial class ProveedorMainMenuForm
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
            btnAgregar = new Button();
            btnEditar = new Button();
            chkInactivos = new CheckBox();
            txtBuscar = new TextBox();
            btnToggleActivo = new Button();
            btnVerCompras = new Button();
            panelBtn = new Panel();
            dgvListar = new DataGridView();
            splitContainer1 = new SplitContainer();
            panelHeader = new Panel();
            lblTituloForm = new Label();
            panelBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
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
            // chkInactivos
            // 
            chkInactivos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkInactivos.AutoSize = true;
            chkInactivos.Location = new Point(12, 38);
            chkInactivos.Name = "chkInactivos";
            chkInactivos.Size = new Size(219, 24);
            chkInactivos.TabIndex = 2;
            chkInactivos.Text = "Incluir Proveedores Inactivos";
            chkInactivos.UseVisualStyleBackColor = true;
            chkInactivos.CheckedChanged += chkInactivos_CheckedChanged;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(12, 9);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "(Ctrl + F) Buscar proveedor";
            txtBuscar.Size = new Size(266, 27);
            txtBuscar.TabIndex = 3;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnToggleActivo
            // 
            btnToggleActivo.Anchor = AnchorStyles.Right;
            btnToggleActivo.Location = new Point(366, 3);
            btnToggleActivo.Name = "btnToggleActivo";
            btnToggleActivo.Size = new Size(161, 60);
            btnToggleActivo.TabIndex = 4;
            btnToggleActivo.Text = "Habilitar/Deshabilitar";
            btnToggleActivo.UseVisualStyleBackColor = true;
            btnToggleActivo.Click += btnToggleEstado_Click;
            // 
            // btnVerCompras
            // 
            btnVerCompras.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVerCompras.Location = new Point(199, 3);
            btnVerCompras.Name = "btnVerCompras";
            btnVerCompras.Size = new Size(161, 60);
            btnVerCompras.TabIndex = 5;
            btnVerCompras.Text = "Ver Compras";
            btnVerCompras.UseVisualStyleBackColor = true;
            btnVerCompras.Click += btnVerCompras_Click;
            // 
            // panelBtn
            // 
            panelBtn.BackColor = SystemColors.ActiveCaption;
            panelBtn.Controls.Add(chkInactivos);
            panelBtn.Controls.Add(btnVerCompras);
            panelBtn.Controls.Add(btnToggleActivo);
            panelBtn.Controls.Add(btnEditar);
            panelBtn.Controls.Add(btnAgregar);
            panelBtn.Controls.Add(txtBuscar);
            panelBtn.Dock = DockStyle.Bottom;
            panelBtn.Location = new Point(0, 381);
            panelBtn.Name = "panelBtn";
            panelBtn.Size = new Size(800, 69);
            panelBtn.TabIndex = 5;
            // 
            // dgvListar
            // 
            dgvListar.AllowUserToAddRows = false;
            dgvListar.AllowUserToDeleteRows = false;
            dgvListar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListar.Dock = DockStyle.Fill;
            dgvListar.Location = new Point(9, 3);
            dgvListar.Name = "dgvListar";
            dgvListar.ReadOnly = true;
            dgvListar.RowHeadersWidth = 51;
            dgvListar.Size = new Size(782, 345);
            dgvListar.TabIndex = 2;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(2, 2, 2, 2);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panelHeader);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvListar);
            splitContainer1.Panel2.Padding = new Padding(9, 3, 9, 3);
            splitContainer1.Size = new Size(800, 381);
            splitContainer1.SplitterDistance = 27;
            splitContainer1.SplitterWidth = 3;
            splitContainer1.TabIndex = 6;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(lblTituloForm);
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(2, 2, 2, 2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 27);
            panelHeader.TabIndex = 1;
            // 
            // lblTituloForm
            // 
            lblTituloForm.Dock = DockStyle.Fill;
            lblTituloForm.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloForm.Location = new Point(0, 0);
            lblTituloForm.Margin = new Padding(2, 0, 2, 0);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Padding = new Padding(6, 0, 6, 0);
            lblTituloForm.Size = new Size(800, 27);
            lblTituloForm.TabIndex = 0;
            lblTituloForm.Text = "Proveedores";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ProveedorMainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(panelBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProveedorMainMenuForm";
            Text = "Gestión de Proveedores";
            Load += ProveedorMainMenuForm_Load;
            panelBtn.ResumeLayout(false);
            panelBtn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListar).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            ResumeLayout(false);
        }



        private Button btnAgregar;
        private Button btnEditar;
        private CheckBox chkInactivos;
        private TextBox txtBuscar;
        private Button btnToggleActivo;
        private Button btnVerCompras;
        private Panel panelBtn;
        private DataGridView dgvListar;
        private SplitContainer splitContainer1;
        private Panel panelHeader;
        private Label lblTituloForm;
    }
}
