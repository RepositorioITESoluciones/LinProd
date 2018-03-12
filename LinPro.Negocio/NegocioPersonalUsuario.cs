using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinPro.Datos;
using LinPro.Entidades;

namespace LinPro.Negocio
{
    public class NegocioPersonalUsuario
    {
        DatosPersonalUsuario datosPersonalUsuario = new DatosPersonalUsuario();
        public PersonalUsuario llenaTablaPersonalUsuario()
        {
            PersonalUsuario listaDatos;
            listaDatos = datosPersonalUsuario.llenaTablaPersonalUsuario();
            return listaDatos;
        }

        public ComboPuestos LlenaComboPuesto()
        {
            ComboPuestos listaDatos;
            listaDatos = datosPersonalUsuario.LlenaComboPuesto();
            return listaDatos;
        }

        public ComboRoles LlenaComboRoles()
        {
            ComboRoles listaDatos;
            listaDatos = datosPersonalUsuario.LlenaComboRoles();
            return listaDatos;
        }

        public ComboPrivilegios LlenaCheckBoxPrivilegios()
        {
            ComboPrivilegios listaDatos;
            listaDatos = datosPersonalUsuario.LlenaCheckBoxPrivilegios();
            return listaDatos;
        }

        public ComboPrivilegiosCHK LlenaCheckBoxPrivilegiosEdit(int idPersonal, int idUsuario, int idRol)
        {
            ComboPrivilegiosCHK listaDatos;
            listaDatos = datosPersonalUsuario.LlenaCheckBoxPrivilegiosEdit(idPersonal, idUsuario, idRol);
            return listaDatos;
        }

        public ComboPersonal LlenaComboPersonal()
        {
            ComboPersonal listaDatos;
            listaDatos = datosPersonalUsuario.LlenaComboPersonal();
            return listaDatos;
        }

        public ComboEstados LlenaComboEstados()
        {
            ComboEstados listaDatos;
            listaDatos = datosPersonalUsuario.LlenaComboEstados();
            return listaDatos;
        }

        public CodigoPostal LlenaComboCP(int idEstado)
        {
            CodigoPostal listaDatos;
            listaDatos = datosPersonalUsuario.LlenaComboCP(idEstado);
            return listaDatos;
        }

        public bool insertaPersonal(string nombre, string apPaterno, string apMaterno, string rfc, string estadoC, string cpC, string idPuesto, string email, string idRol, string usuario, string pwd, string accesarSistema, int[] privilegios)
        {
            bool respuesta = false;
            respuesta = datosPersonalUsuario.insertaPersonal(nombre, apPaterno, apMaterno, rfc, estadoC, cpC, idPuesto, email, idRol, usuario, pwd, accesarSistema, privilegios);
            return respuesta;
        }

        public bool insertaUsuario(string personaC, string idRol, string usuario, string pwd, int[] privilegios)
        {
            bool respuesta = false;
            respuesta = datosPersonalUsuario.insertaUsuario(personaC, idRol, usuario, pwd, privilegios);
            return respuesta;
        }

        public bool modificarPersonalUsuario(string nombre, string apPaterno, string apMaterno, string rfc, string estadoC, string cpC, string idPuesto, string email, string idRol, string usuario, string pwd, string accesarSistema, int[] privilegios, int idPersonal, int idUsuario, int idRolAnterior)
        {
            bool respuesta = false;
            respuesta = datosPersonalUsuario.modificarPersonalUsuario(nombre, apPaterno, apMaterno, rfc, estadoC, cpC, idPuesto, email, idRol, usuario, pwd, accesarSistema, privilegios, idPersonal, idUsuario, idRolAnterior);
            return respuesta;
        }

        public bool eliminarPersonalUsuario(int idPersonal, int idUsuario, int idRolAnterior)
        {
            bool respuesta = false;
            try
            {
                respuesta = datosPersonalUsuario.eliminarPersonalUsuario(idPersonal, idUsuario, idRolAnterior);
                //respuesta = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return respuesta;
        }
    }
}
