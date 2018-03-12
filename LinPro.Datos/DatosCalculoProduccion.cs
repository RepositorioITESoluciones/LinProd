using System;
using System.Collections.Generic;
using LinPro.Entidades;
using LinPro.Framework.AccesoDatos;
using System.Data.SqlClient;
using System.Data;

namespace LinPro.Datos {
    public class DatosCalculoProduccion {


        public CalculoProduccion reporteOEE() {
            CalculoProduccion listadatos = new CalculoProduccion();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposCalculoProduccion> composList = new List<CamposCalculoProduccion>();

            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {

                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_ReporteOEE", null);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows) {
                    CamposCalculoProduccion reg = new CamposCalculoProduccion();
                    reg.OEE = Convert.ToDouble(row["OEE"].ToString());
                    reg.mes = row["mes"].ToString();
                    composList.Add(reg);
                }
                listadatos.ListaRegistros = composList.ToArray();
            } catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }
        public CalculoProduccion reporteEficienciaMaquinaPeriodoFinal(string fechaInicio, string fechaFin, int idMaquina) {
            CalculoProduccion listadatos = new CalculoProduccion();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposCalculoProduccion> composList = new List<CamposCalculoProduccion>();

            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {

                    SqlDataReader consulta;
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@fechaInicio", SqlDbType.VarChar, fechaInicio , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaFin", SqlDbType.VarChar, fechaFin , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idMaquina", SqlDbType.Int, idMaquina , ParameterDirection.Input),
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_ReporteEficienciaPeriodoPorMaquina", parametros);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows) {
                    CamposCalculoProduccion reg = new CamposCalculoProduccion();
                    reg.eficiencia = Convert.ToDouble(row["eficiencia"].ToString());
                    composList.Add(reg);
                }
                listadatos.ListaRegistros = composList.ToArray();
            } catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }
        public CalculoProduccion departamento() {
            CalculoProduccion listadatos = new CalculoProduccion();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposCalculoProduccion> composList = new List<CamposCalculoProduccion>();

            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {

                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_DepartamentosComboMostrar", null);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows) {
                    CamposCalculoProduccion reg = new CamposCalculoProduccion();
                    reg.departamento = new CamposDepartamento();
                    reg.departamento.idDepartamento = Convert.ToInt32(row["idDepartamento"].ToString());
                    reg.departamento.nombreDepartamento = row["nombreDepartamento"].ToString();
                    composList.Add(reg);
                }
                listadatos.ListaRegistros = composList.ToArray();
            } catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }
        public CalculoProduccion reporteEficienciaMaquinaPeriodo(int idDepartamento) {
            CalculoProduccion listadatos = new CalculoProduccion();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposCalculoProduccion> composList = new List<CamposCalculoProduccion>();

            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {

                    SqlDataReader consulta;
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@idDepartamento", SqlDbType.Int, idDepartamento , ParameterDirection.Input),
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_MaquinasXDepartamentosComboMostrar", parametros);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows) {
                    CamposCalculoProduccion reg = new CamposCalculoProduccion();
                    reg.departamento = new CamposDepartamento();
                    reg.maquina = new CamposMaquina();
                    reg.departamento.idDepartamento = Convert.ToInt32(row["idDepartamento"].ToString());
                    reg.departamento.nombreDepartamento = row["nombreDepartamento"].ToString();
                    reg.idMaquina = Convert.ToInt32(row["idMaquina"].ToString());
                    reg.maquina.Descripcion = row["descripcion"].ToString();
                    composList.Add(reg);
                }
                listadatos.ListaRegistros = composList.ToArray();
            } catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }
        public CalculoProduccion ReporteOEEPorDepartamento(string FechaInicio, string FechaFin, int ComboDepar)
        {
            CalculoProduccion listadatos = new CalculoProduccion();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposCalculoProduccion> composList = new List<CamposCalculoProduccion>();

            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {

                    SqlDataReader consulta;
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@fechaInicio", SqlDbType.VarChar, FechaInicio , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaFin", SqlDbType.VarChar, FechaFin , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idDepartamento", SqlDbType.Int, ComboDepar , ParameterDirection.Input),
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_RepOEEPorDepartamento", parametros);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposCalculoProduccion reg = new CamposCalculoProduccion();
                    reg.departamento = new CamposDepartamento();
                    reg.departamento.nombreDepartamento = row["DEPARTAMENTO"].ToString();
                    reg.Porcentaje = Convert.ToDouble(row["OEE"].ToString());
                    reg.FechaCorta = row["FECHA"].ToString();

                    composList.Add(reg);
                }
                listadatos.ListaRegistros = composList.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }
        //public CalculoProduccion LlenaReporteMaquinasEnProduccion() {
        //    CalculoProduccion listadatos = new CalculoProduccion();
        //    DataTable dt = new DataTable();
        //    SqlConnection connection = null;
        //    List<CamposCalculoProduccion> composList = new List<CamposCalculoProduccion>();

        //    try {
        //        using (connection = Conexion.ObtieneConexion("ConexionBD")) {
        //            SqlDataReader consulta;
        //            connection.Open();
        //            consulta = Ejecuta.ConsultaConRetorno(connection, "Usp_RepOMaquinasEnProduccion");
        //            dt.Load(consulta);
        //            connection.Close();
        //        }
        //        foreach (DataRow row in dt.Rows) {
        //            CamposCalculoProduccion reg = new CamposCalculoProduccion();
        //            reg.maquina = new CamposMaquina();
        //            reg.fecha = Convert.ToDateTime(row["fecha"].ToString());
        //            reg.maquina.Descripcion = row["maquina"].ToString();
        //            reg.maquinaEnProduccionHoras = Convert.ToInt32(row["horas"].ToString());

        //            composList.Add(reg);
        //        }
        //        listadatos.ListaRegistros = composList.ToArray();
        //    } catch (Exception e) {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //    return listadatos;
        //}
        public CalculoProduccion ReporteMaquinasEnProduccion(string FechaInicio, string FechaFin, int ComboDepar)
        {
            CalculoProduccion listadatos = new CalculoProduccion();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposCalculoProduccion> composList = new List<CamposCalculoProduccion>();

            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {

                    SqlDataReader consulta;
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@fechaInicio", SqlDbType.VarChar, FechaInicio , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaFin", SqlDbType.VarChar, FechaFin , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idDepartamento", SqlDbType.Int, ComboDepar , ParameterDirection.Input),
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_RepOMaquinasEnProduccion", parametros);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposCalculoProduccion reg = new CamposCalculoProduccion();
                    reg.maquina = new CamposMaquina();
                    reg.fecha = Convert.ToDateTime(row["fecha"].ToString());
                    reg.maquina.Descripcion = row["maquina"].ToString();
                    reg.maquinaEnProduccionHoras = Convert.ToInt32(row["Horas"].ToString());

                    composList.Add(reg);
                }
                listadatos.ListaRegistros = composList.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }

        public CalculoProduccion reportePiezasDefectuosas(string FechaInicio, string FechaFin, int ComboDepar)
        {
            CalculoProduccion listadatos = new CalculoProduccion();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposCalculoProduccion> composList = new List<CamposCalculoProduccion>();

            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {

                    SqlDataReader consulta;
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@fechaInicio", SqlDbType.VarChar, FechaInicio , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaFin", SqlDbType.VarChar, FechaFin , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idDepartamento", SqlDbType.Int, ComboDepar , ParameterDirection.Input),
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_ReportePiezasDefectuosas", parametros);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposCalculoProduccion reg = new CamposCalculoProduccion();
                    reg.departamento = new CamposDepartamento();
                    reg.maquina = new CamposMaquina();
                    reg.idMaquina = Convert.ToInt32(row["idMaquina"].ToString());
                    reg.maquina.Descripcion = row["descripcion"].ToString();
                    reg.piezasDefectuosas = Convert.ToInt32(row["piezasDefectuosas"].ToString());
                    reg.piezasProducidas = Convert.ToInt32(row["piezasaProducidas"].ToString());
                    composList.Add(reg);
                }
                listadatos.ListaRegistros = composList.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }
        public CalculoProduccion reporteTiempoInactivo(string FechaInicio, string FechaFin, int ComboDepar)
        {
            CalculoProduccion listadatos = new CalculoProduccion();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposCalculoProduccion> composList = new List<CamposCalculoProduccion>();

            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {

                    SqlDataReader consulta;
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@fechaInicio", SqlDbType.VarChar, FechaInicio , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaFin", SqlDbType.VarChar, FechaFin , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idDepartamento", SqlDbType.Int, ComboDepar , ParameterDirection.Input),
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_ReporteTiempoInactivo", parametros);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposCalculoProduccion reg = new CamposCalculoProduccion();
                    reg.departamento = new CamposDepartamento();
                    reg.maquina = new CamposMaquina();
                    reg.idMaquina = Convert.ToInt32(row["idMaquina"].ToString());
                    reg.maquina.Descripcion = row["descripcion"].ToString();
                    reg.maquiaEnProduccion = row["activo"].ToString();
                    reg.maquinaInactiva = row["inactivo"].ToString();
                    composList.Add(reg);
                }
                listadatos.ListaRegistros = composList.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }
        public CalculoProduccion LlenaReporteCostoPzaPorMaquina(string FechaInicio, string FechaFin, int ComboDepar)
        {
            CalculoProduccion listadatos = new CalculoProduccion();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposCalculoProduccion> composList = new List<CamposCalculoProduccion>();

            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {

                    SqlDataReader consulta;
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@fechaInicio", SqlDbType.VarChar, FechaInicio , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaFin", SqlDbType.VarChar, FechaFin , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idDepartamento", SqlDbType.Int, ComboDepar , ParameterDirection.Input),
                    };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_RepCostoPiezaPorMaquina", parametros);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposCalculoProduccion reg = new CamposCalculoProduccion();
                    reg.maquina = new CamposMaquina();
                    reg.fecha = Convert.ToDateTime(row["fecha"].ToString());
                    reg.maquina.Descripcion = row["descripcion"].ToString();
                    reg.piezasProducidas = Convert.ToInt16(row["piezasProducidas"].ToString());
                    reg.costoPza = Convert.ToDouble(row["costoPza"].ToString());
                    reg.eficiencia = Convert.ToDouble(row["Total"].ToString());

                    composList.Add(reg);
                }
                listadatos.ListaRegistros = composList.ToArray();
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
