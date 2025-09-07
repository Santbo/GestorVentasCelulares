namespace GestionVentasCel.views.usuario_empleado
{
    partial class UsuarioMainMenuForm
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
            btnUpdate = new Button();
            btnAgregar = new Button();
            panelContenedor = new Panel();
            dgvListarUsuarios = new DataGridView();
            panelBtn.SuspendLayout();
            panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarUsuarios).BeginInit();
            SuspendLayout();
            // 
            // panelBtn
            // 
            panelBtn.BackColor = SystemColors.ActiveCaption;
            panelBtn.Controls.Add(txtBuscar);
            panelBtn.Controls.Add(chkMostrarInactivos);
            panelBtn.Controls.Add(btnToggleActivo);
            panelBtn.Controls.Add(btnUpdate);
            panelBtn.Controls.Add(btnAgregar);
            panelBtn.Dock = DockStyle.Bottom;
            panelBtn.Location = new Point(0, 381);
            panelBtn.Name = "panelBtn";
            panelBtn.Size = new Size(800, 69);
            panelBtn.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(12, 9);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Empleado";
            txtBuscar.Size = new Size(266, 27);
            txtBuscar.TabIndex = 4;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // chkMostrarInactivos
            // 
            chkMostrarInactivos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkMostrarInactivos.AutoSize = true;
            chkMostrarInactivos.Location = new Point(12, 42);
            chkMostrarInactivos.Name = "chkMostrarInactivos";
            chkMostrarInactivos.Size = new Size(193, 24);
            chkMostrarInactivos.TabIndex = 3;
            chkMostrarInactivos.Text = "Incluir Usuarios Inactivos";
            chkMostrarInactivos.UseVisualStyleBackColor = true;
            chkMostrarInactivos.CheckedChanged += chkMostrarInactivos_CheckedChanged;
            // 
            // btnToggleActivo
            // 
            btnToggleActivo.Anchor = AnchorStyles.Right;
            btnToggleActivo.Location = new Point(359, 6);
            btnToggleActivo.Name = "btnToggleActivo";
            btnToggleActivo.Size = new Size(161, 60);
            btnToggleActivo.TabIndex = 2;
            btnToggleActivo.Text = "Habilitar/Deshabilitar";
            btnToggleActivo.UseVisualStyleBackColor = true;
            btnToggleActivo.Click += btnToggleActivo_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Right;
            btnUpdate.Location = new Point(526, 6);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(128, 60);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Actualizar";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Right;
            btnAgregar.Location = new Point(660, 6);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(128, 60);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.Controls.Add(dgvListarUsuarios);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 0);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(800, 381);
            panelContenedor.TabIndex = 1;
            // 
            // dgvListarUsuarios
            // 
            dgvListarUsuarios.AllowUserToAddRows = false;
            dgvListarUsuarios.AllowUserToDeleteRows = false;
            dgvListarUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListarUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListarUsuarios.Dock = DockStyle.Fill;
            dgvListarUsuarios.Location = new Point(0, 0);
            dgvListarUsuarios.Name = "dgvListarUsuarios";
            dgvListarUsuarios.ReadOnly = true;
            dgvListarUsuarios.RowHeadersWidth = 51;
            dgvListarUsuarios.Size = new Size(800, 381);
            dgvListarUsuarios.TabIndex = 0;
            // 
            // UsuarioMainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContenedor);
            Controls.Add(panelBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UsuarioMainMenuForm";
            Text = "UsuarioMainMenu";
            panelBtn.ResumeLayout(false);
            panelBtn.PerformLayout();
            panelContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvListarUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBtn;
        private Panel panelContenedor;
        private DataGridView dgvListarUsuarios;
        private Button btnToggleActivo;
        private Button btnUpdate;
        private Button btnAgregar;
        private TextBox txtBuscar;
        private CheckBox chkMostrarInactivos;
    }
}