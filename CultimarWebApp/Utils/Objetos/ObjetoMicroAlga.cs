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

        private int _idTipoIdentificador;
        private string _nombreIdentificador;
        private int _idTipoContenedor;
        private string _nombreContenedor;
        private string _tipoContenedor;
        private int _resultadoTCBS;
        private int _volumenCosechado;
        private int _concentracion;
        private int _conteo;

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

        public int IdTipoIdentificador
        {
            get { return _idTipoIdentificador; }
            set { _idTipoIdentificador = value; }
        }
        public string NombreIdentificador
        {
            get { return _nombreIdentificador; }
            set { _nombreIdentificador = value; }
        }
        public int IdTipoContenedor
        {
            get { return _idTipoContenedor; }
            set { _idTipoContenedor = value; }
        }
        public string NombreContenedor
        {
            get { return _nombreContenedor; }
            set { _nombreContenedor = value; }
        }
        public string TipoContenedor
        {
            get { return _tipoContenedor; }
            set { _tipoContenedor = value; }
        }
        

        public int ResultadoTCBS
        {
            get { return _resultadoTCBS; }
            set { _resultadoTCBS = value; }
        }
        public int VolumenCosechado
        {
            get { return _volumenCosechado; }
            set { _volumenCosechado = value; }
        }
        public int Concentracion
        {
            get { return _concentracion; }
            set { _concentracion = value; }
        }
        public int Conteo
        {
            get { return _conteo; }
            set { _conteo = value; }
        }
    }
}