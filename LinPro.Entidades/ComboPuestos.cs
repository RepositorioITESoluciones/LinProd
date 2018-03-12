using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class ComboPuestos
    {
        public CamposPuesto[] listaPuestos { get; set; }
    }
    public class CamposPuesto
    {
        public int idPuesto { get; set; }
        public string descripcion { get; set; }
    }
}