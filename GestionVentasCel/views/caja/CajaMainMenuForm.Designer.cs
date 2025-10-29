namespace GestionVentasCel.views.usuario_empleado
{
    partial class CajaMainMenuForm
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
            label1 = new Label();
            dtpFecha = new DateTimePicker();
            btnCerrarCaja = new Button();
            btnVerMovimientos = new Button();
            txtBuscar = new TextBox();
            chkMostrarInactivos = new CheckBox();
            btnRetirarDinero = new Button();
            btnAbrirCaja = new Button();
            panelContenedor = new Panel();
            splitContainer1 = new SplitContainer();
            panelHeader = new Panel();
            lblTituloForm = new Label();
            dgvListar = new DataGridView();
            panelBtn.SuspendLayout();
            panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListar).BeginInit();
            SuspendLayout();
            // 
            // panelBtn
            // 
            panelBtn.BackColor = SystemColors.ActiveCaption;
            panelBtn.Controls.Add(label1);
            panelBtn.Controls.Add(dtpFecha);
            panelBtn.Controls.Add(btnCerrarCaja);
            panelBtn.Controls.Add(btnVerMovimientos);
            panelBtn.Controls.Add(txtBuscar);
            panelBtn.Controls.Add(chkMostrarInactivos);
            panelBtn.Controls.Add(btnRetirarDinero);
            panelBtn.Controls.Add(btnAbrirCaja);
            panelBtn.Dock = DockStyle.Bottom;
            panelBtn.Location = new Point(0, 381);
            panelBtn.Name = "panelBtn";
            panelBtn.Size = new Size(800, 69);
            panelBtn.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(302, 9);
            label1.Name = "label1";
            label1.Size = new Size(163, 20);
            label1.TabIndex = 8;
            label1.Text = "Buscar Cajas por Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(302, 30);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(250, 27);
            dtpFecha.TabIndex = 7;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            // 
            // btnCerrarCaja
            // 
            btnCerrarCaja.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrarCaja.Location = new Point(239, 5);
            btnCerrarCaja.Margin = new Padding(2);
            btnCerrarCaja.Name = "btnCerrarCaja";
            btnCerrarCaja.Size = new Size(139, 60);
            btnCerrarCaja.TabIndex = 6;
            btnCerrarCaja.Text = "Cerrar Caja";
            btnCerrarCaja.UseVisualStyleBackColor = true;
            btnCerrarCaja.Click += btnCerrarCaja_Click;
            // 
            // btnVerMovimientos
            // 
            btnVerMovimientos.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVerMovimientos.Location = new Point(383, 5);
            btnVerMovimientos.Margin = new Padding(2);
            btnVerMovimientos.Name = "btnVerMovimientos";
            btnVerMovimientos.Size = new Size(139, 60);
            btnVerMovimientos.TabIndex = 5;
            btnVerMovimientos.Text = "Ver Movimientos";
            btnVerMovimientos.UseVisualStyleBackColor = true;
            btnVerMovimientos.Click += btnVerMovimientos_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(12, 9);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "(Ctrl + F) Buscar Caja";
            txtBuscar.Size = new Size(266, 27);
            txtBuscar.TabIndex = 4;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // chkMostrarInactivos
            // 
            chkMostrarInactivos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkMostrarInactivos.AutoSize = true;
            chkMostrarInactivos.Location = new Point(12, 41);
            chkMostrarInactivos.Name = "chkMostrarInactivos";
            chkMostrarInactivos.Size = new Size(160, 24);
            chkMostrarInactivos.TabIndex = 3;
            chkMostrarInactivos.Text = "Incluir Caja Cerrada";
            chkMostrarInactivos.UseVisualStyleBackColor = true;
            chkMostrarInactivos.CheckedChanged += chkMostrarInactivos_CheckedChanged;
            // 
            // btnRetirarDinero
            // 
            btnRetirarDinero.Anchor = AnchorStyles.Right;
            btnRetirarDinero.Location = new Point(527, 5);
            btnRetirarDinero.Name = "btnRetirarDinero";
            btnRetirarDinero.Size = new Size(128, 60);
            btnRetirarDinero.TabIndex = 1;
            btnRetirarDinero.Text = "Retirar Dinero";
            btnRetirarDinero.UseVisualStyleBackColor = true;
            btnRetirarDinero.Click += btnRetirarDinero_Click;
            // 
            // btnAbrirCaja
            // 
            btnAbrirCaja.Anchor = AnchorStyles.Right;
            btnAbrirCaja.Location = new Point(660, 5);
            btnAbrirCaja.Name = "btnAbrirCaja";
            btnAbrirCaja.Size = new Size(128, 60);
            btnAbrirCaja.TabIndex = 0;
            btnAbrirCaja.Text = "Abrir Caja";
            btnAbrirCaja.UseVisualStyleBackColor = true;
            btnAbrirCaja.Click += btnAbrirCaja_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.Controls.Add(splitContainer1);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 0);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(800, 381);
            panelContenedor.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(2);
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
            splitContainer1.SplitterDistance = 26;
            splitContainer1.SplitterWidth = 3;
            splitContainer1.TabIndex = 4;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(lblTituloForm);
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 26);
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
            lblTituloForm.Size = new Size(800, 26);
            lblTituloForm.TabIndex = 0;
            lblTituloForm.Text = "Gestión de Caja";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
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
            dgvListar.Size = new Size(782, 346);
            dgvListar.TabIndex = 0;
            dgvListar.SelectionChanged += dgvListar_SelectionChanged;
            // 
            // CajaMainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContenedor);
            Controls.Add(panelBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CajaMainMenuForm";
            Text = "UsuarioMainMenu";
            Load += VentaMianMenu_Load;
            panelBtn.ResumeLayout(false);
            panelBtn.PerformLayout();
            panelContenedor.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvListar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBtn;
        private Panel panelContenedor;
        private DataGridView dgvListar;
        private Button btnRetirarDinero;
        private Button btnAbrirCaja;
        private TextBox txtBuscar;
        private CheckBox chkMostrarInactivos;
        private SplitContainer splitContainer1;
        private Panel panelHeader;
        private Label lblTituloForm;
        private Button btnVerMovimientos;
        private Button btnCerrarCaja;
        private Label label1;
        private DateTimePicker dtpFecha;
    }
}