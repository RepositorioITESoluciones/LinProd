using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPro.Entidades
{
    public class Menu
    {
        public CamposMenu[] listaMenus { get; set; }
        public CamposMenuHijos[] listaMenusHijos { get; set; }

    }

    public class CamposMenu
    {
        public int idMenu { get; set; }
        public int idPadre { get; set; }
        public int idHijo { get; set; }
        public string nombreMenu { get; set; }
        public string descripcionMenu { get; set; }
        public string liga { get; set; }
        public string icono { get; set; }
        public int hijos { get; set; }
    }

    public class CamposMenuHijos
    {
        public int idMenu { get; set; }
        public int idPadre { get; set; }
        public int idHijo { get; set; }
        public string nombreMenu { get; set; }
        public string descripcionMenu { get; set; }
        public string liga { get; set; }
        public string icono { get; set; }
        public int hijos { get; set; }
        
    }

}
