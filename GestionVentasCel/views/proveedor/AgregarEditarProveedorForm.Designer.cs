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
            btnGuardar = new Button();
            btnDescartar = new Button();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(14, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(14, 44);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.MaxLength = 45;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(228, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(249, 20);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(69, 20);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(249, 44);
            txtApellido.Margin = new Padding(3, 4, 3, 4);
            txtApellido.MaxLength = 45;
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "(Opcional)";
            txtApellido.Size = new Size(228, 27);
            txtApellido.TabIndex = 3;
            // 
            // lblTipoDocumento
            // 
            lblTipoDocumento.AutoSize = true;
            lblTipoDocumento.Location = new Point(485, 20);
            lblTipoDocumento.Name = "lblTipoDocumento";
            lblTipoDocumento.Size = new Size(124, 20);
            lblTipoDocumento.TabIndex = 4;
            lblTipoDocumento.Text = "Tipo Documento:";
            // 
            // cmbTipoDocumento
            // 
            cmbTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoDocumento.FormattingEnabled = true;
            cmbTipoDocumento.Location = new Point(485, 44);
            cmbTipoDocumento.Margin = new Padding(3, 4, 3, 4);
            cmbTipoDocumento.Name = "cmbTipoDocumento";
            cmbTipoDocumento.Size = new Size(171, 28);
            cmbTipoDocumento.TabIndex = 5;
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(663, 20);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(90, 20);
            lblDocumento.TabIndex = 6;
            lblDocumento.Text = "Documento:";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(663, 44);
            txtDocumento.Margin = new Padding(3, 4, 3, 4);
            txtDocumento.MaxLength = 13;
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(171, 27);
            txtDocumento.TabIndex = 7;
            txtDocumento.KeyPress += txtDocumento_KeyPress;
            // 
            // lblCondicionIVA
            // 
            lblCondicionIVA.AutoSize = true;
            lblCondicionIVA.Location = new Point(14, 93);
            lblCondicionIVA.Name = "lblCondicionIVA";
            lblCondicionIVA.Size = new Size(105, 20);
            lblCondicionIVA.TabIndex = 8;
            lblCondicionIVA.Text = "Condición IVA:";
            // 
            // cmbCondicionIVA
            // 
            cmbCondicionIVA.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCondicionIVA.FormattingEnabled = true;
            cmbCondicionIVA.Location = new Point(14, 117);
            cmbCondicionIVA.Margin = new Padding(3, 4, 3, 4);
            cmbCondicionIVA.Name = "cmbCondicionIVA";
            cmbCondicionIVA.Size = new Size(228, 28);
            cmbCondicionIVA.TabIndex = 9;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(249, 93);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(70, 20);
            lblTelefono.TabIndex = 10;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(249, 117);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.MaxLength = 15;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "(Opcional)";
            txtTelefono.Size = new Size(228, 27);
            txtTelefono.TabIndex = 11;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(485, 93);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 12;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(485, 117);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.MaxLength = 45;
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "(Opcional)";
            txtEmail.Size = new Size(349, 27);
            txtEmail.TabIndex = 13;
            // 
            // lblCalle
            // 
            lblCalle.AutoSize = true;
            lblCalle.Location = new Point(14, 167);
            lblCalle.Name = "lblCalle";
            lblCalle.Size = new Size(45, 20);
            lblCalle.TabIndex = 14;
            lblCalle.Text = "Calle:";
            // 
            // txtCalle
            // 
            txtCalle.Location = new Point(14, 191);
            txtCalle.Margin = new Padding(3, 4, 3, 4);
            txtCalle.MaxLength = 45;
            txtCalle.Name = "txtCalle";
            txtCalle.PlaceholderText = "(Opcional)";
            txtCalle.Size = new Size(228, 27);
            txtCalle.TabIndex = 15;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Location = new Point(249, 167);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(59, 20);
            lblCiudad.TabIndex = 16;
            lblCiudad.Text = "Ciudad:";
            // 
            // txtCiudad
            // 
            txtCiudad.Location = new Point(249, 191);
            txtCiudad.Margin = new Padding(3, 4, 3, 4);
            txtCiudad.MaxLength = 45;
            txtCiudad.Name = "txtCiudad";
            txtCiudad.PlaceholderText = "(Opcional)";
            txtCiudad.Size = new Size(228, 27);
            txtCiudad.TabIndex = 17;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuardar.Location = new Point(656, 254);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(86, 40);
            btnGuardar.TabIndex = 20;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnDescartar
            // 
            btnDescartar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDescartar.Location = new Point(748, 254);
            btnDescartar.Margin = new Padding(3, 4, 3, 4);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(86, 40);
            btnDescartar.TabIndex = 21;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // AgregarEditarProveedorForm
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnDescartar;
            ClientSize = new Size(848, 305);
            Controls.Add(btnDescartar);
            Controls.Add(btnGuardar);
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
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AgregarEditarProveedorForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Agregar Proveedor";
            FormClosing += AgregarEditarProveedorForm_FormClosing;
            Load += AgregarEditarProveedorForm_Load;
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
        private Button btnGuardar;
        private Button btnDescartar;
    }
}
