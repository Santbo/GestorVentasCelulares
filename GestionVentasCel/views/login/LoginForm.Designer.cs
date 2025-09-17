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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panelContenedor = new Panel();
            lblContra = new Label();
            lblUsuario = new Label();
            lblTitulo = new Label();
            txtPassword = new TextBox();
            txtUsuario = new TextBox();
            btnAcceso = new Button();
            btnSalir = new Button();
            imageList1 = new ImageList(components);
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelContenedor
            // 
            panelContenedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelContenedor.BackColor = Color.Azure;
            panelContenedor.Controls.Add(lblContra);
            panelContenedor.Controls.Add(lblUsuario);
            panelContenedor.Controls.Add(lblTitulo);
            panelContenedor.Controls.Add(txtPassword);
            panelContenedor.Controls.Add(txtUsuario);
            panelContenedor.Controls.Add(btnAcceso);
            panelContenedor.Location = new Point(325, -2);
            panelContenedor.Margin = new Padding(4);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(482, 566);
            panelContenedor.TabIndex = 0;
            // 
            // lblContra
            // 
            lblContra.AutoSize = true;
            lblContra.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContra.Location = new Point(47, 277);
            lblContra.Name = "lblContra";
            lblContra.Size = new Size(108, 25);
            lblContra.TabIndex = 8;
            lblContra.Text = "Contraseña";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(47, 199);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(175, 25);
            lblUsuario.TabIndex = 6;
            lblUsuario.Text = "Nombre de usuario";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(47, 79);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(289, 45);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "Acceder al sistema";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(47, 306);
            txtPassword.Margin = new Padding(4);
            txtPassword.MaxLength = 200;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(391, 39);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(47, 228);
            txtUsuario.Margin = new Padding(4);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(391, 39);
            txtUsuario.TabIndex = 1;
            // 
            // btnAcceso
            // 
            btnAcceso.BackColor = Color.DeepSkyBlue;
            btnAcceso.Cursor = Cursors.Hand;
            btnAcceso.FlatAppearance.BorderColor = Color.Black;
            btnAcceso.FlatAppearance.BorderSize = 0;
            btnAcceso.FlatStyle = FlatStyle.Flat;
            btnAcceso.Font = new Font("Segoe UI", 12F);
            btnAcceso.ForeColor = SystemColors.ControlLightLight;
            btnAcceso.Location = new Point(47, 412);
            btnAcceso.Margin = new Padding(4);
            btnAcceso.Name = "btnAcceso";
            btnAcceso.Size = new Size(201, 51);
            btnAcceso.TabIndex = 3;
            btnAcceso.Text = "Iniciar Sesión";
            btnAcceso.UseVisualStyleBackColor = false;
            btnAcceso.Click += btnAcceso_Click;
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
            btnSalir.Location = new Point(816, 12);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(32, 32);
            btnSalir.TabIndex = 1;
            btnSalir.TabStop = false;
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click_1;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "key-solid-full.png");
            imageList1.Images.SetKeyName(1, "user-solid-full.png");
            imageList1.Images.SetKeyName(2, "xmark-solid-full.png");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(103, 285);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(215, 45);
            label1.TabIndex = 1;
            label1.Text = "Bienvenido al";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(20, 346);
            label2.Name = "label2";
            label2.Size = new Size(298, 45);
            label2.TabIndex = 2;
            label2.Text = "Sistema de Gestión";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._7946204_ai;
            pictureBox1.Location = new Point(0, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(313, 323);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(24, 531);
            label3.Name = "label3";
            label3.Size = new Size(280, 25);
            label3.TabIndex = 6;
            label3.Text = "Copyright 2025 - MantoSoft S.R.L";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LoginForm
            // 
            AcceptButton = btnAcceso;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DeepSkyBlue;
            ClientSize = new Size(860, 562);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSalir);
            Controls.Add(panelContenedor);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Load += LoginForm_Load;
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        private Panel panelContenedor;
        private Button btnAcceso;
        private TextBox txtPassword;
        private TextBox txtUsuario;
        private Label lblTitulo;
        private Button btnSalir;
        private ImageList imageList1;
        private Label lblUsuario;
        private Label lblContra;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label3;
    }
}