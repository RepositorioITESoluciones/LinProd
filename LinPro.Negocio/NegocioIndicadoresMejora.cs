using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio
{
    public class NegocioIndicadoresMejora
    {
        DatosIndicadoresMejora clasedatos = new DatosIndicadoresMejora();
        public CalculoProduccion IndicadoresEficiencia(string FechaInicio, string FechaFin, int ComboDepar)
        {
            CalculoProduccion listadatos;
            listadatos = clasedatos.IndicadoresEficiencia(FechaInicio, FechaFin, ComboDepar);

            return listadatos;
        }
    }
}
