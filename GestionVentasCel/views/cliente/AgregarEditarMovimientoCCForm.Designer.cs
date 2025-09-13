namespace GestionVentasCel.views.usuario_empleado
{
    partial class AgregarEditarMovimientoCCForm
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
            label4 = new Label();
            label9 = new Label();
            comboTipoMov = new ComboBox();
            label1 = new Label();
            panel1 = new Panel();
            nMonto = new NumericUpDown();
            panel2 = new Panel();
            dtpFecha = new DateTimePicker();
            panel3 = new Panel();
            panel8 = new Panel();
            panel11 = new Panel();
            panel4 = new Panel();
            txtDescripcion = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nMonto).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel8.SuspendLayout();
            panel11.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Verdana", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(975, 44);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Agregar Movimiento";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDescartar
            // 
            btnDescartar.Location = new Point(0, 4);
            btnDescartar.Margin = new Padding(4);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(244, 48);
            btnDescartar.TabIndex = 9;
            btnDescartar.Text = "Descartar";
            btnDescartar.UseVisualStyleBackColor = true;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(252, 4);
            btnGuardar.Margin = new Padding(4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(244, 48);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 14;
            label4.Text = "Monto";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Top;
            label9.Location = new Point(0, 0);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(173, 25);
            label9.TabIndex = 19;
            label9.Text = "Tipo de Movimiento";
            // 
            // comboTipoMov
            // 
            comboTipoMov.Dock = DockStyle.Bottom;
            comboTipoMov.FormattingEnabled = true;
            comboTipoMov.Location = new Point(0, 29);
            comboTipoMov.Margin = new Padding(4);
            comboTipoMov.Name = "comboTipoMov";
            comboTipoMov.Size = new Size(300, 33);
            comboTipoMov.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(57, 25);
            label1.TabIndex = 21;
            label1.Text = "Fecha";
            // 
            // panel1
            // 
            panel1.Controls.Add(nMonto);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(10, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 62);
            panel1.TabIndex = 0;
            // 
            // nMonto
            // 
            nMonto.DecimalPlaces = 2;
            nMonto.Dock = DockStyle.Bottom;
            nMonto.Location = new Point(0, 31);
            nMonto.Maximum = new decimal(new int[] { -1486618625, 232830643, 0, 0 });
            nMonto.Name = "nMonto";
            nMonto.Size = new Size(300, 31);
            nMonto.TabIndex = 15;
            nMonto.ThousandsSeparator = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(dtpFecha);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(660, 30);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 62);
            panel2.TabIndex = 4;
            // 
            // dtpFecha
            // 
            dtpFecha.Dock = DockStyle.Bottom;
            dtpFecha.Location = new Point(0, 31);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(300, 31);
            dtpFecha.TabIndex = 22;
            // 
            // panel3
            // 
            panel3.Controls.Add(label9);
            panel3.Controls.Add(comboTipoMov);
            panel3.Location = new Point(332, 30);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 62);
            panel3.TabIndex = 2;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel8.Controls.Add(btnDescartar);
            panel8.Controls.Add(btnGuardar);
            panel8.Location = new Point(461, 429);
            panel8.Name = "panel8";
            panel8.Size = new Size(500, 57);
            panel8.TabIndex = 30;
            // 
            // panel11
            // 
            panel11.Controls.Add(panel4);
            panel11.Controls.Add(panel3);
            panel11.Controls.Add(panel2);
            panel11.Controls.Add(panel1);
            panel11.Dock = DockStyle.Top;
            panel11.Location = new Point(0, 44);
            panel11.Name = "panel11";
            panel11.Size = new Size(975, 301);
            panel11.TabIndex = 33;
            // 
            // panel4
            // 
            panel4.Controls.Add(txtDescripcion);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(10, 114);
            panel4.Name = "panel4";
            panel4.Size = new Size(953, 133);
            panel4.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Dock = DockStyle.Bottom;
            txtDescripcion.Location = new Point(0, 28);
            txtDescripcion.MaxLength = 255;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(953, 105);
            txtDescripcion.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(104, 25);
            label2.TabIndex = 14;
            label2.Text = "Descripción";
            // 
            // AgregarEditarMovimientoCCForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 498);
            Controls.Add(panel11);
            Controls.Add(lblTitulo);
            Controls.Add(panel8);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AgregarEditarMovimientoCCForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += AgregarEditarMovimientoCCForm_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nMonto).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel8.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Button button1;
        private Button btnDescartar;
        private Button btnGuardar;
        private TextBox txtNombre;
        private Label label4;
        private Label label9;
        private ComboBox comboTipoMov;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel8;
        private Panel panel11;
        private DateTimePicker dtpFecha;
        private NumericUpDown nMonto;
        private Panel panel4;
        private TextBox txtDescripcion;
        private Label label2;
    }
}