using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio
{
    public class NegocioArea
    {
        DatosArea clasedatos = new DatosArea();

        public Area LlenaTabla()
        {
            Area listadatos;

            listadatos = clasedatos.LlenaTablaDatos();

            return listadatos;
        }

        public bool InsertaAreaNegocio(CamposArea campos, int[] idSucursales)
        {
            bool respuesta = false;
            try
            {
               clasedatos.InsertaAreaBySP(campos, idSucursales);
               respuesta = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        
            return respuesta;
        }

        
        public bool actualizarAreaNegocio(CamposArea campos, int[] idSucursales)
        {
            bool respuesta = false;

            respuesta = clasedatos.actualizarAreaBySP(campos, idSucursales);
            return respuesta;
        }

        public bool eliminarAreaNegocio(int idArea)
        {
            bool respuesta = false;

            respuesta = clasedatos.EliminaAreaBySP(idArea);
            return respuesta;
        }

        public Sucursal LlenacomboSucursalNegocio()
        {

            return clasedatos.LlenaComboSucursal();
        }

        public Sucursal getidSucursalesByArea(int idArea)
        {
            Sucursal listaSucursales;
            listaSucursales = clasedatos.getidSucursalesByArea(idArea);

            return listaSucursales;
        }

        public Departamentos LlenaComboDptos()
        {
            return clasedatos.LlenaComboDptos();
        }

    }
}
