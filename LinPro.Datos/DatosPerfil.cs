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
    public class DatosPerfil
    {


        public Perfil LlenaTablaDatos()
        {
            Perfil listadatos = new Perfil();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposPerfil> composList = new List<CamposPerfil>();

            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "Usp_CatPerfilesMostrarInfoPerfil");
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposPerfil reg = new CamposPerfil();
                    reg.idPerfil = Convert.ToInt32(row["idRol"].ToString());
                    reg.nombre = row["nombreRol"].ToString();
                    reg.descripcion = row["descripcionRol"].ToString();
                    composList.Add(reg);
                }
                listadatos.listaPerfiles = composList.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }

        public bool InsertaPerfilBySP(CamposPerfil campos)
        {
            bool respuesta = false;
            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    var parametros = new[]
                     {
                        ParametroAcceso.CrearParametro("@nombre", SqlDbType.VarChar, campos.nombre , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, campos.descripcion , ParameterDirection.Input)
                     };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatPerfilInsertar", parametros);
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

        public bool actualizaPerfilBySP(CamposPerfil campos)
        {
            bool respuesta = false;
            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@nombre", SqlDbType.VarChar, campos.nombre , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, campos.descripcion , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idRol", SqlDbType.Int, campos.idPerfil , ParameterDirection.Input)
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatPerfilActualizar", parametros);
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

        public bool EliminaPerfilBySP(int idPerfil)
        {
            bool respuesta = false;
            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@idRol", SqlDbType.Int, idPerfil , ParameterDirection.Input)
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatPerfilEliminar", parametros);
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



    }
}
