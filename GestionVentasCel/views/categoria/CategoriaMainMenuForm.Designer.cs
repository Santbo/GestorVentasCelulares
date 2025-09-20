namespace GestionVentasCel.views.categoria
{
    partial class CategoriaMainMenuForm
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
            chkMostrarInactivos = new CheckBox();
            txtBuscar = new TextBox();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnToggleActivo = new Button();
            chkInactivos = new CheckBox();
            panelBtn = new Panel();
            dgvListarCategorias = new DataGridView();
            splitContainer1 = new SplitContainer();
            panelHeader = new Panel();
            lblTituloForm = new Label();
            panelBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarCategorias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // chkMostrarInactivos
            // 
            chkMostrarInactivos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkMostrarInactivos.AutoSize = true;
            chkMostrarInactivos.Location = new Point(15, 15);
            chkMostrarInactivos.Margin = new Padding(4);
            chkMostrarInactivos.Name = "chkMostrarInactivos";
            chkMostrarInactivos.Size = new Size(233, 29);
            chkMostrarInactivos.TabIndex = 3;
            chkMostrarInactivos.Text = "Incluir Usuarios Inactivos";
            chkMostrarInactivos.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(15, 11);
            txtBuscar.Margin = new Padding(4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "(Ctrl + F) Buscar categorías";
            txtBuscar.Size = new Size(332, 31);
            txtBuscar.TabIndex = 4;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Right;
            btnAgregar.Location = new Point(834, 4);
            btnAgregar.Margin = new Padding(4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(160, 75);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAdd_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Right;
            btnActualizar.Location = new Point(666, 4);
            btnActualizar.Margin = new Padding(4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(160, 75);
            btnActualizar.TabIndex = 6;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnToggleActivo
            // 
            btnToggleActivo.Anchor = AnchorStyles.Right;
            btnToggleActivo.Location = new Point(458, 4);
            btnToggleActivo.Margin = new Padding(4);
            btnToggleActivo.Name = "btnToggleActivo";
            btnToggleActivo.Size = new Size(201, 75);
            btnToggleActivo.TabIndex = 7;
            btnToggleActivo.Text = "Habilitar/Deshabilitar";
            btnToggleActivo.UseVisualStyleBackColor = true;
            btnToggleActivo.Click += btnToggleEstado_Click;
            // 
            // chkInactivos
            // 
            chkInactivos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkInactivos.AutoSize = true;
            chkInactivos.Location = new Point(15, 49);
            chkInactivos.Margin = new Padding(4);
            chkInactivos.Name = "chkInactivos";
            chkInactivos.Size = new Size(243, 29);
            chkInactivos.TabIndex = 8;
            chkInactivos.Text = "Incluir categorías inactivas";
            chkInactivos.UseVisualStyleBackColor = true;
            chkInactivos.CheckedChanged += chkInactivos_CheckedChanged;
            // 
            // panelBtn
            // 
            panelBtn.BackColor = SystemColors.ActiveCaption;
            panelBtn.Controls.Add(chkInactivos);
            panelBtn.Controls.Add(btnToggleActivo);
            panelBtn.Controls.Add(btnActualizar);
            panelBtn.Controls.Add(btnAgregar);
            panelBtn.Controls.Add(txtBuscar);
            panelBtn.Controls.Add(chkMostrarInactivos);
            panelBtn.Dock = DockStyle.Bottom;
            panelBtn.Location = new Point(0, 476);
            panelBtn.Margin = new Padding(4);
            panelBtn.Name = "panelBtn";
            panelBtn.Size = new Size(1000, 86);
            panelBtn.TabIndex = 1;
            // 
            // dgvListarCategorias
            // 
            dgvListarCategorias.AllowUserToAddRows = false;
            dgvListarCategorias.AllowUserToDeleteRows = false;
            dgvListarCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListarCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListarCategorias.Dock = DockStyle.Fill;
            dgvListarCategorias.Location = new Point(11, 4);
            dgvListarCategorias.Margin = new Padding(4);
            dgvListarCategorias.Name = "dgvListarCategorias";
            dgvListarCategorias.ReadOnly = true;
            dgvListarCategorias.RowHeadersWidth = 51;
            dgvListarCategorias.Size = new Size(978, 430);
            dgvListarCategorias.TabIndex = 2;
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
            splitContainer1.Panel2.Controls.Add(dgvListarCategorias);
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
            lblTituloForm.Text = "Gestión de categorías";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CategoriaMainMenuForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(splitContainer1);
            Controls.Add(panelBtn);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "CategoriaMainMenuForm";
            Text = "CategoriaMainMenuForm";
            Load += CategoriaMainMenuForm_Load;
            panelBtn.ResumeLayout(false);
            panelBtn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarCategorias).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            ResumeLayout(false);
        }
        private CheckBox chkMostrarInactivos;
        private TextBox txtBuscar;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnToggleActivo;
        private CheckBox chkInactivos;
        private Panel panelBtn;
        private DataGridView dgvListarCategorias;
        private SplitContainer splitContainer1;
        private Panel panelHeader;
        private Label lblTituloForm;
    }
}