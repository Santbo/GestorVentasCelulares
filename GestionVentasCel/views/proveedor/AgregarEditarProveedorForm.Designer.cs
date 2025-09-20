namespace GestionVentasCel.views.proveedor
{
    partial class AgregarEditarProveedorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEditarProveedorForm));
            btnGuardar = new Button();
            btnDescartar = new Button();
            btnSalir = new Button();
            imageList1 = new ImageList(components);
            panel11 = new Panel();
            panel9 = new Panel();
            lblCalle = new Label();
            txtCalle = new TextBox();
            panel4 = new Panel();
            lblEmail = new Label();
            txtEmail = new TextBox();
            panel10 = new Panel();
            lblCiudad = new Label();
            txtCiudad = new TextBox();
            panel3 = new Panel();
            lblTipoDocumento = new Label();
            comboTipoDoc = new ComboBox();
            panel2 = new Panel();
            lblCondicionIVA = new Label();
            comboCondicionIVA = new ComboBox();
            panel7 = new Panel();
            lblDni = new Label();
            txtDni = new TextBox();
            panel1 = new Panel();
            lblNombre = new Label();
            txtNombre = new TextBox();
            panel6 = new Panel();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            panel5 = new Panel();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblTituloForm = new Label();
            panel11.SuspendLayout();
            panel9.SuspendLayout();
            panel4.SuspendLayout();
            panel10.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel7.SuspendLayout();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuardar.Location = new Point(579, 374);
            btnGuardar.Margin = new Padding(4, 5, 4, 5);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(199, 50);
            btnGuardar.TabIndex = 20;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnDescartar
            // 
            btnDescartar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDescartar.Location = new Point(372, 374);
            btnDescartar.Margin = new Padding(4, 5, 4, 5);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(199, 50);
            btnDescartar.TabIndex = 21;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
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
            btnSalir.Location = new Point(745, 12);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(33, 37);
            btnSalir.TabIndex = 37;
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
            panel11.Location = new Point(12, 80);
            panel11.Name = "panel11";
            panel11.Size = new Size(780, 288);
            panel11.TabIndex = 36;
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
            // panel3
            // 
            panel3.Controls.Add(lblTipoDocumento);
            panel3.Controls.Add(comboTipoDoc);
            panel3.Location = new Point(266, 24);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(240, 65);
            panel3.TabIndex = 2;
            // 
            // lblTipoDocumento
            // 
            lblTipoDocumento.AutoSize = true;
            lblTipoDocumento.Dock = DockStyle.Top;
            lblTipoDocumento.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTipoDocumento.Location = new Point(0, 0);
            lblTipoDocumento.Margin = new Padding(4, 0, 4, 0);
            lblTipoDocumento.Name = "lblTipoDocumento";
            lblTipoDocumento.Size = new Size(180, 25);
            lblTipoDocumento.TabIndex = 19;
            lblTipoDocumento.Text = "Tipo de Documento";
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
            // panel2
            // 
            panel2.Controls.Add(lblCondicionIVA);
            panel2.Controls.Add(comboCondicionIVA);
            panel2.Location = new Point(529, 24);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(240, 65);
            panel2.TabIndex = 4;
            // 
            // lblCondicionIVA
            // 
            lblCondicionIVA.AutoSize = true;
            lblCondicionIVA.Dock = DockStyle.Top;
            lblCondicionIVA.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCondicionIVA.Location = new Point(0, 0);
            lblCondicionIVA.Margin = new Padding(4, 0, 4, 0);
            lblCondicionIVA.Name = "lblCondicionIVA";
            lblCondicionIVA.Size = new Size(204, 25);
            lblCondicionIVA.TabIndex = 21;
            lblCondicionIVA.Text = "Condición frente a IVA";
            // 
            // comboCondicionIVA
            // 
            comboCondicionIVA.Dock = DockStyle.Bottom;
            comboCondicionIVA.Font = new Font("Segoe UI", 12F);
            comboCondicionIVA.FormattingEnabled = true;
            comboCondicionIVA.Location = new Point(0, 25);
            comboCondicionIVA.Name = "comboCondicionIVA";
            comboCondicionIVA.Size = new Size(240, 40);
            comboCondicionIVA.TabIndex = 4;
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
            // txtApellido
            // 
            txtApellido.Dock = DockStyle.Bottom;
            txtApellido.Font = new Font("Segoe UI", 12F);
            txtApellido.Location = new Point(0, 26);
            txtApellido.MaxLength = 45;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(240, 39);
            txtApellido.TabIndex = 1;
            // 
            // lblTituloForm
            // 
            lblTituloForm.Dock = DockStyle.Top;
            lblTituloForm.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloForm.Location = new Point(0, 0);
            lblTituloForm.Margin = new Padding(4, 0, 4, 0);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Padding = new Padding(9, 0, 9, 0);
            lblTituloForm.Size = new Size(795, 77);
            lblTituloForm.TabIndex = 38;
            lblTituloForm.Text = "Agregar proveedor";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AgregarEditarProveedorForm
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnDescartar;
            ClientSize = new Size(795, 438);
            Controls.Add(btnSalir);
            Controls.Add(lblTituloForm);
            Controls.Add(panel11);
            Controls.Add(btnDescartar);
            Controls.Add(btnGuardar);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AgregarEditarProveedorForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Agregar Proveedor";
            FormClosing += AgregarEditarProveedorForm_FormClosing;
            Load += AgregarEditarProveedorForm_Load;
            panel11.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }
        private Button btnGuardar;
        private Button btnDescartar;
        private Button btnSalir;
        private Panel panel11;
        private Panel panel9;
        private Label lblCalle;
        private TextBox txtCalle;
        private Panel panel4;
        private Label lblEmail;
        private TextBox txtEmail;
        private Panel panel10;
        private Label lblCiudad;
        private TextBox txtCiudad;
        private Panel panel3;
        private Label lblTipoDocumento;
        private ComboBox comboTipoDoc;
        private Panel panel2;
        private Label lblCondicionIVA;
        private ComboBox comboCondicionIVA;
        private Panel panel7;
        private Label lblDni;
        private TextBox txtDni;
        private Panel panel1;
        private Label lblNombre;
        private TextBox txtNombre;
        private Panel panel6;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Panel panel5;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblTituloForm;
        private ImageList imageList1;
    }
}
