using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPA_DATOS;


namespace CAPA_NEGOCIO
{
    public class NArticulo
    {

        public bool ValidarDatos(CDArticulos articulos)
        {
            bool resultado = true;
            if (articulos.Nombre_Producto == string.Empty)
            {
                return false;
                //MessageBox.Show("El Nombre es Obligatorio");
            }
            
            if (articulos.Descripcion == string.Empty)
            {
                return false;
                //MessageBox.Show("El Descripcion es Obligatorio");
            }
            
            return resultado;
        }

        //Método Insertar que llama al método insertar de la clase
        //DArticulo de la CapaDatos
        public string Insertar(string nombre, string descripcion, int precio, int stock, int proveedor)
        {
            CDArticulos obj = new CDArticulos();

            obj.Nombre_Producto = nombre;
            obj.Descripcion = descripcion;
            obj.Precio = precio;
            obj.Stock = stock;
            obj.Id_proveedor = proveedor; // Aquí proveedor ahora es de tipo int

            return obj.insertarArticulos(obj);

        }

        //Método Editar que llama al método editar de la clase
        //DArticulo de la CapaDatos
        public string Editar(string nombre, string descripcion, int precio, int stock, int proveedor)
        {
            CDArticulos Obj = new CDArticulos();

            Obj.Nombre_Producto = nombre;
            Obj.Descripcion = descripcion;
            Obj.Precio = precio;
            Obj.Stock = stock;
            Obj.Id_proveedor = proveedor; // Aquí proveedor ahora es de tipo int

            return Obj.Editar(Obj);
        }
        //Método Eliminar que llama al método eliminar de la clase
        //DArticulo de la CapaDatos
        public string Eliminar(int idarticulo)
        {
            CDArticulos Obj = new CDArticulos();
            Obj.Id_proveedor = idarticulo; // Esto está bien si Id_proveedor es de tipo int

            return Obj.Eliminar(idarticulo);
        }


        //Método BuscarNombre que llama al método BuscarNombre de la clase
        //CDArticulo de la CapaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            CDArticulos Obj = new CDArticulos();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
