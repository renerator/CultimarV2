using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoRegistroInicialMar
    {
        private int _idRegistro;
        private DateTime _fechaIngreso;
        private DateTime _fechaFuturoDesdoble;
        private int _cantidadOrigen;
        private int _calibreOrigen;
        private int _idOrigen;
        private string _nombreOrigen;
        private int _cantidad;
        private int _idTipoSistema;
        private string _nombreSistema;
        private int _idMortalidad;
        private string _nombreMortalidad;


        public int IdRegistro
        {
            get { return _idRegistro; }
            set { _idRegistro = value; }
        }
        public int IdMortalidad
        {
            get { return _idMortalidad; }
            set { _idMortalidad = value; }
        }

        public string NombreMortalidad
        {
            get { return _nombreMortalidad; }
            set { _nombreMortalidad = value; }
        }
        public int IdTipoSistema
        {
            get { return _idTipoSistema; }
            set { _idTipoSistema = value; }
        }
        public string NombreSistema
        {
            get { return _nombreSistema; }
            set { _nombreSistema = value; }
        }

        public int IdOrigen
        {
            get { return _idOrigen; }
            set { _idOrigen = value; }
        }
        public string NombreOrigen
        {
            get { return _nombreOrigen; }
            set { _nombreOrigen = value; }
        }

        public int CalibreOrigen
        {
            get { return _calibreOrigen; }
            set { _calibreOrigen = value; }
        }

        public int CantidadOrigen
        {
            get { return _cantidadOrigen; }
            set { _cantidadOrigen = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public DateTime FechaIngreso
        {
            get { return _fechaIngreso; }
            set { _fechaIngreso = value; }
        }

        public DateTime FechaFuturoDesdoble
        {
            get { return _fechaFuturoDesdoble; }
            set { _fechaFuturoDesdoble = value; }
        }

    }
}