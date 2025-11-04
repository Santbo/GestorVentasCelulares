namespace GestionVentasCel.views.reparacion
{
    partial class AgregarEditarReparacionForm
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
            cmbCliente = new ComboBox();
            label1 = new Label();
            btnBuscar = new Button();
            dgvListarDispositivos = new DataGridView();
            label2 = new Label();
            txtFallasReportadas = new TextBox();
            label3 = new Label();
            txtDiagnostico = new TextBox();
            label4 = new Label();
            lblTotal = new Label();
            btnAgregar = new Button();
            btnGuardar = new Button();
            btnDescartar = new Button();
            lblTitulo = new Label();
            btnEditar = new Button();
            label7 = new Label();
            cmbServicio = new ComboBox();
            btnAplicar = new Button();
            dgvListarServicios = new DataGridView();
            btnAgregarServicio = new Button();
            btnEliminarServicio = new Button();
            panel1 = new Panel();
            dtpFechaVencimiento = new DateTimePicker();
            lblFechaVencimiento = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvListarDispositivos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvListarServicios).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(15, 116);
            cmbCliente.Margin = new Padding(4);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(258, 33);
            cmbCliente.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 88);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(248, 25);
            label1.TabIndex = 1;
            label1.Text = "Buscar Dispositivo por Cliente";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(292, 115);
            btnBuscar.Margin = new Padding(4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(118, 36);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvListarDispositivos
            // 
            dgvListarDispositivos.AllowUserToAddRows = false;
            dgvListarDispositivos.AllowUserToDeleteRows = false;
            dgvListarDispositivos.AllowUserToResizeColumns = false;
            dgvListarDispositivos.AllowUserToResizeRows = false;
            dgvListarDispositivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListarDispositivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListarDispositivos.Location = new Point(15, 191);
            dgvListarDispositivos.Margin = new Padding(4);
            dgvListarDispositivos.Name = "dgvListarDispositivos";
            dgvListarDispositivos.ReadOnly = true;
            dgvListarDispositivos.RowHeadersWidth = 51;
            dgvListarDispositivos.Size = new Size(395, 134);
            dgvListarDispositivos.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 162);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(180, 25);
            label2.TabIndex = 4;
            label2.Text = "Dispositivo Asociado";
            // 
            // txtFallasReportadas
            // 
            txtFallasReportadas.Location = new Point(468, 115);
            txtFallasReportadas.Margin = new Padding(4);
            txtFallasReportadas.Multiline = true;
            txtFallasReportadas.Name = "txtFallasReportadas";
            txtFallasReportadas.PlaceholderText = "(Opcional) Escribe las fallas reportadas por el cliente...";
            txtFallasReportadas.ScrollBars = ScrollBars.Vertical;
            txtFallasReportadas.Size = new Size(516, 144);
            txtFallasReportadas.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(468, 86);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(149, 25);
            label3.TabIndex = 6;
            label3.Text = "Fallas Reportadas";
            // 
            // txtDiagnostico
            // 
            txtDiagnostico.Location = new Point(468, 308);
            txtDiagnostico.Margin = new Padding(4);
            txtDiagnostico.Multiline = true;
            txtDiagnostico.Name = "txtDiagnostico";
            txtDiagnostico.PlaceholderText = "(Opcional) Escribe tu Diagnóstico...";
            txtDiagnostico.ScrollBars = ScrollBars.Vertical;
            txtDiagnostico.Size = new Size(516, 144);
            txtDiagnostico.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(468, 279);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(107, 25);
            label4.TabIndex = 8;
            label4.Text = "Diagnostico";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(468, 549);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(111, 45);
            lblTotal.TabIndex = 9;
            lblTotal.Text = "TOTAL";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(140, 332);
            btnAgregar.Margin = new Padding(4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(118, 36);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(845, 614);
            btnGuardar.Margin = new Padding(4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(139, 56);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnDescartar
            // 
            btnDescartar.Location = new Point(698, 614);
            btnDescartar.Margin = new Padding(4);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(139, 56);
            btnDescartar.TabIndex = 12;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(15, 11);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(305, 45);
            lblTitulo.TabIndex = 13;
            lblTitulo.Text = "Agregar Reparacion";
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(15, 332);
            btnEditar.Margin = new Padding(4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(118, 36);
            btnEditar.TabIndex = 14;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 378);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(73, 25);
            label7.TabIndex = 15;
            label7.Text = "Servicio";
            // 
            // cmbServicio
            // 
            cmbServicio.FormattingEnabled = true;
            cmbServicio.Location = new Point(15, 406);
            cmbServicio.Margin = new Padding(4);
            cmbServicio.Name = "cmbServicio";
            cmbServicio.Size = new Size(310, 33);
            cmbServicio.TabIndex = 16;
            // 
            // btnAplicar
            // 
            btnAplicar.Location = new Point(246, 634);
            btnAplicar.Margin = new Padding(4);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(164, 36);
            btnAplicar.TabIndex = 17;
            btnAplicar.Text = "Aplicar Cambios";
            btnAplicar.UseVisualStyleBackColor = true;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // dgvListarServicios
            // 
            dgvListarServicios.AllowUserToAddRows = false;
            dgvListarServicios.AllowUserToDeleteRows = false;
            dgvListarServicios.AllowUserToResizeColumns = false;
            dgvListarServicios.AllowUserToResizeRows = false;
            dgvListarServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListarServicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListarServicios.Location = new Point(15, 492);
            dgvListarServicios.Margin = new Padding(4);
            dgvListarServicios.Name = "dgvListarServicios";
            dgvListarServicios.ReadOnly = true;
            dgvListarServicios.RowHeadersWidth = 51;
            dgvListarServicios.Size = new Size(395, 134);
            dgvListarServicios.TabIndex = 18;
            // 
            // btnAgregarServicio
            // 
            btnAgregarServicio.Location = new Point(15, 449);
            btnAgregarServicio.Margin = new Padding(4);
            btnAgregarServicio.Name = "btnAgregarServicio";
            btnAgregarServicio.Size = new Size(118, 36);
            btnAgregarServicio.TabIndex = 19;
            btnAgregarServicio.Text = "Agregar";
            btnAgregarServicio.UseVisualStyleBackColor = true;
            btnAgregarServicio.Click += btnAgregarServicio_Click;
            // 
            // btnEliminarServicio
            // 
            btnEliminarServicio.Location = new Point(140, 449);
            btnEliminarServicio.Margin = new Padding(4);
            btnEliminarServicio.Name = "btnEliminarServicio";
            btnEliminarServicio.Size = new Size(118, 36);
            btnEliminarServicio.TabIndex = 20;
            btnEliminarServicio.Text = "Eliminar";
            btnEliminarServicio.UseVisualStyleBackColor = true;
            btnEliminarServicio.Click += btnEliminarServicio_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dtpFechaVencimiento);
            panel1.Controls.Add(lblFechaVencimiento);
            panel1.Location = new Point(468, 472);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 59);
            panel1.TabIndex = 21;
            // 
            // dtpFechaVencimiento
            // 
            dtpFechaVencimiento.Dock = DockStyle.Bottom;
            dtpFechaVencimiento.Location = new Point(0, 28);
            dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            dtpFechaVencimiento.Size = new Size(300, 31);
            dtpFechaVencimiento.TabIndex = 1;
            // 
            // lblFechaVencimiento
            // 
            lblFechaVencimiento.AutoSize = true;
            lblFechaVencimiento.Dock = DockStyle.Top;
            lblFechaVencimiento.Location = new Point(0, 0);
            lblFechaVencimiento.Name = "lblFechaVencimiento";
            lblFechaVencimiento.Size = new Size(183, 25);
            lblFechaVencimiento.TabIndex = 0;
            lblFechaVencimiento.Text = "Fecha de vencimiento";
            // 
            // AgregarEditarReparacionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 675);
            Controls.Add(panel1);
            Controls.Add(btnEliminarServicio);
            Controls.Add(btnAgregarServicio);
            Controls.Add(dgvListarServicios);
            Controls.Add(btnAplicar);
            Controls.Add(cmbServicio);
            Controls.Add(label7);
            Controls.Add(btnEditar);
            Controls.Add(lblTitulo);
            Controls.Add(btnDescartar);
            Controls.Add(btnGuardar);
            Controls.Add(btnAgregar);
            Controls.Add(lblTotal);
            Controls.Add(label4);
            Controls.Add(txtDiagnostico);
            Controls.Add(label3);
            Controls.Add(txtFallasReportadas);
            Controls.Add(label2);
            Controls.Add(dgvListarDispositivos);
            Controls.Add(btnBuscar);
            Controls.Add(label1);
            Controls.Add(cmbCliente);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "AgregarEditarReparacionForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += AgregarEditarReparacionForm_FormClosing;
            Load += AgregarEditarReparacionForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListarDispositivos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvListarServicios).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCliente;
        private Label label1;
        private Button btnBuscar;
        private DataGridView dgvListarDispositivos;
        private Label label2;
        private TextBox txtFallasReportadas;
        private Label label3;
        private TextBox txtDiagnostico;
        private Label label4;
        private Label lblTotal;
        private Button btnAgregar;
        private Button btnGuardar;
        private Button btnDescartar;
        private Label lblTitulo;
        private Button btnEditar;
        private Label label7;
        private ComboBox cmbServicio;
        private Button btnAplicar;
        private DataGridView dgvListarServicios;
        private Button btnAgregarServicio;
        private Button btnEliminarServicio;
        private Panel panel1;
        private Label lblFechaVencimiento;
        private DateTimePicker dtpFechaVencimiento;
    }
}