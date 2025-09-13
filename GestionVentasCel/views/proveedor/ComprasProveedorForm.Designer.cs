namespace GestionVentasCel.views.proveedor
{
    partial class ComprasProveedorForm
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
            dgvCompras = new DataGridView();
            panelBtn = new Panel();
            btnVerDetalle = new Button();
            btnEditar = new Button();
            btnCerrar = new Button();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            panelBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).BeginInit();
            SuspendLayout();
            // 
            // dgvCompras
            // 
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AllowUserToDeleteRows = false;
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompras.Dock = DockStyle.Fill;
            dgvCompras.Location = new Point(0, 0);
            dgvCompras.Name = "dgvCompras";
            dgvCompras.ReadOnly = true;
            dgvCompras.RowHeadersWidth = 51;
            dgvCompras.Size = new Size(800, 381);
            dgvCompras.TabIndex = 0;
            // 
            // panelBtn
            // 
            panelBtn.BackColor = SystemColors.ActiveCaption;
            panelBtn.Controls.Add(lblBuscar);
            panelBtn.Controls.Add(txtBuscar);
            panelBtn.Controls.Add(btnCerrar);
            panelBtn.Controls.Add(btnEditar);
            panelBtn.Controls.Add(btnVerDetalle);
            panelBtn.Dock = DockStyle.Bottom;
            panelBtn.Location = new Point(0, 381);
            panelBtn.Name = "panelBtn";
            panelBtn.Size = new Size(800, 69);
            panelBtn.TabIndex = 1;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Anchor = AnchorStyles.Right;
            btnVerDetalle.Location = new Point(533, 3);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(128, 60);
            btnVerDetalle.TabIndex = 0;
            btnVerDetalle.Text = "Ver Detalle";
            btnVerDetalle.UseVisualStyleBackColor = true;
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Right;
            btnEditar.Location = new Point(667, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(128, 60);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Right;
            btnCerrar.Location = new Point(399, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(128, 60);
            btnCerrar.TabIndex = 2;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(80, 9);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar compras...";
            txtBuscar.Size = new Size(266, 27);
            txtBuscar.TabIndex = 3;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(12, 12);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(62, 20);
            lblBuscar.TabIndex = 4;
            lblBuscar.Text = "Buscar:";
            // 
            // ComprasProveedorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvCompras);
            Controls.Add(panelBtn);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ComprasProveedorForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Compras del Proveedor";
            panelBtn.ResumeLayout(false);
            panelBtn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).EndInit();
            ResumeLayout(false);
        }

          

        private DataGridView dgvCompras;
        private Panel panelBtn;
        private Button btnVerDetalle;
        private Button btnEditar;
        private Button btnCerrar;
        private TextBox txtBuscar;
        private Label lblBuscar;
    }
}
