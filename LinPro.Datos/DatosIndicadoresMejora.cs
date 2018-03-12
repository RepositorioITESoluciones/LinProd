
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
    public class DatosIndicadoresMejora
    {
        public CalculoProduccion IndicadoresEficiencia(string FechaInicio, string FechaFin, int ComboDepar)
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
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_RepMejoras", parametros);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposCalculoProduccion reg = new CamposCalculoProduccion();
                    reg.maquina = new CamposMaquina();
                    reg.maquina.Descripcion = row["descripcion"].ToString();
                    reg.fechas = row["fecha"].ToString();
                    reg.piezasProducidas = Convert.ToInt32(row["piezasProducidas"].ToString());
                    reg.piezasDefectuosas = Convert.ToInt32(row["piezasDefectuosas"].ToString());
                    reg.PiezasBuenas = Convert.ToInt32(row["piezasBuenas"].ToString());
                    reg.eficiencia = Convert.ToDouble(row["eficiencia"].ToString());
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
