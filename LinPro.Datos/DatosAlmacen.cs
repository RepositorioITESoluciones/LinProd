using System;
using System.Collections.Generic;
using LinPro.Entidades;
using LinPro.Framework.AccesoDatos;
using System.Data.SqlClient;
using System.Data;

namespace LinPro.Datos {
    public class DatosAlmacen {

        //Metodo encargado de consultar un giro empresarial
        public Almacen LlenaTablaAlmacen() {
            Almacen listadatos = new Almacen();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposAlmacen> composList = new List<CamposAlmacen>();
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {

                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatAmacenMostrar", null);
                    dt.Load(consulta);
                    connection.Close();

                }
                foreach (DataRow row in dt.Rows) {
                    CamposAlmacen reg = new CamposAlmacen();

                    //Almacen
                    reg.idAlmacen = Convert.ToInt32(row["idAlmacen"].ToString());
                    reg.descripcion = row["descripcionAlmacen"].ToString();

                    //Tipo almacen
                    reg.idTipoAlmacen = Convert.ToInt32(row["idTipoAlmacen"].ToString());
                    reg.nombreTipoAlmacen = row["nombreTipoAlmacen"].ToString();

                    //Sucursal
                    reg.idSucursal = Convert.ToInt32(row["idSucursal"].ToString());
                    reg.nombreSucursal = row["nombreSucursal"].ToString();

                    composList.Add(reg);
                }
                listadatos.ListaRegistros = composList.ToArray();
            } catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }

        public Almacen LlenaComboSucursales() {
            Almacen listadatos = new Almacen();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposAlmacen> composList = new List<CamposAlmacen>();

            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {

                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CombSucursalMostrar", null);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows) {
                    CamposAlmacen reg = new CamposAlmacen();
                    reg.idSucursal = Convert.ToInt32(row["idSucursal"].ToString());
                    reg.nombreSucursal = row["nombre"].ToString();
                    composList.Add(reg);
                }
                listadatos.ListaRegistros = composList.ToArray();
            } catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }

        public Almacen LlenaComboTipoAlmacen() {
            Almacen listadatos = new Almacen();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposAlmacen> composList = new List<CamposAlmacen>();

            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {

                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CombTiposAlmacenMostrar", null);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows) {
                    CamposAlmacen reg = new CamposAlmacen();
                    reg.idTipoAlmacen = Convert.ToInt32(row["idTipoAlmacen"].ToString());
                    reg.nombreTipoAlmacen = row["nombreAlmacen"].ToString();
                    composList.Add(reg);
                }
                listadatos.ListaRegistros = composList.ToArray();
            } catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }


        ////Metodo encargado de insertar un giro empresarial
        public bool InsertarAlmacen(CamposAlmacen campos) {

            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();
                    var parametros = new[]{
                    ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, campos.descripcion , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@IdSucursal", SqlDbType.Int, campos.idSucursal , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@IdTipoAlmacen", SqlDbType.Int, campos.idTipoAlmacen , ParameterDirection.Input)

                };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatAlmacenInsertar", parametros);
                    connection.Close();
                    respuesta = true;
                }
            } catch (Exception ex) {
                respuesta = false;
                Console.WriteLine(ex);
            }
            return respuesta;
        }

        ////Metodo encargado de actualizar un giro empresarial
        public bool ActualizarAlmacen(CamposAlmacen campos) {
            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();

                    var parametros = new[]{
                         ParametroAcceso.CrearParametro("@idAlmacen", SqlDbType.Int, campos.idAlmacen , ParameterDirection.Input),
                         ParametroAcceso.CrearParametro("@idTipoAlmacen", SqlDbType.Int, campos.idTipoAlmacen , ParameterDirection.Input),
                       ParametroAcceso.CrearParametro("@idSucursal", SqlDbType.Int, campos.idSucursal , ParameterDirection.Input),
                         ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, campos.descripcion , ParameterDirection.Input)

                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatAlmacenActualizar", parametros);
                    connection.Close();
                    respuesta = true;
                }
            } catch (Exception ex) {
                respuesta = false;
                Console.WriteLine(ex);
            }
            return respuesta;
        }

        ////Metodo encargado de eliminar logicamente un giro empresarial
        public bool EliminarAlmacen(CamposAlmacen campos) {

            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();
                    var parametros = new[]{
                    ParametroAcceso.CrearParametro("@idAlmacen", SqlDbType.Int, campos.idAlmacen , ParameterDirection.Input),
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatAlmacenEliminar", parametros);
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
