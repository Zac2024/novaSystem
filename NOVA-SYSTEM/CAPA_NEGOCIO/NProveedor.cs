using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
using System.Windows.Forms;

namespace CAPA_NEGOCIO
{
    public class NProveedor
    {
        // Lógica para agregar un proveedor
        public void AgregarProveedor(CDProveedor proveedor)
        {
            try
            {
                // Llamar al método de la capa de datos para insertar el proveedor
                proveedor.InsertarProveedor();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el proveedor: " + ex.Message);
            }
        }

        // Lógica para eliminar un proveedor por su ID
        public void EliminarProveedor(int idProveedor)
        {
            try
            {
                // Llamar al método de la capa de datos para eliminar el proveedor
                CDProveedor proveedor = new CDProveedor();
                proveedor.Id_proveedor = idProveedor;
                proveedor.EliminarProveedor();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el proveedor: " + ex.Message);
            }
        }

        // Lógica para actualizar los datos de un proveedor
        public void ActualizarProveedor(CDProveedor proveedor)
        {
            try
            {
                // Llamar al método de la capa de datos para actualizar el proveedor
                proveedor.ActualizarProveedor();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el proveedor: " + ex.Message);
            }
        }

        // Lógica para obtener todos los proveedores (si lo necesitas para llenar el DataGridView)
        public List<CDProveedor> ObtenerProveedores()
        {
            try
            {
                CDProveedor proveedor = new CDProveedor();
                return proveedor.ListarProveedores();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los proveedores: " + ex.Message);
            }
        }

    }
}
