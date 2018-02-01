using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoPreparadoDespacho
    {
        private int _IdPreparoDespacho;
        private string _FechaEnvio;
        private string _FechaPreparado;
        private int _IdOrigen;
        private int _IdDestino;
        private int _PesoNeto;
        private int _PesoBruto;
        private int _Cantidad;
        private int _Calibre;
        private string _Cliente;

        public int IdTipoAlimento
        {
            get { return _IdPreparoDespacho; }
            set { _IdPreparoDespacho = value; }
        }
        public string FechaEnvio
        {
            get { return _FechaEnvio; }
            set { _FechaEnvio = value; }
        }
        public string FechaPreparado
        {
            get { return _FechaPreparado; }
            set { _FechaPreparado = value; }
        }
        public int IdOrigen
        {
            get { return _IdOrigen; }
            set { _IdOrigen = value; }
        }
        public int IdDestino
        {
            get { return _IdDestino; }
            set { _IdDestino = value; }
        }
        public int PesoNeto
        {
            get { return _PesoNeto; }
            set { _PesoNeto = value; }
        }
        public int PesoBruto
        {
            get { return _PesoBruto; }
            set { _PesoBruto = value; }
        }
        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        public int Calibre
        {
            get { return _Calibre; }
            set { _Calibre = value; }
        }
        public string Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

    }
}