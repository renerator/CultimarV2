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

        public bool SetGrabaMicroAlga(ObjetoMicroAlga microAlga)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_SET_GRABAMICROALGA", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"@id", microAlga.IdMicroAlga },
                                                                                                {"@idEspecie", microAlga.IdEspecie },
                                                                                                {"@volumenSembrado", microAlga.VolumenSembrado },
                                                                                                {"@numeroBolsa", microAlga.NumeroBolsa },
                                                                                                {"@fechaRegistro", microAlga.FechaRegistro }
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
        
       
        public List<ObjetoMicroAlga> ListadoSeguimientoMicroAlgas()
        {
            var lisMicroAlgas = new List<ObjetoMicroAlga>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOSEGUIMIENTOMICROALGA", new System.Collections.Hashtable());

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

                    validador = data.Rows[i].Field<object>("FechaIngreso");
                    resultadoListado.FechaRegistro = validador != null ? data.Rows[i].Field<DateTime>("FechaIngreso") : DateTime.Now.AddYears(-100);

                    validador = data.Rows[i].Field<object>("IdTipoIdentificacion");
                    resultadoListado.IdTipoIdentificador = validador != null ? data.Rows[i].Field<int>("IdTipoIdentificacion") : -1;

                    validador = data.Rows[i].Field<object>("NombreIdentificacion");
                    resultadoListado.NombreIdentificador = validador != null ? data.Rows[i].Field<string>("NombreIdentificacion") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("IdTipoContenedor");
                    resultadoListado.IdTipoContenedor = validador != null ? data.Rows[i].Field<int>("IdTipoContenedor") : -1;

                    validador = data.Rows[i].Field<object>("NombreContenedor");
                    resultadoListado.NombreContenedor = validador != null ? data.Rows[i].Field<string>("NombreContenedor") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("TipoContenedor");
                    resultadoListado.TipoContenedor = validador != null ? data.Rows[i].Field<string>("TipoContenedor") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("ResultadoTCBS");
                    resultadoListado.ResultadoTCBS = validador != null ? data.Rows[i].Field<int>("ResultadoTCBS") : -1;
                    
                    validador = data.Rows[i].Field<object>("VolumenCosechado");
                    resultadoListado.VolumenCosechado = validador != null ? data.Rows[i].Field<int>("VolumenCosechado") : -1;

                    validador = data.Rows[i].Field<object>("Concentracion");
                    resultadoListado.Concentracion = validador != null ? data.Rows[i].Field<int>("Concentracion") : -1;
                    
                    validador = data.Rows[i].Field<object>("Conteo");
                    resultadoListado.Conteo = validador != null ? data.Rows[i].Field<int>("Conteo") : -1;

                    validador = data.Rows[i].Field<object>("FechaSistema");
                    resultadoListado.FechaSistema = validador != null ? data.Rows[i].Field<DateTime>("FechaSistema") : DateTime.Now.AddYears(-100);

                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<bool>("Estado") : false;

                    lisMicroAlgas.Add(resultadoListado);
                }
            }
            return lisMicroAlgas;
        }
    }
}