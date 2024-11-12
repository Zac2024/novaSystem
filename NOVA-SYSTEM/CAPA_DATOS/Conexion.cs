using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAPA_DATOS
{
    public class Conexion
    {
        public string Cn = "Data Source=USER;Initial Catalog=NEXORA;Integrated Security=True;Trust Server Certificate=True";
        SqlConnection cn;

        public void abirBD()
        {
            try
            {
                string nomser = Dns.GetHostName();
                cn = new SqlConnection("Data Source=USER;Initial Catalog=NEXORA;Integrated Security=True;Trust Server Certificate=True");
                cn.Open();
                MessageBox.Show("Connexion abierta");
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        public void cerrarBD()
        {
            cn.Close();
            MessageBox.Show("Conexion cerrada");

        }

        public string cadenaConcexion()
        {
            return cn.ConnectionString;
        }
    }
}
