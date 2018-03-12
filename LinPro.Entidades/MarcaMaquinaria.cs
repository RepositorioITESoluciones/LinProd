using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class MarcaMaquinaria
    {
        public CamposMarcaMaquinaria[] listaMarca { get; set; }
    }
    public class CamposMarcaMaquinaria
    {
        public int idMarca { get; set; }
        public string descripcion { get; set; }

    }
}
