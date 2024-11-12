using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace CAPA_DATOS
{
    public class CDTrabajador
    {


        Conexion con = new Conexion();

        // Propiedades de la clase
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }

        public string Cargo { get; set; }
        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public string TextoBuscar { get; set; }

        // EN REVISION
        public string Acceso { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
  



        // Constructor
        public CDTrabajador()
        {
        }

        // Constructor
        public CDTrabajador(int idempleado, string nombre, string apaterno, string amaterno,
                          string telefono, string cargo, string direccion, string acceso, string usuario,
                          string contraseña, string textoBuscar)
        {
            this.IdEmpleado = idempleado;
            this.Nombre = nombre;
            this.APaterno = apaterno;
            this.AMaterno = amaterno;
            this.Cargo = cargo;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Acceso = acceso;
            this.Usuario = usuario;
            this.Contraseña = contraseña;
            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(CDTrabajador trabajador)
        {
            string result = "";
            con.abirBD();
            string cad = con.cadenaConcexion();

            using (SqlConnection sqlCon = new SqlConnection(cad))
            {
                sqlCon.ConnectionString = cad/*Conexion.Cn*/;
                sqlCon.Open();
                using (SqlCommand command = new SqlCommand("CrearEmp", sqlCon))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", trabajador.Nombre);
                    command.Parameters.AddWithValue("@Apellido_Paterno", trabajador.APaterno);
                    command.Parameters.AddWithValue("@Apellido_Materno", trabajador.AMaterno);
                    command.Parameters.AddWithValue("@Cargo", trabajador.Cargo);
                    command.Parameters.AddWithValue("@Telefono", trabajador.Telefono);
                    command.Parameters.AddWithValue("@Direccion", trabajador.Direccion);
                    // command.Parameters.AddWithValue("@telefono", trabajador.Telefono);
                    //command.Parameters.AddWithValue("@email", trabajador.Email);
                    //command.Parameters.AddWithValue("@acceso", trabajador.Acceso);
                    //command.Parameters.AddWithValue("@usuario", trabajador.Usuario);
                    //command.Parameters.AddWithValue("@password", trabajador.Password);

                    try
                    {
                        sqlCon.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Empleado registrado.");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            con.cerrarBD();

            return result;
        }

        public string Editar(CDTrabajador trabajador)
        {
            string result = "";
            con.abirBD();
            string cad = con.cadenaConcexion();

            using (SqlConnection sqlCon = new SqlConnection(cad))
            {
                sqlCon.ConnectionString = cad/*Conexion.Cn*/;
                sqlCon.Open();
                using (SqlCommand command = new SqlCommand("modificarEmp", sqlCon))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID_Empleado", trabajador.IdEmpleado);
                    command.Parameters.AddWithValue("@Nombre", trabajador.Nombre);
                    command.Parameters.AddWithValue("@Apellido_Paterno", trabajador.APaterno);
                    command.Parameters.AddWithValue("@Apellido_Materno", trabajador.AMaterno);
                    command.Parameters.AddWithValue("@Cargo", trabajador.Cargo);
                    command.Parameters.AddWithValue("@Telefono", trabajador.Telefono);
                    command.Parameters.AddWithValue("@Direccion", trabajador.Direccion);
                    //command.Parameters.AddWithValue("@telefono", trabajador.Telefono);
                    //command.Parameters.AddWithValue("@email", trabajador.Email);
                    //command.Parameters.AddWithValue("@acceso", trabajador.Acceso);
                    //command.Parameters.AddWithValue("@usuario", trabajador.Usuario);
                    //command.Parameters.AddWithValue("@password", trabajador.Password);

                    try
                    {
                        sqlCon.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Trabajador actualizado.");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            con.cerrarBD();
            return result;
        }

        public void MostrarTrabajadores(DataGridView dgv)
        {
            con.abirBD();
            string cad = con.cadenaConcexion();
            using (SqlConnection sqlCon = new SqlConnection(cad))
            {
                sqlCon.ConnectionString = cad/*Conexion.Cn*/;
                try
                {
                    sqlCon.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Empleado", sqlCon);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo llenar el DataGridView: " + ex.Message);
                }
                sqlCon.Close();
            }
        }

        public string Eliminar(CDTrabajador trabajador)
        {
            string result = "";

            using (SqlConnection sqlConnection = new SqlConnection())
            {

                //Codigo
                con.abirBD();
                string cad = con.cadenaConcexion();

                using (SqlCommand command = new SqlCommand("EliminarEmp", sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID_Empleado", trabajador.IdEmpleado);

                    if (MessageBox.Show("El empleado " + trabajador.IdEmpleado + " se eliminará",
                        "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            sqlConnection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Se ha eliminado el registro.");
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }

            return result;
        }

        public DataTable BuscarPorNombre(CDTrabajador trabajador)
        {
            DataTable dtResultado = new DataTable("trabajadores");

            using (SqlConnection sqlCon = new SqlConnection())
            {
                //Codigo
                con.abirBD();
                string cad = con.cadenaConcexion();

                sqlCon.ConnectionString = cad/*Conexion.Cn*/;
                sqlCon.Open();

                using (SqlCommand command = new SqlCommand("spBuscarTrabajadorPorNombre", sqlCon))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@textoBuscar", trabajador.TextoBuscar);

                    try
                    {
                        sqlCon.Open();
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(dtResultado);
                    }
                    catch (Exception ex)
                    {
                        dtResultado = null;
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            return dtResultado;
        }


        //public bool Login(CDTrabajador Trabajador)
        //{
        //    //DataTable DtResultado = new DataTable("trabajador");
        //    SqlConnection SqlCon = new SqlConnection();
        //    // string rpta = "";



        //    //Codigo
        //    con.abirBD();
        //    string cad = con.cadenaConcexion();
        //    //SqlCon.ConnectionString = Conexion.Cn;
        //    SqlCon.ConnectionString = cad/*Conexion.Cn*/;
        //    SqlCon.Open();
        //    SqlCommand SqlCmd = new SqlCommand();
        //    SqlCmd.Connection = SqlCon;
        //    SqlCmd.CommandText = "LoginEmp";
        //    SqlCmd.CommandType = CommandType.StoredProcedure;

        //    SqlCmd.Parameters.AddWithValue("@Usuario", Trabajador.Usuario);
        //    SqlCmd.Parameters.AddWithValue("@Contraseña", Trabajador.Contraseña);

        //    SqlDataReader reader = SqlCmd.ExecuteReader();

        //    if (reader.HasRows)

        //    {
        //        MessageBox.Show("USUARIO CONSULTADO");
        //        return true;


        //    }
        //    else

        //        return false; }
        public bool Login(CDTrabajador Trabajador)
        {
            bool resultado = false;
            SqlConnection SqlCon = new SqlConnection();
            con.abirBD();
            string cad = con.cadenaConcexion();
            SqlCon.ConnectionString = cad;
            SqlCon.Open();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = SqlCon;
            SqlCmd.CommandText = "LoginEmp";
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.Parameters.AddWithValue("@Usuario", Trabajador.Usuario);
            SqlCmd.Parameters.AddWithValue("@Contraseña", Trabajador.Contraseña);

            SqlDataReader reader = SqlCmd.ExecuteReader();

            if (reader.Read()) // Cambiado a reader.Read()
            {
                resultado = reader.GetInt32(0) == 1; // Asumiendo que el procedimiento devuelve 1 o 0
            }

            reader.Close();
            SqlCon.Close();
            return resultado;
        }


    }
}
