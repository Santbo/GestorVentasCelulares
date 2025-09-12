namespace GestionVentasCel.views.compra
{
    partial class VerDetallesCompraForm
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
            lblProveedor = new Label();
            lblFecha = new Label();
            lblTotal = new Label();
            lblObservaciones = new Label();
            dgvDetalles = new DataGridView();
            btnCerrar = new Button();
            btnEditar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblProveedor.Location = new Point(12, 15);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(75, 19);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblFecha.Location = new Point(12, 44);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(46, 19);
            lblFecha.TabIndex = 1;
            lblFecha.Text = "Fecha:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotal.Location = new Point(400, 15);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(42, 21);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total:";
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblObservaciones.Location = new Point(12, 73);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(101, 19);
            lblObservaciones.TabIndex = 3;
            lblObservaciones.Text = "Observaciones:";
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(12, 105);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.RowTemplate.Height = 25;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(600, 300);
            dgvDetalles.TabIndex = 4;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(537, 420);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 30);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(456, 420);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 30);
            btnEditar.TabIndex = 6;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // VerDetallesCompraForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 462);
            Controls.Add(btnCerrar);
            Controls.Add(btnEditar);
            Controls.Add(dgvDetalles);
            Controls.Add(lblObservaciones);
            Controls.Add(lblTotal);
            Controls.Add(lblFecha);
            Controls.Add(lblProveedor);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VerDetallesCompraForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalles de Compra";
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

          

        private Label lblProveedor;
        private Label lblFecha;
        private Label lblTotal;
        private Label lblObservaciones;
        private DataGridView dgvDetalles;
        private Button btnCerrar;
        private Button btnEditar;
    }
}
