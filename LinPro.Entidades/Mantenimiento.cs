using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class Mantenimiento
    {
        public CamposMantenimiento[] ListaRegistrosMantenimiento { get; set; }
    }

    public class CamposMantenimiento
    {

        public int IdMantenimiento { get; set; }
        public CamposMaquina Maquina { get; set; }
        public CamposMotivoMantenimiento MotivoMantenimiento { get; set; }
        public CamposMotivoMantenimiento Descripcion { get; set; }
        public CamposPersonal Personal { get; set; }
        public DateTime FechaAlta { get; set; }
        public string FechaALtaS { get; set; }
        public DateTime FechaFin { get; set; }
        public string FechaFins { get; set; }
        public CamposDepartamento Departamento { get; set; }


    }


}
