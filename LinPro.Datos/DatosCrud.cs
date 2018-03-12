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
    public class DatosCrud
    {


        public EntidadCrud LlenaTablaDatos()
        {
            EntidadCrud listadatos = new EntidadCrud();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposCrud> composList = new List<CamposCrud>();

            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "SELECT * FROM Ejemplo");
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    CamposCrud reg = new CamposCrud();
                    reg.idUsuario = Convert.ToInt32(row["idUsuario"].ToString());
                    reg.nombre = row["nombre"].ToString();
                    reg.apellidos = row["apellidos"].ToString();
                    reg.edad = Convert.ToInt32(row["edad"].ToString());
                    reg.email = row["email"].ToString();
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
        public bool InsertarDatos(CamposCrud campos)
        {

            bool respuesta = false;
            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    respuesta = Ejecuta.ConsultaSinRetorno1(connection, "INSERT INTO Ejemplo VALUES('"+ campos .nombre+ "','"+campos.apellidos+"',"+ campos.edad + ",'"+ campos.email+ "',"+campos.idArea+",'"+campos.fecha.ToString("dd/MM/yyyy HH:mm:ss")+"' )");
                    connection.Close();
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
               

            }

            return respuesta;


        }
        public bool ActualizarDatos(CamposCrud campos)
        {

            bool respuesta = false;
            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    respuesta = Ejecuta.ConsultaSinRetorno1(connection, "UPDATE Ejemplo SET nombre = '"+ campos.nombre + "',apellidos = '" + campos.apellidos + "',edad = " + campos.edad + ",email = '" + campos.email + "' WHERE idUsuario = "+campos.idUsuario);
                    connection.Close();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);


            }

            return respuesta;


        }
        public bool EliminarDatos(CamposCrud campos)
        {

            bool respuesta = false;
            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    respuesta = Ejecuta.ConsultaSinRetorno1(connection, "DELETE FROM Ejemplo WHERE idUsuario = " + campos.idUsuario);
                    connection.Close();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);


            }

            return respuesta;


        }

        public Area LlenaCombo()
        {
            Area campos = new Area();
            DataTable dt = new DataTable();
            List<CamposArea> composList = new List<CamposArea>();
            

            SqlConnection connection = null;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "SELECT idArea,descripcion FROM Areas");
                    dt.Load(consulta);
                    connection.Close();
                }


                foreach (DataRow row in dt.Rows)
                {
                    CamposArea reg = new CamposArea();
                    reg.idArea = Convert.ToInt32(row["idArea"].ToString());
                    reg.descripcion = row["descripcion"].ToString();
                    composList.Add(reg);
                }
                campos.listaReg = composList.ToArray();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);


            }

            return campos;
        }
    }
}
