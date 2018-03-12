using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio {
    public class NegocioModeloPlacas {

        DatosModeloPlacas clasedatos = new DatosModeloPlacas();

        public ModelosPlacas LlenaTablaModeloPlacas() {
            ModelosPlacas listadatos;
            listadatos = clasedatos.LlenaTablaDatosModeloPlacas();
            return listadatos;
        }

        public bool InsertarModeloPlacas(CamposModeloPlacas datos) {
            bool respuesta = false;
            respuesta = clasedatos.InsertarModeloPlacas(datos);
            return respuesta;
        }

        public bool ActualizarModeloPlacas(CamposModeloPlacas datos) {
            bool respuesta = false;
            respuesta = clasedatos.ActualizarModeloPlacas(datos);
            return respuesta;
        }

        public bool EliminarModeloPlacas(CamposModeloPlacas datos) {
            bool respuesta = false;
            respuesta = clasedatos.EliminarModeloPlacas(datos);
            return respuesta;
        }

    }
}
