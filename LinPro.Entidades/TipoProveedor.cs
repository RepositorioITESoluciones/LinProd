using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class TipoProveedor
    {
        public CamposTipoProveedor[] listaRegTipoProveedor { get; set; }
    }

    public class CamposTipoProveedor
    {
        public int idTipoProveedor { get; set; }
        public string descripcion { get; set; }
    }
}
