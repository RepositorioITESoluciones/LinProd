using LinPro.Framework.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Datos
{
    public class DatosLogin {
        // Método Consulta en la BD en List
        public static DataTable ObtieneUsuarios(String usuario, String contrasena) {
            DataTable Lecturas = new DataTable();
            SqlConnection connection = new SqlConnection();
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
                    connection.Open();
                    var parametros = new[]{
                    ParametroAcceso.CrearParametro("@nombreUsuario", SqlDbType.VarChar, usuario , ParameterDirection.Input),
                    ParametroAcceso.CrearParametro("@contrasena", SqlDbType.VarChar, contrasena , ParameterDirection.Input)
                    };
                    Lecturas = Ejecuta.EjecutarConsulta(connection, parametros, "[Validar].[Usp_InicioSesion]", true);
                    connection.Close();
                }
            } catch (Exception ex) {
                connection.Close();
                throw new Exception("Error en obtener los estados por máquina  \r\nError: " + ex.Message, ex);
            }
            return Lecturas;
        }
    }
}
