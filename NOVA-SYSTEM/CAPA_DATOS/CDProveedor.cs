using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
namespace CAPA_DATOS
{
    public class CDProveedor
    {
        // Propiedades
        public int Id_proveedor { get; set; }
        public string Nombre_Proveedor { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        // Método para insertar un proveedor
        public void InsertarProveedor()
        {
            using (SqlConnection connection = new SqlConnection("tu_cadena_de_conexion"))
            {
                string query = "INSERT INTO Proveedores (Nombre_Proveedor, Telefono, Email, Direccion) VALUES (@Nombre, @Telefono, @Email, @Direccion)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Nombre", Nombre_Proveedor);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Método para eliminar un proveedor
        public void EliminarProveedor()
        {
            using (SqlConnection connection = new SqlConnection("tu_cadena_de_conexion"))
            {
                string query = "DELETE FROM Proveedores WHERE Id_Proveedor = @IdProveedor";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdProveedor", Id_proveedor);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Método para actualizar los datos de un proveedor
        public void ActualizarProveedor()
        {
            using (SqlConnection connection = new SqlConnection("tu_cadena_de_conexion"))
            {
                string query = "UPDATE Proveedores SET Nombre_Proveedor = @Nombre, Telefono = @Telefono, Email = @Email, Direccion = @Direccion WHERE Id_Proveedor = @IdProveedor";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdProveedor", Id_proveedor);
                cmd.Parameters.AddWithValue("@Nombre", Nombre_Proveedor);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Direccion", Direccion);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Método para obtener la lista de proveedores (para llenar el DataGridView)
        public List<CDProveedor> ListarProveedores()
        {
            List<CDProveedor> proveedores = new List<CDProveedor>();

            using (SqlConnection connection = new SqlConnection("tu_cadena_de_conexion"))
            {
                string query = "SELECT Id_Proveedor, Nombre_Proveedor, Telefono, Email, Direccion FROM Proveedores";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CDProveedor proveedor = new CDProveedor
                        {
                            Id_proveedor = reader.GetInt32(0),
                            Nombre_Proveedor = reader.GetString(1),
                            Telefono = reader.GetString(2),
                            Email = reader.GetString(3),
                            Direccion = reader.GetString(4)
                        };

                        proveedores.Add(proveedor);
                    }
                }

                connection.Close();
            }

            return proveedores;
        }



    }
}
