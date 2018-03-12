using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class MaquinariaDispositivosMedicion
    {
        public CamposMaquinariaDispositivosMedicion[] ListaRegistros { get; set; }
    }

    public class CamposMaquinariaDispositivosMedicion {
        public int idPlaca { get; set; }
        public string nombrePlaca { get; set; }

        public int idMaquina { get; set; }
        public string nombreMaquina { get; set; }

    }
}
