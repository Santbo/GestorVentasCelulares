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



        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEditarEmpleadoForm));
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
            lblUsuario = new Label();
            lblContra = new Label();
            lblNombre = new Label();
            lblApellido = new Label();
            lblTelefono = new Label();
            lblDni = new Label();
            lblEmail = new Label();
            lblRol = new Label();
            comboRol = new ComboBox();
            panelHeader = new Panel();
            btnSalir = new Button();
            imageList1 = new ImageList(components);
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            panel9 = new Panel();
            panelHeader.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Padding = new Padding(9, 0, 9, 0);
            lblTitulo.Size = new Size(1005, 77);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Agregar Empleado";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnDescartar
            // 
            btnDescartar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDescartar.Location = new Point(447, 415);
            btnDescartar.Margin = new Padding(4);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(268, 48);
            btnDescartar.TabIndex = 8;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuardar.Location = new Point(724, 415);
            btnGuardar.Margin = new Padding(4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(268, 48);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.Dock = DockStyle.Bottom;
            txtUsuario.Font = new Font("Segoe UI", 12F);
            txtUsuario.Location = new Point(0, 30);
            txtUsuario.Margin = new Padding(4);
            txtUsuario.MaxLength = 50;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(300, 39);
            txtUsuario.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Dock = DockStyle.Bottom;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(0, 30);
            txtPassword.Margin = new Padding(4);
            txtPassword.MaxLength = 100;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(300, 39);
            txtPassword.TabIndex = 5;
            // 
            // txtNombre
            // 
            txtNombre.Dock = DockStyle.Bottom;
            txtNombre.Font = new Font("Segoe UI", 12F);
            txtNombre.Location = new Point(0, 30);
            txtNombre.Margin = new Padding(4);
            txtNombre.MaxLength = 45;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(300, 39);
            txtNombre.TabIndex = 6;
            txtNombre.KeyPress += txtNombre_KeyPress;
            // 
            // txtApellido
            // 
            txtApellido.Dock = DockStyle.Bottom;
            txtApellido.Font = new Font("Segoe UI", 12F);
            txtApellido.Location = new Point(0, 30);
            txtApellido.Margin = new Padding(4);
            txtApellido.MaxLength = 45;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(300, 39);
            txtApellido.TabIndex = 7;
            txtApellido.KeyPress += txtNombre_KeyPress;
            // 
            // txtTelefono
            // 
            txtTelefono.Dock = DockStyle.Bottom;
            txtTelefono.Font = new Font("Segoe UI", 12F);
            txtTelefono.Location = new Point(0, 30);
            txtTelefono.Margin = new Padding(4);
            txtTelefono.MaxLength = 12;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(300, 39);
            txtTelefono.TabIndex = 8;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // txtDni
            // 
            txtDni.Dock = DockStyle.Bottom;
            txtDni.Font = new Font("Segoe UI", 12F);
            txtDni.Location = new Point(0, 30);
            txtDni.Margin = new Padding(4);
            txtDni.MaxLength = 13;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(300, 39);
            txtDni.TabIndex = 9;
            txtDni.KeyPress += txtDni_KeyPress;
            // 
            // txtEmail
            // 
            txtEmail.Dock = DockStyle.Bottom;
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(0, 30);
            txtEmail.Margin = new Padding(4);
            txtEmail.MaxLength = 50;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 39);
            txtEmail.TabIndex = 10;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Dock = DockStyle.Top;
            lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuario.Location = new Point(0, 0);
            lblUsuario.Margin = new Padding(4, 0, 4, 0);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(77, 25);
            lblUsuario.TabIndex = 12;
            lblUsuario.Text = "Usuario";
            // 
            // lblContra
            // 
            lblContra.AutoSize = true;
            lblContra.Dock = DockStyle.Top;
            lblContra.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblContra.Location = new Point(0, 0);
            lblContra.Margin = new Padding(4, 0, 4, 0);
            lblContra.Name = "lblContra";
            lblContra.Size = new Size(108, 25);
            lblContra.TabIndex = 13;
            lblContra.Text = "Contraseña";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Dock = DockStyle.Top;
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombre.Location = new Point(0, 0);
            lblNombre.Margin = new Padding(4, 0, 4, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(81, 25);
            lblNombre.TabIndex = 14;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Dock = DockStyle.Top;
            lblApellido.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblApellido.Location = new Point(0, 0);
            lblApellido.Margin = new Padding(4, 0, 4, 0);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(83, 25);
            lblApellido.TabIndex = 15;
            lblApellido.Text = "Apellido";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Dock = DockStyle.Top;
            lblTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTelefono.Location = new Point(0, 0);
            lblTelefono.Margin = new Padding(4, 0, 4, 0);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(86, 25);
            lblTelefono.TabIndex = 16;
            lblTelefono.Text = "Teléfono";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Dock = DockStyle.Top;
            lblDni.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDni.Location = new Point(0, 0);
            lblDni.Margin = new Padding(4, 0, 4, 0);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(41, 25);
            lblDni.TabIndex = 17;
            lblDni.Text = "Dni";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Dock = DockStyle.Top;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.Location = new Point(0, 0);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 18;
            lblEmail.Text = "Email";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Dock = DockStyle.Top;
            lblRol.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRol.Location = new Point(0, 0);
            lblRol.Margin = new Padding(4, 0, 4, 0);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(40, 25);
            lblRol.TabIndex = 19;
            lblRol.Text = "Rol";
            // 
            // comboRol
            // 
            comboRol.Dock = DockStyle.Bottom;
            comboRol.Font = new Font("Segoe UI", 12F);
            comboRol.FormattingEnabled = true;
            comboRol.Location = new Point(0, 29);
            comboRol.Margin = new Padding(4);
            comboRol.Name = "comboRol";
            comboRol.Size = new Size(300, 40);
            comboRol.TabIndex = 20;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(btnSalir);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1005, 77);
            panelHeader.TabIndex = 21;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ImageKey = "xmark-solid-full.png";
            btnSalir.ImageList = imageList1;
            btnSalir.Location = new Point(961, 12);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(32, 32);
            btnSalir.TabIndex = 2;
            btnSalir.TabStop = false;
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "xmark-solid-full.png");
            // 
            // panel2
            // 
            panel2.Controls.Add(lblUsuario);
            panel2.Controls.Add(txtUsuario);
            panel2.Location = new Point(12, 106);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 69);
            panel2.TabIndex = 1;
            panel2.TabStop = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblTelefono);
            panel3.Controls.Add(txtTelefono);
            panel3.Location = new Point(340, 297);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 69);
            panel3.TabIndex = 8;
            panel3.TabStop = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(lblRol);
            panel4.Controls.Add(comboRol);
            panel4.Location = new Point(691, 106);
            panel4.Name = "panel4";
            panel4.Size = new Size(300, 69);
            panel4.TabIndex = 3;
            panel4.TabStop = true;
            // 
            // panel5
            // 
            panel5.Controls.Add(lblContra);
            panel5.Controls.Add(txtPassword);
            panel5.Location = new Point(340, 106);
            panel5.Name = "panel5";
            panel5.Size = new Size(300, 69);
            panel5.TabIndex = 2;
            panel5.TabStop = true;
            // 
            // panel6
            // 
            panel6.Controls.Add(lblDni);
            panel6.Controls.Add(txtDni);
            panel6.Location = new Point(691, 207);
            panel6.Name = "panel6";
            panel6.Size = new Size(300, 69);
            panel6.TabIndex = 6;
            panel6.TabStop = true;
            // 
            // panel7
            // 
            panel7.Controls.Add(lblNombre);
            panel7.Controls.Add(txtNombre);
            panel7.Location = new Point(12, 207);
            panel7.Name = "panel7";
            panel7.Size = new Size(300, 69);
            panel7.TabIndex = 4;
            panel7.TabStop = true;
            // 
            // panel8
            // 
            panel8.Controls.Add(lblApellido);
            panel8.Controls.Add(txtApellido);
            panel8.Location = new Point(340, 207);
            panel8.Name = "panel8";
            panel8.Size = new Size(300, 69);
            panel8.TabIndex = 5;
            panel8.TabStop = true;
            // 
            // panel9
            // 
            panel9.Controls.Add(lblEmail);
            panel9.Controls.Add(txtEmail);
            panel9.Location = new Point(12, 297);
            panel9.Name = "panel9";
            panel9.Size = new Size(300, 69);
            panel9.TabIndex = 7;
            panel9.TabStop = true;
            // 
            // AgregarEditarEmpleadoForm
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnDescartar;
            ClientSize = new Size(1005, 476);
            Controls.Add(panel9);
            Controls.Add(panel8);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panelHeader);
            Controls.Add(btnGuardar);
            Controls.Add(btnDescartar);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "AgregarEditarEmpleadoForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += AgregarEditarEmpleadoForm_FormClosing;
            Load += AgregarEditarEmpleadoForm_Load;
            panelHeader.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ResumeLayout(false);
        }



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
        private Label lblUsuario;
        private Label lblContra;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblTelefono;
        private Label lblDni;
        private Label lblEmail;
        private Label lblRol;
        private ComboBox comboRol;
        private Panel panelHeader;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Button btnSalir;
        private ImageList imageList1;
    }
}