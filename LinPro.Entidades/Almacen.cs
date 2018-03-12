
using System.Collections.Generic;

namespace LinPro.Entidades {
    public class Almacen {
        public CamposAlmacen[] ListaRegistros { get; set; }
    }

    public class CamposAlmacen {
        public int idAlmacen { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int idTipoAlmacen { get; set; }
        public string nombreTipoAlmacen { get; set; }
        public int idSucursal { get; set; }
        public string nombreSucursal { get; set; }

    }
}
