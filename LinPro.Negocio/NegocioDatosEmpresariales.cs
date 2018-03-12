using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio {
    public class NegocioDatosEmpresariales {

        DatosDatosEmpresariales clasedatos = new DatosDatosEmpresariales();

        public DatosEmpresariales LlenaTablaDE() {
            DatosEmpresariales listadatos;

            listadatos = clasedatos.LlenaTablaDatosDE();

            return listadatos;
        }

        public bool InsertaDatosEmpresariales(CamposDatosEmpresariales campos) {
            bool respuesta = false;
            try {

                clasedatos.InsertaDatosEmpresariales(campos);
                respuesta = true;

            } catch (Exception ex) {
                Console.WriteLine(ex);

            }

            return respuesta;
        }

        public bool ActualizarDatosEmpresariales(CamposDatosEmpresariales campos) {
            bool respuesta = false;
            try {

                clasedatos.ActualizarDatosEmpresariales(campos);
                respuesta = true;

            } catch (Exception ex) {
                Console.WriteLine(ex);

            }

            return respuesta;
        }
        public bool EliminarDatosEmpresariales(CamposDatosEmpresariales campos) {
            bool respuesta = false;

            respuesta = clasedatos.EliminaDatosEmpresariales(campos);
            return respuesta;
        }

        public bool ExisteRFC(CamposDatosEmpresariales campos) {
            bool respuesta = false;

            respuesta = clasedatos.ExisteRFC(campos);
            return respuesta;
        }

    }
}
