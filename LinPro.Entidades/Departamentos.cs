
using System.Collections.Generic;

namespace LinPro.Entidades {
    public class Departamentos {
        public CamposDepartamento[] ListaRegistros { get; set; }
    }

    public class CamposDepartamento {
        public int idDepartamento { get; set; }
        public string nombreDepartamento { get; set; }
        public string descripcionDepartamento { get; set; }
        public int idArea { get; set; }
    }
}
