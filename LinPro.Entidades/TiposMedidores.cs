using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class TiposMedidores
    {
        public CamposTiposMed[] ListaRegTiposMed { get; set; }

    }
    public class CamposTiposMed
    {
        public int IdTipoMedidor { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
    }
}
