using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPA_NEGOCIO;

namespace CAPA_PRESENTACION
{
    public partial class Inicio_de_sesion : Form
    {
        public Inicio_de_sesion()
        {
            InitializeComponent();
        }
        ////IMPORTAR LIBRERIA
        //[DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        //private extern static void ReleaseCapture();

        //[DllImport("user32.Dll", EntryPoint = "SendMessage")]

        //private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int param, int v);
        ///// FIN


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {

            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = ""; // Borra el texto "Usuario"
                txtUsuario.ForeColor = Color.White; // Cambia el color de texto a negro
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario"; // Restaura el texto si no se ingresó nada
                txtUsuario.ForeColor = Color.Gray; // Color gris para indicar texto de sugerencia
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Contraseña")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.White;
                txtContraseña.UseSystemPasswordChar = true; // Oculta el texto de la contraseña
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.UseSystemPasswordChar = false; // Muestra el texto "Contraseña"
                txtContraseña.Text = "Contraseña";
                txtContraseña.ForeColor = Color.Gray;
            }
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Contraseña")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.White;
                txtContraseña.UseSystemPasswordChar = true; // Oculta el texto de la contraseña
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        { 
            //NTrabajador Usuario = new NTrabajador();
            //var validacion = Usuario.Login(txtUsuario.Text, txtContraseña.Text);

            //lblError.Visible = true;
            //lblError.Text = "" + validacion;
            //if (validacion == true)
            //{
            //    Principal principal = new Principal();
            //    principal.Show();
            //    this.Hide();

            //}
            //else if (validacion == false)
            //{
            //    MessageBox.Show("Usted no tiene acceso al sistema");
            //    txtUsuario.Clear();
            //    txtContraseña.Clear();
            //}

            if (txtUsuario.Text == "admin" && txtContraseña.Text == "1234")
            {
                // Crear una instancia del formulario principal
                Principal principal = new Principal();

                // Mostrar el siguiente formulario
                principal.Show();

                // Ocultar el formulario de inicio de sesión
                this.Hide();
            }
            else
            {
                //error
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsuario_BorderStyleChanged(object sender, EventArgs e)
        {

        }

        private void txtContraseña_Click(object sender, EventArgs e)
        {
            
        }

        private void Inicio_de_sesion_MouseDown(object sender, MouseEventArgs e)
        {
            //ReleaseCapture();
            //SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
