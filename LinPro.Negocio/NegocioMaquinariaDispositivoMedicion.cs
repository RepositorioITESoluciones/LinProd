using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio
{
    public class NegocioMaquinariaDispositivoMedicion
    {
        DatosMaquinariaDispositivosMedicion clasedatos = new DatosMaquinariaDispositivosMedicion();

        public MaquinariaDispositivosMedicion consultarMaquinas()
        {
            MaquinariaDispositivosMedicion listadatos;

            listadatos = clasedatos.ConsultarMaqinariaPlacas();

            return listadatos;
        }

    
    }
}
