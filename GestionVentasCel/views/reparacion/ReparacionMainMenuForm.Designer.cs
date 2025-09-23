namespace GestionVentasCel.views.servicio
{
    partial class ReparacionMainMenuForm
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
            dgvListar = new DataGridView();
            btnEstadoReparacion = new Button();
            txtBuscar = new TextBox();
            btnCambiarEstado = new Button();
            btnEditar = new Button();
            chkInactivos = new CheckBox();
            btnAdd = new Button();
            panelBtn = new Panel();
            splitContainer1 = new SplitContainer();
            panelHeader = new Panel();
            lblTituloForm = new Label();
            btnDetalle = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvListar).BeginInit();
            panelBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
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
            dgvListar.Size = new Size(782, 333);
            dgvListar.TabIndex = 4;
            // 
            // btnEstadoReparacion
            // 
            btnEstadoReparacion.Anchor = AnchorStyles.Right;
            btnEstadoReparacion.Location = new Point(267, 4);
            btnEstadoReparacion.Name = "btnEstadoReparacion";
            btnEstadoReparacion.Size = new Size(128, 60);
            btnEstadoReparacion.TabIndex = 7;
            btnEstadoReparacion.Text = "Cambiar Estado";
            btnEstadoReparacion.UseVisualStyleBackColor = true;
            btnEstadoReparacion.Click += btnEstadoReparacion_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(12, 6);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "(Ctrl  + F) Buscar reparaciones";
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
            chkInactivos.Size = new Size(225, 24);
            chkInactivos.TabIndex = 10;
            chkInactivos.Text = "Incluir Reparaciones inactivas";
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
            panelBtn.Controls.Add(btnEstadoReparacion);
            panelBtn.Controls.Add(btnDetalle);
            panelBtn.Dock = DockStyle.Bottom;
            panelBtn.Location = new Point(0, 381);
            panelBtn.Name = "panelBtn";
            panelBtn.Size = new Size(800, 69);
            panelBtn.TabIndex = 2;
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
            splitContainer1.SplitterDistance = 39;
            splitContainer1.SplitterWidth = 3;
            splitContainer1.TabIndex = 9;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(lblTituloForm);
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 39);
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
            lblTituloForm.Size = new Size(800, 39);
            lblTituloForm.TabIndex = 0;
            lblTituloForm.Text = "Reparaciones";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnDetalle
            // 
            btnDetalle.Anchor = AnchorStyles.Right;
            btnDetalle.Location = new Point(133, 3);
            btnDetalle.Name = "btnDetalle";
            btnDetalle.Size = new Size(128, 60);
            btnDetalle.TabIndex = 12;
            btnDetalle.Text = "Ver Detalle";
            btnDetalle.UseVisualStyleBackColor = true;
            btnDetalle.Click += btnDetalle_Click;
            // 
            // ReparacionMainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(panelBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReparacionMainMenuForm";
            Text = "ServicioMainMenuForm";
            Load += ServicioMainMenuForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListar).EndInit();
            panelBtn.ResumeLayout(false);
            panelBtn.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnVerDetalle;
        private Button button2;
        private Button button3;
        private DataGridView dgvListar;
        private Button btnEstadoReparacion;
        private TextBox txtBuscar;
        private Button btnCambiarEstado;
        private Button btnEditar;
        private CheckBox chkInactivos;
        private Button btnAdd;
        private Panel panelBtn;
        private SplitContainer splitContainer1;
        private Panel panelHeader;
        private Label lblTituloForm;
        private Button btnDetalle;
    }
}