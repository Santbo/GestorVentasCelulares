namespace GestionVentasCel.views.servicio
{
    partial class ServicioMainMenuForm
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
            dgvListar = new DataGridView();
            btnArticulosAsociados = new Button();
            txtBuscar = new TextBox();
            btnCambiarEstado = new Button();
            btnEditar = new Button();
            chkInactivos = new CheckBox();
            btnAdd = new Button();
            panelBtn = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvListar).BeginInit();
            panelBtn.SuspendLayout();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Right;
            btnAgregar.Location = new Point(669, 3);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(128, 60);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // dgvListar
            // 
            dgvListar.AllowUserToAddRows = false;
            dgvListar.AllowUserToDeleteRows = false;
            dgvListar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListar.Dock = DockStyle.Fill;
            dgvListar.Location = new Point(0, 0);
            dgvListar.Name = "dgvListar";
            dgvListar.ReadOnly = true;
            dgvListar.RowHeadersWidth = 51;
            dgvListar.Size = new Size(800, 381);
            dgvListar.TabIndex = 4;
            // 
            // btnArticulosAsociados
            // 
            btnArticulosAsociados.Anchor = AnchorStyles.Right;
            btnArticulosAsociados.Location = new Point(267, 4);
            btnArticulosAsociados.Name = "btnArticulosAsociados";
            btnArticulosAsociados.Size = new Size(128, 60);
            btnArticulosAsociados.TabIndex = 7;
            btnArticulosAsociados.Text = "Ver Articulos Asociados";
            btnArticulosAsociados.UseVisualStyleBackColor = true;
            btnArticulosAsociados.Click += btnArticulosAsociados_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(12, 6);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "(Ctrl  + F) Buscar compras";
            txtBuscar.Size = new Size(266, 27);
            txtBuscar.TabIndex = 6;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnCambiarEstado
            // 
            btnCambiarEstado.Anchor = AnchorStyles.Right;
            btnCambiarEstado.Location = new Point(401, 4);
            btnCambiarEstado.Name = "btnCambiarEstado";
            btnCambiarEstado.Size = new Size(128, 60);
            btnCambiarEstado.TabIndex = 8;
            btnCambiarEstado.Text = "Habilitar/Deshabilitar";
            btnCambiarEstado.UseVisualStyleBackColor = true;
            btnCambiarEstado.Click += btnCambiarEstado_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Right;
            btnEditar.Location = new Point(535, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(128, 60);
            btnEditar.TabIndex = 9;
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
            chkInactivos.Size = new Size(195, 24);
            chkInactivos.TabIndex = 10;
            chkInactivos.Text = "Incluir Servicios inactivos";
            chkInactivos.UseVisualStyleBackColor = true;
            chkInactivos.CheckedChanged += chkInactivos_CheckedChanged;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Right;
            btnAdd.Location = new Point(669, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(128, 60);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Agregar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // panelBtn
            // 
            panelBtn.BackColor = SystemColors.ActiveCaption;
            panelBtn.Controls.Add(btnAdd);
            panelBtn.Controls.Add(chkInactivos);
            panelBtn.Controls.Add(btnEditar);
            panelBtn.Controls.Add(btnCambiarEstado);
            panelBtn.Controls.Add(txtBuscar);
            panelBtn.Controls.Add(btnArticulosAsociados);
            panelBtn.Dock = DockStyle.Bottom;
            panelBtn.Location = new Point(0, 381);
            panelBtn.Name = "panelBtn";
            panelBtn.Size = new Size(800, 69);
            panelBtn.TabIndex = 2;
            // 
            // ServicioMainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvListar);
            Controls.Add(panelBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ServicioMainMenuForm";
            Text = "ServicioMainMenuForm";
            ((System.ComponentModel.ISupportInitialize)dgvListar).EndInit();
            panelBtn.ResumeLayout(false);
            panelBtn.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnVerDetalle;
        private Button btnAgregar;
        private Button button2;
        private Button button3;
        private DataGridView dgvListar;
        private Button btnArticulosAsociados;
        private TextBox txtBuscar;
        private Button btnCambiarEstado;
        private Button btnEditar;
        private CheckBox chkInactivos;
        private Button btnAdd;
        private Panel panelBtn;
    }
}