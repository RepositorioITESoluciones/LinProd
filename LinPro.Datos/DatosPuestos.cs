using System;
using System.Collections.Generic;
using LinPro.Entidades;
using LinPro.Framework.AccesoDatos;
using System.Data.SqlClient;
using System.Data;

namespace LinPro.Datos {
    public class DatosPuestos {

        //Metodo encargado de consultar para la tabla de puestos
        public Puestos LlenaTablaDatosPuestos() {
            Puestos listadatos = new Puestos();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposPuestos> composList = new List<CamposPuestos>();
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {

                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatPuestosMostrar", null);
                    dt.Load(consulta);
                    connection.Close();

                }
                foreach (DataRow row in dt.Rows) {
                    CamposPuestos reg = new CamposPuestos();
                    reg.idPuesto = Convert.ToInt32(row["idPuesto"].ToString());
                    reg.nombrePuesto = row["nombrePuesto"].ToString();
                    reg.descripcion = row["descripcionPuesto"].ToString();
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
        public bool InsertarPuestos(CamposPuestos campos) {

            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();
                    var parametros = new[]{
                    ParametroAcceso.CrearParametro("@nombre", SqlDbType.VarChar, campos.nombrePuesto , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, campos.descripcion , ParameterDirection.Input)
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatPuestosInsertar", parametros);
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
        public bool ActualizarPuestos(CamposPuestos campos) {
            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();

                    var parametros = new[]{
                    ParametroAcceso.CrearParametro("@idPuesto", SqlDbType.Int, campos.idPuesto , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@nombre", SqlDbType.VarChar, campos.nombrePuesto , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, campos.descripcion , ParameterDirection.Input)
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatPuestosActualizar", parametros);
                    connection.Close();
                    respuesta = true;
                }
            } catch (Exception ex) {
                respuesta = false;
                Console.WriteLine(ex);
            }
            return respuesta;
        }

        //    //Metodo encargado de eliminar logicamente un giro empresarial
        public bool EliminarPuestos(CamposPuestos campos) {

            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@idPuesto", SqlDbType.Int, campos.idPuesto , ParameterDirection.Input)
                        };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatPuestosEliminar", parametros);
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
