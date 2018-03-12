
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
    public class DatosEnergiaXEquipos
    {
        //public CalculoProduccion LlenaTablaEnergiaXEquipos(int idDepartamento, string fechaInicio, string fechaFin)
        //{
        //    CalculoProduccion campos = new CalculoProduccion();
        //    DataTable dt = new DataTable();
        //    SqlConnection connection = null;
        //    List<CamposCalculoProduccion> composList = new List<CamposCalculoProduccion>();

          
        //    try
        //    {
        //        using (connection = Conexion.ObtieneConexion("ConexionBD"))
        //        {
        //            SqlDataReader consulta;
        //            connection.Open();
        //            var parametros = new[]{
        //                ParametroAcceso.CrearParametro("@fechaInicio", SqlDbType.VarChar, fechaInicio , ParameterDirection.Input),
        //                ParametroAcceso.CrearParametro("@fechaFin", SqlDbType.VarChar, fechaFin , ParameterDirection.Input),
        //                ParametroAcceso.CrearParametro("@idDepartamento", SqlDbType.Int, idDepartamento , ParameterDirection.Input),
        //            };
        //            consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_RepEnergia", parametros);
        //            dt.Load(consulta);
        //            connection.Close();
                   
        //        }


        //        foreach (DataRow row in dt.Rows)
        //        {
        //            CamposCalculoProduccion reg = new CamposCalculoProduccion();
        //            reg.maquina = new CamposMaquina();
        //            reg.departamento = new CamposDepartamento();
        //            reg.departamento.nombreDepartamento = row["nombreDepartamento"].ToString();
        //            reg.maquina.Descripcion = row["Descripcion"].ToString();
        //            reg.KWH_pza = Convert.ToDouble(row["KWH_pza"].ToString());
        //            reg.KWH_turno = Convert.ToDouble(row["KWH_turno"].ToString());
        //            reg.fechas = row["fecha"].ToString();
        //            ListaCamposCalculo.Add(reg);
        //        }
        //        campos.ListaRegistros = ListaCamposCalculo.ToArray();


        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);


        //    }

        //    return campos;

        //}

        public CalculoProduccion EnergiaXEquipos(string FechaInicio, string FechaFin, int ComboDepar)
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
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_RepEnergia", parametros);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposCalculoProduccion reg = new CamposCalculoProduccion();
                    reg.maquina = new CamposMaquina();
                    reg.departamento = new CamposDepartamento();
                    reg.departamento.nombreDepartamento = row["nombreDepartamento"].ToString();
                    reg.maquina.Descripcion = row["Descripcion"].ToString();
                    reg.KWH_pza = Convert.ToDouble(row["KWH_pza"].ToString());
                    reg.KWH_turno = Convert.ToDouble(row["KWH_turno"].ToString());
                    reg.fechas = row["fecha"].ToString();
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
