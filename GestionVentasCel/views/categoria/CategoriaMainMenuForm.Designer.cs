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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAgregar = new Button();
            btnUpdate = new Button();
            chkMostrarInactivos = new CheckBox();
            txtBuscar = new TextBox();
            btnAdd = new Button();
            btnActualizar = new Button();
            btnToggleEstado = new Button();
            chkInactivos = new CheckBox();
            panelBtn = new Panel();
            dgvListarCategorias = new DataGridView();
            panelBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarCategorias).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Right;
            btnAgregar.Location = new Point(1260, -10);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(128, 60);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Right;
            btnUpdate.Location = new Point(1126, -10);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(128, 60);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Actualizar";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // chkMostrarInactivos
            // 
            chkMostrarInactivos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkMostrarInactivos.AutoSize = true;
            chkMostrarInactivos.Location = new Point(12, 11);
            chkMostrarInactivos.Name = "chkMostrarInactivos";
            chkMostrarInactivos.Size = new Size(193, 24);
            chkMostrarInactivos.TabIndex = 3;
            chkMostrarInactivos.Text = "Incluir Usuarios Inactivos";
            chkMostrarInactivos.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(12, 9);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Categoria...";
            txtBuscar.Size = new Size(266, 27);
            txtBuscar.TabIndex = 4;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Right;
            btnAdd.Location = new Point(667, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(128, 60);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Agregar";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Right;
            btnActualizar.Location = new Point(533, 3);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(128, 60);
            btnActualizar.TabIndex = 6;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnToggleEstado
            // 
            btnToggleEstado.Anchor = AnchorStyles.Right;
            btnToggleEstado.Location = new Point(366, 3);
            btnToggleEstado.Name = "btnToggleEstado";
            btnToggleEstado.Size = new Size(161, 60);
            btnToggleEstado.TabIndex = 7;
            btnToggleEstado.Text = "Habilitar/Deshabilitar";
            btnToggleEstado.UseVisualStyleBackColor = true;
            btnToggleEstado.Click += btnToggleEstado_Click;
            // 
            // chkInactivos
            // 
            chkInactivos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkInactivos.AutoSize = true;
            chkInactivos.Location = new Point(12, 39);
            chkInactivos.Name = "chkInactivos";
            chkInactivos.Size = new Size(207, 24);
            chkInactivos.TabIndex = 8;
            chkInactivos.Text = "Incluir Categorias Inactivas";
            chkInactivos.UseVisualStyleBackColor = true;
            chkInactivos.CheckedChanged += chkInactivos_CheckedChanged;
            // 
            // panelBtn
            // 
            panelBtn.BackColor = SystemColors.ActiveCaption;
            panelBtn.Controls.Add(chkInactivos);
            panelBtn.Controls.Add(btnToggleEstado);
            panelBtn.Controls.Add(btnActualizar);
            panelBtn.Controls.Add(btnAdd);
            panelBtn.Controls.Add(txtBuscar);
            panelBtn.Controls.Add(chkMostrarInactivos);
            panelBtn.Controls.Add(btnUpdate);
            panelBtn.Controls.Add(btnAgregar);
            panelBtn.Dock = DockStyle.Bottom;
            panelBtn.Location = new Point(0, 381);
            panelBtn.Name = "panelBtn";
            panelBtn.Size = new Size(800, 69);
            panelBtn.TabIndex = 1;
            // 
            // dgvListarCategorias
            // 
            dgvListarCategorias.AllowUserToAddRows = false;
            dgvListarCategorias.AllowUserToDeleteRows = false;
            dgvListarCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListarCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListarCategorias.Dock = DockStyle.Fill;
            dgvListarCategorias.Location = new Point(0, 0);
            dgvListarCategorias.Name = "dgvListarCategorias";
            dgvListarCategorias.ReadOnly = true;
            dgvListarCategorias.RowHeadersWidth = 51;
            dgvListarCategorias.Size = new Size(800, 381);
            dgvListarCategorias.TabIndex = 2;
            // 
            // CategoriaMainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvListarCategorias);
            Controls.Add(panelBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CategoriaMainMenuForm";
            Text = "CategoriaMainMenuForm";
            panelBtn.ResumeLayout(false);
            panelBtn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarCategorias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAgregar;
        private Button btnUpdate;
        private CheckBox chkMostrarInactivos;
        private TextBox txtBuscar;
        private Button btnAdd;
        private Button btnActualizar;
        private Button btnToggleEstado;
        private CheckBox chkInactivos;
        private Panel panelBtn;
        private DataGridView dgvListarCategorias;
    }
}