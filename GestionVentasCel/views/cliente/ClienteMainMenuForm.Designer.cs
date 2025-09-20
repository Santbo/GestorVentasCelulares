namespace GestionVentasCel.views.usuario_empleado
{
    partial class ClienteMainMenuForm
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
            txtBuscar = new TextBox();
            chkMostrarInactivos = new CheckBox();
            btnToggleActivo = new Button();
            btnActualizar = new Button();
            btnAgregar = new Button();
            panelContenedor = new Panel();
            splitContainer1 = new SplitContainer();
            panelHeader = new Panel();
            lblTituloForm = new Label();
            dgvListarClientes = new DataGridView();
            panelBtn.SuspendLayout();
            panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarClientes).BeginInit();
            SuspendLayout();
            // 
            // panelBtn
            // 
            panelBtn.BackColor = SystemColors.ActiveCaption;
            panelBtn.Controls.Add(txtBuscar);
            panelBtn.Controls.Add(chkMostrarInactivos);
            panelBtn.Controls.Add(btnToggleActivo);
            panelBtn.Controls.Add(btnActualizar);
            panelBtn.Controls.Add(btnAgregar);
            panelBtn.Dock = DockStyle.Bottom;
            panelBtn.Location = new Point(0, 476);
            panelBtn.Margin = new Padding(4);
            panelBtn.Name = "panelBtn";
            panelBtn.Size = new Size(1000, 86);
            panelBtn.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(15, 11);
            txtBuscar.Margin = new Padding(4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "(Ctrl + F) Buscar cliente";
            txtBuscar.Size = new Size(332, 31);
            txtBuscar.TabIndex = 4;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // chkMostrarInactivos
            // 
            chkMostrarInactivos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkMostrarInactivos.AutoSize = true;
            chkMostrarInactivos.Location = new Point(15, 53);
            chkMostrarInactivos.Margin = new Padding(4);
            chkMostrarInactivos.Name = "chkMostrarInactivos";
            chkMostrarInactivos.Size = new Size(222, 29);
            chkMostrarInactivos.TabIndex = 3;
            chkMostrarInactivos.Text = "Incluir clientes inactivos";
            chkMostrarInactivos.UseVisualStyleBackColor = true;
            chkMostrarInactivos.CheckedChanged += chkMostrarInactivos_CheckedChanged;
            // 
            // btnToggleActivo
            // 
            btnToggleActivo.Anchor = AnchorStyles.Right;
            btnToggleActivo.Location = new Point(451, 6);
            btnToggleActivo.Margin = new Padding(4);
            btnToggleActivo.Name = "btnToggleActivo";
            btnToggleActivo.Size = new Size(201, 75);
            btnToggleActivo.TabIndex = 2;
            btnToggleActivo.Text = "Habilitar/Deshabilitar";
            btnToggleActivo.UseVisualStyleBackColor = true;
            btnToggleActivo.Click += btnToggleActivo_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Right;
            btnActualizar.Location = new Point(660, 6);
            btnActualizar.Margin = new Padding(4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(160, 75);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnUpdate_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Right;
            btnAgregar.Location = new Point(827, 6);
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
            panelContenedor.Size = new Size(1000, 476);
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
            splitContainer1.Panel2.Controls.Add(dgvListarClientes);
            splitContainer1.Panel2.Padding = new Padding(11, 4, 11, 4);
            splitContainer1.Size = new Size(1000, 476);
            splitContainer1.SplitterDistance = 34;
            splitContainer1.TabIndex = 4;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(lblTituloForm);
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1000, 34);
            panelHeader.TabIndex = 1;
            // 
            // lblTituloForm
            // 
            lblTituloForm.Dock = DockStyle.Fill;
            lblTituloForm.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloForm.Location = new Point(0, 0);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Padding = new Padding(8, 0, 8, 0);
            lblTituloForm.Size = new Size(1000, 34);
            lblTituloForm.TabIndex = 0;
            lblTituloForm.Text = "Gestión de clientes";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvListarClientes
            // 
            dgvListarClientes.AllowUserToAddRows = false;
            dgvListarClientes.AllowUserToDeleteRows = false;
            dgvListarClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListarClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListarClientes.Dock = DockStyle.Fill;
            dgvListarClientes.Location = new Point(11, 4);
            dgvListarClientes.Margin = new Padding(4);
            dgvListarClientes.Name = "dgvListarClientes";
            dgvListarClientes.ReadOnly = true;
            dgvListarClientes.RowHeadersWidth = 51;
            dgvListarClientes.Size = new Size(978, 430);
            dgvListarClientes.TabIndex = 0;
            // 
            // ClienteMainMenuForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(panelContenedor);
            Controls.Add(panelBtn);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "ClienteMainMenuForm";
            Text = "UsuarioMainMenu";
            Load += ClienteMainMenuForm_Load;
            panelBtn.ResumeLayout(false);
            panelBtn.PerformLayout();
            panelContenedor.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvListarClientes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBtn;
        private Panel panelContenedor;
        private DataGridView dgvListarClientes;
        private Button btnToggleActivo;
        private Button btnActualizar;
        private Button btnAgregar;
        private TextBox txtBuscar;
        private CheckBox chkMostrarInactivos;
        private SplitContainer splitContainer1;
        private Panel panelHeader;
        private Label lblTituloForm;
    }
}