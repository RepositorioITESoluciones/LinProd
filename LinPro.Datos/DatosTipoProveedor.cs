using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Entidades;
using LinPro.Framework.AccesoDatos;
using System.Data.SqlClient;
using System.Data;

namespace LinPro.Datos
{
    class DatosTipoProveedor
    {
        /*public TipoProveedor LlenaTablaDatos()
        {
            TipoProveedor listadatos = new TipoProveedor();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposTipoProveedor> composList = new List<CamposTipoProveedor>();

            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "Usp_CatAreaMostrarInfo");
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposTipoProveedor reg = new CamposTipoProveedor();
                    reg.sucursal = new CamposSucursal();
                    reg.idArea = Convert.ToInt32(row["idArea"].ToString());
                    reg.descripcion = row["descripcion"].ToString();
                    reg.sucursal.idSucursal = Convert.ToInt32(row["idSucursal"].ToString());
                    reg.sucursal.nombre = row["nombre"].ToString();
                    composList.Add(reg);
                }
                listadatos.listaRegTipoProveedor = composList.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }*/

    }
}
