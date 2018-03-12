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
    public class DatosMantenimientoEquipos
    {
        //public Mantenimiento LlenaTablaMantenimiento()
        //{
        //    Mantenimiento campos = new Mantenimiento();
        //    DataTable dt = new DataTable();
        //    List<CamposMantenimiento> ListaCamposMantenimiento = new List<CamposMantenimiento>();


        //    SqlConnection connection = null;
        //    try
        //    {
        //        using (connection = Conexion.ObtieneConexion("ConexionBD"))
        //        {
               
        //            SqlDataReader consulta;
        //            connection.Open();
        //            consulta = Ejecuta.ConsultaConRetorno(connection, "Usp_RepMantenimiento");
        //            dt.Load(consulta);
        //            connection.Close();
        //        }


        //        foreach (DataRow row in dt.Rows)
        //        {
        //            CamposMantenimiento reg = new CamposMantenimiento();
        //            reg.Maquina = new CamposMaquina();
        //            reg.MotivoMantenimiento = new CamposMotivoMantenimiento();
        //            reg.Personal = new CamposPersonal();
        //            reg.Departamento = new CamposDepartamento();
        //            reg.IdMantenimiento = Convert.ToInt32(row["idMantenimiento"].ToString());
        //            reg.Maquina.IdMaquina = Convert.ToInt32(row["idMaquina"].ToString());
        //            reg.Maquina.Descripcion = row["Descripcion"].ToString();
        //            reg.MotivoMantenimiento.Descripcion = row["descripcionMantenimiento"].ToString();
        //            reg.FechaALtaS = row["fecha"].ToString();
        //            reg.Personal.idPersonal = Convert.ToInt32(row["idPersonal"].ToString());
        //            reg.Personal.nombrePersonal = row["empleado"].ToString();
        //            reg.Departamento.nombreDepartamento = row["nombreDepartamento"].ToString();
        //            ListaCamposMantenimiento.Add(reg);
        //        }
        //        campos.ListaRegistrosMantenimiento = ListaCamposMantenimiento.ToArray();


        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);


        //    }

        //    return campos;

        //}


        public Mantenimiento LlenaTablaMantenimiento(string FechaInicio, string FechaFin, int ComboDepar)
        {
            Mantenimiento listadatos = new Mantenimiento();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposMantenimiento> composList = new List<CamposMantenimiento>();

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
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_RepMantenimiento", parametros);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {

                    CamposMantenimiento reg = new CamposMantenimiento();
                    reg.Maquina = new CamposMaquina();
                    reg.MotivoMantenimiento = new CamposMotivoMantenimiento();
                    reg.Personal = new CamposPersonal();
                    reg.Departamento = new CamposDepartamento();
                    reg.Departamento.nombreDepartamento = row["nombreDepartamento"].ToString();
                    reg.Maquina.Descripcion = row["Descripcion"].ToString();
                    reg.MotivoMantenimiento.Descripcion = row["descripcionMantenimiento"].ToString();
                    reg.FechaALtaS = row["fecha"].ToString();
                    reg.Personal.nombrePersonal = row["empleado"].ToString();
                    composList.Add(reg);
                }
                listadatos.ListaRegistrosMantenimiento = composList.ToArray();
               
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
