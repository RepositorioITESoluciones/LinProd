
using System.Collections.Generic;

namespace LinPro.Entidades {
    public class TipoAlmcanen {
        public CamposTipoAlmacen[] ListaRegistros { get; set; }
    }

    public class CamposTipoAlmacen {
        public int idTipoAlmacen { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

    }
}
