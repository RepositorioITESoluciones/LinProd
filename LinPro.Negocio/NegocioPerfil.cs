using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio
{
    public class NegocioPerfil  
    {
        DatosPerfil clasedatos = new DatosPerfil();

        public Perfil LlenaTabla()
        {
            Perfil listadatos;

            listadatos = clasedatos.LlenaTablaDatos();

            return listadatos;
        }

        public bool InsertaPerfilNegocio(CamposPerfil campos)
        {
            bool respuesta = false;
            try
            {
                clasedatos.InsertaPerfilBySP(campos);
                respuesta = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }

            return respuesta;
        }

        public bool actualizarPerfilNegocio(CamposPerfil campos)
        {
            bool respuesta = false;

            respuesta = clasedatos.actualizaPerfilBySP(campos);
            return respuesta;
        }

        public bool eliminarPerfilNegocio(int idPerfil)
        {
            bool respuesta = false;

            respuesta = clasedatos.EliminaPerfilBySP(idPerfil);
            return respuesta;
        }


    }
}
