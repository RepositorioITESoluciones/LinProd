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
    public class DatosMenu
    {

        public Menu MuestraMenus()
          {
            Menu listaMenu = new Menu();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposMenu> composList = new List<CamposMenu>();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_MaeMenuMostrarMenus");
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposMenu reg = new CamposMenu();
                    reg.idMenu = Convert.ToInt32(row["idMenu"].ToString());
                    reg.idPadre = Convert.ToInt32(row["idPadre"].ToString());
                    reg.idHijo = Convert.ToInt32(row["idHijo"].ToString());
                    reg.nombreMenu = row["nombreMenu"].ToString();
                    reg.descripcionMenu = row["descripcionMenu"].ToString();
                    reg.liga = row["liga"].ToString();
                    reg.icono = row["icono"].ToString();
                    reg.hijos = Convert.ToInt32(row["hijos"].ToString());
                    composList.Add(reg);
                }
                listaMenu.listaMenus = composList.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
              return listaMenu;
          }

          public Menu MuestraSubMenus(int idPadre)
          {
              Menu listaMenuHijos = new Menu();
              DataTable dt = new DataTable();
              SqlConnection connection = null;
              List<CamposMenuHijos> composList = new List<CamposMenuHijos>();
              try
              {
                  using (connection = Conexion.ObtieneConexion("ConexionBD"))
                  {
                      SqlDataReader consulta;
                      connection.Open();
                      var parametros = new[]
                       {
                          ParametroAcceso.CrearParametro("@idPadre", SqlDbType.Int, idPadre , ParameterDirection.Input)
                       };
                      consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_MaeMenuMostrarSubMenus", parametros);
                      dt.Load(consulta);
                      connection.Close();
                  }
                  foreach (DataRow row in dt.Rows)
                  {
                    CamposMenuHijos reg = new CamposMenuHijos();
                      reg.idMenu = Convert.ToInt32(row["idMenu"].ToString());
                      reg.idPadre = Convert.ToInt32(row["idPadre"].ToString());
                      reg.idHijo = Convert.ToInt32(row["idHijo"].ToString());
                      reg.nombreMenu = row["nombreMenu"].ToString();
                      reg.descripcionMenu = row["descripcionMenu"].ToString();
                      reg.liga = row["liga"].ToString();
                      reg.icono = row["icono"].ToString();
                      reg.hijos = Convert.ToInt32(row["hijos"].ToString());
                    composList.Add(reg);
                  }
                listaMenuHijos.listaMenusHijos = composList.ToArray();
              }
              catch (Exception e)
              {
                  Console.WriteLine(e);
                  throw;
              }
              return listaMenuHijos;
          }
    }
}
