using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
using System.Windows.Forms;

namespace CAPA_NEGOCIO
{
    public class NTrabajador
    {

        public bool Login(string usuario, string contraseña)
        {
            CDTrabajador obj = new CDTrabajador();
            obj.Usuario = usuario;
            obj.Contraseña = contraseña;
            return obj.Login(obj);
        }

        public string Insertar(string nombre, string apaterno, string amaterno, 
                         string cargo, string telefono, string direccion, 
                         string acceso, string usuario, string contraseña, string textoBuscar)
        {
            // Crear una instancia de la clase CDTrabajador
            CDTrabajador obj = new CDTrabajador();

            // Establecer las propiedades del objeto Trabajador
            obj.Nombre = nombre;
            obj.APaterno = apaterno;
            obj.AMaterno = amaterno;
            obj.Cargo = cargo;
            obj.Telefono = telefono;
            obj.Direccion = direccion;
            obj.Acceso = acceso;
            obj.Usuario = usuario;
            obj.Contraseña = contraseña;
            obj.TextoBuscar = textoBuscar;

            // Llamar al método Insertar de la clase CDTrabajador
            return obj.Insertar(obj);
        }

        public string Editar(int idempleado, string nombre, string apaterno, string amaterno,
                         string cargo, string telefono, string direccion,
                         string acceso, string usuario, string contraseña, string textoBuscar)
        {
            // Crear una instancia de la clase CDTrabajador
            CDTrabajador obj = new CDTrabajador();

            // Establecer las propiedades del objeto Trabajador
            obj.IdEmpleado = idempleado;
            obj.Nombre = nombre;
            obj.APaterno = apaterno;
            obj.AMaterno = amaterno;
            obj.Cargo = cargo;
            obj.Telefono = telefono;
            obj.Direccion = direccion;
            obj.Acceso = acceso;
            obj.Usuario = usuario;
            obj.Contraseña = contraseña;

            // Llamar al método Editar de la clase CDTrabajador
            return obj.Editar(obj);
        }

        public string Eliminar(int idTrabajador)
        {
            // Crear una instancia de la clase CDTrabajador
            CDTrabajador obj = new CDTrabajador();

            // Establecer la propiedad IdTrabajador del objeto
            obj.IdEmpleado = idTrabajador;

            // Llamar al método Eliminar de la clase CDTrabajador
            return obj.Eliminar(obj);
        }

        public DataTable BuscarPorNombre(string textoBuscar)
        {
            // Crear una instancia de la clase CDTrabajador
            CDTrabajador obj = new CDTrabajador();

            // Establecer la propiedad TextoBuscar del objeto
            obj.TextoBuscar = textoBuscar;

            // Llamar al método BuscarPorNombre de la clase CDTrabajador
            return obj.BuscarPorNombre(obj);
        }
    }
}
