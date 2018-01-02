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
        private FactoryTipoContenedor _dtFactoryTipoContenedor = new FactoryTipoContenedor();
        private FactoryRegistroProduccion _dtFactoryRegistroProduccion = new FactoryRegistroProduccion();
        private FactoryMicroAlgas _dtMicroAlgas = new FactoryMicroAlgas();

        public List<ObjetoSeguimientoLarval> ListadoSeguimientoLarval()
        {
            return _dtSegLarval.ListadoSeguimientoLarval(1);
        }
        public List<ObjetoFactoresMedicion> ListadoFactorMedicion()
        {
            return _dtFac.ListadoFactoresMedicion();
        }

        public bool SetGrabaSeguimientoLarval(ObjetoSeguimientoLarval larval)
        {
            return _dtSegLarval.setGrabaSegimientoLarval(larval);
        }

        public bool SetEditaSegimientoLarval(ObjetoSeguimientoLarval larval)
        {
            return _dtSegLarval.setEditaSegimientoLarval(larval);
        }
        public bool SetEliminaSeguimientoLarval(int id)
        {
            return _dtSegLarval.setEliminaSeguimientoLarval(id);
        }

        public List<ObjetoSeguimientoSemilla> ListadoSeguimientoSemilla()
        {
            return _dtFacSeguimientoSemilla.SeguimientoSemilla(1);
        }
        public List<ObjetoRegistroProduccion> ListadoRegistroProduccion()
        {
            return _dtFactoryRegistroProduccion.listadoRegistroProduccion();
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

        public List<ObjetoOrigen> ListadoParametrosOrigen()
        {
            return _dtFac.ListadoParametrosOrigen();
        }

        public List<ObjetoDestino> ListadoParametrosDestino()
        {
            return _dtFac.ListadoParametrosDestino();
        }

        public List<ObjetoEspecies> ListadoParametrosEspecies()
        {
            return _dtFac.ListadoParametrosEspecies();
        }

        public List<ObjetoTipoContenedor> ListadoTipoContenedor()
        {
            return _dtFac.ListadoTipoContenedor();
        }
        public List<ObjetoTipoContenedor> ListadoTipoContenedorOrigen()
        {
            return _dtFactoryTipoContenedor.ListadoContenedorOrigen();
        }

        public List<ObjetoTipoContenedor> ListadoTipoContenedorDestino()
        {
            return _dtFactoryTipoContenedor.ListadoContenedorDestino();

        }

        public List<ObjetoTipoIdentificacion> ListadoTipoIdentificacion()
        {
            return _dtFac.ListadoTipoIdentificacion();
        }

        public List<ObjetoTipoMortalidad> ListadoTipoMortalidad()
        {
            return _dtFac.ListadoTipoMortalidad();
        }

        public List<ObjetoTipoSistema> ListadoTipoSistema()
        {
            return _dtFac.ListadoTipoSistema();
        }

        public List<ObjetoFactoresMedicion> ListaFactoresMedicion()
        {
            return _dtFac.ListadoFactoresMedicion();
        }

        public List<ObjetoMicroAlga> ListadoMicroAlgas()
        {
            return _dtMicroAlgas.ListadoMicroAlgas();
        }

        public bool SetGrabaUsuario(ObjetoUsuarios usuario)
        {
            return _dtFac.setGrabaUsuario(usuario);
        }
        public bool SetGrabaSeguimientoSemilla(ObjetoSeguimientoSemilla semilla)
        {
            return _dtFacSeguimientoSemilla.setGrabaSeuimientoSemillla(semilla);
        }

        public bool SetGrabaRegistroProduccion(ObjetoRegistroProduccion produccion)
        {
            return _dtFactoryRegistroProduccion.setGrabaRegistroProduccion(produccion);
        }
        public bool GetVerificaUsuario(string rutUsuario)
        {
            return _dtFac.getVerificaUsuario(rutUsuario);
        }

        public bool SetAutorizaUsuario(int idUsuario)
        {
            return _dtFac.setAutorizaUsuario(idUsuario);
        }

        public bool SetQuitaPermisoUsuario(int idUsuario)
        {
            return _dtFac.setQuitaPermisoUsuario(idUsuario);
        }

        public bool SetGrabaParametroOrigen(ObjetoOrigen origen)
        {
            return _dtFac.setGrabaParametroOrigen(origen);
        }
        public bool SetGrabaParametroDestino(ObjetoDestino destino)
        {
            return _dtFac.setGrabaParametroDestino(destino);
        }

        public bool SetGrabaParametroEspecies(ObjetoEspecies especies)
        {
            return _dtFac.setGrabaParametrosEspecies(especies);
        }
        public bool SetGrabaParametrosTipoContenedor(ObjetoTipoContenedor tipoContenedor)
        {
            return _dtFac.setGrabaParametrosTipoContenedor(tipoContenedor);
        }
        public bool SetGrabaParametrosTipoIdentificacion(ObjetoTipoIdentificacion tipoIdentificacion)
        {
            return _dtFac.setGrabaParametrosTipoIdentificacion(tipoIdentificacion);
        }

        public bool SetGrabaParametrosTipoMortalidad(ObjetoTipoMortalidad tipoMortalidad)
        {
            return _dtFac.setGrabaParametrosTipoMortalidad(tipoMortalidad);
        }
        public bool SetGrabaParametrosTipoSistema(ObjetoTipoSistema tipoSistema)
        {
            return _dtFac.setGrabaParametrosTipoSistema(tipoSistema);
        }
    }
}