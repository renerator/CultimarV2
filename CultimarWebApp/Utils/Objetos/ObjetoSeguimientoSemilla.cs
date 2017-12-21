using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoSeguimientoSemilla
    {

        private Decimal _IdSeguimientoSemilla;
        private int _IdTipoContenedorOrigen;
        private DateTime _FechaRegistro;
        private int _IdFactoresMedicion;
        private int _CantidadOrigen;
        private int _CalibreOrigen;
        private int _IdOrigen;
        private int _IdTipoContenedorDestino;
        private int _CantidadCosechado;
        private int _CantidadCalibre;
        private bool _Estado;
        private string _NombreContenedor;


        public Decimal IdSeguimientoSemilla
        {
            get { return _IdSeguimientoSemilla; }
            set { _IdSeguimientoSemilla = value; }
        }


        public string NombreContendor
        {
            get { return _NombreContenedor; }
            set { _NombreContenedor = value; }
        }


        public int IdTipoContenedorOrigen
        {
            get { return _IdTipoContenedorOrigen; }
            set { _IdTipoContenedorOrigen = value; }
        }
        public DateTime FechaRegistro
        {
            get { return _FechaRegistro; }
            set { _FechaRegistro = value; }
        }
        public int IdFactoresMedicion
        {
            get { return _IdFactoresMedicion; }
            set { _IdFactoresMedicion = value; }
        }
        public int CantidadOrigen
        {
            get { return _CantidadOrigen; }
            set { _CantidadOrigen = value; }
        }
        public int CalibreOrigen
        {
            get { return _CalibreOrigen; }
            set { _CalibreOrigen = value; }
        }
        public int IdOrigen
        {
            get { return _IdOrigen; }
            set { _IdOrigen = value; }
        }
        public int IdTipoContenedorDestino
        {
            get { return _IdTipoContenedorDestino; }
            set { _IdTipoContenedorDestino = value; }
        }
        public int CantidadCosechado
        {
            get { return _CantidadCosechado; }
            set { _CantidadCosechado = value; }
        }
        public int CantidadCalibre
        {
            get { return _CantidadCalibre; }
            set { _CantidadCalibre = value; }
        }
       
        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

    }
}