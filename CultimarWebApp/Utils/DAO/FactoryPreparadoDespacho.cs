using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.DAO
{
    public class FactoryPreparadoDespacho
    {


        public List<ObjetoPreparadoDespacho> ListadoPreparadoDespechao()
        {
            var ListadoPDespachoado = new List<ObjetoPreparadoDespacho>();

            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOPreparadoDespacho", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoPreparadoDespacho();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.IdPreparoDespacho = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("FechaEnvio");
                    resultadoListado.FechaEnvio = validador != null ? data.Rows[i].Field<string>("FechaEnvio") : "01-01-1900";

                    validador = data.Rows[i].Field<object>("FechaPreparado");
                    resultadoListado.FechaPreparado = validador != null ? data.Rows[i].Field<string>("FechaPreparado") : "01-01-1900";

                    validador = data.Rows[i].Field<object>("IdOrigen");
                    resultadoListado.IdOrigen = validador != null ? data.Rows[i].Field<int>("IdOrigen") : 1;

                    validador = data.Rows[i].Field<object>("IdDestino");
                    resultadoListado.IdDestino = validador != null ? data.Rows[i].Field<int>("IdDestino") : 1;

                    validador = data.Rows[i].Field<object>("PesoNeto");
                    resultadoListado.PesoNeto = validador != null ? data.Rows[i].Field<int>("PesoNeto") : 0;


                    validador = data.Rows[i].Field<object>("PesoBruto");
                    resultadoListado.PesoBruto = validador != null ? data.Rows[i].Field<int>("PesoBruto") : 0;

                    validador = data.Rows[i].Field<object>("Cantidad");
                    resultadoListado.Cantidad = validador != null ? data.Rows[i].Field<int>("Cantidad") :0;


                    validador = data.Rows[i].Field<object>("Calibre");
                    resultadoListado.Cantidad = validador != null ? data.Rows[i].Field<int>("Calibre") : 0;


                    validador = data.Rows[i].Field<object>("Cliente");
                    resultadoListado.Cliente = validador != null ? data.Rows[i].Field<string>("Cliente") : ".";
                     
                    ListadoPDespachoado.Add(resultadoListado);
                }
            }
            return ListadoPDespachoado;
        }




        public bool setGrabaPreparadoDespachl(ObjetoPreparadoDespacho pdespacho)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("CRUD_PreparadoDespacho", new System.Collections.Hashtable()
                                                                                            {   {"@p_Id", pdespacho.IdPreparoDespacho },
                                                                                                {"@p_FechaEnvio", pdespacho.FechaEnvio },
                                                                                                {"@p_FechaPreparado", pdespacho.FechaPreparado},
                                                                                                {"@p_IdOrigen", pdespacho.IdOrigen},
                                                                                                {"@p_IdDestino", pdespacho.IdDestino },
                                                                                                {"@p_PesoNeto", pdespacho.PesoNeto },
                                                                                                {"@p_PesoBruto", pdespacho.PesoBruto },
                                                                                                {"@p_Cantidad", pdespacho.Cantidad },
                                                                                                {"@p_Calibre", pdespacho.Calibre },
                                                                                                  {"@p_Cliente", pdespacho.Cliente}

                                                                                           });
                if (data.Rows.Count > 0)
                {
                    respuesta = true;
                }
            }
            catch (SqlException ex)
            {
                new CapturaExcepciones(ex);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
            }
            return respuesta;
        }




    }
}