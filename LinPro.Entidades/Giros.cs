using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades {
    public class Giros {
        public CamposGirosEmpresariales[] ListaRegistros { get; set; }
    }

    public class CamposGirosEmpresariales {
        public int idGiro { get; set; }
        public string nombre { get; set; }

    }

}
