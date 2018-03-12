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
    public class DatosArea
    {


        public Area LlenaTablaDatos()
        {
            Area listadatos = new Area();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposArea> composList = new List<CamposArea>();

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
                    CamposArea reg = new CamposArea();
                    reg.idArea = Convert.ToInt32(row["idArea"].ToString());
                    reg.nombre = row["nombreArea"].ToString();
                    reg.descripcion = row["descripcion"].ToString();
                    reg.sucursales = row["sucursales"].ToString();

                    composList.Add(reg);
                }
                listadatos.listaReg = composList.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }

        public bool InsertaAreaBySP(CamposArea campos, int[] idSucursales)
        {
            bool respuesta = false;
            SqlConnection connection = null;
            SqlDataReader response = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    var parametros = new[]
                     {
                        ParametroAcceso.CrearParametro("@nombreArea", SqlDbType.VarChar, campos.nombre , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, campos.descripcion , ParameterDirection.Input)
                     };
                    response = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatAreaInsertar", parametros);
                    response.Close();
                    foreach (int id in idSucursales)
                    {
                        SqlDataReader responseSucursales = null;
                        var sucursal = new[]
                        {
                            ParametroAcceso.CrearParametro("@idSucursal", SqlDbType.Int, id, ParameterDirection.Input)
                        };
                        responseSucursales = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatAreasxSucursalesInsertar", sucursal);
                        responseSucursales.Close();
                    }
                    respuesta = true;
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return respuesta;
        }

        
        public bool actualizarAreaBySP(CamposArea campos, int[] idSucursales)
        {
            bool respuesta = false;
            SqlConnection connection = null;
            SqlDataReader response = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    /*var parametros = new[]{
                        ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, campos.descripcion , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@sucursal", SqlDbType.Int, campos.sucursal.idSucursal, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idArea", SqlDbType.Int, campos.idArea , ParameterDirection.Input)
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatAreaActualizar", parametros);
                    connection.Close();*/
                    var parametros = new[]
                    {
                        ParametroAcceso.CrearParametro("@idArea", SqlDbType.Int, campos.idArea , ParameterDirection.Input)
                        
                     };
                    response = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatAreaEliminar", parametros);
                    response.Close();
                    foreach (int id in idSucursales)
                    {
                        SqlDataReader responseSucursales = null;
                        var sucursal = new[]
                        {
                            ParametroAcceso.CrearParametro("@nombreArea", SqlDbType.VarChar, campos.nombre , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, campos.descripcion , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idArea", SqlDbType.Int, campos.idArea , ParameterDirection.Input),
                            ParametroAcceso.CrearParametro("@idsucursal", SqlDbType.Int, id, ParameterDirection.Input)
                        };
                        responseSucursales = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatAreaActualizar", sucursal);
                        responseSucursales.Close();
                    }
                    respuesta = true;
                    connection.Close();

                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return respuesta;
        }

        public bool EliminaAreaBySP(int idArea)
        {
            bool respuesta = false;
            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@idArea", SqlDbType.Int, idArea , ParameterDirection.Input)
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatAreaEliminar", parametros);
                    connection.Close();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return respuesta;
        }

        public Sucursal LlenaComboSucursal()
         {
             Sucursal campos = new Sucursal();
             DataTable dt = new DataTable();
             List<CamposSucursal> composList = new List<CamposSucursal>();

             SqlConnection connection = null;
             try
             {
                 using (connection = Conexion.ObtieneConexion("ConexionBD"))
                 {
                     SqlDataReader consulta;
                     connection.Open();
                     consulta = Ejecuta.ConsultaConRetorno(connection, "Usp_CatAreaMostrarComboSucursal");
                     dt.Load(consulta);
                     connection.Close();
                 }


                 foreach (DataRow row in dt.Rows)
                 {
                     CamposSucursal reg = new CamposSucursal();
                     reg.idSucursal = Convert.ToInt32(row["idSucursal"].ToString());
                     reg.nombre = row["nombre"].ToString();
                     composList.Add(reg);
                 }
                 campos.ListaRegistrosSucursal = composList.ToArray();

             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex);
             }

             return campos;
         }
        
        
        public Sucursal getidSucursalesByArea(int idArea)
        {
            Sucursal listadatos = new Sucursal();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposSucursal> composList = new List<CamposSucursal>();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    var parametros = new[]
                    {
                        ParametroAcceso.CrearParametro("@idArea", SqlDbType.Int, idArea , ParameterDirection.Input)
                     };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatMostrarSucursalesXArea", parametros);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposSucursal reg = new CamposSucursal();
                    reg.idSucursal = Convert.ToInt32(row["idSucursal"].ToString());
                    reg.nombre = row["nombre"].ToString();
                    reg.empresa = row["isCheck"].ToString();

                    composList.Add(reg);
                }
                listadatos.ListaRegistrosSucursal = composList.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;

        } 


    }
}
