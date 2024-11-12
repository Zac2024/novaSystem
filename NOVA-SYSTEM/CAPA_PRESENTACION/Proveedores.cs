using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPA_DATOS;
using CAPA_NEGOCIO;

namespace CAPA_PRESENTACION
{
    public partial class Proveedores : Form
    {
        NProveedor nProveedor = new NProveedor();
        public Proveedores()
        {
            InitializeComponent();
            //nProveedor = new NProveedor();
            //CargarProveedores();
        }

        private void CargarProveedores()
        {
            //// Carga los proveedores en el DataGridView
            //List<Proveedor> proveedores = nProveedor.ObtenerProveedores();
            //dataGridView1.DataSource = proveedores;
        }

        private void LimpiarCampos()
        {
            txtIdProveedor.Clear();
            txtNombreProveedor.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
        }

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CDProveedor proveedor = new CDProveedor
                {
                    Nombre_Proveedor = txtNombreProveedor.Text,
                    Telefono = txtTelefono.Text,
                    Email = txtEmail.Text,
                    Direccion = txtDireccion.Text
                };

                nProveedor.AgregarProveedor(proveedor); // Llamar al método de negocio
                MessageBox.Show("Proveedor registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int idProveedor = int.Parse(txtIdProveedor.Text);
                nProveedor.EliminarProveedor(idProveedor); // Llamar al método de negocio para eliminar
                MessageBox.Show("Proveedor eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void txtNombreProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDomicilio_TextChanged(object sender, EventArgs e)
        {

        }

        private void Proveedores_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                CDProveedor proveedor = new CDProveedor
                {
                    Id_proveedor = int.Parse(txtIdProveedor.Text), 
                    Nombre_Proveedor = txtNombreProveedor.Text,
                    Telefono = txtTelefono.Text,
                    Email = txtEmail.Text,
                    Direccion = txtDireccion.Text
                };

                // Llamamos al método de actualizar (en la capa de negocio)
                nProveedor.ActualizarProveedor(proveedor);
                MessageBox.Show("Proveedor actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Hide();
        }
    }

}


