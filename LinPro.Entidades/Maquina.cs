using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class Maquina
    {
        public CamposMaquina[] ListaRegistrosMaquina { get; set; }

    }

    public class CamposMaquina
    {

        public int IdMaquina { get; set; }
        public string Descripcion { get; set; }
        public int Año { get; set; }
        public string NoSerie { get; set; }

        public CamposMarcasMaquina MarcasMaquina { get; set; }
        public CamposEtatusMaquina EtatusMaquina { get; set; }
        public CamposNavesIndus NavesIndus { get; set; }
        public CamposPlaca CamposPlaca { get; set; }

    }
}
