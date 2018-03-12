using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class AgentesMedidos
    {
        public CamposAgentesM[] ListaRegAgentesM { get; set; }
    }
    public class CamposAgentesM
    {
        public int IdAgenteMedido { get; set; }
        public string Nombre { get; set; }

    }
}
