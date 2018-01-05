﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoLogin
    {

        private string _rut;
        private string _nombre;
        private int _idPerfil;
        private bool _autorizaModificacion;
        private bool _activo;

        public string Rut
        {
            get { return _rut; }
            set { _rut = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public int IdPerfil
        {
            get { return _idPerfil; }
            set { _idPerfil = value; }
        }
        public bool AutorizaModificacion
        {
            get { return _autorizaModificacion; }
            set { _autorizaModificacion = value; }
        }
        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }
    }
}