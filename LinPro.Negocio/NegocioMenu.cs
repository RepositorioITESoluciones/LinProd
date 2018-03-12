using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Entidades;
using LinPro.Datos;


namespace LinPro.Negocio
{
    public class NegocioMenu
    {
        DatosMenu menus = new DatosMenu();

        public Menu MuestraMenus()
        {
            Menu listadatos;

            listadatos = menus.MuestraMenus();

            return listadatos;
        }

       public Menu muestraSubMenus(int idPadre)
        {
            Menu listaSub;

            listaSub = menus.MuestraSubMenus(idPadre);

            return listaSub;
        }

    }
}
