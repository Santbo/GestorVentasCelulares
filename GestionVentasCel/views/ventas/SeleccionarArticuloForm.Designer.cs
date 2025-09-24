namespace GestionVentasCel.views.usuario_empleado
{
    partial class SeleccionarArticuloForm
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
            dgvListarArticulos = new DataGridView();
            splitContainer1 = new SplitContainer();
            panelHeader = new Panel();
            lblTituloForm = new Label();
            panelBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarArticulos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelBtn
            // 
            panelBtn.BackColor = SystemColors.ActiveCaption;
            panelBtn.Controls.Add(txtBuscar);
            panelBtn.Controls.Add(btnCancelar);
            panelBtn.Controls.Add(btnSeleccionar);
            panelBtn.Dock = DockStyle.Bottom;
            panelBtn.Location = new Point(0, 587);
            panelBtn.Margin = new Padding(4);
            panelBtn.Name = "panelBtn";
            panelBtn.Size = new Size(1452, 86);
            panelBtn.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(15, 11);
            txtBuscar.Margin = new Padding(4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "(Ctrl + F) Buscar artículo";
            txtBuscar.Size = new Size(332, 31);
            txtBuscar.TabIndex = 4;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Right;
            btnCancelar.Location = new Point(1110, 8);
            btnCancelar.Margin = new Padding(4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(160, 75);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Anchor = AnchorStyles.Right;
            btnSeleccionar.Location = new Point(1277, 8);
            btnSeleccionar.Margin = new Padding(4);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(160, 75);
            btnSeleccionar.TabIndex = 0;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // dgvListarArticulos
            // 
            dgvListarArticulos.AllowUserToAddRows = false;
            dgvListarArticulos.AllowUserToDeleteRows = false;
            dgvListarArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListarArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListarArticulos.Dock = DockStyle.Fill;
            dgvListarArticulos.Location = new Point(11, 4);
            dgvListarArticulos.Margin = new Padding(4);
            dgvListarArticulos.Name = "dgvListarArticulos";
            dgvListarArticulos.ReadOnly = true;
            dgvListarArticulos.RowHeadersWidth = 51;
            dgvListarArticulos.Size = new Size(1430, 526);
            dgvListarArticulos.TabIndex = 0;
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
            splitContainer1.Panel2.Controls.Add(dgvListarArticulos);
            splitContainer1.Panel2.Padding = new Padding(11, 4, 11, 4);
            splitContainer1.Size = new Size(1452, 587);
            splitContainer1.SplitterDistance = 49;
            splitContainer1.TabIndex = 1;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(lblTituloForm);
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1452, 49);
            panelHeader.TabIndex = 1;
            // 
            // lblTituloForm
            // 
            lblTituloForm.BorderStyle = BorderStyle.Fixed3D;
            lblTituloForm.Dock = DockStyle.Fill;
            lblTituloForm.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloForm.Location = new Point(0, 0);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Padding = new Padding(8, 0, 8, 0);
            lblTituloForm.Size = new Size(1452, 49);
            lblTituloForm.TabIndex = 999;
            lblTituloForm.Text = "Artículos";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SeleccionarArticuloForm
            // 
            AcceptButton = btnSeleccionar;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(1452, 673);
            Controls.Add(splitContainer1);
            Controls.Add(panelBtn);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SeleccionarArticuloForm";
            FormClosing += SeleccionarPersonaForm_FormClosing;
            Load += SeleccionarClienteForm_Load;
            panelBtn.ResumeLayout(false);
            panelBtn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarArticulos).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBtn;
        private Button btnCancelar;
        private Button btnSeleccionar;
        private TextBox txtBuscar;
        private DataGridView dgvListarArticulos;
        private SplitContainer splitContainer1;
        private Panel panelHeader;
        private Label lblTituloForm;
    }
}