using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using System.Data;
using LinPro.Entidades;

namespace LinPro.Negocio {
    public class NegocioLogin {

        public String ObtieneUsuarios(String usuario, String contrasena) {
            try {
                DataTable dt = DatosLogin.ObtieneUsuarios(usuario, contrasena);
                List<Usuario> List = new List<Usuario>();
                Usuario tr = new Usuario();

                foreach (DataRow row in dt.Rows) {
                    tr.idPersonal = Convert.ToInt32(row["idPersonal"].ToString());
                    tr.nombre = row["nombre"].ToString();
                    tr.apPaterno = row["apPaterno"].ToString();
                    List.Add(tr);
                }

                if (List.Count == 0) {
                    return "Error";
                } else {
                    return tr.nombre + " " + tr.apPaterno;
                }
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
