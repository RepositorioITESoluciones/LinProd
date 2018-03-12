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
   public class DatosMaquina
    {

        public Maquina LlenaTablaMaquina()
        {
            Maquina listadatos = new Maquina();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposMaquina> camposList = new List<CamposMaquina>();

            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "[Usp_CatMaquinasMostrar]");
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposMaquina reg = new CamposMaquina();
                    reg.CamposPlaca = new CamposPlaca();
                    reg.MarcasMaquina = new CamposMarcasMaquina();
                    reg.EtatusMaquina = new CamposEtatusMaquina();
                    reg.NavesIndus = new CamposNavesIndus();
                    reg.IdMaquina = Convert.ToInt32(row["idMaquina"].ToString());
                    reg.Descripcion = row["Maquina"].ToString();
                    reg.MarcasMaquina.IdMarca = Convert.ToInt32(row["IdMarca"].ToString());
                    reg.MarcasMaquina.Descripcion  = row["Marca"].ToString();
                    reg.Año = Convert.ToInt32(row["año"].ToString());
                    reg.NoSerie = row["noSerie"].ToString();
                    reg.NavesIndus.IdNave = Convert.ToInt32(row["idNave"].ToString());
                    reg.NavesIndus.DescripcionNave = row["Nave"].ToString();
                    reg.EtatusMaquina.Descripcion = row["Estatus"].ToString();
                    reg.CamposPlaca.Descripcion = row["Placa"].ToString();
                    reg.CamposPlaca.IdPlaca = Convert.ToInt32(row["idPlaca"].ToString());

                    camposList.Add(reg);
                }
                listadatos.ListaRegistrosMaquina = camposList.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }
        public Placa ComboPlaca()
        {
            Placa campos = new Placa();
            DataTable dt = new DataTable();
            List<CamposPlaca> ListaCamposPlaca = new List<CamposPlaca>();


            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "[Usp_ComboPlaca]");
                    dt.Load(consulta);
                    connection.Close();
                }


                foreach (DataRow row in dt.Rows)
                {
                    CamposPlaca reg = new CamposPlaca();
                    reg.IdPlaca = Convert.ToInt32(row["IdPlaca"].ToString());
                    reg.Descripcion = row["Descripcion"].ToString();
                    ListaCamposPlaca.Add(reg);
                }
                campos.ListaRegPlaca = ListaCamposPlaca.ToArray();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);


            }

            return campos;

        }
        public NavesIndustriales ComboNave()
        {
            NavesIndustriales campos = new NavesIndustriales();
            DataTable dt = new DataTable();
            List<CamposNavesIndus> ListaCamposNave = new List<CamposNavesIndus>();


            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "[Usp_ComboNave]");
                    dt.Load(consulta);
                    connection.Close();
                }


                foreach (DataRow row in dt.Rows)
                {
                    CamposNavesIndus reg = new CamposNavesIndus();
                    reg.IdNave = Convert.ToInt32(row["IdNave"].ToString());
                    reg.DescripcionNave = row["DescripcionNave"].ToString();
                    ListaCamposNave.Add(reg);
                }
                campos.ListaRegNavesIndus = ListaCamposNave.ToArray();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);


            }

            return campos;

        }
        public MarcasMaquina ComboMarcasMaq()
        {
            MarcasMaquina campos = new MarcasMaquina();
            DataTable dt = new DataTable();
            List<CamposMarcasMaquina> ListaCamposMarcas = new List<CamposMarcasMaquina>();


            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "[Usp_ComboMarcasMaq]");
                    dt.Load(consulta);
                    connection.Close();
                }


                foreach (DataRow row in dt.Rows)
                {
                    CamposMarcasMaquina reg = new CamposMarcasMaquina();
                    reg.IdMarca = Convert.ToInt32(row["IdMarca"].ToString());
                    reg.Descripcion = row["Descripcion"].ToString();
                    ListaCamposMarcas.Add(reg);
                }
                campos.ListaRegMarcasMaq = ListaCamposMarcas.ToArray();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);


            }

            return campos;

        }

        public Maquina LlenaMaquina(int idDepartamento)
        {
                 Maquina campos = new Maquina();
                DataTable dt = new DataTable();
                List<CamposMaquina> ListaRegistros = new List<CamposMaquina>();


                SqlConnection connection = null;
                try
                {
                    using (connection = Conexion.ObtieneConexion("ConexionBD"))
                    {
                       // SqlDataReader consulta;
                        connection.Open();
                        var parametros = new[]{
                     ParametroAcceso.CrearParametro("@idDepartamento", SqlDbType.Int , idDepartamento , ParameterDirection.Input)
                    };
                        //consulta = Ejecuta.ConsultaConRetorno(connection, "Usp_CombCP", parametros);
                        DataTable prueba = Ejecuta.EjecutarConsulta(connection, parametros, "Usp_CombMaq");
                        dt = prueba;
                        connection.Close();
                    }


                    foreach (DataRow row in dt.Rows)
                    {
                        CamposMaquina reg = new CamposMaquina();
                        reg.IdMaquina = Convert.ToInt32(row["idMaquina"].ToString());
                        reg.Descripcion = row["descripcion"].ToString();
                        ListaRegistros.Add(reg);
                    }
                    campos.ListaRegistrosMaquina = ListaRegistros.ToArray();


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);


                }

                return campos;

            
        }
        public bool InsertaMaquina(CamposMaquina campos)
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
                    ParametroAcceso.CrearParametro("@Descripcion", SqlDbType.VarChar, campos.Descripcion , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@IdMarca", SqlDbType.Int, campos.MarcasMaquina.IdMarca , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@Año", SqlDbType.Int, campos.Año, ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@noSerie", SqlDbType.VarChar, campos.NoSerie , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@idNave", SqlDbType.Int, campos.NavesIndus.IdNave , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@idPlaca", SqlDbType.Int, campos.CamposPlaca.IdPlaca , ParameterDirection.Input)


                };
                    Ejecuta.ProcedimientoAlmacenado(connection, "[Usp_CatMaquinaInsertar]", parametros);
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
        public bool ActualizaMaquina(CamposMaquina campos)
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
                    ParametroAcceso.CrearParametro("@idMaquina", SqlDbType.Int, campos.IdMaquina , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@Descripcion", SqlDbType.VarChar, campos.Descripcion , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@IdMarca", SqlDbType.Int, campos.MarcasMaquina.IdMarca , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@Año", SqlDbType.Int, campos.Año, ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@noSerie", SqlDbType.VarChar, campos.NoSerie , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@idNave", SqlDbType.Int, campos.NavesIndus.IdNave , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@idPlaca", SqlDbType.Int, campos.CamposPlaca.IdPlaca , ParameterDirection.Input)


                };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatMaquinaActualizar", parametros);
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
        public bool EliminarMaquina(int IdMaquina)
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
                    ParametroAcceso.CrearParametro("@IdMaquina", SqlDbType.Int, IdMaquina , ParameterDirection.Input)
                  
                };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatMaquinaEliminar", parametros);
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
    }
}
