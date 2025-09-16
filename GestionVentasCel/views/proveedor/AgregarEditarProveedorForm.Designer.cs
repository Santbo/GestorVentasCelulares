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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblTipoDocumento = new Label();
            cmbTipoDocumento = new ComboBox();
            lblDocumento = new Label();
            txtDocumento = new TextBox();
            lblCondicionIVA = new Label();
            cmbCondicionIVA = new ComboBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblCalle = new Label();
            txtCalle = new TextBox();
            lblCiudad = new Label();
            txtCiudad = new TextBox();
            lblObservaciones = new Label();
            txtObservaciones = new TextBox();
            btnGuardar = new Button();
            btnDescartar = new Button();
            dtpFechaNacimiento = new DateTimePicker();
            lblFechaNacimiento = new Label();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 15);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 33);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 1;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(218, 15);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(218, 33);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(200, 23);
            txtApellido.TabIndex = 3;
            // 
            // lblTipoDocumento
            // 
            lblTipoDocumento.AutoSize = true;
            lblTipoDocumento.Location = new Point(424, 15);
            lblTipoDocumento.Name = "lblTipoDocumento";
            lblTipoDocumento.Size = new Size(103, 15);
            lblTipoDocumento.TabIndex = 4;
            lblTipoDocumento.Text = "Tipo Documento:";
            // 
            // cmbTipoDocumento
            // 
            cmbTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoDocumento.FormattingEnabled = true;
            cmbTipoDocumento.Location = new Point(424, 33);
            cmbTipoDocumento.Name = "cmbTipoDocumento";
            cmbTipoDocumento.Size = new Size(150, 23);
            cmbTipoDocumento.TabIndex = 5;
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(580, 15);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(70, 15);
            lblDocumento.TabIndex = 6;
            lblDocumento.Text = "Documento:";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(580, 33);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(150, 23);
            txtDocumento.TabIndex = 7;
            // 
            // lblCondicionIVA
            // 
            lblCondicionIVA.AutoSize = true;
            lblCondicionIVA.Location = new Point(12, 70);
            lblCondicionIVA.Name = "lblCondicionIVA";
            lblCondicionIVA.Size = new Size(91, 15);
            lblCondicionIVA.TabIndex = 8;
            lblCondicionIVA.Text = "Condición IVA:";
            // 
            // cmbCondicionIVA
            // 
            cmbCondicionIVA.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCondicionIVA.FormattingEnabled = true;
            cmbCondicionIVA.Location = new Point(12, 88);
            cmbCondicionIVA.Name = "cmbCondicionIVA";
            cmbCondicionIVA.Size = new Size(200, 23);
            cmbCondicionIVA.TabIndex = 9;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(218, 70);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(52, 15);
            lblTelefono.TabIndex = 10;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(218, 88);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(200, 23);
            txtTelefono.TabIndex = 11;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(424, 70);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 12;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(424, 88);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(306, 23);
            txtEmail.TabIndex = 13;
            // 
            // lblCalle
            // 
            lblCalle.AutoSize = true;
            lblCalle.Location = new Point(12, 125);
            lblCalle.Name = "lblCalle";
            lblCalle.Size = new Size(33, 15);
            lblCalle.TabIndex = 14;
            lblCalle.Text = "Calle:";
            // 
            // txtCalle
            // 
            txtCalle.Location = new Point(12, 143);
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(200, 23);
            txtCalle.TabIndex = 15;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Location = new Point(218, 125);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(45, 15);
            lblCiudad.TabIndex = 16;
            lblCiudad.Text = "Ciudad:";
            // 
            // txtCiudad
            // 
            txtCiudad.Location = new Point(218, 143);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(200, 23);
            txtCiudad.TabIndex = 17;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(12, 180);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(87, 15);
            lblObservaciones.TabIndex = 18;
            lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(12, 198);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(718, 100);
            txtObservaciones.TabIndex = 19;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(575, 320);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 30);
            btnGuardar.TabIndex = 20;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnDescartar
            // 
            btnDescartar.Location = new Point(656, 320);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(75, 30);
            btnDescartar.TabIndex = 21;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(424, 143);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(200, 23);
            dtpFechaNacimiento.TabIndex = 22;
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(424, 125);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(103, 15);
            lblFechaNacimiento.TabIndex = 23;
            lblFechaNacimiento.Text = "Fecha Nacimiento:";
            // 
            // AgregarEditarProveedorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(742, 362);
            Controls.Add(lblFechaNacimiento);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(btnDescartar);
            Controls.Add(btnGuardar);
            Controls.Add(txtObservaciones);
            Controls.Add(lblObservaciones);
            Controls.Add(txtCiudad);
            Controls.Add(lblCiudad);
            Controls.Add(txtCalle);
            Controls.Add(lblCalle);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(cmbCondicionIVA);
            Controls.Add(lblCondicionIVA);
            Controls.Add(txtDocumento);
            Controls.Add(lblDocumento);
            Controls.Add(cmbTipoDocumento);
            Controls.Add(lblTipoDocumento);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AgregarEditarProveedorForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Agregar Proveedor";
            Load += AgregarEditarProveedorForm_Load;
            FormClosing += AgregarEditarProveedorForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

          

        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblTipoDocumento;
        private ComboBox cmbTipoDocumento;
        private Label lblDocumento;
        private TextBox txtDocumento;
        private Label lblCondicionIVA;
        private ComboBox cmbCondicionIVA;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblCalle;
        private TextBox txtCalle;
        private Label lblCiudad;
        private TextBox txtCiudad;
        private Label lblObservaciones;
        private TextBox txtObservaciones;
        private Button btnGuardar;
        private Button btnDescartar;
        private DateTimePicker dtpFechaNacimiento;
        private Label lblFechaNacimiento;
    }
}
