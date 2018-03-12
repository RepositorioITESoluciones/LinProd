using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class PlacasSensores
    {
        public CamposPlacasSen[] ListaRegPlacasSen { get; set; }
    }
    public class CamposPlacasSen
    {
        public int IdPlaca { get; set; }
        public string DireccionMacEquipo { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Descripcion { get; set; }
        public string DireccionIP { get; set; }
        public DateTime FechaBaja { get; set; }
        public string NoSerie { get; set; }

    }
}
