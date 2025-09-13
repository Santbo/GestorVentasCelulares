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
            btnToggleEstado = new Button();
            btnVerCompras = new Button();
            panelBtn = new Panel();
            dgvListarProveedores = new DataGridView();
            panelBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarProveedores).BeginInit();
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
            chkInactivos.Location = new Point(12, 39);
            chkInactivos.Name = "chkInactivos";
            chkInactivos.Size = new Size(207, 24);
            chkInactivos.TabIndex = 2;
            chkInactivos.Text = "Incluir Proveedores Inactivos";
            chkInactivos.UseVisualStyleBackColor = true;
            chkInactivos.CheckedChanged += chkInactivos_CheckedChanged;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(12, 9);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Proveedor...";
            txtBuscar.Size = new Size(266, 27);
            txtBuscar.TabIndex = 3;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnToggleEstado
            // 
            btnToggleEstado.Anchor = AnchorStyles.Right;
            btnToggleEstado.Location = new Point(366, 3);
            btnToggleEstado.Name = "btnToggleEstado";
            btnToggleEstado.Size = new Size(161, 60);
            btnToggleEstado.TabIndex = 4;
            btnToggleEstado.Text = "Habilitar/Deshabilitar";
            btnToggleEstado.UseVisualStyleBackColor = true;
            btnToggleEstado.Click += btnToggleEstado_Click;
            // 
            // btnVerCompras
            // 
            btnVerCompras.Anchor = AnchorStyles.Right;
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
            panelBtn.Controls.Add(btnToggleEstado);
            panelBtn.Controls.Add(btnEditar);
            panelBtn.Controls.Add(btnAgregar);
            panelBtn.Controls.Add(txtBuscar);
            panelBtn.Dock = DockStyle.Bottom;
            panelBtn.Location = new Point(0, 381);
            panelBtn.Name = "panelBtn";
            panelBtn.Size = new Size(800, 69);
            panelBtn.TabIndex = 5;
            // 
            // dgvListarProveedores
            // 
            dgvListarProveedores.AllowUserToAddRows = false;
            dgvListarProveedores.AllowUserToDeleteRows = false;
            dgvListarProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListarProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListarProveedores.Dock = DockStyle.Fill;
            dgvListarProveedores.Location = new Point(0, 0);
            dgvListarProveedores.Name = "dgvListarProveedores";
            dgvListarProveedores.ReadOnly = true;
            dgvListarProveedores.RowHeadersWidth = 51;
            dgvListarProveedores.Size = new Size(800, 381);
            dgvListarProveedores.TabIndex = 2;
            // 
            // ProveedorMainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvListarProveedores);
            Controls.Add(panelBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProveedorMainMenuForm";
            Text = "Gestión de Proveedores";
            panelBtn.ResumeLayout(false);
            panelBtn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarProveedores).EndInit();
            ResumeLayout(false);
        }

          

        private Button btnAgregar;
        private Button btnEditar;
        private CheckBox chkInactivos;
        private TextBox txtBuscar;
        private Button btnToggleEstado;
        private Button btnVerCompras;
        private Panel panelBtn;
        private DataGridView dgvListarProveedores;
    }
}
