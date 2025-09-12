namespace GestionVentasCel.views.articulo
{
    partial class ArticuloMainMenuForm
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
            btnUpdate = new Button();
            btnToggleActivo = new Button();
            txtBuscar = new TextBox();
            chkMostrarInactivos = new CheckBox();
            btnAdd = new Button();
            btnActualizar = new Button();
            bntToggleActivo = new Button();
            panelBtn = new Panel();
            dgvListarArticulos = new DataGridView();
            panelBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarArticulos).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Right;
            btnAgregar.Location = new Point(1260, -13);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(128, 60);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Right;
            btnUpdate.Location = new Point(1126, -13);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(128, 60);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Actualizar";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnToggleActivo
            // 
            btnToggleActivo.Anchor = AnchorStyles.Right;
            btnToggleActivo.Location = new Point(959, -13);
            btnToggleActivo.Name = "btnToggleActivo";
            btnToggleActivo.Size = new Size(161, 60);
            btnToggleActivo.TabIndex = 2;
            btnToggleActivo.Text = "Habilitar/Deshabilitar";
            btnToggleActivo.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(12, 9);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Articulo...";
            txtBuscar.Size = new Size(266, 27);
            txtBuscar.TabIndex = 4;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // chkMostrarInactivos
            // 
            chkMostrarInactivos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkMostrarInactivos.AutoSize = true;
            chkMostrarInactivos.Location = new Point(12, 36);
            chkMostrarInactivos.Name = "chkMostrarInactivos";
            chkMostrarInactivos.Size = new Size(195, 24);
            chkMostrarInactivos.TabIndex = 5;
            chkMostrarInactivos.Text = "Incluir Articulos Inactivos";
            chkMostrarInactivos.UseVisualStyleBackColor = true;
            chkMostrarInactivos.CheckedChanged += chckMostrarInactivos_CheckedChanged;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Right;
            btnAdd.Location = new Point(669, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(128, 60);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Agregar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Right;
            btnActualizar.Location = new Point(535, 3);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(128, 60);
            btnActualizar.TabIndex = 7;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // bntToggleActivo
            // 
            bntToggleActivo.Anchor = AnchorStyles.Right;
            bntToggleActivo.Location = new Point(368, 3);
            bntToggleActivo.Name = "bntToggleActivo";
            bntToggleActivo.Size = new Size(161, 60);
            bntToggleActivo.TabIndex = 8;
            bntToggleActivo.Text = "Habilitar/Deshabilitar";
            bntToggleActivo.UseVisualStyleBackColor = true;
            bntToggleActivo.Click += bntToggleActivo_Click;
            // 
            // panelBtn
            // 
            panelBtn.BackColor = SystemColors.ActiveCaption;
            panelBtn.Controls.Add(bntToggleActivo);
            panelBtn.Controls.Add(btnActualizar);
            panelBtn.Controls.Add(btnAdd);
            panelBtn.Controls.Add(chkMostrarInactivos);
            panelBtn.Controls.Add(txtBuscar);
            panelBtn.Controls.Add(btnToggleActivo);
            panelBtn.Controls.Add(btnUpdate);
            panelBtn.Controls.Add(btnAgregar);
            panelBtn.Dock = DockStyle.Bottom;
            panelBtn.Location = new Point(0, 387);
            panelBtn.Name = "panelBtn";
            panelBtn.Size = new Size(800, 63);
            panelBtn.TabIndex = 1;
            // 
            // dgvListarArticulos
            // 
            dgvListarArticulos.AllowUserToAddRows = false;
            dgvListarArticulos.AllowUserToDeleteRows = false;
            dgvListarArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListarArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListarArticulos.Dock = DockStyle.Fill;
            dgvListarArticulos.Location = new Point(0, 0);
            dgvListarArticulos.Name = "dgvListarArticulos";
            dgvListarArticulos.ReadOnly = true;
            dgvListarArticulos.RowHeadersWidth = 51;
            dgvListarArticulos.Size = new Size(800, 387);
            dgvListarArticulos.TabIndex = 2;
            // 
            // ArticuloMainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvListarArticulos);
            Controls.Add(panelBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ArticuloMainMenuForm";
            panelBtn.ResumeLayout(false);
            panelBtn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarArticulos).EndInit();
            ResumeLayout(false);
        }

          

        private Button btnAgregar;
        private Button btnUpdate;
        private Button btnToggleActivo;
        private TextBox txtBuscar;
        private CheckBox chkMostrarInactivos;
        private Button btnAdd;
        private Button btnActualizar;
        private Button bntToggleActivo;
        private Panel panelBtn;
        private DataGridView dgvListarArticulos;
    }
}