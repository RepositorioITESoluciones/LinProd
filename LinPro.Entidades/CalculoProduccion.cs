using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class CalculoProduccion
    {
        public CamposCalculoProduccion[] ListaRegistros { get; set; }
    }
    public class CamposCalculoProduccion
    {
        public int idCalculosProduccion { get; set; }
        public int idTurno { get; set; }
        public DateTime fecha { get; set; }

        public String fechas { get; set; }
        public int idMaquina { get; set; }
        public String duracionTurno { get; set; }
        public String maquinaApagada { get; set; }
        public String maquiaEnProduccion { get; set; }
        public int maquinaEnProduccionHoras { get; set; }
        public String maquinaInactiva { get; set; }
        public int piezasProducidas { get; set; }
        public int piezasDefectuosas { get; set; }
        public int PiezasBuenas { get; set; }
        public double KWH_turno { get; set; }
        public double KWH_pza { get; set; }
        public int idTarifa { get; set; }
        public double costoKWHturno { get; set; }
        public double costoPza { get; set; }
        public double disponibilidad { get; set; }
        public double eficiencia { get; set; }
        public double calidad { get; set; }
        public double OEE { get; set; }
        public string mes { get; set; }
        public double Porcentaje { get; set; }
        public string PorcentajeS { get; set; }
        public CamposDepartamento departamento { get; set; }
        public CamposMaquina maquina { get; set; }
        public string FechaCorta { get; set; }

    }
}
