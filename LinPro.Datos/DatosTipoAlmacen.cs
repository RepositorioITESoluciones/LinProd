using System;
using System.Collections.Generic;
using LinPro.Entidades;
using LinPro.Framework.AccesoDatos;
using System.Data.SqlClient;
using System.Data;

namespace LinPro.Datos {
    public class DatosTipoAlmacen {

        //Metodo encargado de consultar un giro empresarial
        public TipoAlmcanen LlenaTablaTipoAlmacen() {
            TipoAlmcanen listadatos = new TipoAlmcanen();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposTipoAlmacen> composList = new List<CamposTipoAlmacen>();
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {

                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatTipoAlmacenConsultar", null);
                    dt.Load(consulta);
                    connection.Close();

                }
                foreach (DataRow row in dt.Rows) {
                    CamposTipoAlmacen reg = new CamposTipoAlmacen();
                    reg.idTipoAlmacen = Convert.ToInt32(row["idTipoAlmacen"].ToString());
                    reg.nombre = row["nombreAlmacen"].ToString();
                    reg.descripcion = row["descripcion"].ToString();
                    composList.Add(reg);
                }
                listadatos.ListaRegistros = composList.ToArray();
            } catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }

        //Metodo encargado de insertar un giro empresarial
        public bool InsertarTipoAlmacen(CamposTipoAlmacen campos) {

            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();
                    var parametros = new[]{
                    ParametroAcceso.CrearParametro("@nombreAlmacen", SqlDbType.VarChar, campos.nombre , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, campos.descripcion , ParameterDirection.Input)
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatTipoAlmacenInsertar", parametros);
                    connection.Close();
                    respuesta = true;
                }
            } catch (Exception ex) {
                respuesta = false;
                Console.WriteLine(ex);
            }
            return respuesta;
        }

        //Metodo encargado de actualizar un giro empresarial
        public bool ActualizarTipoAlmacen(CamposTipoAlmacen campos) {
            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();

                    var parametros = new[]{
                         ParametroAcceso.CrearParametro("@idTipoAlmacen", SqlDbType.Int, campos.idTipoAlmacen , ParameterDirection.Input),
                         ParametroAcceso.CrearParametro("@nombreAlmacen", SqlDbType.VarChar, campos.nombre , ParameterDirection.Input),
                         ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, campos.descripcion , ParameterDirection.Input)

                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatTipoAlmacenActualizar", parametros);
                    connection.Close();
                    respuesta = true;
                }
            } catch (Exception ex) {
                respuesta = false;
                Console.WriteLine(ex);
            }
            return respuesta;
        }

        //Metodo encargado de eliminar logicamente un giro empresarial
        public bool EliminarTipoAlmacen(CamposTipoAlmacen campos) {

            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();
                    var parametros = new[]{
                    ParametroAcceso.CrearParametro("@idTipoAlmacen", SqlDbType.Int, campos.idTipoAlmacen , ParameterDirection.Input),
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatTipoAlmacenEliminar", parametros);
                    connection.Close();
                    respuesta = true;
                }
            } catch (Exception ex) {
                respuesta = false;
                Console.WriteLine(ex);
            }
            return respuesta;
        }




    }



}
