using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoRegistroProduccion
    {

        private int _idRegistroProduccion;
        private int _CantidadProductoresMachos;
        private int _CantidadProductoresHembras;
        private DateTime _FechaInicioCultivo;
        private int _NumeroDesoveTemporada;
        private int _CantidadFecundada;
        private int _CantidadSembrada;
        private DateTime _FechaRegistro;
        private string _FactoresMedicion;
        private int _NumeroEstanquesUtilizado;
        private int _DensidadSiembra;
        private int _IdPloidia;
        private int _IdFactor;


        public int IdFactor
        {
            get { return _IdFactor; }
            set { _IdFactor = value; }
        }
        public int IdPloidia
        {
            get { return _IdPloidia; }
            set { _IdPloidia = value; }
        }
        public int DensidadSiembra
        {
            get { return _DensidadSiembra; }
            set { _DensidadSiembra = value; }
        }
        public int NumeroEstanquesUtilizado
        {
            get { return _NumeroEstanquesUtilizado; }
            set { _NumeroEstanquesUtilizado = value; }
        }
        public string FactoresMedicion
        {
            get { return _FactoresMedicion; }
            set { _FactoresMedicion = value; }
        }
        public DateTime FechaRegistro
        {
            get { return _FechaRegistro; }
            set { _FechaRegistro = value; }
        }
        public int CantidadSembrada
        {
            get { return _CantidadSembrada; }
            set { _CantidadSembrada = value; }
        }
        public int CantidadFecundada
        {
            get { return _CantidadFecundada; }
            set { _CantidadFecundada = value; }
        }
        public int NumeroDesoveTemporada
        {
            get { return _NumeroDesoveTemporada; }
            set { _NumeroDesoveTemporada = value; }
        }
        public DateTime FechaInicioCultivo
        {
            get { return _FechaInicioCultivo; }
            set { _FechaInicioCultivo = value; }
        }
        public int CantidadProductoresHembras
        {
            get { return _CantidadProductoresHembras; }
            set { _CantidadProductoresHembras = value; }
        }
        public int CantidadProductoresMachos
        {
            get { return _CantidadProductoresMachos; }
            set { _CantidadProductoresMachos = value; }
        }
        public int IdRegistroProduccion
        {
            get { return _idRegistroProduccion; }
            set { _idRegistroProduccion = value; }
        }



    }
}