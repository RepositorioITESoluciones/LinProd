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
    public class DatosSensores
    {
        public Sensores LlenaTablaSensores()
        {
            Sensores listadatos = new Sensores();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposSensores> camposList = new List<CamposSensores>();

            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "Usp_CatSensoresMostrar");
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposSensores reg = new CamposSensores();
                    reg.AgentesMedidos = new CamposAgentesM();
                    reg.PlacasSensores = new CamposPlacasSen();
                    reg.UnidadesMedida = new CamposUnidadesM();
                    reg.TipoMedidor = new CamposTiposMed();
                    reg.ModeloSensores = new CamposModeloSen();
                    reg.TipoSensor = new CamposTiposSen();

                    reg.IdSensor = Convert.ToInt32(row["IdSensor"].ToString());
                    reg.TipoSensor.IdTipoSensor = Convert.ToInt32(row["IdTipoSensor"].ToString());
                    reg.TipoSensor.Nombre = row["TipoSensor"].ToString();
                    reg.TipoMedidor.IdTipoMedidor = Convert.ToInt32(row["IdTipoMedidor"].ToString());
                    reg.TipoMedidor.Descripcion = row["Medidor"].ToString();
                    reg.NoSerie = row["NoSerie"].ToString();
                    reg.UnidadesMedida.IdUnidadMedida = Convert.ToInt32(row["IdUnidadMedida"].ToString());
                    reg.UnidadesMedida.Nombre = row["UnidadDeMedida"].ToString();
                    reg.AgentesMedidos.IdAgenteMedido = Convert.ToInt32(row["IdAgenteMedido"].ToString());
                    reg.AgentesMedidos.Nombre = row["AgenteMedido"].ToString();
                    // DateTime fechafinal = Convert.ToDateTime(row["FechaAlta"].ToString 
                    //reg.FechaAlta = Convert.ToDateTime(fechafinal.ToString("MMMM dd, yyyy"));
                    //reg.FechaAlta = Convert.ToDateTime(row["FechaAlta"].ToString());
                    reg.FechaALtaS = row["FechaAlta"].ToString();
                    reg.Descripcion = row["Descripcion"].ToString();
                    //DateTime fchIns = Convert.ToDateTime(row["FechaInstalacion"].ToString());
                    //reg.FechaInstalacion = Convert.ToDateTime(row["FechaInstalacion"].ToString());
                    //Convert.ToDateTime(fchIns.ToString("DD/MM/YYYY HH:mm:ss"));
                    //  reg.FechaInstalacion = Convert.ToDateTime(row["FechaInstalacion"].ToString());
                    reg.FechaInstalacionS = row["FechaInstalacion"].ToString();
                   reg.PlacasSensores.IdPlaca = Convert.ToInt32(row["IdPlaca"].ToString());
                    reg.PlacasSensores.Descripcion = row["Placa"].ToString();
                    reg.ModeloSensores.IdModeloSensor = Convert.ToInt32(row["IdModeloSensor"].ToString());
                    reg.ModeloSensores.Nombre = row["Modelo"].ToString();
                    reg.IntervaloLectura = Convert.ToInt32(row["IntervaloLectura"].ToString());
                    camposList.Add(reg);
                }
                listadatos.ListaRegSensores = camposList.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }
        public bool InsertaSensor(CamposSensores campos)
        {
            bool respuesta = false;
            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    var parametros = new[]
                     {
                        ParametroAcceso.CrearParametro("@IdTipoSensor", SqlDbType.Int, campos.TipoSensor.IdTipoSensor, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@IdTipoMedidor", SqlDbType.Int, campos.TipoMedidor.IdTipoMedidor, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@NSerie", SqlDbType.VarChar, campos.NoSerie, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@IdUnidadMedida", SqlDbType.Int, campos.UnidadesMedida.IdUnidadMedida, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@IdAgenteMedido", SqlDbType.Int, campos.AgentesMedidos.IdAgenteMedido, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@FechaAlta", SqlDbType.VarChar, campos.FechaALtaS, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@Descripcion", SqlDbType.VarChar, campos.Descripcion, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@FechaIns", SqlDbType.VarChar, campos.FechaInstalacionS, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@IdPlaca", SqlDbType.Int, campos.PlacasSensores.IdPlaca, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@IdModeloSensor", SqlDbType.Int, campos.ModeloSensores.IdModeloSensor, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@Intervalo", SqlDbType.Int, campos.IntervaloLectura, ParameterDirection.Input)

                };
                    Ejecuta.ProcedimientoAlmacenado(connection, "[Usp_CatSensorInsertar]", parametros);
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
        public bool ActualizarSensor(CamposSensores campos)
        {
           // Convert.ToDateTime(fchIns.ToString("DD/MM/YYYY HH:mm:ss"));
            bool respuesta = false;
            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    var parametros = new[]
                     {
                        ParametroAcceso.CrearParametro("@IdTipoSensor", SqlDbType.Int, campos.TipoSensor.IdTipoSensor, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@IdTipoMedidor", SqlDbType.Int, campos.TipoMedidor.IdTipoMedidor, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@NSerie", SqlDbType.VarChar, campos.NoSerie, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@IdUnidadMedida", SqlDbType.Int, campos.UnidadesMedida.IdUnidadMedida, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@IdAgenteMedido", SqlDbType.Int, campos.AgentesMedidos.IdAgenteMedido, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@FechaAlta", SqlDbType.VarChar, campos.FechaALtaS, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@Descripcion", SqlDbType.VarChar, campos.Descripcion, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@FechaIns", SqlDbType.VarChar, campos.FechaInstalacionS, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@IdPlaca", SqlDbType.Int, campos.PlacasSensores.IdPlaca, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@IdModeloSensor", SqlDbType.Int, campos.ModeloSensores.IdModeloSensor, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@Intervalo", SqlDbType.Int, campos.IntervaloLectura, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@IdSensor",SqlDbType.Int, campos.IdSensor, ParameterDirection.Input)
                };
                    Ejecuta.ProcedimientoAlmacenado(connection, "[Usp_CatSensorActualizar]", parametros);
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
        public bool EliminarSensor(int IdSensor)
        {

            bool respuesta = false;
            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    var parametros = new[]
                     {
                    ParametroAcceso.CrearParametro("@IdSensor", SqlDbType.Int, IdSensor , ParameterDirection.Input)

                };
                    Ejecuta.ProcedimientoAlmacenado(connection, "[Usp_CatSensorEliminar]", parametros);
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
        public TiposSensores LlenaComboTipoSensore()
        {
            TiposSensores campos = new TiposSensores();
            DataTable dt = new DataTable();
            List<CamposTiposSen> ListaCamposTipoSensor = new List<CamposTiposSen>();


            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "[Usp_ComboTipoSensor]");
                    dt.Load(consulta);
                    connection.Close();
                }


                foreach (DataRow row in dt.Rows)
                {
                    CamposTiposSen reg = new CamposTiposSen();
                    reg.IdTipoSensor = Convert.ToInt32(row["IdTipoSensor"].ToString());
                    reg.Nombre = row["NombreTipoSensor"].ToString();
                    ListaCamposTipoSensor.Add(reg);
                }
                campos.ListaRegTiposSen = ListaCamposTipoSensor.ToArray();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);


            }

            return campos;

        }
        public TiposMedidores LlenaComboTipoMedidores()
        {
            TiposMedidores campos = new TiposMedidores();
            DataTable dt = new DataTable();
            List<CamposTiposMed> ListaCamposTipoMed = new List<CamposTiposMed>();


            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "[Usp_ComboTipoMedidor]");
                    dt.Load(consulta);
                    connection.Close();
                }


                foreach (DataRow row in dt.Rows)
                {
                    CamposTiposMed reg = new CamposTiposMed();
                    reg.IdTipoMedidor = Convert.ToInt32(row["IdTipoMedidor"].ToString());
                    reg.Nombre = row["Nombre"].ToString();
                    ListaCamposTipoMed.Add(reg);
                }
                campos.ListaRegTiposMed = ListaCamposTipoMed.ToArray();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);


            }

            return campos;

        }
        public UnidadesMedida LlenaComboUnidadMedida()
        {
            UnidadesMedida campos = new UnidadesMedida();
            DataTable dt = new DataTable();
            List<CamposUnidadesM> ListaCamposUnidadMedida = new List<CamposUnidadesM>();


            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "[Usp_ComboUnidadesMedida]");
                    dt.Load(consulta);
                    connection.Close();
                }


                foreach (DataRow row in dt.Rows)
                {
                    CamposUnidadesM reg = new CamposUnidadesM();
                    reg.IdUnidadMedida = Convert.ToInt32(row["IdUnidadMedida"].ToString());
                    reg.Nombre = row["Nombre"].ToString();
                    ListaCamposUnidadMedida.Add(reg);
                }
                campos.ListaRegUnidadesM = ListaCamposUnidadMedida.ToArray();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);


            }

            return campos;

        }
        public AgentesMedidos LlenaComboAgentesMed()
        {
            AgentesMedidos campos = new AgentesMedidos();
            DataTable dt = new DataTable();
            List<CamposAgentesM> ListaCamposAgentesMed = new List<CamposAgentesM>();


            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "[Usp_ComboAgenteMedido]");
                    dt.Load(consulta);
                    connection.Close();
                }


                foreach (DataRow row in dt.Rows)
                {
                    CamposAgentesM reg = new CamposAgentesM();
                    reg.IdAgenteMedido = Convert.ToInt32(row["IdAgenteMedido"].ToString());
                    reg.Nombre = row["Nombre"].ToString();
                    ListaCamposAgentesMed.Add(reg);
                }
                campos.ListaRegAgentesM = ListaCamposAgentesMed.ToArray();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);


            }

            return campos;

        }
        public PlacasSensores LlenaComboPlacasSen()
        {
            PlacasSensores campos = new PlacasSensores();
            DataTable dt = new DataTable();
            List<CamposPlacasSen> ListaCamposPlacasSen = new List<CamposPlacasSen>();


            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "[Usp_ComboSensoresPlacas]");
                    dt.Load(consulta);
                    connection.Close();
                }


                foreach (DataRow row in dt.Rows)
                {
                    CamposPlacasSen reg = new CamposPlacasSen();
                    reg.IdPlaca = Convert.ToInt32(row["IdPlaca"].ToString());
                    reg.Descripcion = row["Descripcion"].ToString();
                    ListaCamposPlacasSen.Add(reg);
                }
                campos.ListaRegPlacasSen = ListaCamposPlacasSen.ToArray();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);


            }

            return campos;
        }
        public ModelosSensores LlenaComboModelosSen()
        {
            ModelosSensores campos = new ModelosSensores();
            DataTable dt = new DataTable();
            List<CamposModeloSen> ListaCamposModeloSen = new List<CamposModeloSen>();


            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "[Usp_ComboModeloSensor]");
                    dt.Load(consulta);
                    connection.Close();
                }


                foreach (DataRow row in dt.Rows)
                {
                    CamposModeloSen reg = new CamposModeloSen();
                    reg.IdModeloSensor = Convert.ToInt32(row["IdModeloSensor"].ToString());
                    reg.Nombre = row["Nombre"].ToString();
                    ListaCamposModeloSen.Add(reg);
                }
                campos.ListaRegModelosSen = ListaCamposModeloSen.ToArray();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);


            }

            return campos;

        }
    }
}
