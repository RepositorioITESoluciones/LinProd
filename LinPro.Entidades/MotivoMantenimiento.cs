using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class MotivoMantenimiento
    {
        public CamposMotivoMantenimiento[] ListaRegistrosMotivoMantenimiento { get; set; }
    }

    public class CamposMotivoMantenimiento
    {
        public int IdMotivoMantenimiento { get; set; }
        public string Descripcion { get; set; }
    }
}
