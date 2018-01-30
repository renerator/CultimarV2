using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoSeguimientoLarval
    {
        private int _id;
        private int _cantidadDeLarvas;
        private int _cosechaLarvas;
        private int _numeroEstanque;
        private int _densidadCultivo;
        private DateTime _fechaRegistro;
        private int _factoresMedicion;
        private string _nombre;
        private bool _estado;
        private int _IdMortalidad;
        private int _IdFactor;



        public int IdFactor
        {
            get { return _IdFactor; }
            set { _IdFactor = value; }
        }


        public int IdMortalidad
        {
            get { return _IdMortalidad; }
            set { _IdMortalidad = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int CantidadDeLarvas
        {
            get { return _cantidadDeLarvas; }
            set { _cantidadDeLarvas = value; }
        }
        public int CosechaLarvas
        {
            get { return _cosechaLarvas; }
            set { _cosechaLarvas = value; }
        }
        public int NumeroEstanque
        {
            get { return _numeroEstanque; }
            set { _numeroEstanque = value; }
        }
        public int DensidadCultivo
        {
            get { return _densidadCultivo; }
            set { _densidadCultivo = value; }
        }
        public DateTime FechaRegistro
        {
            get { return _fechaRegistro; }
            set { _fechaRegistro = value; }
        }
        public int FactoresMedicion
        {
            get { return _factoresMedicion; }
            set { _factoresMedicion = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }




    }
}


