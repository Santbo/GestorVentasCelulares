namespace GestionVentasCel.views.usuario_empleado
{
    partial class CuentaCorrienteMainMenuForm
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
            dgvListarCuentas = new DataGridView();
            panelBtn.SuspendLayout();
            panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarCuentas).BeginInit();
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
            txtBuscar.PlaceholderText = "Buscar Cliente";
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
            chkMostrarInactivos.Size = new Size(226, 29);
            chkMostrarInactivos.TabIndex = 3;
            chkMostrarInactivos.Text = "Incluir Clientes Inactivos";
            chkMostrarInactivos.UseVisualStyleBackColor = true;
            chkMostrarInactivos.CheckedChanged += chkMostrarInactivos_CheckedChanged;
            // 
            // btnToggleActivo
            // 
            btnToggleActivo.Anchor = AnchorStyles.Right;
            btnToggleActivo.Location = new Point(449, 8);
            btnToggleActivo.Margin = new Padding(4);
            btnToggleActivo.Name = "btnToggleActivo";
            btnToggleActivo.Size = new Size(201, 75);
            btnToggleActivo.TabIndex = 2;
            btnToggleActivo.Text = "Habilitar/Deshabilitar";
            btnToggleActivo.UseVisualStyleBackColor = true;
            btnToggleActivo.Click += btnToggleActivo_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Right;
            btnUpdate.Location = new Point(658, 8);
            btnUpdate.Margin = new Padding(4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(160, 75);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Actualizar";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Right;
            btnAgregar.Location = new Point(825, 8);
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
            panelContenedor.Controls.Add(dgvListarCuentas);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 0);
            panelContenedor.Margin = new Padding(4);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1000, 476);
            panelContenedor.TabIndex = 1;
            // 
            // dgvListarCuentas
            // 
            dgvListarCuentas.AllowUserToAddRows = false;
            dgvListarCuentas.AllowUserToDeleteRows = false;
            dgvListarCuentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListarCuentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListarCuentas.Dock = DockStyle.Fill;
            dgvListarCuentas.Location = new Point(0, 0);
            dgvListarCuentas.Margin = new Padding(4);
            dgvListarCuentas.Name = "dgvListarCuentas";
            dgvListarCuentas.ReadOnly = true;
            dgvListarCuentas.RowHeadersWidth = 51;
            dgvListarCuentas.Size = new Size(1000, 476);
            dgvListarCuentas.TabIndex = 0;
            // 
            // CuentaCorrienteMainMenuForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(panelContenedor);
            Controls.Add(panelBtn);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "CuentaCorrienteMainMenuForm";
            Text = "UsuarioMainMenu";
            panelBtn.ResumeLayout(false);
            panelBtn.PerformLayout();
            panelContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvListarCuentas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBtn;
        private Panel panelContenedor;
        private DataGridView dgvListarCuentas;
        private Button btnToggleActivo;
        private Button btnUpdate;
        private Button btnAgregar;
        private TextBox txtBuscar;
        private CheckBox chkMostrarInactivos;
    }
}