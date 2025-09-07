namespace GestionVentasCel.views.usuario_empleado
{
    partial class AgregarEditarEmpleadoForm
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
            btnDescartar = new Button();
            btnGuardar = new Button();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtTelefono = new TextBox();
            txtDni = new TextBox();
            txtEmail = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            comboRol = new ComboBox();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Verdana", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(238, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(326, 36);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Agregar Empleado";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnDescartar
            // 
            btnDescartar.Location = new Point(577, 355);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(195, 38);
            btnDescartar.TabIndex = 2;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(577, 400);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(195, 38);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(58, 108);
            txtUsuario.MaxLength = 50;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(203, 27);
            txtUsuario.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(58, 191);
            txtPassword.MaxLength = 100;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(203, 27);
            txtPassword.TabIndex = 5;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(58, 272);
            txtNombre.MaxLength = 45;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(203, 27);
            txtNombre.TabIndex = 6;
            txtNombre.KeyPress += txtNombre_KeyPress;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(58, 355);
            txtApellido.MaxLength = 45;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(203, 27);
            txtApellido.TabIndex = 7;
            txtApellido.KeyPress += txtNombre_KeyPress;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(334, 108);
            txtTelefono.MaxLength = 12;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(203, 27);
            txtTelefono.TabIndex = 8;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(334, 191);
            txtDni.MaxLength = 10;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(203, 27);
            txtDni.TabIndex = 9;
            txtDni.KeyPress += txtDni_KeyPress;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(334, 272);
            txtEmail.MaxLength = 50;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(203, 27);
            txtEmail.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 85);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 12;
            label2.Text = "Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(58, 168);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 13;
            label3.Text = "Contraseña";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(58, 249);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 14;
            label4.Text = "Nombre";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(58, 332);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 15;
            label5.Text = "Apellido";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(334, 85);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 16;
            label6.Text = "Telefono";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(334, 168);
            label7.Name = "label7";
            label7.Size = new Size(32, 20);
            label7.TabIndex = 17;
            label7.Text = "Dni";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(334, 249);
            label8.Name = "label8";
            label8.Size = new Size(46, 20);
            label8.TabIndex = 18;
            label8.Text = "Email";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(577, 85);
            label9.Name = "label9";
            label9.Size = new Size(31, 20);
            label9.TabIndex = 19;
            label9.Text = "Rol";
            // 
            // comboRol
            // 
            comboRol.FormattingEnabled = true;
            comboRol.Location = new Point(577, 108);
            comboRol.Name = "comboRol";
            comboRol.Size = new Size(203, 28);
            comboRol.TabIndex = 20;
            // 
            // AgregarEditarEmpleadoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboRol);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtEmail);
            Controls.Add(txtDni);
            Controls.Add(txtTelefono);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(txtPassword);
            Controls.Add(txtUsuario);
            Controls.Add(btnGuardar);
            Controls.Add(btnDescartar);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AgregarEditarEmpleadoForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += AgregarEditarEmpleadoForm_FormClosing;
            Load += AgregarEditarEmpleadoForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button button1;
        private Button btnDescartar;
        private Button btnGuardar;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtTelefono;
        private TextBox txtDni;
        private TextBox txtEmail;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private ComboBox comboRol;
    }
}