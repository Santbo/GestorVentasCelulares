using GestionVentasCel.service.usuario;
using GestionVentasCel.temas;
using Microsoft.Extensions.DependencyInjection;

namespace GestionVentasCel.views.ejemplo
{
    public partial class EjemploPermisosForm : Form
    {
        private readonly SesionUsuario _sesionUsuario;

        public EjemploPermisosForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _sesionUsuario = serviceProvider.GetRequiredService<SesionUsuario>();
            ConfigurarPermisos();
        }

        private void ConfigurarPermisos()
        {
            // Ejemplo de cómo ocultar/deshabilitar controles según permisos
            
            // Solo administradores pueden ver el botón de eliminar
            btnEliminar.Visible = _sesionUsuario.PuedeAccederAUsuarios();
            
            // Solo administradores y vendedores pueden editar
            btnEditar.Enabled = _sesionUsuario.PuedeAccederAVentas();
            
            // Solo administradores pueden acceder a configuración
            btnConfiguracion.Visible = _sesionUsuario.PuedeAccederAConfiguracionPrecios();
            
            // Solo técnicos y administradores pueden acceder a reparaciones
            btnReparaciones.Enabled = _sesionUsuario.PuedeAccederAReparaciones();
            
            // Mostrar información del usuario actual
            lblUsuarioActual.Text = $"Usuario: {_sesionUsuario.Username}";
            lblRolActual.Text = $"Rol: {_sesionUsuario.Rol}";
        }

        private void EjemploPermisosForm_Load(object sender, EventArgs e)
        {
            // Aplicar estilos
            this.BackColor = Tema.ColorFondo;
            this.ForeColor = Tema.ColorTextoPrimario;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar permisos antes de ejecutar la acción
            if (!_sesionUsuario.PuedeAccederAUsuarios())
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.", "Sin permisos", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            MessageBox.Show("Acción de eliminación ejecutada.", "Éxito", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verificar permisos antes de ejecutar la acción
            if (!_sesionUsuario.PuedeAccederAVentas())
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.", "Sin permisos", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            MessageBox.Show("Acción de edición ejecutada.", "Éxito", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            // Verificar permisos antes de ejecutar la acción
            if (!_sesionUsuario.PuedeAccederAConfiguracionPrecios())
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.", "Sin permisos", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            MessageBox.Show("Acción de configuración ejecutada.", "Éxito", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReparaciones_Click(object sender, EventArgs e)
        {
            // Verificar permisos antes de ejecutar la acción
            if (!_sesionUsuario.PuedeAccederAReparaciones())
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.", "Sin permisos", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            MessageBox.Show("Acción de reparaciones ejecutada.", "Éxito", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
