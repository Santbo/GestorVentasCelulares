namespace GestionVentasCel
{
    partial class MainMenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            UsuarioMenuItem = new ToolStripMenuItem();
            gestionarArticulosToolStripMenuItem = new ToolStripMenuItem();
            categoriasMenuItem = new ToolStripMenuItem();
            ArticulosMenuItem = new ToolStripMenuItem();
            gestionarProveedoresToolStripMenuItem = new ToolStripMenuItem();
            proveedoresMenuItem = new ToolStripMenuItem();
            comprasMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            gestionarClientesToolStripMenuItem = new ToolStripMenuItem();
            gestionarCuentasCorrientesToolStripMenuItem = new ToolStripMenuItem();
            panelContenedor = new Panel();
            aumentarMargenMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveCaption;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { UsuarioMenuItem, gestionarArticulosToolStripMenuItem, gestionarProveedoresToolStripMenuItem, clientesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // UsuarioMenuItem
            // 
            UsuarioMenuItem.Name = "UsuarioMenuItem";
            UsuarioMenuItem.Size = new Size(97, 24);
            UsuarioMenuItem.Text = "Empleados";
            UsuarioMenuItem.Click += UsuarioMenuItem_Click;
            // 
            // gestionarArticulosToolStripMenuItem
            // 
            gestionarArticulosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { categoriasMenuItem, ArticulosMenuItem });
            gestionarArticulosToolStripMenuItem.Name = "gestionarArticulosToolStripMenuItem";
            gestionarArticulosToolStripMenuItem.Size = new Size(148, 24);
            gestionarArticulosToolStripMenuItem.Text = "Gestionar Articulos";
            // 
            // categoriasMenuItem
            // 
            categoriasMenuItem.Name = "categoriasMenuItem";
            categoriasMenuItem.Size = new Size(163, 26);
            categoriasMenuItem.Text = "Categorias";
            categoriasMenuItem.Click += categoriasMenuItem_Click;
            // 
            // ArticulosMenuItem
            // 
            ArticulosMenuItem.Name = "ArticulosMenuItem";
            ArticulosMenuItem.Size = new Size(163, 26);
            ArticulosMenuItem.Text = "Articulos";
            ArticulosMenuItem.Click += ArticulosMenuItem_Click;
            // 
            // gestionarProveedoresToolStripMenuItem
            // 
            gestionarProveedoresToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { proveedoresMenuItem, comprasMenuItem, aumentarMargenMenuItem });
            gestionarProveedoresToolStripMenuItem.Name = "gestionarProveedoresToolStripMenuItem";
            gestionarProveedoresToolStripMenuItem.Size = new Size(172, 24);
            gestionarProveedoresToolStripMenuItem.Text = "Gestionar Proveedores";
            // 
            // proveedoresMenuItem
            // 
            proveedoresMenuItem.Name = "proveedoresMenuItem";
            proveedoresMenuItem.Size = new Size(224, 26);
            proveedoresMenuItem.Text = "Proveedores";
            proveedoresMenuItem.Click += proveedoresMenuItem_Click;
            // 
            // comprasMenuItem
            // 
            comprasMenuItem.Name = "comprasMenuItem";
            comprasMenuItem.Size = new Size(224, 26);
            comprasMenuItem.Text = "Compras";
            comprasMenuItem.Click += comprasMenuItem_Click;
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionarClientesToolStripMenuItem, gestionarCuentasCorrientesToolStripMenuItem });
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(75, 24);
            clientesToolStripMenuItem.Text = "Clientes";
            // 
            // gestionarClientesToolStripMenuItem
            // 
            gestionarClientesToolStripMenuItem.Name = "gestionarClientesToolStripMenuItem";
            gestionarClientesToolStripMenuItem.Size = new Size(282, 26);
            gestionarClientesToolStripMenuItem.Text = "Gestionar Clientes";
            gestionarClientesToolStripMenuItem.Click += gestionarClientesToolStripMenuItem_Click;
            // 
            // gestionarCuentasCorrientesToolStripMenuItem
            // 
            gestionarCuentasCorrientesToolStripMenuItem.Name = "gestionarCuentasCorrientesToolStripMenuItem";
            gestionarCuentasCorrientesToolStripMenuItem.Size = new Size(282, 26);
            gestionarCuentasCorrientesToolStripMenuItem.Text = "Gestionar Cuentas Corrientes";
            gestionarCuentasCorrientesToolStripMenuItem.Click += gestionarCuentasCorrientesToolStripMenuItem_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 28);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(800, 422);
            panelContenedor.TabIndex = 1;
            // 
            // aumentarMargenMenuItem
            // 
            aumentarMargenMenuItem.Name = "aumentarMargenMenuItem";
            aumentarMargenMenuItem.Size = new Size(224, 26);
            aumentarMargenMenuItem.Text = "Aumentar Margen";
            aumentarMargenMenuItem.Click += aumentarMargenMenuItem_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContenedor);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainMenuForm";
            WindowState = FormWindowState.Maximized;
            FormClosing += MainMenuForm_FormClosing;
            Load += MainMenuForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        private MenuStrip menuStrip1;
        private ToolStripMenuItem UsuarioMenuItem;
        private Panel panelContenedor;
        private ToolStripMenuItem gestionarArticulosToolStripMenuItem;
        private ToolStripMenuItem categoriasMenuItem;
        private ToolStripMenuItem ArticulosMenuItem;
        private ToolStripMenuItem gestionarProveedoresToolStripMenuItem;
        private ToolStripMenuItem proveedoresMenuItem;
        private ToolStripMenuItem comprasMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem gestionarClientesToolStripMenuItem;
        private ToolStripMenuItem gestionarCuentasCorrientesToolStripMenuItem;
        private ToolStripMenuItem aumentarMargenMenuItem;
    }
}
