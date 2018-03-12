using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio {
    public class NegocioTipoAlmacen {

        DatosTipoAlmacen clasedatos = new DatosTipoAlmacen();

        public TipoAlmcanen LlenaTablaTipoAlmacen() {
            TipoAlmcanen listadatos;

            listadatos = clasedatos.LlenaTablaTipoAlmacen();

            return listadatos;
        }

        public bool insertarTipoAlmacen(CamposTipoAlmacen datos) {
            bool respuesta = false;
            respuesta = clasedatos.InsertarTipoAlmacen(datos);
            return respuesta;
        }

        public bool actualizarTipoAlmacen(CamposTipoAlmacen datos) {
            bool respuesta = false;
            respuesta = clasedatos.ActualizarTipoAlmacen(datos);
            return respuesta;
        }

        public bool eliminarTipoAlmacen(CamposTipoAlmacen datos) {
            bool respuesta = false;
            respuesta = clasedatos.EliminarTipoAlmacen(datos);
            return respuesta;
        }

    }
}
