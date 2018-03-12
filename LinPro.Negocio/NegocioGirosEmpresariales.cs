using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio {
    public class NegocioGirosEmpresariales {

        DatosGirosEmpresariales clasedatosGE = new DatosGirosEmpresariales();

        public Giros LlenaTablaGE() {
            Giros listadatos;

            listadatos = clasedatosGE.LlenaTablaDatosGE();

            return listadatos;
        }

        public bool insertarGE(CamposGirosEmpresariales datos) {
            bool respuesta = false;
            respuesta = clasedatosGE.InsertarGirosEmpresariales(datos);
            return respuesta;
        }

        public bool actualizarGE(CamposGirosEmpresariales datos) {
            bool respuesta = false;

            respuesta = clasedatosGE.ActualizarGirosEmpresariales(datos);
            return respuesta;
        }

        public bool eliminarGE(CamposGirosEmpresariales datos) {
            bool respuesta = false;

            respuesta = clasedatosGE.EliminarGirosEmpresariales(datos);
            return respuesta;
        }


        //public Area LlenacomboNeg()
        //{
        //    Area listadatos;

        //    listadatos = clasedatos.LlenaCombo();

        //    return listadatos;
        //}

    }
}
