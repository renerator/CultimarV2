using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.DAO
{
    /// <summary>
    /// Clase de Control para acceso a DAO de Factory (nivel intermedio de acceso)
    /// </summary>
    public class Control
    {
        private Factory _dtFac = new Factory();

        public List<ObjetoMenu> MenuUsuario(int idUsuario)
        {
            return _dtFac.MenuUsuario(idUsuario);
        }

        public List<ObjetoLogin> Login(string rut, string pass)
        {
            return _dtFac.LoginUsuario(rut, pass);
        }

        public List<ObjetoPerfil> ListadoPerfiles()
        {
            return _dtFac.ListadoPerfiles();
        }

        public List<ObjetoUsuarios> ListadoUsuarios()
        {
            return _dtFac.ListadoUsuarios();
        }

        public bool setGrabaUsuario(ObjetoUsuarios usuario)
        {
            return _dtFac.setGrabaUsuario(usuario);
        }

        public bool getVerificaUsuario(string rutUsuario)
        {
            return _dtFac.getVerificaUsuario(rutUsuario);
        }

        public bool setAutorizaUsuario(int idUsuario)
        {
            return _dtFac.setAutorizaUsuario(idUsuario);
        }

        public bool setQuitaPermisoUsuario(int idUsuario)
        {
            return _dtFac.setQuitaPermisoUsuario(idUsuario);
        }

    }
}