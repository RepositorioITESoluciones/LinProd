using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class Sensores
    {
        public CamposSensores[] ListaRegSensores { get; set; }
    }
    public class CamposSensores
    {
        public int IdSensor { get; set; }
        public string NoSerie { get; set; }
        public string Descripcion { get; set; }
        public CamposTiposSen TipoSensor { get; set; }
        public CamposTiposMed TipoMedidor { get; set; }
        public CamposUnidadesM UnidadesMedida { get; set; }
        public CamposAgentesM AgentesMedidos { get; set; }
        public DateTime FechaAlta { get; set; }
        public string FechaALtaS { get; set; }
        public string FechaInstalacionS { get; set; }
        public DateTime FechaBaja { get; set; }
        public DateTime FechaInstalacion { get; set; }
        public CamposPlacasSen PlacasSensores { get; set; }
        public CamposModeloSen ModeloSensores { get; set; }
        public int IntervaloLectura { get; set; }


    }
}
