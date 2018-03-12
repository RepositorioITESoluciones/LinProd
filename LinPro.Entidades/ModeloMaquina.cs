using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class ModeloMaquina
    {
        public CamposModeloMaquina[] listaModelos { get; set; }
    }

    public class CamposModeloMaquina
    {
        public int idModeloMaquina { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int anio { get; set; }
        public CamposMarcaMaquinaria marca { get; set; }
    }
}
