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
    public class DatosProveedor
    {


        public Proveedor LlenaTablaDatos()
        {
            Proveedor listadatos = new Proveedor();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposProveedor> composList = new List<CamposProveedor>();

            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "Usp_CatProveedorMostrarInfo");
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposProveedor reg = new CamposProveedor();
                    reg.tipoProveedor = new CamposTipoProveedor();
                    reg.datosFiscales = new CamposDatosFiscales();
                    reg.tipoPersona = new CamposTipoPersona();
                    reg.estado = new CamposEstado();
                    reg.idProveedor = Convert.ToInt32(row["idProveedor"].ToString());
                    reg.tipoProveedor.idTipoProveedor = Convert.ToInt32(row["idTipoProveedor"].ToString());
                    reg.datosFiscales.IdDatosFiscales = Convert.ToInt32(row["idDatosFiscales"].ToString());
                    reg.fechaAlta = Convert.ToDateTime(row["fechaAlta"].ToString());
                    //reg.fechaBaja = Convert.ToDateTime(row["fechaBaja"].ToString());
                    reg.nombre = row["nombre"].ToString();
                    reg.tipoProveedor.descripcion = row["TipoProveedor"].ToString();
                    reg.datosFiscales.RFC = row["rfc"].ToString();
                    reg.datosFiscales.RazonSocial = row["razonSocial"].ToString(); 
                    reg.datosFiscales.C_CP = Convert.ToInt32(row["CodigoPostal"].ToString());
                    reg.datosFiscales.Calle = row["calle"].ToString();
                    reg.estado.idEstado = Convert.ToInt32(row["idEstado"].ToString());
                    reg.estado.descripcion = row["estado"].ToString();
                    reg.tipoPersona.IdTipoPersona = Convert.ToInt32(row["idTipoPersona"].ToString());
                    reg.datosFiscales.NumeroExterior = row["numeroExterior"].ToString();
                    reg.datosFiscales.NumeroInterior = row["numeroInterior"].ToString();
                    reg.tipoPersona.TipoPersona = row["TipoPersona"].ToString();

                    composList.Add(reg);
                }
                listadatos.listaProveedores = composList.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }

        public bool InsertaProveedorBySP(CamposProveedor campos)
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
                        ParametroAcceso.CrearParametro("@razonSocial", SqlDbType.VarChar, campos.datosFiscales.RazonSocial , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@RFC", SqlDbType.VarChar, campos.datosFiscales.RFC , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@TipoPersona", SqlDbType.Int, campos.tipoPersona.IdTipoPersona , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@Calle", SqlDbType.VarChar, campos.datosFiscales.Calle , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@numExt", SqlDbType.VarChar, campos.datosFiscales.NumeroExterior , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@numInt", SqlDbType.VarChar, campos.datosFiscales.NumeroInterior , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@CP", SqlDbType.Int, campos.datosFiscales.C_CP , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@Estado", SqlDbType.Int, campos.estado.idEstado , ParameterDirection.Input),

                        ParametroAcceso.CrearParametro("@nombre", SqlDbType.VarChar, campos.nombre, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idTipoProveedor", SqlDbType.Int, campos.tipoProveedor.idTipoProveedor , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaAlta", SqlDbType.DateTime, campos.fechaAlta , ParameterDirection.Input)
                };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatProveedorInsertar", parametros);
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

        public bool actualizarProveedorBySP(CamposProveedor campos)
        {
            bool respuesta = false;
            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    var parametros = new[]{
                       ParametroAcceso.CrearParametro("@razonSocial", SqlDbType.VarChar, campos.datosFiscales.RazonSocial , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@RFC", SqlDbType.VarChar, campos.datosFiscales.RFC , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@TipoPersona", SqlDbType.Int, campos.tipoPersona.IdTipoPersona , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@Calle", SqlDbType.VarChar, campos.datosFiscales.Calle , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@numExt", SqlDbType.VarChar, campos.datosFiscales.NumeroExterior , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@numInt", SqlDbType.VarChar, campos.datosFiscales.NumeroInterior , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@CP", SqlDbType.Int, campos.datosFiscales.C_CP , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@Estado", SqlDbType.Int, campos.estado.idEstado , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idDatosFiscales", SqlDbType.Int, campos.datosFiscales.IdDatosFiscales , ParameterDirection.Input),

                        ParametroAcceso.CrearParametro("@idProveedor", SqlDbType.Int, campos.idProveedor , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@nombre", SqlDbType.VarChar, campos.nombre, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@idTipoProveedor", SqlDbType.Int, campos.tipoProveedor.idTipoProveedor , ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaAlta", SqlDbType.DateTime,  campos.fechaAlta, ParameterDirection.Input),
                        ParametroAcceso.CrearParametro("@fechaBaja", SqlDbType.DateTime, campos.fechaBaja, ParameterDirection.Input)
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatProveedorActualiza", parametros);
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

        public bool EliminaProveedorBySP(int idProveedor)
        {
            bool respuesta = false;
            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    var parametros = new[]{
                        ParametroAcceso.CrearParametro("@idProveedor", SqlDbType.Int, idProveedor , ParameterDirection.Input)
                    };
                    Ejecuta.ProcedimientoAlmacenado(connection, "Usp_CatProveedorEliminar", parametros);
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

        public TipoProveedor LlenaComboTipoProveedor()
        {
            TipoProveedor campos = new TipoProveedor();
            DataTable dt = new DataTable();
            List<CamposTipoProveedor> composList = new List<CamposTipoProveedor>();
            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "Usp_ComboTipoProveedor");
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposTipoProveedor reg = new CamposTipoProveedor();
                    reg.idTipoProveedor = Convert.ToInt32(row["idTipoProveedor"].ToString());
                    reg.descripcion = row["descripcion"].ToString();
                    composList.Add(reg);
                }
                campos.listaRegTipoProveedor = composList.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return campos;
        }

        public TipoPersona LlenaComboTipoPersona()
        {
            TipoPersona campos = new TipoPersona();
            DataTable dt = new DataTable();
            List<CamposTipoPersona> composList = new List<CamposTipoPersona>();
            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "Usp_ComboTipoPersona");
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposTipoPersona reg = new CamposTipoPersona();
                    reg.IdTipoPersona = Convert.ToInt32(row["idTipoPersona"].ToString());
                    reg.TipoPersona = row["TipoPersona"].ToString();
                    composList.Add(reg);
                }
                campos.ListaRegTipoPersona = composList.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return campos;
        }

        public CodigoPostal LlenaComboCodigoPostal()
        {
            CodigoPostal campos = new CodigoPostal();
            DataTable dt = new DataTable();
            List<CamposCP> composList = new List<CamposCP>();
            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "Usp_TodosLosCPyEstados");
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposCP reg = new CamposCP();
                    reg.Estado = new CamposEstado();
                    reg.c_CP = Convert.ToInt32(row["c_CP"].ToString());
                    reg.Estado.idEstado = Convert.ToInt32(row["idEstado"].ToString());
                    reg.Estado.descripcion = row["descripcion"].ToString();
                    composList.Add(reg);
                }
                campos.ListaRegistroCP = composList.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return campos;
        }

        public Estado getEstadoByCP(int cp)
        {
            Estado listadatos = new Estado();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposEstado> composList = new List<CamposEstado>();
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    var parametros = new[]
                    {
                        ParametroAcceso.CrearParametro("@cp", SqlDbType.Int, cp , ParameterDirection.Input)
                     };
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_EstadoPorCP", parametros);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposEstado reg = new CamposEstado();
                    reg.idEstado = Convert.ToInt32(row["idEstado"].ToString());
                    reg.descripcion = row["descripcion"].ToString();

                    composList.Add(reg);
                }
                listadatos.ListaRegistrosEstado = composList.ToArray();
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
