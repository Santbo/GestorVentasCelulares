namespace GestionVentasCel.views.reparacion
{
    partial class AgregarEditarDispositivoForm
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
            txtNombre = new TextBox();
            lblTitulo = new Label();
            lblNombre = new Label();
            label2 = new Label();
            txtCliente = new TextBox();
            btnGuardar = new Button();
            btnDescartar = new Button();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(35, 155);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(203, 27);
            txtNombre.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(259, 38);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Agregar Dispositivo";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(35, 132);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(142, 20);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre Dispositivo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 67);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 3;
            label2.Text = "Cliente";
            // 
            // txtCliente
            // 
            txtCliente.Enabled = false;
            txtCliente.Location = new Point(35, 90);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(203, 27);
            txtCliente.TabIndex = 4;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(153, 211);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(118, 48);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnDescartar
            // 
            btnDescartar.Location = new Point(7, 211);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(118, 48);
            btnDescartar.TabIndex = 6;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // AgregarEditarDispositivoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 271);
            Controls.Add(btnDescartar);
            Controls.Add(btnGuardar);
            Controls.Add(txtCliente);
            Controls.Add(label2);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            Controls.Add(txtNombre);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AgregarEditarDispositivoForm";
            FormClosing += AgregarEditarDispositivoForm_FormClosing;
            Load += AgregarEditarDispositivoForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private Label lblTitulo;
        private Label lblNombre;
        private Label label2;
        private TextBox txtCliente;
        private Button btnGuardar;
        private Button btnDescartar;
    }
}