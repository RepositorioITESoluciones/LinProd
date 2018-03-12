using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio {
    public class NegocioAlmacen {

        DatosAlmacen clasedatos = new DatosAlmacen();

        public Almacen LlenaTablaAlmacen() {
            Almacen listadatos;
            listadatos = clasedatos.LlenaTablaAlmacen();
            return listadatos;
        }
        public Almacen LlenaComboSucursales() {
            Almacen listadatos;
            listadatos = clasedatos.LlenaComboSucursales();
            return listadatos;
        }
        public Almacen LlenaComboTipoAlmacen() {
            Almacen listadatos;
            listadatos = clasedatos.LlenaComboTipoAlmacen();
            return listadatos;
        }

        public bool InsertarAlmacen(CamposAlmacen datos) {
            bool respuesta = false;
            respuesta = clasedatos.InsertarAlmacen(datos);
            return respuesta;
        }

        public bool ActualizarAlmacen(CamposAlmacen datos) {
            bool respuesta = false;
            respuesta = clasedatos.ActualizarAlmacen(datos);
            return respuesta;
        }

        public bool EliminarAlmacen(CamposAlmacen datos) {
            bool respuesta = false;
            respuesta = clasedatos.EliminarAlmacen(datos);
            return respuesta;
        }

    }
}
