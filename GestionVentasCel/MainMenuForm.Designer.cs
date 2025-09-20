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
            clientesToolStripMenuItem = new ToolStripMenuItem();
            gestionarClientesToolStripMenuItem = new ToolStripMenuItem();
            gestionarCuentasCorrientesToolStripMenuItem = new ToolStripMenuItem();
            gestionarProveedoresToolStripMenuItem = new ToolStripMenuItem();
            proveedoresMenuItem = new ToolStripMenuItem();
            comprasMenuItem = new ToolStripMenuItem();
            aumentarMargenMenuItem = new ToolStripMenuItem();
            panelContenedor = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveCaption;
            menuStrip1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { UsuarioMenuItem, gestionarArticulosToolStripMenuItem, clientesToolStripMenuItem, gestionarProveedoresToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(10, 5, 0, 5);
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(1000, 44);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // UsuarioMenuItem
            // 
            UsuarioMenuItem.Name = "UsuarioMenuItem";
            UsuarioMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            UsuarioMenuItem.Size = new Size(135, 34);
            UsuarioMenuItem.Text = "&Empleados";
            UsuarioMenuItem.Click += UsuarioMenuItem_Click;
            // 
            // gestionarArticulosToolStripMenuItem
            // 
            gestionarArticulosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { categoriasMenuItem, ArticulosMenuItem });
            gestionarArticulosToolStripMenuItem.Name = "gestionarArticulosToolStripMenuItem";
            gestionarArticulosToolStripMenuItem.Size = new Size(126, 34);
            gestionarArticulosToolStripMenuItem.Text = "&Inventario";
            // 
            // categoriasMenuItem
            // 
            categoriasMenuItem.Name = "categoriasMenuItem";
            categoriasMenuItem.Size = new Size(219, 38);
            categoriasMenuItem.Text = "&Categorias";
            categoriasMenuItem.Click += categoriasMenuItem_Click;
            // 
            // ArticulosMenuItem
            // 
            ArticulosMenuItem.Name = "ArticulosMenuItem";
            ArticulosMenuItem.Size = new Size(219, 38);
            ArticulosMenuItem.Text = "&Articulos";
            ArticulosMenuItem.Click += ArticulosMenuItem_Click;
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionarClientesToolStripMenuItem, gestionarCuentasCorrientesToolStripMenuItem });
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(105, 34);
            clientesToolStripMenuItem.Text = "&Clientes";
            // 
            // gestionarClientesToolStripMenuItem
            // 
            gestionarClientesToolStripMenuItem.Name = "gestionarClientesToolStripMenuItem";
            gestionarClientesToolStripMenuItem.Size = new Size(306, 38);
            gestionarClientesToolStripMenuItem.Text = "Clientes &registrados";
            gestionarClientesToolStripMenuItem.Click += gestionarClientesToolStripMenuItem_Click;
            // 
            // gestionarCuentasCorrientesToolStripMenuItem
            // 
            gestionarCuentasCorrientesToolStripMenuItem.Name = "gestionarCuentasCorrientesToolStripMenuItem";
            gestionarCuentasCorrientesToolStripMenuItem.Size = new Size(306, 38);
            gestionarCuentasCorrientesToolStripMenuItem.Text = "Cuentas &corrientes";
            gestionarCuentasCorrientesToolStripMenuItem.Click += gestionarCuentasCorrientesToolStripMenuItem_Click;
            // 
            // gestionarProveedoresToolStripMenuItem
            // 
            gestionarProveedoresToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { proveedoresMenuItem, comprasMenuItem, aumentarMargenMenuItem });
            gestionarProveedoresToolStripMenuItem.Name = "gestionarProveedoresToolStripMenuItem";
            gestionarProveedoresToolStripMenuItem.Size = new Size(116, 34);
            gestionarProveedoresToolStripMenuItem.Text = "C&ompras";
            // 
            // proveedoresMenuItem
            // 
            proveedoresMenuItem.Name = "proveedoresMenuItem";
            proveedoresMenuItem.Size = new Size(316, 38);
            proveedoresMenuItem.Text = "&Proveedores";
            proveedoresMenuItem.Click += proveedoresMenuItem_Click;
            // 
            // comprasMenuItem
            // 
            comprasMenuItem.Name = "comprasMenuItem";
            comprasMenuItem.Size = new Size(316, 38);
            comprasMenuItem.Text = "&Compras";
            comprasMenuItem.Click += comprasMenuItem_Click;
            // 
            // aumentarMargenMenuItem
            // 
            aumentarMargenMenuItem.Name = "aumentarMargenMenuItem";
            aumentarMargenMenuItem.Size = new Size(316, 38);
            aumentarMargenMenuItem.Text = "Margen de &Ganancia";
            aumentarMargenMenuItem.Click += aumentarMargenMenuItem_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 44);
            panelContenedor.Margin = new Padding(5, 5, 5, 5);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1000, 518);
            panelContenedor.TabIndex = 1;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(panelContenedor);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5, 5, 5, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainMenuForm";
            Text = "Menú principal - SGVC";
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
