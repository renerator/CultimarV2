using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoMicroAlga
    {
        private int _idMicroAlga;
        private int _idEspecie;
        private string _nombreEspecie;
        private DateTime _fechaSistema;
        private int _volumenSembrado;
        private int _numeroBolsa;
        private DateTime _fechaRegistro;
        private bool _estado;

        public int IdMicroAlga
        {
            get { return _idMicroAlga; }
            set { _idMicroAlga = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public int IdEspecie {
            get { return _idEspecie; }
            set { _idEspecie = value; }
        }
        public string NombreEspecie {
            get { return _nombreEspecie; }
            set { _nombreEspecie = value; }
        }
        public DateTime FechaSistema {
            get { return _fechaSistema; }
            set { _fechaSistema = value; }
        }
        public int VolumenSembrado
        {
            get { return _volumenSembrado; }
            set { _volumenSembrado = value; }
        }
        public int NumeroBolsa {
            get { return _numeroBolsa; }
            set { _numeroBolsa = value; }
        }
        public DateTime FechaRegistro {
            get { return _fechaRegistro; }
            set { _fechaRegistro = value; }
        }
    }
}