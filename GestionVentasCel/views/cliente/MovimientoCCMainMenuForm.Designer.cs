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
            txtBuscar = new TextBox();
            btnToggleActivo = new Button();
            btnVerMovimientos = new Button();
            btnAgregar = new Button();
            panelContenedor = new Panel();
            dgvListarCuentas = new DataGridView();
            lblSaldoActual = new Label();
            panelBtn.SuspendLayout();
            panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarCuentas).BeginInit();
            SuspendLayout();
            // 
            // panelBtn
            // 
            panelBtn.BackColor = SystemColors.ActiveCaption;
            panelBtn.Controls.Add(lblSaldoActual);
            panelBtn.Controls.Add(txtBuscar);
            panelBtn.Controls.Add(btnToggleActivo);
            panelBtn.Controls.Add(btnVerMovimientos);
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
            txtBuscar.PlaceholderText = "Buscar por fecha";
            txtBuscar.Size = new Size(332, 31);
            txtBuscar.TabIndex = 4;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnToggleActivo
            // 
            btnToggleActivo.Anchor = AnchorStyles.Right;
            btnToggleActivo.Location = new Point(449, 8);
            btnToggleActivo.Margin = new Padding(4);
            btnToggleActivo.Name = "btnToggleActivo";
            btnToggleActivo.Size = new Size(201, 75);
            btnToggleActivo.TabIndex = 2;
            btnToggleActivo.Text = "Eliminar";
            btnToggleActivo.UseVisualStyleBackColor = true;
            // 
            // btnVerMovimientos
            // 
            btnVerMovimientos.Anchor = AnchorStyles.Right;
            btnVerMovimientos.Location = new Point(658, 8);
            btnVerMovimientos.Margin = new Padding(4);
            btnVerMovimientos.Name = "btnVerMovimientos";
            btnVerMovimientos.Size = new Size(160, 75);
            btnVerMovimientos.TabIndex = 1;
            btnVerMovimientos.Text = "Editar";
            btnVerMovimientos.UseVisualStyleBackColor = true;
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
            // lblSaldoActual
            // 
            lblSaldoActual.AutoSize = true;
            lblSaldoActual.Location = new Point(13, 51);
            lblSaldoActual.Name = "lblSaldoActual";
            lblSaldoActual.Size = new Size(117, 25);
            lblSaldoActual.TabIndex = 5;
            lblSaldoActual.Text = "Saldo actual: ";
            // 
            // MovimientosCCMainMenuForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(panelContenedor);
            Controls.Add(panelBtn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MinimizeBox = false;
            Name = "MovimientosCCMainMenuForm";
            Text = "Movimientos de la cuenta corriente";
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
        private Button btnVerMovimientos;
        private Button btnAgregar;
        private TextBox txtBuscar;
        private Label lblSaldoActual;
    }
}