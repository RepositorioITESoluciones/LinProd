using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio {
    public class NegocioPuestos {

        DatosPuestos clasedatos = new DatosPuestos();

        public Puestos LlenaTablaPuestos() {
            Puestos listadatos;
            listadatos = clasedatos.LlenaTablaDatosPuestos();
            return listadatos;
        }

        public bool InsertarPuestos(CamposPuestos datos) {
            bool respuesta = false;
            respuesta = clasedatos.InsertarPuestos(datos);
            return respuesta;
        }

        public bool actualizarPuestos(CamposPuestos datos) {
            bool respuesta = false;
            respuesta = clasedatos.ActualizarPuestos(datos);
            return respuesta;
        }

        public bool eliminarPuestos(CamposPuestos datos) {
            bool respuesta = false;
            respuesta = clasedatos.EliminarPuestos(datos);
            return respuesta;
        }

    }
}
