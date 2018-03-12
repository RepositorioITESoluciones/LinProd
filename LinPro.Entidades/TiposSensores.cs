using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class TiposSensores
    {
        public CamposTiposSen[] ListaRegTiposSen { get; set; }
    }
    public class CamposTiposSen
    {
        public int IdTipoSensor { get; set; }
        public string Nombre { get; set; }

    }
}
