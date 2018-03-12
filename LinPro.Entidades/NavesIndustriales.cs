using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class NavesIndustriales
    {
        public CamposNavesIndus[] ListaRegNavesIndus { get; set; }
    }

    public class CamposNavesIndus
    {
        public int IdNave { get; set; }
        public string DescripcionNave { get; set; }
        public int IdSucursal { get; set; }

    }
}
