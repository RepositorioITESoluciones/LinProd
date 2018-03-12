using System;
using System.Collections.Generic;
using LinPro.Entidades;
using LinPro.Framework.AccesoDatos;
using System.Data.SqlClient;
using System.Data;

namespace LinPro.Datos {
    public class DatosModeloPlacas {

        //Metodo encargado de consultar para la tabla de ModeloPlacas
        public ModelosPlacas LlenaTablaDatosModeloPlacas() {
            ModelosPlacas listadatos = new ModelosPlacas();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposModeloPlacas> composList = new List<CamposModeloPlacas>();
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {

                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatModeloPlacasMostrar", null);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows) {
                    CamposModeloPlacas reg = new CamposModeloPlacas();
                    reg.idModeloCircuito = Convert.ToInt32(row["idModeloPlaca"].ToString());
                    reg.nombre = row["nombre"].ToString();
                    reg.modelo = row["modelo"].ToString();
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

        //Metodo encargado de insertar omdelo de una placa
        public bool InsertarModeloPlacas(CamposModeloPlacas campos) {

            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();
                    var parametros = new[]{
                    ParametroAcceso.CrearParametro("@nombre", SqlDbType.VarChar, campos.nombre , ParameterDirection.Input),
                     ParametroAcceso.CrearParametro("@modelo", SqlDbType.VarChar, campos.modelo , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, campos.descripcion , ParameterDirection.Input)
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatModelosPlacasInsertar", parametros);
                    connection.Close();
                    respuesta = true;
                }
            } catch (Exception ex) {
                respuesta = false;
                Console.WriteLine(ex);
            }
            return respuesta;
        }

        //Metodo encargado de actualizar un modelo de unna placa
        public bool ActualizarModeloPlacas(CamposModeloPlacas campos) {
            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();

                    var parametros = new[]{
                    ParametroAcceso.CrearParametro("@idModeloCircuito", SqlDbType.Int, campos.idModeloCircuito , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@nombre", SqlDbType.VarChar, campos.nombre , ParameterDirection.Input),
                     ParametroAcceso.CrearParametro("@modelo", SqlDbType.VarChar, campos.modelo , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, campos.descripcion , ParameterDirection.Input)
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatModeloPlacasActualizar", parametros);
                    connection.Close();
                    respuesta = true;
                }
            } catch (Exception ex) {
                respuesta = false;
                Console.WriteLine(ex);
            }
            return respuesta;
        }

        //Metodo encargado de eliminar logicamente un modelo de una placa
        public bool EliminarModeloPlacas(CamposModeloPlacas campos) {

            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@idModeloCircuito", SqlDbType.Int, campos.idModeloCircuito , ParameterDirection.Input)
                        };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatModeloPlacasEliminar", parametros);
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
