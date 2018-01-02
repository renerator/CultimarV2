using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace CultimarWebApp.Utils.DAO
{
    internal class FactoryMicroAlgas
    {
        public List<ObjetoMicroAlga> ListadoMicroAlgas()
        {
            var lisMicroAlgas = new List<ObjetoMicroAlga>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOMICROALGAS", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoMicroAlga();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdMicroAlga = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("IdEspecie");
                    resultadoListado.IdEspecie = validador != null ? data.Rows[i].Field<int>("IdEspecie") : -1;

                    validador = data.Rows[i].Field<object>("NombreEspecie");
                    resultadoListado.NombreEspecie = validador != null ? data.Rows[i].Field<string>("NombreEspecie") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("FechaSistema");
                    resultadoListado.FechaSistema = validador != null ? data.Rows[i].Field<DateTime>("FechaSistema") : DateTime.Now.AddYears(-100);

                    validador = data.Rows[i].Field<object>("VolumenSembrado");
                    resultadoListado.VolumenSembrado = validador != null ? data.Rows[i].Field<int>("VolumenSembrado") : -1;

                    validador = data.Rows[i].Field<object>("NumeroBolsa");
                    resultadoListado.NumeroBolsa = validador != null ? data.Rows[i].Field<int>("NumeroBolsa") : -1;

                    validador = data.Rows[i].Field<object>("FechaRegistro");
                    resultadoListado.FechaRegistro = validador != null ? data.Rows[i].Field<DateTime>("FechaRegistro") : DateTime.Now.AddYears(-100);

                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<bool>("Estado") : false;

                    lisMicroAlgas.Add(resultadoListado);
                }
            }
            return lisMicroAlgas;
        }
    }
}