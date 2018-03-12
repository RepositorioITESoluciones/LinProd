using System;
using System.Collections.Generic;
using LinPro.Entidades;
using LinPro.Framework.AccesoDatos;
using System.Data.SqlClient;
using System.Data;

namespace LinPro.Datos {
    public class DatosPlacas {

        //Metodo encargado de consultar para la tabla de Placas
        public Placas LlenaTablaDatosPlacas() {
            Placas listadatos = new Placas();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposPlacas> composList = new List<CamposPlacas>();
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatPlacasMostrar", null);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows) {
                    CamposPlacas reg = new CamposPlacas();
                    reg.idPlaca = Convert.ToInt32(row["idPlaca"].ToString());
                    reg.direccionMACEquipo = row["direccionMACEquipo"].ToString();
                    reg.fechaAlta = row["fechaAlta"].ToString();
                    reg.fechaBaja = row["fechaBaja"].ToString();
                    reg.descripcion = row["descripcion"].ToString();
                    reg.direccionIp = row["direccionIP"].ToString();
                    reg.idModeloCircuito = Convert.ToInt32(row["idModeloPlaca"].ToString());
                    reg.nombreModeloCircuito = row["nombreModeloCircuito"].ToString();
                    reg.numeroSerie = row["noSerie"].ToString();
                    composList.Add(reg);
                }
                listadatos.ListaRegistros = composList.ToArray();
            } catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }


        //Metodo encargado de llenar el combo de modelo de placas 
        public Placas LlenaComboModeloPlacaDatos() {
            Placas listadatos = new Placas();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposPlacas> composList = new List<CamposPlacas>();
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatModeloPlacasMostrar", null);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows) {
                    CamposPlacas reg = new CamposPlacas();
                    reg.idModeloCircuito = Convert.ToInt32(row["idModeloPlaca"].ToString());
                    reg.nombreModeloCircuito = row["nombre"].ToString();
                    composList.Add(reg);
                }
                listadatos.ListaRegistros = composList.ToArray();
            } catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }


        //Metodo encargado de insertar una placa
        public bool InsertarPlacas(CamposPlacas campos) {
            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@direccionMAC", SqlDbType.VarChar, campos.direccionMACEquipo , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaAlta", SqlDbType.DateTime, campos.fechaAlta , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaBaja", SqlDbType.DateTime, campos.fechaBaja , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, campos.descripcion , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@direccionIP", SqlDbType.VarChar, campos.direccionIp , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idModeloCircuito", SqlDbType.Int, campos.idModeloCircuito , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@noSerie", SqlDbType.VarChar, campos.numeroSerie  , ParameterDirection.Input)
                        };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatPlacasInsertar", parametros);
                    connection.Close();
                    respuesta = true;
                }
            } catch (Exception ex) {
                respuesta = false;
                Console.WriteLine(ex);
            }
            return respuesta;
        }


        //Metodo encargado de actualizar una placa
        public bool actualizarPlacas(CamposPlacas campos) {
            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("conexionbd")) {
                    connection.Open();
                   

                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@idPlaca", SqlDbType.Int, campos.idPlaca , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@direccionMAC", SqlDbType.VarChar, campos.direccionMACEquipo , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaAlta", SqlDbType.DateTime, campos.fechaAlta , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaBaja", SqlDbType.DateTime, campos.fechaBaja , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, campos.descripcion , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@direccionIP", SqlDbType.VarChar, campos.direccionIp , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idModeloCircuito", SqlDbType.Int, campos.idModeloCircuito , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@noSerie", SqlDbType.VarChar, campos.numeroSerie  , ParameterDirection.Input)
                        };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatPlacasActualizar", parametros);
                    connection.Close();
                    respuesta = true;
                    respuesta = true;
                }
            } catch (Exception ex) {
                respuesta = false;
                Console.WriteLine(ex);
            }
            return respuesta;
        }


        //Metodo encargado de eliminar logicamente una placa
        public bool EliminarPlacas(CamposPlacas campos) {
            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@idPlaca", SqlDbType.Int, campos.idPlaca , ParameterDirection.Input)
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatPlacasEliminar", parametros);
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
