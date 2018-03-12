using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio
{
    public class NegocioProyeccionesCalculadas
    {
        DatosProyeccionesCalculadas clasedatos = new DatosProyeccionesCalculadas();
        public CalculoProduccion GraficaProyeccion(string fechaInicio, string fechaFin)
        {
            CalculoProduccion listadatos;
            listadatos = clasedatos.GraficaProyeccion( fechaInicio, fechaFin);

            return listadatos;

        }

        public CalculoProduccion GraficaEufem(string fechaInicio, string fechaFin)
        {
            CalculoProduccion listadatos;
            listadatos = clasedatos.GraficaEufem(fechaInicio, fechaFin);

            return listadatos;

        }
    }
}


