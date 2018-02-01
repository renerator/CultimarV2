using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.DAO
{
    public class FactoryPreparadoDespacho
    {


        //public List<ObjetoPreparadoDespacho> ListadoPreparadoDespechao()
        //{
        //    var ListadoSeguimientoLarval = new List<ObjetoPreparadoDespacho>();

        //    var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOSPreparadoDespacho", new System.Collections.Hashtable());

        //    if (data.Rows.Count > 0)
        //    {
        //        for (var i = 0; i < data.Rows.Count; i++)
        //        {
        //            var validador = new object();
        //            var resultadoListado = new ObjetoPreparadoDespacho();
        //            validador = data.Rows[i].Field<object>("Id");
        //            resultadoListado.Id = validador != null ? data.Rows[i].Field<int>("Id") : 1;

        //            validador = data.Rows[i].Field<object>("CantidadDeLarvas");
        //            resultadoListado.CantidadDeLarvas = validador != null ? data.Rows[i].Field<int>("CantidadDeLarvas") : 0;

        //            validador = data.Rows[i].Field<object>("CosechaLarvas");
        //            resultadoListado.CosechaLarvas = validador != null ? data.Rows[i].Field<int>("CosechaLarvas") : 0;

        //            validador = data.Rows[i].Field<object>("NumeroEstanque");
        //            resultadoListado.NumeroEstanque = validador != null ? data.Rows[i].Field<int>("NumeroEstanque") : 0;

        //            validador = data.Rows[i].Field<object>("DensidadCultivo");
        //            resultadoListado.DensidadCultivo = validador != null ? data.Rows[i].Field<int>("DensidadCultivo") : 0;

        //            validador = data.Rows[i].Field<object>("FechaRegistro");
        //            resultadoListado.FechaRegistro = validador != null ? data.Rows[i].Field<DateTime>("FechaRegistro") : DateTime.Today;

        //            validador = data.Rows[i].Field<object>("FactoresMedicion");
        //            resultadoListado.FactoresMedicion = validador != null ? data.Rows[i].Field<string>("FactoresMedicion") : "0";

        //            validador = data.Rows[i].Field<object>("IdMortalidad");
        //            resultadoListado.IdMortalidad = validador != null ? data.Rows[i].Field<int>("IdMortalidad") : 0;


        //            ListadoSeguimientoLarval.Add(resultadoListado);
        //        }
        //    }
        //    return ListadoSeguimientoLarval;
        //}





    }
}