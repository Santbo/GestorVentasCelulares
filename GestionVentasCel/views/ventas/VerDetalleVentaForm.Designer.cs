namespace GestionVentasCel.views.ventas
{
    partial class VerDetalleVentaForm
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
            Panel panel1;
            Panel panel4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerDetalleVentaForm));
            lblValorCliente = new Label();
            lblCliente = new Label();
            lblValorFecha = new Label();
            lblFecha = new Label();
            imageList1 = new ImageList(components);
            btnSalir = new Button();
            lblTituloForm = new Label();
            panel8 = new Panel();
            btnOk = new Button();
            panel2 = new Panel();
            lblValorTipoPago = new Label();
            lblTipoPago = new Label();
            dgvListarDetalles = new DataGridView();
            panel3 = new Panel();
            panel11 = new Panel();
            lblTotal = new Label();
            lblTotalIVA = new Label();
            lblSubtotalSinIVA = new Label();
            panel1 = new Panel();
            panel4 = new Panel();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel8.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarDetalles).BeginInit();
            panel3.SuspendLayout();
            panel11.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblValorCliente);
            panel1.Controls.Add(lblCliente);
            panel1.Location = new Point(12, 80);
            panel1.Name = "panel1";
            panel1.Size = new Size(718, 68);
            panel1.TabIndex = 0;
            // 
            // lblValorCliente
            // 
            lblValorCliente.AutoSize = true;
            lblValorCliente.Dock = DockStyle.Bottom;
            lblValorCliente.Font = new Font("Segoe UI", 12F);
            lblValorCliente.Location = new Point(0, 36);
            lblValorCliente.Name = "lblValorCliente";
            lblValorCliente.Size = new Size(78, 32);
            lblValorCliente.TabIndex = 1;
            lblValorCliente.Text = "label1";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Dock = DockStyle.Top;
            lblCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCliente.Location = new Point(0, 0);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(71, 25);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente";
            // 
            // panel4
            // 
            panel4.Controls.Add(lblValorFecha);
            panel4.Controls.Add(lblFecha);
            panel4.Location = new Point(1132, 80);
            panel4.Name = "panel4";
            panel4.Size = new Size(300, 68);
            panel4.TabIndex = 100003;
            // 
            // lblValorFecha
            // 
            lblValorFecha.AutoSize = true;
            lblValorFecha.Dock = DockStyle.Bottom;
            lblValorFecha.Font = new Font("Segoe UI", 12F);
            lblValorFecha.Location = new Point(0, 36);
            lblValorFecha.Name = "lblValorFecha";
            lblValorFecha.Size = new Size(78, 32);
            lblValorFecha.TabIndex = 1;
            lblValorFecha.Text = "label1";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Dock = DockStyle.Top;
            lblFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFecha.Location = new Point(0, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(61, 25);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fecha";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "xmark-solid-full.png");
            imageList1.Images.SetKeyName(1, "plus-solid.png");
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
            btnSalir.Location = new Point(1404, 12);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(32, 32);
            btnSalir.TabIndex = 38;
            btnSalir.TabStop = false;
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblTituloForm
            // 
            lblTituloForm.Dock = DockStyle.Top;
            lblTituloForm.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloForm.Location = new Point(0, 0);
            lblTituloForm.Margin = new Padding(4, 0, 4, 0);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Padding = new Padding(9, 0, 9, 0);
            lblTituloForm.Size = new Size(1448, 77);
            lblTituloForm.TabIndex = 99999;
            lblTituloForm.Text = "Agregar venta";
            lblTituloForm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel8.Controls.Add(btnOk);
            panel8.Location = new Point(1036, 728);
            panel8.Margin = new Padding(2);
            panel8.Name = "panel8";
            panel8.Size = new Size(400, 46);
            panel8.TabIndex = 3;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(202, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(195, 38);
            btnOk.TabIndex = 1;
            btnOk.Text = "Aceptar";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblValorTipoPago);
            panel2.Controls.Add(lblTipoPago);
            panel2.Location = new Point(781, 80);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 68);
            panel2.TabIndex = 1;
            // 
            // lblValorTipoPago
            // 
            lblValorTipoPago.AutoSize = true;
            lblValorTipoPago.Dock = DockStyle.Bottom;
            lblValorTipoPago.Font = new Font("Segoe UI", 12F);
            lblValorTipoPago.Location = new Point(0, 36);
            lblValorTipoPago.Name = "lblValorTipoPago";
            lblValorTipoPago.Size = new Size(78, 32);
            lblValorTipoPago.TabIndex = 1;
            lblValorTipoPago.Text = "label1";
            // 
            // lblTipoPago
            // 
            lblTipoPago.AutoSize = true;
            lblTipoPago.Dock = DockStyle.Top;
            lblTipoPago.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTipoPago.Location = new Point(0, 0);
            lblTipoPago.Name = "lblTipoPago";
            lblTipoPago.Size = new Size(124, 25);
            lblTipoPago.TabIndex = 0;
            lblTipoPago.Text = "Tipo de pago";
            // 
            // dgvListarDetalles
            // 
            dgvListarDetalles.AllowUserToAddRows = false;
            dgvListarDetalles.AllowUserToDeleteRows = false;
            dgvListarDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListarDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListarDetalles.Dock = DockStyle.Bottom;
            dgvListarDetalles.Location = new Point(0, 0);
            dgvListarDetalles.Margin = new Padding(4);
            dgvListarDetalles.Name = "dgvListarDetalles";
            dgvListarDetalles.ReadOnly = true;
            dgvListarDetalles.RowHeadersWidth = 51;
            dgvListarDetalles.Size = new Size(1421, 491);
            dgvListarDetalles.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(dgvListarDetalles);
            panel3.Location = new Point(12, 165);
            panel3.Name = "panel3";
            panel3.Size = new Size(1421, 491);
            panel3.TabIndex = 2;
            // 
            // panel11
            // 
            panel11.Controls.Add(lblTotal);
            panel11.Controls.Add(lblTotalIVA);
            panel11.Controls.Add(lblSubtotalSinIVA);
            panel11.Location = new Point(666, 661);
            panel11.Name = "panel11";
            panel11.Size = new Size(766, 62);
            panel11.TabIndex = 100004;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(580, 16);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(59, 25);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total:";
            // 
            // lblTotalIVA
            // 
            lblTotalIVA.AutoSize = true;
            lblTotalIVA.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalIVA.Location = new Point(322, 16);
            lblTotalIVA.Name = "lblTotalIVA";
            lblTotalIVA.Size = new Size(97, 25);
            lblTotalIVA.TabIndex = 1;
            lblTotalIVA.Text = "IVA total: ";
            // 
            // lblSubtotalSinIVA
            // 
            lblSubtotalSinIVA.AutoSize = true;
            lblSubtotalSinIVA.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtotalSinIVA.Location = new Point(3, 16);
            lblSubtotalSinIVA.Name = "lblSubtotalSinIVA";
            lblSubtotalSinIVA.Size = new Size(158, 25);
            lblSubtotalSinIVA.TabIndex = 0;
            lblSubtotalSinIVA.Text = "Subtotal sin IVA: ";
            // 
            // VerDetalleVentaForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1448, 785);
            Controls.Add(panel11);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnSalir);
            Controls.Add(lblTituloForm);
            Controls.Add(panel8);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VerDetalleVentaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AgregarEditarVentaForm";
            Load += AgregarEditarVentaForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel8.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListarDetalles).EndInit();
            panel3.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalir;
        private Label lblTituloForm;
        private Panel panel8;
        private Button btnOk;
        private ImageList imageList1;
        private Label lblCliente;
        private Panel panel2;
        private Label lblTipoPago;
        private DataGridView dgvListarDetalles;
        private Panel panel3;
        private Panel panel4;
        private Label lblFecha;
        private Panel panel11;
        private Label lblSubtotalSinIVA;
        private Label lblTotalIVA;
        private Label lblTotal;
        private Label lblValorCliente;
        private Label lblValorTipoPago;
        private Label lblValorFecha;
    }
}