namespace GestionVentasCel.views.ejemplo
{
    partial class EjemploPermisosForm
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
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.btnReparaciones = new System.Windows.Forms.Button();
            this.lblUsuarioActual = new System.Windows.Forms.Label();
            this.lblRolActual = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(50, 100);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.TabIndex = 0;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(200, 100);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 30);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Location = new System.Drawing.Point(350, 100);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(100, 30);
            this.btnConfiguracion.TabIndex = 2;
            this.btnConfiguracion.Text = "Configuración";
            this.btnConfiguracion.UseVisualStyleBackColor = true;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // btnReparaciones
            // 
            this.btnReparaciones.Location = new System.Drawing.Point(500, 100);
            this.btnReparaciones.Name = "btnReparaciones";
            this.btnReparaciones.Size = new System.Drawing.Size(100, 30);
            this.btnReparaciones.TabIndex = 3;
            this.btnReparaciones.Text = "Reparaciones";
            this.btnReparaciones.UseVisualStyleBackColor = true;
            this.btnReparaciones.Click += new System.EventHandler(this.btnReparaciones_Click);
            // 
            // lblUsuarioActual
            // 
            this.lblUsuarioActual.AutoSize = true;
            this.lblUsuarioActual.Location = new System.Drawing.Point(50, 50);
            this.lblUsuarioActual.Name = "lblUsuarioActual";
            this.lblUsuarioActual.Size = new System.Drawing.Size(50, 15);
            this.lblUsuarioActual.TabIndex = 4;
            this.lblUsuarioActual.Text = "Usuario:";
            // 
            // lblRolActual
            // 
            this.lblRolActual.AutoSize = true;
            this.lblRolActual.Location = new System.Drawing.Point(200, 50);
            this.lblRolActual.Name = "lblRolActual";
            this.lblRolActual.Size = new System.Drawing.Size(30, 15);
            this.lblRolActual.TabIndex = 5;
            this.lblRolActual.Text = "Rol:";
            // 
            // EjemploPermisosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 200);
            this.Controls.Add(this.lblRolActual);
            this.Controls.Add(this.lblUsuarioActual);
            this.Controls.Add(this.btnReparaciones);
            this.Controls.Add(this.btnConfiguracion);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Name = "EjemploPermisosForm";
            this.Text = "Ejemplo de Sistema de Permisos";
            this.Load += new System.EventHandler(this.EjemploPermisosForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Button btnReparaciones;
        private System.Windows.Forms.Label lblUsuarioActual;
        private System.Windows.Forms.Label lblRolActual;
    }
}
