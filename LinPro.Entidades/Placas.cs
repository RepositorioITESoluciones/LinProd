
namespace LinPro.Entidades {
    public class Placas {
        public CamposPlacas[] ListaRegistros { get; set; }
    }

    public class CamposPlacas {
        public int idPlaca { get; set; }
        public string direccionMACEquipo { get; set; }
        public string fechaAlta { get; set; }
        public string fechaBaja { get; set; }
        public string descripcion { get; set; }
        public string direccionIp { get; set; }
        public int idModeloCircuito { get; set; }
        public string nombreModeloCircuito { get; set; }
        public string numeroSerie { get; set; }


    }
}
