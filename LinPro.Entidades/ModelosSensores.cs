using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class ModelosSensores
    {
        public CamposModeloSen[] ListaRegModelosSen { get; set; }
    }
    public class CamposModeloSen
    {
        public int IdModeloSensor { get; set; }
        public string Nombre { get; set; }
        public string Modelo { get; set; }
        public CamposProveedor Provedor { get; set; }

    }
}
