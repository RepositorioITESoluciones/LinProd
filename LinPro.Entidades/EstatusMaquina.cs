using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class EstatusMaquina
    {
        public CamposEtatusMaquina[] ListaRegEstatusMaq { get; set; }
    }

    public class CamposEtatusMaquina
    {

        public int IdEstatus { get; set; }
        public string Descripcion { get; set; }
    }
}
