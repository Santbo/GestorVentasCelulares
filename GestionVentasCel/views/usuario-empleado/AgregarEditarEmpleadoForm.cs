using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionVentasCel.controller.usuario;
using GestionVentasCel.enumerations.modoForms;
using GestionVentasCel.enumerations.usuarios;
using GestionVentasCel.models.usuario;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Net.Mime.MediaTypeNames;
using GestionVentasCel.exceptions.usuario;

namespace GestionVentasCel.views.usuario_empleado
{
    public partial class AgregarEditarEmpleadoForm : Form
    {
        private readonly UsuarioController _usuarioController;

        //Sirve para el comportamiento del Formulario, tanto para agregar como editar
        public ModoFormulario Modo { get; set; }
        //Se utiliza si el modo del Form es editar
        public Usuario UsuarioActual { get; set; }
        public AgregarEditarEmpleadoForm(UsuarioController usuarioController)
        {
            InitializeComponent();
            _usuarioController = usuarioController;

            //Agregamos al Combobox los tipos en el Enum de rol
            comboRol.DataSource = Enum.GetValues(typeof(RolEnum));
        }

        private void AgregarEditarEmpleadoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {

                var result = MessageBox.Show(
                "¿Seguro que desea descartar los cambios?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancela el cierre
                }
            }
        }

        private void btnDescartar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (CamposValidos())
            {
                //Se ve en que modo se abrio el Form, si es en agregar se agrega, si no se edita
                if (Modo == ModoFormulario.Agregar)
                {
                    try
                    {

                        _usuarioController.CrearUsuario(
                            txtUsuario.Text.ToUpper(),
                            txtPassword.Text.ToUpper(),
                            comboRol.SelectedItem.ToString(),
                            txtNombre.Text.ToUpper(),
                            txtApellido.Text.ToUpper(),
                            txtTelefono.Text.ToUpper(),
                            txtDni.Text.ToUpper(),
                            txtEmail.Text.ToUpper()
                        );

                        DialogResult = DialogResult.OK;
                        this.Close();
                    } catch( UsuarioExistenteException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (Modo == ModoFormulario.Editar && UsuarioActual != null)
                {
                    try
                    {

                        UsuarioActual.Username = txtUsuario.Text.ToUpper();
                        UsuarioActual.Password = txtPassword.Text.ToUpper();
                        UsuarioActual.Rol = (RolEnum)comboRol.SelectedItem;
                        UsuarioActual.Nombre = txtNombre.Text.ToUpper();
                        UsuarioActual.Apellido = txtApellido.Text.ToUpper();
                        UsuarioActual.Telefono = txtTelefono.Text;
                        UsuarioActual.Dni = txtDni.Text;
                        UsuarioActual.Email = txtEmail.Text.ToUpper();

                        _usuarioController.UpdateUsuario(UsuarioActual);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    } catch( UsuarioNoEncontradoException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                
               
            }
        }

        private bool CamposValidos()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt && string.IsNullOrWhiteSpace(txt.Text))
                {
                    MessageBox.Show("Por favor, completá todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt.Focus();
                    return false;
                }
            }

            try
            {
                var mail = new MailAddress(txtEmail.Text);
                return true;
            }
            catch
            {
                MessageBox.Show("Por favor, agrega un mail válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;

            }
            


        }

        private void AgregarEditarEmpleadoForm_Load(object sender, EventArgs e)
        {
            if (Modo == ModoFormulario.Editar && UsuarioActual != null)
            {
                lblTitulo.Text = "Editar Empleado";
                txtUsuario.Text = UsuarioActual.Username;
                txtPassword.Text = UsuarioActual.Password;
                comboRol.SelectedItem = UsuarioActual.Rol;
                txtNombre.Text = UsuarioActual.Nombre;
                txtApellido.Text = UsuarioActual.Apellido;
                txtTelefono.Text = UsuarioActual.Telefono;
                txtDni.Text = UsuarioActual.Dni;
                txtEmail.Text = UsuarioActual.Email;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo acepta dígitos y la tecla backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}
