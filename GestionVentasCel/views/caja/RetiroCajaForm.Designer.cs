namespace GestionVentasCel.views.caja
{
    partial class RetiroCajaForm
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
            txtMonto = new TextBox();
            lblMonto = new Label();
            txtDescripcion = new TextBox();
            lblDesripcion = new Label();
            btnGuardar = new Button();
            lblTitulo = new Label();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(37, 112);
            txtMonto.MaxLength = 13;
            txtMonto.Name = "txtMonto";
            txtMonto.PlaceholderText = "$0000.00";
            txtMonto.Size = new Size(244, 27);
            txtMonto.TabIndex = 2;
            txtMonto.KeyPress += txtMonto_KeyPress;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(37, 89);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(53, 20);
            lblMonto.TabIndex = 3;
            lblMonto.Text = "Monto";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(37, 192);
            txtDescripcion.MaxLength = 255;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "Escribe el motivo del retiro...";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(389, 153);
            txtDescripcion.TabIndex = 4;
            // 
            // lblDesripcion
            // 
            lblDesripcion.AutoSize = true;
            lblDesripcion.Location = new Point(37, 169);
            lblDesripcion.Name = "lblDesripcion";
            lblDesripcion.Size = new Size(87, 20);
            lblDesripcion.TabIndex = 5;
            lblDesripcion.Text = "Descripcion";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(312, 394);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(133, 44);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(221, 38);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "Retiro de Dinero";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(173, 394);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(133, 44);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // RetiroCajaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 450);
            Controls.Add(btnCancelar);
            Controls.Add(lblTitulo);
            Controls.Add(btnGuardar);
            Controls.Add(lblDesripcion);
            Controls.Add(txtDescripcion);
            Controls.Add(lblMonto);
            Controls.Add(txtMonto);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "RetiroCajaForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += RetiroCajaForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtMonto;
        private Label lblMonto;
        private TextBox txtDescripcion;
        private Label lblDesripcion;
        private Button btnGuardar;
        private Label lblTitulo;
        private Button btnCancelar;
    }
}