using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.Objetos
{
    public class ObjetoSeguimientoFijacion
    {
        private int _id; 
        private int _larvasCalibre;
        private int _larvasCantidad;
        private int _cosechaCalibre;
        private int _cosechaCantidad;
        private int _numeroEstanque;
        private int _densidadSiembra;
        private int _idMortalidad;
        private int _cantidadMortalidad;
        private string _fechaRegistro;
        private string _factoresMedicion;
        private DateTime _fechaSistema;
        private bool _estado;

        

        public int IdSeguimientoFijacion
        {
            get { return _id; }
            set { _id = value; }
        }

        public int CantidadMortalidad
        {
            get { return _cantidadMortalidad; }
            set { _cantidadMortalidad = value; }
        }


        public string FechaRegistro
        {
            get { return _fechaRegistro; }
            set { _fechaRegistro = value; }
        }


        public int LarvasCalibre
        {
            get { return _larvasCalibre; }
            set { _larvasCalibre = value; }
        }

        public int LarvasCantidad
        {
            get { return _larvasCantidad; }
            set { _larvasCantidad = value; }
        }

        public int CosechaCalibre
        {
            get { return _cosechaCalibre; }
            set { _cosechaCalibre = value; }
        }

        public int CosechaCantidad
        {
            get { return _cosechaCantidad; }
            set { _cosechaCantidad = value; }
        }

        public int NumeroEstanque
        {
            get { return _numeroEstanque; }
            set { _numeroEstanque = value; }
        }

        public int DensidadSiembra
        {
            get { return _densidadSiembra; }
            set { _densidadSiembra = value; }
        }

        public int IdMortalidad
        {
            get { return _idMortalidad; }
            set { _idMortalidad = value; }
        }

        public string FactoresMedicion
        {
            get { return _factoresMedicion; }
            set { _factoresMedicion = value; }
        }

        public DateTime FechaSistema
        {
            get { return _fechaSistema; }
            set { _fechaSistema = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }



        public ObjetoSeguimientoFijacion(int Id, string fechaRegistro, int larvasCalibre, int larvasCantidad, int cosechaCalibre, int cosechaCantidad, int numeroEstanque,
                                            int densidadSiembra, int idMortalidad, string factoresMedicion, DateTime fechaSistema, bool estado)
        {
            FechaRegistro = fechaRegistro;
            LarvasCalibre = larvasCalibre;
            LarvasCantidad = larvasCantidad;
            CosechaCalibre = cosechaCalibre;
            CosechaCantidad = cosechaCantidad;
            NumeroEstanque = numeroEstanque;
            DensidadSiembra = densidadSiembra;
            IdMortalidad = idMortalidad;
            FactoresMedicion = factoresMedicion;
            FechaSistema = fechaSistema;
            Estado = estado;
        }

        public ObjetoSeguimientoFijacion()
        {
        }
    }
}
   