namespace GestionVentasCel.views
{
    partial class LoginForm
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
            panelContenedor = new Panel();
            btnSalir = new Button();
            label1 = new Label();
            txtPassword = new TextBox();
            txtUsuario = new TextBox();
            btnAcceso = new Button();
            panelContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.Azure;
            panelContenedor.Controls.Add(btnSalir);
            panelContenedor.Controls.Add(label1);
            panelContenedor.Controls.Add(txtPassword);
            panelContenedor.Controls.Add(txtUsuario);
            panelContenedor.Controls.Add(btnAcceso);
            panelContenedor.Location = new Point(103, 12);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(635, 426);
            panelContenedor.TabIndex = 0;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.White;
            btnSalir.Font = new Font("Segoe UI", 12F);
            btnSalir.ForeColor = SystemColors.ActiveCaptionText;
            btnSalir.Location = new Point(110, 371);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(430, 41);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Enabled = false;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(245, 25);
            label1.Name = "label1";
            label1.Size = new Size(140, 35);
            label1.TabIndex = 3;
            label1.Text = "ACCESO";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(71, 215);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Contraseña";
            txtPassword.Size = new Size(500, 27);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(71, 123);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Nombre de Usuario";
            txtUsuario.Size = new Size(500, 27);
            txtUsuario.TabIndex = 1;
            // 
            // btnAcceso
            // 
            btnAcceso.BackColor = Color.DeepSkyBlue;
            btnAcceso.Font = new Font("Segoe UI", 12F);
            btnAcceso.ForeColor = SystemColors.ControlLightLight;
            btnAcceso.Location = new Point(110, 324);
            btnAcceso.Name = "btnAcceso";
            btnAcceso.Size = new Size(430, 41);
            btnAcceso.TabIndex = 0;
            btnAcceso.Text = "ACCEDER";
            btnAcceso.UseVisualStyleBackColor = false;
            btnAcceso.Click += btnAcceso_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DeepSkyBlue;
            ClientSize = new Size(840, 450);
            Controls.Add(panelContenedor);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
        }

          

        private Panel panelContenedor;
        private Button btnAcceso;
        private TextBox txtPassword;
        private TextBox txtUsuario;
        private Label label1;
        private Button btnSalir;
    }
}