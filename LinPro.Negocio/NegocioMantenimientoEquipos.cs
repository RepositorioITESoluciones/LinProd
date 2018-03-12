using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio
{
    public class NegocioMantenimientoEquipos
    {

        DatosMantenimientoEquipos clasedatos = new DatosMantenimientoEquipos();
        public Mantenimiento LlenaTablaMantenimiento(string FechaInicio, string FechaFin, int ComboDepar)
        {
            Mantenimiento listadatos;
            listadatos = clasedatos.LlenaTablaMantenimiento(FechaInicio, FechaFin, ComboDepar);
            return listadatos;
        }

    }


}
