
using System.Collections.Generic;

namespace LinPro.Entidades {
    public class Puestos {
        public CamposPuestos[] ListaRegistros { get; set; }
    }

    public class CamposPuestos {
        public int idPuesto { get; set; }
        public string nombrePuesto { get; set; }
        public string descripcion { get; set; }

    }
}
