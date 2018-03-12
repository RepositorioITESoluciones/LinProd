using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio {
    public class NegocioPlacas {

        DatosPlacas clasedatos = new DatosPlacas();

        public Placas LlenaTablaPlacas() {
            Placas listadatos;
            listadatos = clasedatos.LlenaTablaDatosPlacas();
            return listadatos;
        }
        public Placas LlenaComboModeloPlacaDatos() {
            Placas listadatos;
            listadatos = clasedatos.LlenaComboModeloPlacaDatos();
            return listadatos;
        }
        public bool InsertarPlacas(CamposPlacas datos) {
            bool respuesta = false;
            respuesta = clasedatos.InsertarPlacas(datos);
            return respuesta;
        }

        public bool ActualizarPlacas(CamposPlacas datos) {
            bool respuesta = false;
            respuesta = clasedatos.actualizarPlacas(datos);
            return respuesta;
        }

        public bool EliminarPlacas(CamposPlacas datos) {
            bool respuesta = false;
            respuesta = clasedatos.EliminarPlacas(datos);
            return respuesta;
        }

    }
}
