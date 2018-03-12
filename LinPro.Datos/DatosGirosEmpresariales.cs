using System;
using System.Collections.Generic;
using LinPro.Entidades;
using LinPro.Framework.AccesoDatos;
using System.Data.SqlClient;
using System.Data;

namespace LinPro.Datos {
    public class DatosGirosEmpresariales {

        //Metodo encargado de consultar un giro empresarial
        public Giros LlenaTablaDatosGE() {
            Giros listadatos = new Giros();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposGirosEmpresariales> composList = new List<CamposGirosEmpresariales>();
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {

                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatGiroEmpresarialConsultar", null);
                    dt.Load(consulta);
                    connection.Close();

                }
                foreach (DataRow row in dt.Rows) {
                    CamposGirosEmpresariales reg = new CamposGirosEmpresariales();
                    reg.idGiro = Convert.ToInt32(row["idGiro"].ToString());
                    reg.nombre = row["nombre"].ToString();
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
        public bool InsertarGirosEmpresariales(CamposGirosEmpresariales campos) {

            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();
                    var parametros = new[]{
                    ParametroAcceso.CrearParametro("@nombre", SqlDbType.VarChar, campos.nombre , ParameterDirection.Input)
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatGiroEmpresarialInsertar", parametros);
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
        public bool ActualizarGirosEmpresariales(CamposGirosEmpresariales campos) {
            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();

                    var parametros = new[]{
                    ParametroAcceso.CrearParametro("@nombre", SqlDbType.VarChar, campos.nombre , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@idGiro", SqlDbType.Int, campos.idGiro , ParameterDirection.Input)
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatGiroEmpresarialActualizar", parametros);
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
        public bool EliminarGirosEmpresariales(CamposGirosEmpresariales campos) {

            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();
                    var parametros = new[]{
                    ParametroAcceso.CrearParametro("@idGiro", SqlDbType.Int, campos.idGiro , ParameterDirection.Input)
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatGiroEmpresarialEliminar", parametros);
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
