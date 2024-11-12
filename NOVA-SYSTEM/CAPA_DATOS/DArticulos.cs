using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPA_DATOS;

namespace CAPA_DATOS
{
    internal class DArticulos
    {
        Conexion con = new Conexion();
        public void insertarArticulos(CDArticulos articulos)
        {
            SqlConnection SqlCon = new SqlConnection();
            con.abirBD();

            string cad = con.cadenaConcexion();
            SqlCon.ConnectionString = cad;

            using (SqlConnection sqlCon = new SqlConnection(cad))
            {
                try
                {
                    sqlCon.Open();

                    // Establecemos el comando para llamar al procedimiento almacenado
                    using (SqlCommand sqlCmd = new SqlCommand("CrearProd", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros al comando
                        sqlCmd.Parameters.AddWithValue("@id_producto", articulos.Id_producto);
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
        }

        public void Editar(CDArticulos articulo)
        {

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
                        sqlCmd.Parameters.AddWithValue("@id_producto", articulo.Id_producto);
                        sqlCmd.Parameters.AddWithValue("@Nombre_Producto", articulo.Nombre_Producto);
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
                    MessageBox.Show("Error al mostrar los productos: " + ex.Message);
                }
                sqlCon.Close();
            } // La conexión se cierra automáticamente aquí
        }

        public void Eliminar(int idArticulo)
        {
            string cad = con.cadenaConcexion();
            using (SqlConnection sqlCon = new SqlConnection(cad))
            {
                try
                {
                    // Abrimos la conexión
                    sqlCon.Open();

                    // Establecemos el comando para llamar al stored procedure
                    using (SqlCommand sqlCmd = new SqlCommand("EliminarProd", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetro para el ID del artículo
                        sqlCmd.Parameters.AddWithValue("@id_producto", idArticulo);

                        // Ejecutar el comando
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("producto ELIMINADO");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el producto: " + ex.Message);
                }
            } // La conexión se cierra automáticamente aquí
        }

        //public DataTable BuscarNombre(CDArticulos articulos1)
        //{
        //    string cad = con.cadenaConcexion();
        //    DataTable dtResultado = new DataTable("PRODUCTO");
        //    using (SqlConnection sqlCon = new SqlConnection(cad))
        //    {
        //        try
        //        {
        //            // Abrimos la conexión
        //            sqlCon.Open();

        //            // Establecemos el comando para llamar al stored procedure
        //            using (SqlCommand sqlCmd = new SqlCommand("spbuscar_articulo_nombre", sqlCon))
        //            {
        //                sqlCmd.CommandType = CommandType.StoredProcedure;

        //                // Agregar parámetro para el texto a buscar
        //                sqlCmd.Parameters.AddWithValue("@textobuscar", articulos1.TextoBuscar);

        //                // Usamos SqlDataAdapter para llenar el DataTable
        //                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
        //                sqlDat.Fill(dtResultado);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error al buscar el artículo: " + ex.Message);
        //        }
        //    } // La conexión se cierra automáticamente aquí

        //    return dtResultado;
        //}
    }
}
