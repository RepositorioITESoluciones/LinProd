using System;
using System.Collections.Generic;
using LinPro.Entidades;
using LinPro.Framework.AccesoDatos;
using System.Data.SqlClient;
using System.Data;

namespace LinPro.Datos {
    public class DatosMaquinariaDispositivosMedicion {

        public MaquinariaDispositivosMedicion ConsultarMaqinariaPlacas() {
            MaquinariaDispositivosMedicion listadatos = new MaquinariaDispositivosMedicion();
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            List<CamposMaquinariaDispositivosMedicion> composList = new List<CamposMaquinariaDispositivosMedicion>();
            try {
                using (connection = Conexion.ObtieneConexion("ConexionBD")) {
             
                    SqlDataReader consulta;
                    connection.Open();
                    consulta = Ejecuta.ProcedimientoAlmacenado(connection, "Usp_MaquinariaPlacasMostrar", null);
                    dt.Load(consulta);
                    connection.Close();
                }
                foreach (DataRow row in dt.Rows) {
                    CamposMaquinariaDispositivosMedicion reg = new CamposMaquinariaDispositivosMedicion();
                    reg.idPlaca = Convert.ToInt32(row["idPlaca"].ToString());
                    reg.nombrePlaca = row["nombrePlaca"].ToString();

                    reg.idMaquina = Convert.ToInt32(row["idMaquina"].ToString());
                    reg.nombreMaquina = row["nombreMaquina"].ToString();

                    composList.Add(reg);
                }
                listadatos.ListaRegistros = composList.ToArray();
            } catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            return listadatos;
        }
    }
}
