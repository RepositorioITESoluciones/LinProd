
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio
{
    public class NegocioEnergiaXEquipos
    {

        DatosEnergiaXEquipos clasedatos = new DatosEnergiaXEquipos();

        public CalculoProduccion LlenaTablaEnergiaXEquipos(string FechaInicio, string FechaFin, int ComboDepar)
        {
            CalculoProduccion listadatos;
            listadatos = clasedatos.EnergiaXEquipos( FechaInicio,  FechaFin,  ComboDepar);

            return listadatos;

        }

    }


}
