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
    public class DatosModeloMaquina
    {


        public ModeloMaquina LlenaTablaDatos()
        {
            ModeloMaquina listadatos = new ModeloMaquina();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposModeloMaquina> composList = new List<CamposModeloMaquina>();

            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "Usp_CatModeloMaquinasMostrarInfo");
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposModeloMaquina reg = new CamposModeloMaquina();
                    reg.marca = new CamposMarcaMaquinaria();
                    reg.idModeloMaquina = Convert.ToInt32(row["idModelo"].ToString());
                    reg.nombre = row["modelo"].ToString();
                    reg.descripcion = row["descripcion"].ToString();
                    reg.anio = Convert.ToInt32(row["año"].ToString());
                    reg.marca.idMarca = Convert.ToInt32(row["idMarca"].ToString());
                    reg.marca.descripcion = row["marca"].ToString();
                    composList.Add(reg);
                }
                listadatos.listaModelos = composList.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }

        public bool InsertaModeloMaquinaBySP(CamposModeloMaquina campos)
        {
            bool respuesta = false;
            SqlConnection connection = null;
            SqlDataReader response = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    var parametros = new[]
                     {
                        ParametroAcceso.CrearParametro("@nombre", SqlDbType.VarChar, campos.nombre , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, campos.descripcion , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@anio", SqlDbType.Int, campos.anio , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@marca", SqlDbType.Int, campos.marca.idMarca , ParameterDirection.Input)
                };
                    response = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatModeloMaquinaInsertar", parametros);
                }
                    respuesta = true;
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return respuesta;
        }

        public bool actualizarModeloMaquinaBySP(CamposModeloMaquina campos)
        {
            bool respuesta = false;
            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@nombre", SqlDbType.VarChar, campos.nombre , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@descripcion", SqlDbType.VarChar, campos.descripcion , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@anio", SqlDbType.Int, campos.anio , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@marca", SqlDbType.Int, campos.marca.idMarca , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idModelo", SqlDbType.Int, campos.idModeloMaquina , ParameterDirection.Input)
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatModeloMaquinaActualizar", parametros);
                    connection.Close();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return respuesta;
        }

        public bool EliminaModeloMaquinaBySP(int idModeloMaquina)
        {
            bool respuesta = false;
            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@idModelo", SqlDbType.Int, idModeloMaquina , ParameterDirection.Input)
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatModeloMaquinaEliminar", parametros);
                    connection.Close();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return respuesta;
        }

       public MarcaMaquinaria LlenaComboMarca()
        {
            MarcaMaquinaria campos = new MarcaMaquinaria();
            DataTable dt = new DataTable();
            List<CamposMarcaMaquinaria> composList = new List<CamposMarcaMaquinaria>();

            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "Usp_CatModeloMaquinariaMostrarComboMarca");
                    dt.Load(consulta);
                    connection.Close();
                }


                foreach (DataRow row in dt.Rows)
                {
                    CamposMarcaMaquinaria reg = new CamposMarcaMaquinaria();
                    reg.idMarca = Convert.ToInt32(row["idMarca"].ToString());
                    reg.descripcion = row["descripcion"].ToString();
                    composList.Add(reg);
                }
                campos.listaMarca = composList.ToArray();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return campos;
        }

    }
}
