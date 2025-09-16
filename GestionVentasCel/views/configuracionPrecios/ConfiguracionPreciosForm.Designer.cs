namespace GestionVentasCel.views.configuracionPrecios
{
    partial class ConfiguracionPreciosForm
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
            txtAumento = new TextBox();
            label2 = new Label();
            btnGuardar = new Button();
            btnDescartar = new Button();
            label3 = new Label();
            label5 = new Label();
            btnVer = new Button();
            SuspendLayout();
            // 
            // txtAumento
            // 
            txtAumento.Location = new Point(167, 114);
            txtAumento.MaxLength = 3;
            txtAumento.Name = "txtAumento";
            txtAumento.Size = new Size(45, 27);
            txtAumento.TabIndex = 1;
            txtAumento.KeyPress += txtAumento_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 117);
            label2.Name = "label2";
            label2.Size = new Size(149, 20);
            label2.TabIndex = 3;
            label2.Text = "Margen de Aumento:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(149, 167);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(131, 44);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnDescartar
            // 
            btnDescartar.Location = new Point(12, 167);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(131, 44);
            btnDescartar.TabIndex = 5;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(218, 117);
            label3.Name = "label3";
            label3.Size = new Size(21, 20);
            label3.TabIndex = 6;
            label3.Text = "%";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(31, 9);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.No;
            label5.Size = new Size(226, 31);
            label5.TabIndex = 8;
            label5.Text = "Margen de Aumento";
            // 
            // btnVer
            // 
            btnVer.Location = new Point(73, 57);
            btnVer.Name = "btnVer";
            btnVer.Size = new Size(152, 32);
            btnVer.TabIndex = 9;
            btnVer.Text = "Ver Margen Actual";
            btnVer.UseVisualStyleBackColor = true;
            btnVer.Click += btnVer_Click;
            // 
            // ConfiguracionPreciosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(308, 219);
            Controls.Add(btnVer);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(btnDescartar);
            Controls.Add(btnGuardar);
            Controls.Add(label2);
            Controls.Add(txtAumento);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ConfiguracionPreciosForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += ConfiguracionPreciosForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtAumento;
        private Label label2;
        private Button btnGuardar;
        private Button btnDescartar;
        private Label label3;
        private Label label5;
        private Button btnVer;
    }
}