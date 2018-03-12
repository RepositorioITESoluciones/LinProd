using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class Proveedor
    {
        public CamposProveedor [] listaProveedores { get; set; }
    }

    public class CamposProveedor
    {
        public int idProveedor { get; set; }
        public string nombre { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime fechaBaja { get; set; }
        public CamposEstado estado { get; set; }
        public CamposDatosFiscales datosFiscales { get; set; }
        public CamposTipoProveedor tipoProveedor { get; set; }
        public CamposTipoPersona tipoPersona { get; set; }
    }
}
