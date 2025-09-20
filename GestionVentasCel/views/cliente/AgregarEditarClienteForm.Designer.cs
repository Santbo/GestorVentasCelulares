namespace GestionVentasCel.views.usuario_empleado
{
    partial class AgregarEditarClienteForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEditarClienteForm));
            btnDescartar = new Button();
            btnGuardar = new Button();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtTelefono = new TextBox();
            txtDni = new TextBox();
            txtEmail = new TextBox();
            lblNombre = new Label();
            lblApellido = new Label();
            lblTelefono = new Label();
            lblDni = new Label();
            lblEmail = new Label();
            lblTipoDni = new Label();
            comboTipoDoc = new ComboBox();
            comboIVA = new ComboBox();
            lblCondicionIva = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            panel9 = new Panel();
            lblCalle = new Label();
            txtCalle = new TextBox();
            panel10 = new Panel();
            lblCiudad = new Label();
            txtCiudad = new TextBox();
            panel11 = new Panel();
            btnSalir = new Button();
            imageList1 = new ImageList(components);
            lblTituloForm = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            SuspendLayout();
            // 
            // btnDescartar
            // 
            btnDescartar.Location = new Point(0, 3);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(195, 38);
            btnDescartar.TabIndex = 9;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(202, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(195, 38);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Dock = DockStyle.Bottom;
            txtNombre.Font = new Font("Segoe UI", 12F);
            txtNombre.Location = new Point(0, 26);
            txtNombre.MaxLength = 45;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(240, 39);
            txtNombre.TabIndex = 0;
            txtNombre.KeyPress += txtNombre_KeyPress;
            // 
            // txtApellido
            // 
            txtApellido.Dock = DockStyle.Bottom;
            txtApellido.Font = new Font("Segoe UI", 12F);
            txtApellido.Location = new Point(0, 26);
            txtApellido.MaxLength = 45;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(240, 39);
            txtApellido.TabIndex = 1;
            txtApellido.KeyPress += txtNombre_KeyPress;
            // 
            // txtTelefono
            // 
            txtTelefono.Dock = DockStyle.Bottom;
            txtTelefono.Font = new Font("Segoe UI", 12F);
            txtTelefono.Location = new Point(0, 26);
            txtTelefono.MaxLength = 14;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(240, 39);
            txtTelefono.TabIndex = 5;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // txtDni
            // 
            txtDni.Dock = DockStyle.Bottom;
            txtDni.Font = new Font("Segoe UI", 12F);
            txtDni.Location = new Point(0, 26);
            txtDni.MaxLength = 13;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(240, 39);
            txtDni.TabIndex = 3;
            txtDni.KeyPress += txtDni_KeyPress;
            // 
            // txtEmail
            // 
            txtEmail.Dock = DockStyle.Bottom;
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(0, 26);
            txtEmail.MaxLength = 50;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(240, 39);
            txtEmail.TabIndex = 6;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Dock = DockStyle.Top;
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(0, 0);
            lblNombre.Margin = new Padding(4, 0, 4, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(200, 25);
            lblNombre.TabIndex = 14;
            lblNombre.Text = "Nombre / razón social";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Dock = DockStyle.Top;
            lblApellido.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            lblTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            lblDni.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDni.Location = new Point(0, 0);
            lblDni.Margin = new Padding(4, 0, 4, 0);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(209, 25);
            lblDni.TabIndex = 17;
            lblDni.Text = "Número de documento";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Dock = DockStyle.Top;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(0, 0);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 18;
            lblEmail.Text = "Email";
            // 
            // lblTipoDni
            // 
            lblTipoDni.AutoSize = true;
            lblTipoDni.Dock = DockStyle.Top;
            lblTipoDni.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTipoDni.Location = new Point(0, 0);
            lblTipoDni.Margin = new Padding(4, 0, 4, 0);
            lblTipoDni.Name = "lblTipoDni";
            lblTipoDni.Size = new Size(180, 25);
            lblTipoDni.TabIndex = 19;
            lblTipoDni.Text = "Tipo de Documento";
            // 
            // comboTipoDoc
            // 
            comboTipoDoc.Dock = DockStyle.Bottom;
            comboTipoDoc.Font = new Font("Segoe UI", 12F);
            comboTipoDoc.FormattingEnabled = true;
            comboTipoDoc.Location = new Point(0, 25);
            comboTipoDoc.Name = "comboTipoDoc";
            comboTipoDoc.Size = new Size(240, 40);
            comboTipoDoc.TabIndex = 2;
            // 
            // comboIVA
            // 
            comboIVA.Dock = DockStyle.Bottom;
            comboIVA.Font = new Font("Segoe UI", 12F);
            comboIVA.FormattingEnabled = true;
            comboIVA.Location = new Point(0, 25);
            comboIVA.Name = "comboIVA";
            comboIVA.Size = new Size(240, 40);
            comboIVA.TabIndex = 4;
            // 
            // lblCondicionIva
            // 
            lblCondicionIva.AutoSize = true;
            lblCondicionIva.Dock = DockStyle.Top;
            lblCondicionIva.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCondicionIva.Location = new Point(0, 0);
            lblCondicionIva.Margin = new Padding(4, 0, 4, 0);
            lblCondicionIva.Name = "lblCondicionIva";
            lblCondicionIva.Size = new Size(204, 25);
            lblCondicionIva.TabIndex = 21;
            lblCondicionIva.Text = "Condición frente a IVA";
            // 
            // panel1
            // 
            panel1.Controls.Add(lblNombre);
            panel1.Controls.Add(txtNombre);
            panel1.Location = new Point(8, 24);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(240, 65);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblCondicionIva);
            panel2.Controls.Add(comboIVA);
            panel2.Location = new Point(529, 24);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(240, 65);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblTipoDni);
            panel3.Controls.Add(comboTipoDoc);
            panel3.Location = new Point(266, 24);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(240, 65);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Controls.Add(lblEmail);
            panel4.Controls.Add(txtEmail);
            panel4.Location = new Point(8, 190);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Size = new Size(240, 65);
            panel4.TabIndex = 6;
            // 
            // panel5
            // 
            panel5.Controls.Add(lblApellido);
            panel5.Controls.Add(txtApellido);
            panel5.Location = new Point(8, 106);
            panel5.Margin = new Padding(2);
            panel5.Name = "panel5";
            panel5.Size = new Size(240, 65);
            panel5.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.Controls.Add(lblTelefono);
            panel6.Controls.Add(txtTelefono);
            panel6.Location = new Point(528, 106);
            panel6.Margin = new Padding(2);
            panel6.Name = "panel6";
            panel6.Size = new Size(240, 65);
            panel6.TabIndex = 5;
            // 
            // panel7
            // 
            panel7.Controls.Add(lblDni);
            panel7.Controls.Add(txtDni);
            panel7.Location = new Point(266, 106);
            panel7.Margin = new Padding(2);
            panel7.Name = "panel7";
            panel7.Size = new Size(240, 65);
            panel7.TabIndex = 3;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel8.Controls.Add(btnDescartar);
            panel8.Controls.Add(btnGuardar);
            panel8.Location = new Point(369, 449);
            panel8.Margin = new Padding(2);
            panel8.Name = "panel8";
            panel8.Size = new Size(400, 46);
            panel8.TabIndex = 30;
            // 
            // panel9
            // 
            panel9.Controls.Add(lblCalle);
            panel9.Controls.Add(txtCalle);
            panel9.Location = new Point(266, 190);
            panel9.Margin = new Padding(2);
            panel9.Name = "panel9";
            panel9.Size = new Size(240, 65);
            panel9.TabIndex = 7;
            // 
            // lblCalle
            // 
            lblCalle.AutoSize = true;
            lblCalle.Dock = DockStyle.Top;
            lblCalle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCalle.Location = new Point(0, 0);
            lblCalle.Margin = new Padding(4, 0, 4, 0);
            lblCalle.Name = "lblCalle";
            lblCalle.Size = new Size(53, 25);
            lblCalle.TabIndex = 18;
            lblCalle.Text = "Calle";
            // 
            // txtCalle
            // 
            txtCalle.Dock = DockStyle.Bottom;
            txtCalle.Font = new Font("Segoe UI", 12F);
            txtCalle.Location = new Point(0, 26);
            txtCalle.MaxLength = 50;
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(240, 39);
            txtCalle.TabIndex = 7;
            // 
            // panel10
            // 
            panel10.Controls.Add(lblCiudad);
            panel10.Controls.Add(txtCiudad);
            panel10.Location = new Point(528, 190);
            panel10.Margin = new Padding(2);
            panel10.Name = "panel10";
            panel10.Size = new Size(240, 65);
            panel10.TabIndex = 8;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Dock = DockStyle.Top;
            lblCiudad.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCiudad.Location = new Point(0, 0);
            lblCiudad.Margin = new Padding(4, 0, 4, 0);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(71, 25);
            lblCiudad.TabIndex = 18;
            lblCiudad.Text = "Ciudad";
            // 
            // txtCiudad
            // 
            txtCiudad.Dock = DockStyle.Bottom;
            txtCiudad.Font = new Font("Segoe UI", 12F);
            txtCiudad.Location = new Point(0, 26);
            txtCiudad.MaxLength = 50;
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(240, 39);
            txtCiudad.TabIndex = 8;
            // 
            // panel11
            // 
            panel11.Controls.Add(panel9);
            panel11.Controls.Add(panel4);
            panel11.Controls.Add(panel10);
            panel11.Controls.Add(panel3);
            panel11.Controls.Add(panel2);
            panel11.Controls.Add(panel7);
            panel11.Controls.Add(panel1);
            panel11.Controls.Add(panel6);
            panel11.Controls.Add(panel5);
            panel11.Location = new Point(0, 80);
            panel11.Name = "panel11";
            panel11.Size = new Size(780, 321);
            panel11.TabIndex = 33;
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
            btnSalir.Location = new Point(736, 12);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(32, 32);
            btnSalir.TabIndex = 35;
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
            // lblTituloForm
            // 
            lblTituloForm.Dock = DockStyle.Top;
            lblTituloForm.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloForm.Location = new Point(0, 0);
            lblTituloForm.Margin = new Padding(4, 0, 4, 0);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Padding = new Padding(9, 0, 9, 0);
            lblTituloForm.Size = new Size(780, 77);
            lblTituloForm.TabIndex = 34;
            lblTituloForm.Text = "Agregar cliente";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AgregarEditarClienteForm
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnDescartar;
            ClientSize = new Size(780, 506);
            Controls.Add(btnSalir);
            Controls.Add(lblTituloForm);
            Controls.Add(panel11);
            Controls.Add(panel8);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "AgregarEditarClienteForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += AgregarEditarEmpleadoForm_FormClosing;
            Load += AgregarEditarClienteForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel11.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button btnDescartar;
        private Button btnGuardar;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtTelefono;
        private TextBox txtDni;
        private TextBox txtEmail;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblTelefono;
        private Label lblDni;
        private Label lblEmail;
        private Label lblTipoDni;
        private ComboBox comboTipoDoc;
        private ComboBox comboIVA;
        private Label lblCondicionIva;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Label lblCalle;
        private TextBox txtCalle;
        private Panel panel10;
        private Label lblCiudad;
        private TextBox txtCiudad;
        private Panel panel11;
        private Button btnSalir;
        private Label lblTituloForm;
        private ImageList imageList1;
    }
}