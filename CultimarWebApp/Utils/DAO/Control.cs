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
        private FactorySeguimientoLarval _dtSegLarval = new FactorySeguimientoLarval();
        private FactorySeguimientosSemillas _dtFacSeguimientoSemilla = new FactorySeguimientosSemillas();

        public List<ObjetoSeguimientoLarval> ListadoSeguimientoLarval()
        {
            return _dtSegLarval.ListadoSeguimientoLarval(1);
        }

        public bool setGrabaSeguimientoLarval(ObjetoSeguimientoLarval larval)
        {
            return _dtSegLarval.setGrabaSegimientoLarval(larval);
        }

        public bool setEditaSegimientoLarval(ObjetoSeguimientoLarval larval)
        {
            return _dtSegLarval.setEditaSegimientoLarval(larval);
        }
        public bool setEliminaSeguimientoLarval(int id)
        {
            return _dtSegLarval.setEliminaSeguimientoLarval(id);
        }

        public List<ObjetoSeguimientoSemilla> ListadoSeguimientoSemilla()
        {
            return _dtFacSeguimientoSemilla.SeguimientoSemilla(1);
        }

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

        public List<ObjetoFactoresMedicion> ListaFactoresMedicion()
        {
            return _dtFac.ListadoFactoresMedicion();
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