using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class ComboRoles
    {
        public CamposRoles[] listaRoles { get; set; }
    }
    public class CamposRoles
    {
        public int idRol { get; set; }
        public string nombreRol { get; set; }
    }
}
