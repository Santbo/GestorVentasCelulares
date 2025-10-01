namespace GestionVentasCel.views.caja
{
    partial class MontoAperturaForm
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
            lblTitulo = new Label();
            txtMontoApertura = new TextBox();
            lblMonto = new Label();
            label1 = new Label();
            btnAbrirCaja = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(15, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(475, 46);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Agregar el Monto de Apertura";
            // 
            // txtMontoApertura
            // 
            txtMontoApertura.Location = new Point(213, 91);
            txtMontoApertura.MaxLength = 13;
            txtMontoApertura.Name = "txtMontoApertura";
            txtMontoApertura.Size = new Size(203, 27);
            txtMontoApertura.TabIndex = 2;
            txtMontoApertura.KeyPress += txtMontoApertura_KeyPress;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMonto.Location = new Point(92, 87);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(72, 28);
            lblMonto.TabIndex = 3;
            lblMonto.Text = "Monto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(184, 87);
            label1.Name = "label1";
            label1.Size = new Size(23, 28);
            label1.TabIndex = 4;
            label1.Text = "$";
            // 
            // btnAbrirCaja
            // 
            btnAbrirCaja.Location = new Point(382, 147);
            btnAbrirCaja.Name = "btnAbrirCaja";
            btnAbrirCaja.Size = new Size(108, 48);
            btnAbrirCaja.TabIndex = 5;
            btnAbrirCaja.Text = "Abrir Caja";
            btnAbrirCaja.UseVisualStyleBackColor = true;
            btnAbrirCaja.Click += btnAbrirCaja_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(268, 147);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(108, 48);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // MontoAperturaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 207);
            Controls.Add(btnCancelar);
            Controls.Add(btnAbrirCaja);
            Controls.Add(label1);
            Controls.Add(lblMonto);
            Controls.Add(txtMontoApertura);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MontoAperturaForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += MontoAperturaForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private TextBox txtMontoApertura;
        private Label lblMonto;
        private Label label1;
        private Button btnAbrirCaja;
        private Button btnCancelar;
    }
}