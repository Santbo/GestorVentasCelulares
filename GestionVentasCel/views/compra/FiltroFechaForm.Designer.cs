namespace GestionVentasCel.views.compra
{
    partial class FiltroFechaForm
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
            lblFechaDesde = new Label();
            dtpFechaDesde = new DateTimePicker();
            lblFechaHasta = new Label();
            dtpFechaHasta = new DateTimePicker();
            btnFiltrar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblFechaDesde
            // 
            lblFechaDesde.AutoSize = true;
            lblFechaDesde.Location = new Point(12, 15);
            lblFechaDesde.Name = "lblFechaDesde";
            lblFechaDesde.Size = new Size(76, 15);
            lblFechaDesde.TabIndex = 0;
            lblFechaDesde.Text = "Fecha desde:";
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Location = new Point(12, 33);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(200, 23);
            dtpFechaDesde.TabIndex = 1;
            // 
            // lblFechaHasta
            // 
            lblFechaHasta.AutoSize = true;
            lblFechaHasta.Location = new Point(12, 70);
            lblFechaHasta.Name = "lblFechaHasta";
            lblFechaHasta.Size = new Size(74, 15);
            lblFechaHasta.TabIndex = 2;
            lblFechaHasta.Text = "Fecha hasta:";
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Location = new Point(12, 88);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(200, 23);
            dtpFechaHasta.TabIndex = 3;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(12, 130);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(75, 30);
            btnFiltrar.TabIndex = 4;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(137, 130);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 30);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FiltroFechaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(224, 172);
            Controls.Add(btnCancelar);
            Controls.Add(btnFiltrar);
            Controls.Add(dtpFechaHasta);
            Controls.Add(lblFechaHasta);
            Controls.Add(dtpFechaDesde);
            Controls.Add(lblFechaDesde);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FiltroFechaForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Filtrar por Fecha";
            ResumeLayout(false);
            PerformLayout();
        }

          

        private Label lblFechaDesde;
        private DateTimePicker dtpFechaDesde;
        private Label lblFechaHasta;
        private DateTimePicker dtpFechaHasta;
        private Button btnFiltrar;
        private Button btnCancelar;
    }
}
