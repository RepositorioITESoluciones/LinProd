using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class MarcasMaquina
    {

        public CamposMarcasMaquina[] ListaRegMarcasMaq { get; set; }

    }

    public class CamposMarcasMaquina
    {

        public int IdMarca { get; set; }
        public string Descripcion { get; set; }

    }
}
