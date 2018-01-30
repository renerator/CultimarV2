﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoSeguimientoSemilla
    {

        private int _IdSeguimientoSemilla;
        private int _IdTipoContenedorOrigen;
        private string _FechaRegistro;
        private DateTime _FechaRegistro1;
        private int _IdFactoresMedicion;
        private int _CantidadOrigen;
        private int _CalibreOrigen; 
        private int _IdTipoContenedorDestino;
        private int _CantidadCosechado;
        private int _CantidadCalibre;
        private bool _Estado;
        private string _Contenedororigen;
        private string _NombreContenedorDestino;
        private int _idOrigen;
        private int _IdDestino;
       

        public int IdDestino
        {
            get { return _IdDestino; }
            set { _IdDestino = value; }
        }


        public int idOrigen
        {
            get { return _idOrigen; }
            set { _idOrigen = value; }
        }



        public int IdSeguimientoSemilla
        {
            get { return _IdSeguimientoSemilla; }
            set { _IdSeguimientoSemilla = value; }
        }

        public string NombreContenedorDestino
        {
            get { return _NombreContenedorDestino; }
            set { _NombreContenedorDestino = value; }
        }


        public string NombreContenedororigen
        {
            get { return _Contenedororigen; }
            set { _Contenedororigen = value; }
        }


        public int IdTipoContenedorOrigen
        {
            get { return _IdTipoContenedorOrigen; }
            set { _IdTipoContenedorOrigen = value; }
        }
        public string  FechaRegistro
        {
            get { return _FechaRegistro; }
            set { _FechaRegistro = value; }
        }
        public DateTime FechaRegistro1
        {
            get { return _FechaRegistro1; }
            set { _FechaRegistro1 = value; }
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