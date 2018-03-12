using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class UnidadesMedida
    {
        public CamposUnidadesM[] ListaRegUnidadesM { get; set; }
    }

    public class CamposUnidadesM
    {
        public int IdUnidadMedida { get; set; }
        public string Nombre { get; set; }
        public string Formato { get; set; }
        public string ValorMinino { get; set; }
        public string ValorMaximo { get; set; }
        public string Escala { get; set; }
    }
}
