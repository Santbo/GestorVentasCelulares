namespace GestionVentasCel.views.caja
{
    partial class VerMovimientosForm
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
            panel1 = new Panel();
            lblRetiro = new Label();
            label7 = new Label();
            lblTotales = new Label();
            lblBv = new Label();
            lblCredito = new Label();
            lblDebito = new Label();
            lblTransferencia = new Label();
            lblEfectivo = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnSalir = new Button();
            dgvListar = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListar).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(lblRetiro);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(lblTotales);
            panel1.Controls.Add(lblBv);
            panel1.Controls.Add(lblCredito);
            panel1.Controls.Add(lblDebito);
            panel1.Controls.Add(lblTransferencia);
            panel1.Controls.Add(lblEfectivo);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnSalir);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 339);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 135);
            panel1.TabIndex = 0;
            // 
            // lblRetiro
            // 
            lblRetiro.AutoSize = true;
            lblRetiro.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRetiro.Location = new Point(453, 90);
            lblRetiro.Name = "lblRetiro";
            lblRetiro.Size = new Size(0, 23);
            lblRetiro.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(319, 88);
            label7.Name = "label7";
            label7.Size = new Size(128, 23);
            label7.TabIndex = 13;
            label7.Text = "Total Retirado:";
            // 
            // lblTotales
            // 
            lblTotales.AutoSize = true;
            lblTotales.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotales.Location = new Point(682, 98);
            lblTotales.Name = "lblTotales";
            lblTotales.Size = new Size(0, 28);
            lblTotales.TabIndex = 12;
            // 
            // lblBv
            // 
            lblBv.AutoSize = true;
            lblBv.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBv.Location = new Point(505, 17);
            lblBv.Name = "lblBv";
            lblBv.Size = new Size(0, 23);
            lblBv.TabIndex = 11;
            // 
            // lblCredito
            // 
            lblCredito.AutoSize = true;
            lblCredito.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCredito.Location = new Point(444, 54);
            lblCredito.Name = "lblCredito";
            lblCredito.Size = new Size(0, 23);
            lblCredito.TabIndex = 10;
            // 
            // lblDebito
            // 
            lblDebito.AutoSize = true;
            lblDebito.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDebito.Location = new Point(132, 90);
            lblDebito.Name = "lblDebito";
            lblDebito.Size = new Size(0, 23);
            lblDebito.TabIndex = 9;
            // 
            // lblTransferencia
            // 
            lblTransferencia.AutoSize = true;
            lblTransferencia.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTransferencia.Location = new Point(183, 55);
            lblTransferencia.Name = "lblTransferencia";
            lblTransferencia.Size = new Size(0, 23);
            lblTransferencia.TabIndex = 8;
            // 
            // lblEfectivo
            // 
            lblEfectivo.AutoSize = true;
            lblEfectivo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEfectivo.Location = new Point(141, 15);
            lblEfectivo.Name = "lblEfectivo";
            lblEfectivo.Size = new Size(0, 23);
            lblEfectivo.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(592, 98);
            label6.Name = "label6";
            label6.Size = new Size(84, 28);
            label6.TabIndex = 6;
            label6.Text = "Totales:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 88);
            label5.Name = "label5";
            label5.Size = new Size(114, 23);
            label5.TabIndex = 5;
            label5.Text = "Total Debito:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(319, 52);
            label4.Name = "label4";
            label4.Size = new Size(119, 23);
            label4.TabIndex = 4;
            label4.Text = "Total Credito:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(319, 15);
            label3.Name = "label3";
            label3.Size = new Size(185, 23);
            label3.TabIndex = 3;
            label3.Text = "Total Billetera Virtual:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(165, 23);
            label2.TabIndex = 2;
            label2.Text = "Total Transferencia:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(123, 23);
            label1.TabIndex = 1;
            label1.Text = "Total Efectivo:";
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(700, 9);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(88, 37);
            btnSalir.TabIndex = 0;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // dgvListar
            // 
            dgvListar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListar.BackgroundColor = SystemColors.Control;
            dgvListar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListar.Dock = DockStyle.Fill;
            dgvListar.Location = new Point(0, 0);
            dgvListar.Name = "dgvListar";
            dgvListar.RowHeadersWidth = 51;
            dgvListar.Size = new Size(800, 339);
            dgvListar.TabIndex = 1;
            // 
            // VerMovimientosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 474);
            Controls.Add(dgvListar);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "VerMovimientosForm";
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnSalir;
        private DataGridView dgvListar;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label lblTotales;
        private Label lblBv;
        private Label lblCredito;
        private Label lblDebito;
        private Label lblTransferencia;
        private Label lblEfectivo;
        private Label label6;
        private Label label5;
        private Label lblRetiro;
        private Label label7;
    }
}