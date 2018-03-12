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
   public    class DatosProyeccionesCalculadas
    {

        //[GraficaMejoraProduccion]
        //GraficaEufem
        public CalculoProduccion GraficaProyeccion(string fechaInicio, string fechaFin)
        {
            CalculoProduccion campos = new CalculoProduccion();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposCalculoProduccion> ListaCamposCalculo = new List<CamposCalculoProduccion>();


            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@fechaInicio", SqlDbType.VarChar, fechaInicio , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaFin", SqlDbType.VarChar, fechaFin , ParameterDirection.Input)
                                           };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "GraficaMejoraProduccion", parametros);
                    dt.Load(consulta);
                    connection.Close();

                }


                foreach (DataRow row in dt.Rows)
                {
                    CamposCalculoProduccion reg = new CamposCalculoProduccion();
                    reg.fechas = row["fechaMod"].ToString();
                    reg.Porcentaje = Convert.ToDouble(row["PORCENTAJE"].ToString());
                    reg.FechaCorta = row["fechax"].ToString();
                    ListaCamposCalculo.Add(reg);
                }
                campos.ListaRegistros = ListaCamposCalculo.ToArray();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);


            }

            return campos;

        }


        public CalculoProduccion GraficaEufem(string fechaInicio, string fechaFin)
        {
            CalculoProduccion campos = new CalculoProduccion();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposCalculoProduccion> ListaCamposCalculo = new List<CamposCalculoProduccion>();


            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@fechaInicio", SqlDbType.VarChar, fechaInicio , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaFin", SqlDbType.VarChar, fechaFin , ParameterDirection.Input)
                                           };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "GraficaMejoraProduccionxs", parametros);
                    dt.Load(consulta);
                    connection.Close();

                }


                foreach (DataRow row in dt.Rows)
                {
                    CamposCalculoProduccion reg = new CamposCalculoProduccion();
                    reg.fechas = row["fechaMod"].ToString();
                    reg.Porcentaje = Convert.ToDouble(row["PORCENTAJE"].ToString());
                    reg.FechaCorta = row["fechax"].ToString();
                    reg.PorcentajeS = row["Litros"].ToString();
                    ListaCamposCalculo.Add(reg);
                }
                campos.ListaRegistros = ListaCamposCalculo.ToArray();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);


            }

            return campos;

        }
    }
}
