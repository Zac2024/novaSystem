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

namespace CAPA_PRESENTACION
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        // inicio del metodo para realeasecapture y sendmessage
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.Dll", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lparam);


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

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (Menu.Width == 200)
            {
                Menu.Width = 70;
            }
            else
            {
                Menu.Width = 200;
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            RegistrarVentas RVentas = new RegistrarVentas();
            RVentas.Show();
            this.Hide();
            
            
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            Proveedores formProveedores = new Proveedores();


            formProveedores.Show();


            this.Hide();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            AgregarProducto Aproducto = new AgregarProducto();
            Aproducto.Show();
            this.Hide();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventarios inventarios = new Inventarios();
            inventarios.Show();
            this.Hide();
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            Informes informes = new Informes();
            informes.Show();
            this.Hide();
        }
    }
}
