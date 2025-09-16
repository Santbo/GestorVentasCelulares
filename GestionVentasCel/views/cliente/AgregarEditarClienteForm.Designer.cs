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
            lblTitulo = new Label();
            btnDescartar = new Button();
            btnGuardar = new Button();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtTelefono = new TextBox();
            txtDni = new TextBox();
            txtEmail = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            comboTipoDoc = new ComboBox();
            comboIVA = new ComboBox();
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            panel9 = new Panel();
            label2 = new Label();
            txtCalle = new TextBox();
            panel10 = new Panel();
            label3 = new Label();
            txtCiudad = new TextBox();
            panel11 = new Panel();
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
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Verdana", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(780, 35);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Agregar Cliente";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
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
            txtNombre.Location = new Point(0, 23);
            txtNombre.MaxLength = 45;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(240, 27);
            txtNombre.TabIndex = 0;
            txtNombre.KeyPress += txtNombre_KeyPress;
            // 
            // txtApellido
            // 
            txtApellido.Dock = DockStyle.Bottom;
            txtApellido.Location = new Point(0, 23);
            txtApellido.MaxLength = 45;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(240, 27);
            txtApellido.TabIndex = 1;
            txtApellido.KeyPress += txtNombre_KeyPress;
            // 
            // txtTelefono
            // 
            txtTelefono.Dock = DockStyle.Bottom;
            txtTelefono.Location = new Point(0, 23);
            txtTelefono.MaxLength = 14;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(240, 27);
            txtTelefono.TabIndex = 5;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // txtDni
            // 
            txtDni.Dock = DockStyle.Bottom;
            txtDni.Location = new Point(0, 23);
            txtDni.MaxLength = 13;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(240, 27);
            txtDni.TabIndex = 3;
            txtDni.KeyPress += txtDni_KeyPress;
            // 
            // txtEmail
            // 
            txtEmail.Dock = DockStyle.Bottom;
            txtEmail.Location = new Point(0, 23);
            txtEmail.MaxLength = 50;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(240, 27);
            txtEmail.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(157, 20);
            label4.TabIndex = 14;
            label4.Text = "Nombre / razón social";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Top;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 15;
            label5.Text = "Apellido";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Top;
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 16;
            label6.Text = "Teléfono";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Top;
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(164, 20);
            label7.TabIndex = 17;
            label7.Text = "Número de documento";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Top;
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(46, 20);
            label8.TabIndex = 18;
            label8.Text = "Email";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Top;
            label9.Location = new Point(0, 0);
            label9.Name = "label9";
            label9.Size = new Size(142, 20);
            label9.TabIndex = 19;
            label9.Text = "Tipo de Documento";
            // 
            // comboTipoDoc
            // 
            comboTipoDoc.Dock = DockStyle.Bottom;
            comboTipoDoc.FormattingEnabled = true;
            comboTipoDoc.Location = new Point(0, 22);
            comboTipoDoc.Name = "comboTipoDoc";
            comboTipoDoc.Size = new Size(240, 28);
            comboTipoDoc.TabIndex = 2;
            // 
            // comboIVA
            // 
            comboIVA.Dock = DockStyle.Bottom;
            comboIVA.FormattingEnabled = true;
            comboIVA.Location = new Point(0, 22);
            comboIVA.Name = "comboIVA";
            comboIVA.Size = new Size(240, 28);
            comboIVA.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(157, 20);
            label1.TabIndex = 21;
            label1.Text = "Condición frente a IVA";
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtNombre);
            panel1.Location = new Point(8, 24);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(240, 50);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(comboIVA);
            panel2.Location = new Point(528, 24);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(240, 50);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.Controls.Add(label9);
            panel3.Controls.Add(comboTipoDoc);
            panel3.Location = new Point(266, 24);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(240, 50);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Controls.Add(label8);
            panel4.Controls.Add(txtEmail);
            panel4.Location = new Point(8, 190);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Size = new Size(240, 50);
            panel4.TabIndex = 6;
            // 
            // panel5
            // 
            panel5.Controls.Add(label5);
            panel5.Controls.Add(txtApellido);
            panel5.Location = new Point(8, 106);
            panel5.Margin = new Padding(2);
            panel5.Name = "panel5";
            panel5.Size = new Size(240, 50);
            panel5.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.Controls.Add(label6);
            panel6.Controls.Add(txtTelefono);
            panel6.Location = new Point(528, 106);
            panel6.Margin = new Padding(2);
            panel6.Name = "panel6";
            panel6.Size = new Size(240, 50);
            panel6.TabIndex = 5;
            // 
            // panel7
            // 
            panel7.Controls.Add(label7);
            panel7.Controls.Add(txtDni);
            panel7.Location = new Point(266, 106);
            panel7.Margin = new Padding(2);
            panel7.Name = "panel7";
            panel7.Size = new Size(240, 50);
            panel7.TabIndex = 3;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel8.Controls.Add(btnDescartar);
            panel8.Controls.Add(btnGuardar);
            panel8.Location = new Point(369, 394);
            panel8.Margin = new Padding(2);
            panel8.Name = "panel8";
            panel8.Size = new Size(400, 46);
            panel8.TabIndex = 30;
            // 
            // panel9
            // 
            panel9.Controls.Add(label2);
            panel9.Controls.Add(txtCalle);
            panel9.Location = new Point(266, 190);
            panel9.Margin = new Padding(2);
            panel9.Name = "panel9";
            panel9.Size = new Size(240, 50);
            panel9.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 18;
            label2.Text = "Calle";
            // 
            // txtCalle
            // 
            txtCalle.Dock = DockStyle.Bottom;
            txtCalle.Location = new Point(0, 23);
            txtCalle.MaxLength = 50;
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(240, 27);
            txtCalle.TabIndex = 7;
            // 
            // panel10
            // 
            panel10.Controls.Add(label3);
            panel10.Controls.Add(txtCiudad);
            panel10.Location = new Point(528, 190);
            panel10.Margin = new Padding(2);
            panel10.Name = "panel10";
            panel10.Size = new Size(240, 50);
            panel10.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 18;
            label3.Text = "Ciudad";
            // 
            // txtCiudad
            // 
            txtCiudad.Dock = DockStyle.Bottom;
            txtCiudad.Location = new Point(0, 23);
            txtCiudad.MaxLength = 50;
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(240, 27);
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
            panel11.Dock = DockStyle.Top;
            panel11.Location = new Point(0, 35);
            panel11.Margin = new Padding(2);
            panel11.Name = "panel11";
            panel11.Size = new Size(780, 330);
            panel11.TabIndex = 33;
            // 
            // AgregarEditarClienteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 450);
            Controls.Add(panel11);
            Controls.Add(lblTitulo);
            Controls.Add(panel8);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AgregarEditarClienteForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += AgregarEditarEmpleadoForm_FormClosing;
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

        private Label lblTitulo;
        private Button button1;
        private Button btnDescartar;
        private Button btnGuardar;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtTelefono;
        private TextBox txtDni;
        private TextBox txtEmail;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private ComboBox comboTipoDoc;
        private ComboBox comboIVA;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Label label2;
        private TextBox txtCalle;
        private Panel panel10;
        private Label label3;
        private TextBox txtCiudad;
        private Panel panel11;
    }
}