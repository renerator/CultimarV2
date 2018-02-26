using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CultimarWebApp.Utils.DAO
{
    internal class FactorySeguimientoMar
    {
        public List<ObjetoSeguimientoMar> ListadoSeguimientoMar(int idRegistro)
        {
            var listadoSeguimientoMar = new List<ObjetoSeguimientoMar>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOSEGUIMIENTOMAR", new System.Collections.Hashtable() {
                                                                                                {"@idRegistro",idRegistro }
                                                                                             });
            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoSeguimientoMar();
                    validador = data.Rows[i].Field<object>("idSeguimiento");
                    resultadoListado.IdSeguimiento = validador != null ? data.Rows[i].Field<int>("idSeguimiento") : -1;

                    validador = data.Rows[i].Field<object>("idRegistroInicial");
                    resultadoListado.IdRegistroInicial = validador != null ? data.Rows[i].Field<int>("idRegistroInicial") : -1;

                    validador = data.Rows[i].Field<object>("NombreCultivo");
                    resultadoListado.NombreCultivo = validador != null ? data.Rows[i].Field<string>("NombreCultivo") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("idMortalidad");
                    resultadoListado.IdMortalidad = validador != null ? data.Rows[i].Field<int>("idMortalidad") : -1;

                    validador = data.Rows[i].Field<object>("NombreMortalidad");
                    resultadoListado.NombreMortalidad = validador != null ? data.Rows[i].Field<string>("NombreMortalidad") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("FechaDesdoble");
                    resultadoListado.FechaDesdoble = validador != null ? data.Rows[i].Field<DateTime>("FechaDesdoble") : DateTime.Now;

                    validador = data.Rows[i].Field<object>("CantidadOrigen");
                    resultadoListado.CantidadOrigen = validador != null ? data.Rows[i].Field<int>("CantidadOrigen") : -1;

                    validador = data.Rows[i].Field<object>("idCalibreOrigen");
                    resultadoListado.IdCalibreOrigen = validador != null ? data.Rows[i].Field<int>("idCalibreOrigen") : -1;

                    validador = data.Rows[i].Field<object>("NombreCalibreOrigen");
                    resultadoListado.NombreCalibreOrigen = validador != null ? data.Rows[i].Field<string>("NombreCalibreOrigen") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("idUbicacionOrigen");
                    resultadoListado.IdUbicacionOrigen = validador != null ? data.Rows[i].Field<int>("idUbicacionOrigen") : -1;

                    validador = data.Rows[i].Field<object>("NombreUbicacionOrigen");
                    resultadoListado.NombreUbicacionOrigen = validador != null ? data.Rows[i].Field<string>("NombreUbicacionOrigen") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("idUbicacionDestino");
                    resultadoListado.IdUbicacionDestino = validador != null ? data.Rows[i].Field<int>("idUbicacionDestino") : -1;

                    validador = data.Rows[i].Field<object>("NombreUbicacionDestino");
                    resultadoListado.NombreUbicacionDestino = validador != null ? data.Rows[i].Field<string>("NombreUbicacionDestino") : "NO ASIGNADO";



                    validador = data.Rows[i].Field<object>("CantidadSistemaOrigen");
                    resultadoListado.CantidadSistemaOrigen = validador != null ? data.Rows[i].Field<int>("CantidadSistemaOrigen") : -1;

                    validador = data.Rows[i].Field<object>("idSistemaOrigen");
                    resultadoListado.IdSistemaOrigen = validador != null ? data.Rows[i].Field<int>("idSistemaOrigen") : -1;

                    validador = data.Rows[i].Field<object>("NombreSistemaOrigen");
                    resultadoListado.NombreSistemaOrigen = validador != null ? data.Rows[i].Field<string>("NombreSistemaOrigen") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("CantidadDestino");
                    resultadoListado.CantidadDestino = validador != null ? data.Rows[i].Field<int>("CantidadDestino") : -1;

                    validador = data.Rows[i].Field<object>("idCalibreDestino");
                    resultadoListado.IdCalibreDestino = validador != null ? data.Rows[i].Field<int>("idCalibreDestino") : -1;

                    validador = data.Rows[i].Field<object>("NombreCalibreDestino");
                    resultadoListado.NombreCalibreDestino = validador != null ? data.Rows[i].Field<string>("NombreCalibreDestino") : "NO ASIGNADO";

                    validador = data.Rows[i].Field<object>("CantidadSistemaDestino");
                    resultadoListado.CantidadSistemaDestino = validador != null ? data.Rows[i].Field<int>("CantidadSistemaDestino") : -1;

                    validador = data.Rows[i].Field<object>("idSistemaDestino");
                    resultadoListado.IdSistemaDestino = validador != null ? data.Rows[i].Field<int>("idSistemaDestino") : -1;

                    validador = data.Rows[i].Field<object>("NombreSistemaDestino");
                    resultadoListado.NombreSistemaDestino = validador != null ? data.Rows[i].Field<string>("NombreSistemaDestino") : "NO ASIGNADO";
                    
                    validador = data.Rows[i].Field<object>("Observaciones");
                    resultadoListado.Observaciones = validador != null ? data.Rows[i].Field<string>("Observaciones") : "SIN OBSERVACIONES PARA EL REGISTRO";
                    

                    listadoSeguimientoMar.Add(resultadoListado);
                }
            }
            return listadoSeguimientoMar;
        }

        public bool SetGrabaSeguimientoMar(int idUsuario, ObjetoSeguimientoMar mar)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_SET_INGRESASEGUIMIENTOMAR", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"@idUsuario",idUsuario },
                                                                                                {"@idSeguimiento",mar.IdSeguimiento },
                                                                                                {"@idRegistroInicial",mar.IdRegistroInicial },
                                                                                                {"@idMortalidad",mar.IdMortalidad },
                                                                                                {"@FechaDesdoble",mar.FechaDesdoble },
                                                                                                {"@CantidadOrigen",mar.CantidadOrigen },
                                                                                                {"@idCalibreOrigen",mar.IdCalibreOrigen },
                                                                                                {"@idUbicacionOrigen",mar.IdUbicacionOrigen },
                                                                                                {"@CantidadSistemaOrigen",mar.CantidadSistemaOrigen },
                                                                                                {"@idSistemaOrigen",mar.IdSistemaOrigen },
                                                                                                {"@CantidadDestino",mar.CantidadDestino },
                                                                                                {"@idCalibreDestino",mar.IdCalibreDestino },
                                                                                                {"@idUbicacionDestino",mar.IdUbicacionDestino },
                                                                                                {"@CantidadSistemaDestino",mar.CantidadSistemaDestino },
                                                                                                {"@idSistemaDestino",mar.IdSistemaDestino },
                                                                                                {"@Observaciones",mar.Observaciones }

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