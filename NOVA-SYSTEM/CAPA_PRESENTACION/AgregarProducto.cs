using CAPA_DATOS;
using CAPA_NEGOCIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAPA_PRESENTACION
{
    public partial class AgregarProducto : Form
    {
        public AgregarProducto()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void MostrarArticulos()
        {
            CDArticulos dataLayer = new CDArticulos();
            dataLayer.MostrarArticulos(DGVContenedor);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Clear the input fields for a new entry
            txtidProducto.Text = "0";
            txtNombreProducto.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtIdProveedor.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                NArticulo negocio = new NArticulo();
                string result = negocio.Insertar(
                    txtNombreProducto.Text,
                    txtDescripcion.Text,
                    int.Parse(txtPrecio.Text),
                    int.Parse(txtStock.Text),
                    int.Parse(txtIdProveedor.Text)
                );

                // Show a success message and refresh the DataGridView
                MessageBox.Show("Artículo registrado correctamente");
                MostrarArticulos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el artículo: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                NArticulo negocio = new NArticulo();
                string result = negocio.Editar(
                    txtNombreProducto.Text,
                    txtDescripcion.Text,
                    int.Parse(txtPrecio.Text),
                    int.Parse(txtStock.Text),
                    int.Parse(txtIdProveedor.Text)
                );

                // Show a success message and refresh the DataGridView
                MessageBox.Show("Artículo actualizado correctamente");
                MostrarArticulos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el artículo: " + ex.Message);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int idProducto = int.Parse(txtidProducto.Text);
                NArticulo negocio = new NArticulo();
                string result = negocio.Eliminar(idProducto);

                // Show a success message and refresh the DataGridView
                MessageBox.Show("Artículo eliminado correctamente");
                MostrarArticulos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el artículo: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtBuscarProducto.Text;
                DataTable dt = NArticulo.BuscarNombre(nombre);
                DGVContenedor.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el artículo: " + ex.Message);
            }
        }

        

        private void txtidProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void AgregarProducto_Load(object sender, EventArgs e)
        {
            MostrarArticulos();
        }

        private void DGVContenedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVContenedor.Rows[e.RowIndex];

                txtidProducto.Text = row.Cells["IdProducto"].Value.ToString();
                txtNombreProducto.Text = row.Cells["NombreProducto"].Value.ToString();
                txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = row.Cells["Precio"].Value.ToString();
                txtStock.Text = row.Cells["Stock"].Value.ToString();
                txtIdProveedor.Text = row.Cells["IdProveedor"].Value.ToString();
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Hide();
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
    }
}
