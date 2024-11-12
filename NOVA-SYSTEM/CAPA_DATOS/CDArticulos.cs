using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace CAPA_DATOS
{
    public class CDArticulos
    {
        public int Id_producto { get; set; }
        public string Nombre_Producto { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public int Id_proveedor { get; set; }

        public string TextoBuscar { get; set; }

        // Constructor vacío
        public CDArticulos()
        {
        }

        // Constructor con parámetros
        public CDArticulos(int idproducto, string nombre, string descripcion, int precio, int stock, int proveedor)
        {
            this.Id_producto = idproducto;
            this.Nombre_Producto = nombre;
            this.Descripcion = descripcion;
            this.Precio =precio ;
            this.Stock = stock;
            this.Id_proveedor = proveedor;
        }



        //Metodos de manejo 
        Conexion con = new Conexion();
        public string insertarArticulos(CDArticulos articulos)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            con.abirBD();

            string cad = con.cadenaConcexion();
            SqlCon.ConnectionString = cad;

            using (SqlConnection sqlCon = new SqlConnection(cad))
            {
                try
                {
                    sqlCon.Open();

                    // Establecemos el comando para llamar al stored procedure
                    using (SqlCommand sqlCmd = new SqlCommand("CrearProd", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros al comando

                        sqlCmd.Parameters.AddWithValue("@Nombre_Producto", articulos.Nombre_Producto);
                        sqlCmd.Parameters.AddWithValue("@Descripcion", articulos.Descripcion);
                        sqlCmd.Parameters.AddWithValue("@Precio", articulos.Precio);
                        sqlCmd.Parameters.AddWithValue("@Stock", articulos.Stock);
                        sqlCmd.Parameters.AddWithValue("@id_proveedor", articulos.Id_proveedor);

                        // Ejecutar el comando
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("ARTICULO REGISTRADO");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar el artículo: " + ex.Message);
                }
                finally
                {
                    // Cerrar la conexión si está abierta
                    if (sqlCon.State == ConnectionState.Open)
                    {
                        sqlCon.Close();
                    }
                }
            }
            return rpta;
        }

        public string Editar(CDArticulos articulo)
        {
            string rpta = "";
            string cad = con.cadenaConcexion();
            using (SqlConnection sqlCon = new SqlConnection(cad))
            {
                try
                {
                    sqlCon.Open();

                    // Establecemos el comando para llamar al stored procedure
                    using (SqlCommand sqlCmd = new SqlCommand("ModificarProd", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros al comando
                        sqlCmd.Parameters.AddWithValue("@id_producto", articulo.Id_proveedor);
                        sqlCmd.Parameters.AddWithValue("@Nombre", articulo.Nombre_Producto);
                        sqlCmd.Parameters.AddWithValue("@Descripcion", articulo.Descripcion);
                        sqlCmd.Parameters.AddWithValue("@Precio", articulo.Precio);
                        sqlCmd.Parameters.AddWithValue("@Stock", articulo.Stock);
                        sqlCmd.Parameters.AddWithValue("@id_proveedor", articulo.Id_proveedor);

                        // Ejecutar el comando
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("ARTICULO EDITADO");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar el artículo: " + ex.Message);
                }
                finally
                {
                    // Cerrar la conexión si está abierta
                    if (sqlCon.State == ConnectionState.Open)
                    {
                        sqlCon.Close();
                    }
                }
            }
            return rpta;
        }

        public void MostrarArticulos(DataGridView dgv)
        {
            string cad = con.cadenaConcexion();
            using (SqlConnection sqlCon = new SqlConnection(cad))
            {
                try
                {
                    // Abrimos la conexión
                    sqlCon.Open();

                    // Creamos el adaptador y el DataTable
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PRODUCTO", sqlCon);
                    DataTable dt = new DataTable();

                    // Llenamos el DataTable
                    da.Fill(dt);

                    // Asignamos el DataTable como fuente de datos del DataGridView
                    dgv.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al mostrar los artículos: " + ex.Message);
                }
                sqlCon.Close();
            } // La conexión se cierra automáticamente aquí
        }

        public string Eliminar(int idArticulo)
        {
            string rpta = "";
            string cad = con.cadenaConcexion();
            using (SqlConnection sqlCon = new SqlConnection(cad))
            {
                try
                {
                    // Abrimos la conexión
                    sqlCon.Open();

                    // Establecemos el comando para llamar al stored procedure
                    using (SqlCommand sqlCmd = new SqlCommand("speliminar_articulo", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetro para el ID del artículo
                        sqlCmd.Parameters.AddWithValue("@id_producto", idArticulo);

                        // Ejecutar el comando
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("ARTICULO ELIMINADO");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el artículo: " + ex.Message);
                }
            } // La conexión se cierra automáticamente aquí
            return rpta;
        }

        public DataTable BuscarNombre(CDArticulos articulos1)
        {
            string cad = con.cadenaConcexion();
            DataTable dtResultado = new DataTable("Articulos");
            using (SqlConnection sqlCon = new SqlConnection(cad))
            {
                try
                {
                    // Abrimos la conexión
                    sqlCon.Open();

                    // Establecemos el comando para llamar al stored procedure
                    using (SqlCommand sqlCmd = new SqlCommand("spbuscar_articulo_nombre", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetro para el texto a buscar PENDIENTE 
                        //TAMBIEN AGREGAR
                        sqlCmd.Parameters.AddWithValue("@textobuscar", articulos1.TextoBuscar);

                        // Usamos SqlDataAdapter para llenar el DataTable
                        SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                        sqlDat.Fill(dtResultado);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el artículo: " + ex.Message);
                }
            } // La conexión se cierra automáticamente aquí

            return dtResultado;
        }
    }
}
