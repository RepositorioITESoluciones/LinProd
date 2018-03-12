using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio
{
    public class NegocioSensores
    {
        DatosSensores clasedatos = new DatosSensores();

        public Sensores LlenaTablaSensores()
        {
            Sensores listadatos;

            listadatos = clasedatos.LlenaTablaSensores();

            return listadatos;
        }
        public bool InsertaSensor(CamposSensores campos)
        {
            bool respuesta = false;
            try
            {

                clasedatos.InsertaSensor(campos);
                respuesta = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }

            return respuesta;
        }

        public bool ActualizarSensor(CamposSensores campos)
        {
            bool respuesta = false;
            try
            {

                clasedatos.ActualizarSensor(campos);
                respuesta = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }

            return respuesta;
        }
        public bool EliminarSensor(int IdSensor)
        {
            bool respuesta = false;

            respuesta = clasedatos.EliminarSensor(IdSensor);
            return respuesta;
        }
        public TiposSensores LlenaComboTipoSensore()
        {
            TiposSensores listaDatos;

            listaDatos = clasedatos.LlenaComboTipoSensore();

            return listaDatos;
        }

        //TiposMedidores LlenaComboTipoMedidores
        public TiposMedidores LlenaComboTipoMedidores()
        {
            TiposMedidores listaDatos;

            listaDatos = clasedatos.LlenaComboTipoMedidores();

            return listaDatos;
        }
        
        public UnidadesMedida LlenaComboUnidadMedida()
        {
            UnidadesMedida listaDatos;

            listaDatos = clasedatos.LlenaComboUnidadMedida();

            return listaDatos;
        }
      
        public AgentesMedidos LlenaComboAgentesMed()
        {
            AgentesMedidos listaDatos;

            listaDatos = clasedatos.LlenaComboAgentesMed();

            return listaDatos;
        }

        public PlacasSensores LlenaComboPlacasSen()
        {
            PlacasSensores listaDatos;

            listaDatos = clasedatos.LlenaComboPlacasSen();

            return listaDatos;
        }
        public ModelosSensores LlenaComboModelosSen()
        {
            ModelosSensores listaDatos;

            listaDatos = clasedatos.LlenaComboModelosSen();

            return listaDatos;
        }
    }
}
