using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio
{
    public class NegocioModeloMaquina
    {
        DatosModeloMaquina clasedatos = new DatosModeloMaquina();

        public ModeloMaquina LlenaTabla()
        {
            ModeloMaquina listadatos;

            listadatos = clasedatos.LlenaTablaDatos();

            return listadatos;
        }

        public bool InsertaModeloMaquinaNegocio(CamposModeloMaquina campos)
        {
            bool respuesta = false;
            try
            {
                clasedatos.InsertaModeloMaquinaBySP(campos);
                respuesta = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }

            return respuesta;
        }

        public bool actualizarModeloMaquinaNegocio(CamposModeloMaquina campos)
        {
            bool respuesta = false;

            respuesta = clasedatos.actualizarModeloMaquinaBySP(campos);
            return respuesta;
        }

        public bool eliminarModeloMaquinaNegocio(int idModeloMaquina)
        {
            bool respuesta = false;

            respuesta = clasedatos.EliminaModeloMaquinaBySP(idModeloMaquina);
            return respuesta;
        }

        public MarcaMaquinaria LlenacomboMarcaNegocio()
        {
            MarcaMaquinaria listadatos;

            listadatos = clasedatos.LlenaComboMarca();

            return listadatos;
        }


    }
}
