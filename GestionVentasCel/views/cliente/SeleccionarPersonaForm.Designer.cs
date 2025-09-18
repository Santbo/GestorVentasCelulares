namespace GestionVentasCel.views.usuario_empleado
{
    partial class SeleccionarPersonaForm
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
            btnCancelar = new Button();
            btnSeleccionar = new Button();
            panelContenedor = new Panel();
            splitContainer1 = new SplitContainer();
            panelHeader = new Panel();
            lblTituloForm = new Label();
            dgvListarPersonas = new DataGridView();
            panelBtn.SuspendLayout();
            panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarPersonas).BeginInit();
            SuspendLayout();
            // 
            // panelBtn
            // 
            panelBtn.BackColor = SystemColors.ActiveCaption;
            panelBtn.Controls.Add(txtBuscar);
            panelBtn.Controls.Add(btnCancelar);
            panelBtn.Controls.Add(btnSeleccionar);
            panelBtn.Dock = DockStyle.Bottom;
            panelBtn.Location = new Point(0, 530);
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
            txtBuscar.PlaceholderText = "(Ctrl + F) Buscar persona";
            txtBuscar.Size = new Size(332, 31);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Right;
            btnCancelar.Location = new Point(658, 8);
            btnCancelar.Margin = new Padding(4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(160, 75);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Anchor = AnchorStyles.Right;
            btnSeleccionar.Location = new Point(825, 8);
            btnSeleccionar.Margin = new Padding(4);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(160, 75);
            btnSeleccionar.TabIndex = 2;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.Controls.Add(splitContainer1);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 0);
            panelContenedor.Margin = new Padding(4);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1000, 530);
            panelContenedor.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panelHeader);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvListarPersonas);
            splitContainer1.Panel2.Padding = new Padding(11, 4, 11, 4);
            splitContainer1.Size = new Size(1000, 530);
            splitContainer1.SplitterDistance = 45;
            splitContainer1.TabIndex = 0;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(lblTituloForm);
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1000, 45);
            panelHeader.TabIndex = 1;
            // 
            // lblTituloForm
            // 
            lblTituloForm.Dock = DockStyle.Fill;
            lblTituloForm.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloForm.Location = new Point(0, 0);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Padding = new Padding(8, 0, 8, 0);
            lblTituloForm.Size = new Size(1000, 45);
            lblTituloForm.TabIndex = 999;
            lblTituloForm.Text = "Personas registradas";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvListarPersonas
            // 
            dgvListarPersonas.AllowUserToAddRows = false;
            dgvListarPersonas.AllowUserToDeleteRows = false;
            dgvListarPersonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListarPersonas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListarPersonas.Dock = DockStyle.Fill;
            dgvListarPersonas.Location = new Point(11, 4);
            dgvListarPersonas.Margin = new Padding(4);
            dgvListarPersonas.Name = "dgvListarPersonas";
            dgvListarPersonas.ReadOnly = true;
            dgvListarPersonas.RowHeadersWidth = 51;
            dgvListarPersonas.Size = new Size(978, 473);
            dgvListarPersonas.StandardTab = true;
            dgvListarPersonas.TabIndex = 0;
            // 
            // SeleccionarPersonaForm
            // 
            AcceptButton = btnSeleccionar;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(1000, 616);
            Controls.Add(panelContenedor);
            Controls.Add(panelBtn);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SeleccionarPersonaForm";
            FormClosing += SeleccionarPersonaForm_FormClosing;
            Load += SeleccionarPersonaForm_Load;
            panelBtn.ResumeLayout(false);
            panelBtn.PerformLayout();
            panelContenedor.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvListarPersonas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBtn;
        private Panel panelContenedor;
        private DataGridView dgvListarPersonas;
        private Button btnCancelar;
        private Button btnSeleccionar;
        private TextBox txtBuscar;
        private SplitContainer splitContainer1;
        private Panel panelHeader;
        private Label lblTituloForm;
    }
}