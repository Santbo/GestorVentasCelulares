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
            reparacionesToolStripMenuItem = new ToolStripMenuItem();
            administrarServiciosMenuItem = new ToolStripMenuItem();
            administrarReparacionesMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            gestionarVentasToolStripMenuItem = new ToolStripMenuItem();
            gestionarFacturasToolStripMenuItem = new ToolStripMenuItem();
            cajaToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem1 = new ToolStripMenuItem();
            comprasToolStripMenuItem = new ToolStripMenuItem();
            panelContenedor = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveCaption;
            menuStrip1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { UsuarioMenuItem, gestionarArticulosToolStripMenuItem, clientesToolStripMenuItem, gestionarProveedoresToolStripMenuItem, reparacionesToolStripMenuItem, ventasToolStripMenuItem, cajaToolStripMenuItem, reportesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 4, 0, 4);
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(855, 37);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // UsuarioMenuItem
            // 
            UsuarioMenuItem.Name = "UsuarioMenuItem";
            UsuarioMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            UsuarioMenuItem.Size = new Size(118, 29);
            UsuarioMenuItem.Text = "&Empleados";
            UsuarioMenuItem.Click += UsuarioMenuItem_Click;
            // 
            // gestionarArticulosToolStripMenuItem
            // 
            gestionarArticulosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { categoriasMenuItem, ArticulosMenuItem });
            gestionarArticulosToolStripMenuItem.Name = "gestionarArticulosToolStripMenuItem";
            gestionarArticulosToolStripMenuItem.Size = new Size(111, 29);
            gestionarArticulosToolStripMenuItem.Text = "&Inventario";
            // 
            // categoriasMenuItem
            // 
            categoriasMenuItem.Name = "categoriasMenuItem";
            categoriasMenuItem.Size = new Size(188, 30);
            categoriasMenuItem.Text = "&Categorias";
            categoriasMenuItem.Click += categoriasMenuItem_Click;
            // 
            // ArticulosMenuItem
            // 
            ArticulosMenuItem.Name = "ArticulosMenuItem";
            ArticulosMenuItem.Size = new Size(188, 30);
            ArticulosMenuItem.Text = "&Articulos";
            ArticulosMenuItem.Click += ArticulosMenuItem_Click;
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionarClientesToolStripMenuItem, gestionarCuentasCorrientesToolStripMenuItem });
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(93, 29);
            clientesToolStripMenuItem.Text = "&Clientes";
            // 
            // gestionarClientesToolStripMenuItem
            // 
            gestionarClientesToolStripMenuItem.Name = "gestionarClientesToolStripMenuItem";
            gestionarClientesToolStripMenuItem.Size = new Size(264, 30);
            gestionarClientesToolStripMenuItem.Text = "Clientes &registrados";
            gestionarClientesToolStripMenuItem.Click += gestionarClientesToolStripMenuItem_Click;
            // 
            // gestionarCuentasCorrientesToolStripMenuItem
            // 
            gestionarCuentasCorrientesToolStripMenuItem.Name = "gestionarCuentasCorrientesToolStripMenuItem";
            gestionarCuentasCorrientesToolStripMenuItem.Size = new Size(264, 30);
            gestionarCuentasCorrientesToolStripMenuItem.Text = "Cuentas &corrientes";
            gestionarCuentasCorrientesToolStripMenuItem.Click += gestionarCuentasCorrientesToolStripMenuItem_Click;
            // 
            // gestionarProveedoresToolStripMenuItem
            // 
            gestionarProveedoresToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { proveedoresMenuItem, comprasMenuItem, aumentarMargenMenuItem });
            gestionarProveedoresToolStripMenuItem.Name = "gestionarProveedoresToolStripMenuItem";
            gestionarProveedoresToolStripMenuItem.Size = new Size(101, 29);
            gestionarProveedoresToolStripMenuItem.Text = "C&ompras";
            // 
            // proveedoresMenuItem
            // 
            proveedoresMenuItem.Name = "proveedoresMenuItem";
            proveedoresMenuItem.Size = new Size(274, 30);
            proveedoresMenuItem.Text = "&Proveedores";
            proveedoresMenuItem.Click += proveedoresMenuItem_Click;
            // 
            // comprasMenuItem
            // 
            comprasMenuItem.Name = "comprasMenuItem";
            comprasMenuItem.Size = new Size(274, 30);
            comprasMenuItem.Text = "&Compras";
            comprasMenuItem.Click += comprasMenuItem_Click;
            // 
            // aumentarMargenMenuItem
            // 
            aumentarMargenMenuItem.Name = "aumentarMargenMenuItem";
            aumentarMargenMenuItem.Size = new Size(274, 30);
            aumentarMargenMenuItem.Text = "Margen de &Ganancia";
            aumentarMargenMenuItem.Click += aumentarMargenMenuItem_Click;
            // 
            // reparacionesToolStripMenuItem
            // 
            reparacionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { administrarServiciosMenuItem, administrarReparacionesMenuItem });
            reparacionesToolStripMenuItem.Name = "reparacionesToolStripMenuItem";
            reparacionesToolStripMenuItem.Size = new Size(138, 29);
            reparacionesToolStripMenuItem.Text = "&Reparaciones";
            // 
            // administrarServiciosMenuItem
            // 
            administrarServiciosMenuItem.Name = "administrarServiciosMenuItem";
            administrarServiciosMenuItem.Size = new Size(293, 30);
            administrarServiciosMenuItem.Text = "Gestionar &servicios";
            administrarServiciosMenuItem.Click += administrarServiciosMenuItem_Click;
            // 
            // administrarReparacionesMenuItem
            // 
            administrarReparacionesMenuItem.Name = "administrarReparacionesMenuItem";
            administrarReparacionesMenuItem.Size = new Size(293, 30);
            administrarReparacionesMenuItem.Text = "Gestionar &reparaciones";
            administrarReparacionesMenuItem.Click += administrarReparacionesMenuItem_Click;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionarVentasToolStripMenuItem, gestionarFacturasToolStripMenuItem });
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(82, 29);
            ventasToolStripMenuItem.Text = "&Ventas";
            // 
            // gestionarVentasToolStripMenuItem
            // 
            gestionarVentasToolStripMenuItem.Name = "gestionarVentasToolStripMenuItem";
            gestionarVentasToolStripMenuItem.Size = new Size(251, 30);
            gestionarVentasToolStripMenuItem.Text = "Gestionar &ventas";
            gestionarVentasToolStripMenuItem.Click += gestionarVentasToolStripMenuItem_Click;
            // 
            // gestionarFacturasToolStripMenuItem
            // 
            gestionarFacturasToolStripMenuItem.Name = "gestionarFacturasToolStripMenuItem";
            gestionarFacturasToolStripMenuItem.Size = new Size(251, 30);
            gestionarFacturasToolStripMenuItem.Text = "Gestionar &facturas";
            gestionarFacturasToolStripMenuItem.Click += gestionarFacturasToolStripMenuItem_Click;
            // 
            // cajaToolStripMenuItem
            // 
            cajaToolStripMenuItem.Name = "cajaToolStripMenuItem";
            cajaToolStripMenuItem.Size = new Size(63, 29);
            cajaToolStripMenuItem.Text = "Ca&ja";
            cajaToolStripMenuItem.Click += cajaToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ventasToolStripMenuItem1, comprasToolStripMenuItem });
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(99, 29);
            reportesToolStripMenuItem.Text = "Re&portes";
            // 
            // ventasToolStripMenuItem1
            // 
            ventasToolStripMenuItem1.Name = "ventasToolStripMenuItem1";
            ventasToolStripMenuItem1.Size = new Size(173, 30);
            ventasToolStripMenuItem1.Text = "Ventas";
            ventasToolStripMenuItem1.Click += ventasToolStripMenuItem1_Click;
            // 
            // comprasToolStripMenuItem
            // 
            comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            comprasToolStripMenuItem.Size = new Size(173, 30);
            comprasToolStripMenuItem.Text = "Compras";
            comprasToolStripMenuItem.Click += comprasToolStripMenuItem_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 37);
            panelContenedor.Margin = new Padding(4);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(855, 413);
            panelContenedor.TabIndex = 1;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 450);
            Controls.Add(panelContenedor);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainMenuForm";
            Text = " ";
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
        private ToolStripMenuItem reparacionesToolStripMenuItem;
        private ToolStripMenuItem administrarServiciosMenuItem;
        private ToolStripMenuItem administrarReparacionesMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem gestionarVentasToolStripMenuItem;
        private ToolStripMenuItem gestionarFacturasToolStripMenuItem;
        private ToolStripMenuItem cajaToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem1;
        private ToolStripMenuItem comprasToolStripMenuItem;
    }
}
