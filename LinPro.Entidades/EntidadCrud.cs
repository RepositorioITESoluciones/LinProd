using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class EntidadCrud
    {
        public CamposCrud[] ListaRegistros { get; set; }
    }

    public class CamposCrud
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int edad { get; set; }
        public string email { get; set; }
        public int idArea { get; set; }
        public DateTime fecha { get; set; }

    }



}
