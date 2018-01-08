using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.DAO
{


    internal class FactorySeguimientosSemillas
    {
         
         

        /// <summary>
        /// Metodo Menu
        /// Segun el ID del seguimiento, carga a la base la momento de grabar un dato ya la tabla se auto incrementa.
        /// </summary>
        /// <param name="Id">ID del seguimiento usuadi</param>
        /// <returns>Lista se consumura desde la paginas de seguimiento de semilla segun perfil asociado</returns>
        public List<ObjetoSeguimientoSemilla> SeguimientoSemilla(int Id)
        {
            var listadoSeguimientoSemilla = new List<ObjetoSeguimientoSemilla>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_ListaSguimientoSemilla", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"Id", Id}
                                                                                            });

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoSeguimientoSemilla();
                     

                    validador = data.Rows[i].Field<object>("Id_SeguimientoSemilla");
                    resultadoListado.IdSeguimientoSemilla = validador != null ? data.Rows[i].Field<Decimal>("Id_SeguimientoSemilla") : -1;


                    validador = data.Rows[i].Field<object>("FechaRegistro");
                    resultadoListado.FechaRegistro = validador != null ? data.Rows[i].Field<DateTime>("FechaRegistro") : Convert.ToDateTime("01/01/2017");

                    validador = data.Rows[i].Field<object>("contenedororigen");
                    resultadoListado.NombreContenedororigen = validador != null ? data.Rows[i].Field<string>("contenedororigen") : "Sin Contendor";


                    validador = data.Rows[i].Field<object>("Destino");
                    resultadoListado.NombreContenedorDestino = validador != null ? data.Rows[i].Field<string>("Destino") : "Sin Contendor";



                    validador = data.Rows[i].Field<object>("CantidadOrigen");
                    resultadoListado.CantidadOrigen = validador != null ? data.Rows[i].Field<int>("CantidadOrigen") : 0;

                    validador = data.Rows[i].Field<object>("CalibreOrigen");
                    resultadoListado.CalibreOrigen = validador != null ? data.Rows[i].Field<int>("CalibreOrigen") : 0;

                    validador = data.Rows[i].Field<object>("CantidadCosechado");
                    resultadoListado.CantidadCosechado = validador != null ? data.Rows[i].Field<int>("CantidadCosechado") : 0;


                    validador = data.Rows[i].Field<object>("CantidadCalibre");
                    resultadoListado.CantidadCalibre = validador != null ? data.Rows[i].Field<int>("CantidadCalibre") : 0;
                      

                    listadoSeguimientoSemilla.Add(resultadoListado);
                }
            }
            return listadoSeguimientoSemilla;
        }




        /// <summary>
        /// Metodo para grabar un nuevo usuario
        /// </summary>
        /// <param name="seguimiento semillas">Objeto del tipo usuario con todos los datos</param>
        /// <returns>valor mayor a 1 si el grabado resulta OK, 0 si hay error. </returns>
        public bool setGrabaSeuimientoSemillla(ObjetoSeguimientoSemilla semilla)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("CRUD_SeguimientoSemilla", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"@p_id_SeguimientoSemilla",semilla.IdSeguimientoSemilla},
                                                                                                {"@p_IdTipoContenedorOrigen", semilla.IdTipoContenedorOrigen },
                                                                                                {"@p_FechaRegistro", semilla.FechaRegistro },
                                                                                                {"@p_IdFactoresMedicion", semilla.IdFactoresMedicion },
                                                                                                {"@p_CantidadOrigen", semilla.CantidadOrigen },
                                                                                                {"@p_CalibreOrigen", semilla.CalibreOrigen },
                                                                                                {"@p_IdTipoContenedorDestino", semilla.IdTipoContenedorDestino},
                                                                                                {"@p_CantidadCosechado", semilla.CantidadCosechado},
                                                                                                {"@p_CantidadCalibre", semilla.CantidadCalibre },
                                                                                                {"@p_accion", "A" }}); 
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




        /// <summary>
        /// Metodo para grabar un nuevo usuario
        /// </summary>
        /// <param name="seguimiento semillas">Objeto del tipo usuario con todos los datos</param>
        /// <returns>valor mayor a 1 si el grabado resulta OK, 0 si hay error. </returns>
        public bool setELiminaSeuimientoSemillla(ObjetoSeguimientoSemilla semilla)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("CRUD_SeguimientoSemilla", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"@p_id_SeguimientoSemilla", semilla.IdSeguimientoSemilla},
                                                                                                {"@p_IdTipoContenedorOrigen", semilla.IdTipoContenedorOrigen },
                                                                                                {"@p_FechaRegistro", semilla.FechaRegistro },
                                                                                                {"@p_IdFactoresMedicion", semilla.IdFactoresMedicion },
                                                                                                { "@p_CalibreOrigen", semilla.CalibreOrigen },
                                                                                                {"@p_IdTipoContenedorDestino", semilla.IdTipoContenedorDestino },
                                                                                                {"@p_CantidadCosechado", semilla.CantidadCosechado },
                                                                                                {"@p_CantidadCalibre", semilla.CantidadCalibre },
                                                                                                {"@p_accion", "E" }});
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