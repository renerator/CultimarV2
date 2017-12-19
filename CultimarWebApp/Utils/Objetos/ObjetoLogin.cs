using System;
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
    }
}