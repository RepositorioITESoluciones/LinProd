using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio
{
    public class NegocioCrud
    {
        DatosCrud clasedatos = new DatosCrud();

        public EntidadCrud LlenaTabla()
        {
            EntidadCrud listadatos;

            listadatos = clasedatos.LlenaTablaDatos();

            return listadatos;
        }

        public bool insertar(CamposCrud datos)
        {
            bool respuesta = false;

            respuesta = clasedatos.InsertarDatos(datos);


            return respuesta;
        }

        public bool actualisar(CamposCrud datos)
        {
            bool respuesta = false;

            respuesta = clasedatos.ActualizarDatos(datos);


            return respuesta;
        }

        public bool eliminar(CamposCrud datos)
        {
            bool respuesta = false;

            respuesta = clasedatos.EliminarDatos(datos);


            return respuesta;
        }


        public Area LlenacomboNeg()
        {
            Area listadatos;

            listadatos = clasedatos.LlenaCombo();

            return listadatos;
        }

    }
}
