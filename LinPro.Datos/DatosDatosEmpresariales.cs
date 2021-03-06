﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Entidades;
using LinPro.Framework.AccesoDatos;
using System.Data.SqlClient;
using System.Data;

namespace LinPro.Datos {
    public class DatosDatosEmpresariales {

        public DatosEmpresariales LlenaTablaDatosDE() {
            DatosEmpresariales listadatos = new DatosEmpresariales();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposDatosEmpresariales> composList = new List<CamposDatosEmpresariales>();

            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {

                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatDatosEmpresarialesConsultar", null);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows) {
                    CamposDatosEmpresariales reg = new CamposDatosEmpresariales();
                    reg.DatosFiscales = new CamposDatosFiscales();
                    reg.DatosFiscales.Estado = new CamposEstado();
                    reg.DatosFiscales.TipoPersona = new CamposTipoPersona();

                    reg.idEmpresa = Convert.ToInt32(row["idEmpresa"].ToString());
                    reg.nombre = row["nombreEmpresa"].ToString();
                    reg.fechaRegistro = row["fechaRegistro"].ToString();
                    reg.idGiro = Convert.ToInt32(row["idGiro"].ToString());
                    reg.idDatosFiscales = Convert.ToInt32(row["idDatosFiscales"].ToString());
                   
                    reg.DatosFiscales.RFC = row["RFC"].ToString();
                    reg.DatosFiscales.RazonSocial = row["razonSocial"].ToString();
                    reg.DatosFiscales.Calle = row["calle"].ToString();
                    reg.DatosFiscales.NumeroExterior = row["numeroExterior"].ToString();
                    reg.DatosFiscales.NumeroInterior = row["numeroInterior"].ToString();
                    reg.DatosFiscales.Estado.idEstado = Convert.ToInt32(row["idEstado"].ToString());
                    reg.DatosFiscales.C_CP = Convert.ToInt32(row["c_CP"].ToString());
                    reg.DatosFiscales.TipoPersona.IdTipoPersona = Convert.ToInt32(row["idTipoPersona"].ToString());
                    reg.DatosFiscales.TipoPersona.TipoPersona = row["tipoPersona"].ToString();
                    composList.Add(reg);

                }
                listadatos.ListaRegistros = composList.ToArray();
            } catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }

        public bool InsertaDatosEmpresariales(CamposDatosEmpresariales campos) {
            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();
                    var parametros = new[]
                     {
                    ParametroAcceso.CrearParametro("@nombre", SqlDbType.VarChar, campos.nombre , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@fechaRegistro", SqlDbType.DateTime, campos.fechaRegistro , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@idGiro", SqlDbType.Int, campos.idGiro , ParameterDirection.Input),

           
                    ParametroAcceso.CrearParametro("@razonSocial", SqlDbType.VarChar, campos.DatosFiscales.RazonSocial, ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@TipoPersona", SqlDbType.Int, campos.DatosFiscales.TipoPersona.IdTipoPersona, ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@RFC", SqlDbType.VarChar, campos.DatosFiscales.RFC, ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@Calle", SqlDbType.VarChar, campos.DatosFiscales.Calle, ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@numExt", SqlDbType.VarChar, campos.DatosFiscales.NumeroExterior, ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@numInt", SqlDbType.VarChar, campos.DatosFiscales.NumeroInterior, ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@CP", SqlDbType.Int, campos.DatosFiscales.C_CP, ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@Estado", SqlDbType.Int, campos.DatosFiscales.Estado.idEstado, ParameterDirection.Input)

                };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatDatosEmpresarialesInsertar", parametros);
                    connection.Close();
                }
                respuesta = true;
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }

            return respuesta;
        }


        public bool ActualizarDatosEmpresariales(CamposDatosEmpresariales campos) {
            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();
                    var parametros = new[]
                     {

                    ParametroAcceso.CrearParametro("@idEmpresa", SqlDbType.Int, campos.idEmpresa , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@nombre", SqlDbType.VarChar, campos.nombre , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@fechaRegistro", SqlDbType.DateTime, campos.fechaRegistro , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@idGiro", SqlDbType.Int, campos.idGiro , ParameterDirection.Input),

                    ParametroAcceso.CrearParametro("@razonSocial", SqlDbType.VarChar, campos.DatosFiscales.RazonSocial, ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@TipoPersona", SqlDbType.Int, campos.DatosFiscales.TipoPersona.IdTipoPersona, ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@RFC", SqlDbType.VarChar, campos.DatosFiscales.RFC, ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@Calle", SqlDbType.VarChar, campos.DatosFiscales.Calle, ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@numExt", SqlDbType.VarChar, campos.DatosFiscales.NumeroExterior, ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@numInt", SqlDbType.VarChar, campos.DatosFiscales.NumeroInterior, ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@CP", SqlDbType.Int, campos.DatosFiscales.C_CP, ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@Estado", SqlDbType.Int, campos.DatosFiscales.Estado.idEstado, ParameterDirection.Input)

                };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatDatosEmpresarialesActualizar", parametros);
                    connection.Close();
                }
                respuesta = true;
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }

            return respuesta;
        }

        public bool EliminaDatosEmpresariales(CamposDatosEmpresariales campos) {
            bool respuesta = false;
            SqlConnection connection = null;
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();
                    var parametros = new[]{
                     ParametroAcceso.CrearParametro("@idEmpresa", SqlDbType.Int, campos.idEmpresa , ParameterDirection.Input)
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatDatosEmpresarialesEliminar", parametros);
                    connection.Close();
                }
                respuesta = true;
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            return respuesta;
        }

        public bool ExisteRFC(CamposDatosEmpresariales campos) {
            
            SqlConnection connection = null;
            using (connection = Conexion.ObtieneConexion("ConexionBD")) {

                string query = " select count(*) " +
                    " from[Negocio].Empresas em " +
                    " INNER JOIN Comunes.DatosFiscales df " +
                    " on em.idDatosFiscales = df.idDatosFiscales " +
                    " where em.activo = 1 " +
                    " AND df.rfc = @rfc; ";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("rfc", campos.DatosFiscales.RFC);
                connection.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count >= 1)
                    return false;
                else
                    return true;
            }
        }








    }
}
