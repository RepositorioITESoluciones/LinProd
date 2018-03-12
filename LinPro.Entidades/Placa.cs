using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class Placa
    {
        public CamposPlaca[] ListaRegPlaca { get; set; }
    }

    public class CamposPlaca
    {
        public int IdPlaca { get; set; }
        public string direccionMACEquipo { get; set; }
        public string FechaAlta { get; set; }
        public string Descripcion { get; set; }
        public string DireccionIP { get; set; }
        public int IdModeloCircuito { get; set; }
        public string FechaBaja { get; set; }
        public string NoSerie { get; set; }
    }
}
