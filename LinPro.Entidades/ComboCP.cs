using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class ComboCP
    {
        public CamposCodigosPostales[] listaCodigosPostales { get; set; }
    }
    public class CamposCodigosPostales
    {
        public int c_CP { get; set; }
        public string nombre { get; set; }
    }
}
