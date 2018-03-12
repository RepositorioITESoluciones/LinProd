
namespace LinPro.Entidades {
    public class ModelosPlacas {
        public CamposModeloPlacas[] ListaRegistros { get; set; }
    }

    public class CamposModeloPlacas {
        public int idModeloCircuito { get; set; }
        public string nombre { get; set; }
        public string modelo { get; set; }
        public string descripcion { get; set; }

    }
}
