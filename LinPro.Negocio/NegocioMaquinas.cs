using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio
{
    public class NegocioMaquinas
    {

        DatosMaquina clasedatos = new DatosMaquina();

        public Maquina LlenaTablaMaquina()
        {
            Maquina listadatos;

            listadatos = clasedatos.LlenaTablaMaquina();

            return listadatos;
        }
        public Placa ComboPlaca()
        {
            Placa listaDatos;

            listaDatos = clasedatos.ComboPlaca();

            return listaDatos;
        }
        
        public MarcasMaquina ComboMarcasMaq()
        {
            MarcasMaquina listaDatos;

            listaDatos = clasedatos.ComboMarcasMaq();

            return listaDatos;
        }
        public NavesIndustriales ComboNave()
        {
            NavesIndustriales listaDatos;

            listaDatos = clasedatos.ComboNave();

            return listaDatos;
        }


        public bool InsertaMaquina(CamposMaquina campos)
        {
            bool respuesta = false;
            try
            {

                clasedatos.InsertaMaquina(campos);
                respuesta = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }

            return respuesta;
        }

        public bool ActualizaMaquina(CamposMaquina campos)
        {
            bool respuesta = false;
            try
            {

                clasedatos.ActualizaMaquina(campos);
                respuesta = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }

            return respuesta;
        }

        public bool EliminarMaquina(int IdMaquina)
        {
            bool respuesta = false;

            respuesta = clasedatos.EliminarMaquina(IdMaquina);
            return respuesta;
        }
        public Maquina LlenaMaquina(int idDepartamento)
        {
            Maquina listaDatos;

            listaDatos = clasedatos.LlenaMaquina(idDepartamento);

            return listaDatos;
        }
    }
}
