using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio
{
    public class NegocioProveedor
    {
        DatosProveedor clasedatos = new DatosProveedor();

        public Proveedor LlenaTabla()
        {
            Proveedor listadatos;

            listadatos = clasedatos.LlenaTablaDatos();

            return listadatos;
        }

        public bool InsertaProveedorNegocio(CamposProveedor campos)
        {
            bool respuesta = false;
            try
            {
                clasedatos.InsertaProveedorBySP(campos);
                respuesta = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }

            return respuesta;
        }

        public bool actualizarProveedorNegocio(CamposProveedor campos)
        {
            bool respuesta = false;

            respuesta = clasedatos.actualizarProveedorBySP(campos);
            return respuesta;
        }

        public bool eliminarProveedorNegocio(int idProveedor)
        {
            bool respuesta = false;

            respuesta = clasedatos.EliminaProveedorBySP(idProveedor);
            return respuesta;
        }

        public TipoProveedor LlenaComboTipoProveedor()
        {
            TipoProveedor listaTipoProveedor;

            listaTipoProveedor = clasedatos.LlenaComboTipoProveedor();

            return listaTipoProveedor;
        }

        public TipoPersona LlenaComboTipoPersona()
        {
            TipoPersona listaTipoPersona;

            listaTipoPersona = clasedatos.LlenaComboTipoPersona();

            return listaTipoPersona;
        }

        public CodigoPostal LlenaComboCodigoPostal()
        {
            CodigoPostal listaCodigoPostal;

            listaCodigoPostal = clasedatos.LlenaComboCodigoPostal();

            return listaCodigoPostal;
        }

        public Estado LlenaEstadoByCP(int cp)
        {
            Estado listaEstado;
            listaEstado = clasedatos.getEstadoByCP(cp);
            return listaEstado;
        }
    }
}
