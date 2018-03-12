using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class Perfil
    {
        public CamposPerfil [] listaPerfiles { get; set; }
    }

    public class CamposPerfil
    {
        public int idPerfil { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}
