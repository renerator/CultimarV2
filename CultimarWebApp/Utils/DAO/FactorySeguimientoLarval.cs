using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.DAO
{
    public class FactorySeguimientoLarval
    {

        /// <summary>
        /// Metodo para listar el seguimiento larval
        /// </summary>


        public List<ObjetoSeguimientoLarval> ListadoSeguimientoLarval()
        {
            var ListadoSeguimientoLarval = new List<ObjetoSeguimientoLarval>();

            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOSEGUIMIENTOLARVAL", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoSeguimientoLarval();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.Id = validador != null ? data.Rows[i].Field<int>("Id") : 1;

                    validador = data.Rows[i].Field<object>("CantidadDeLarvas");
                    resultadoListado.CantidadDeLarvas = validador != null ? data.Rows[i].Field<int>("CantidadDeLarvas") : 0;

                    validador = data.Rows[i].Field<object>("CosechaLarvas");
                    resultadoListado.CosechaLarvas = validador != null ? data.Rows[i].Field<int>("CosechaLarvas") : 0;

                    validador = data.Rows[i].Field<object>("NumeroEstanque");
                    resultadoListado.NumeroEstanque = validador != null ? data.Rows[i].Field<int>("NumeroEstanque") : 0;

                    validador = data.Rows[i].Field<object>("DensidadCultivo");
                    resultadoListado.DensidadCultivo = validador != null ? data.Rows[i].Field<int>("DensidadCultivo") : 0;

                    validador = data.Rows[i].Field<object>("FechaRegistro");
                    resultadoListado.FechaRegistro = validador != null ? data.Rows[i].Field<DateTime>("FechaRegistro") : DateTime.Today;

                    validador = data.Rows[i].Field<object>("IdFactor");
                    resultadoListado.IdFactor = validador != null ? data.Rows[i].Field<int>("IdFactor") : 0;

                    validador = data.Rows[i].Field<object>("IdMortalidad");
                    resultadoListado.IdMortalidad= validador != null ? data.Rows[i].Field<int>("IdMortalidad") : 0;

                    
                    ListadoSeguimientoLarval.Add(resultadoListado);
                }
            }
            return ListadoSeguimientoLarval;
        }

        /// <summary>
        /// Metodo para grabar seguimiento larval
        /// </summary>


        public bool setGrabaSegimientoLarval(ObjetoSeguimientoLarval seguimientolarval)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("CRUD_SeguimientoLarval", new System.Collections.Hashtable()
                                                                                            {   {"@p_Id", seguimientolarval.Id },
                                                                                                {"@p_CantidadDeLarvas", seguimientolarval.CantidadDeLarvas },
                                                                                                {"@p_CosechaLarvas", seguimientolarval.CosechaLarvas},
                                                                                                {"@p_NumeroEstanque", seguimientolarval.NumeroEstanque},
                                                                                                {"@p_DensidadCultivo", seguimientolarval.DensidadCultivo },
                                                                                                {"@p_FechaRegistro", seguimientolarval.FechaRegistro.ToShortDateString() },
                                                                                                {"@p_FactoresMedicion", seguimientolarval.FactoresMedicion },
                                                                                                {"@p_IdMortalidad", seguimientolarval.IdMortalidad }
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

        public bool setEditaSegimientoLarval(ObjetoSeguimientoLarval seguimientolarval)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("CRUD_SeguimientoLarval", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"@CantidadDeLarvas", seguimientolarval.CantidadDeLarvas },
                                                                                                {"@CosechaLarvas", seguimientolarval.CosechaLarvas },
                                                                                                {"@NumeroEstanque", seguimientolarval.NumeroEstanque },
                                                                                                {"@DensidadCultivo", seguimientolarval.DensidadCultivo },
                                                                                                {"@FechaRegistro", seguimientolarval.FechaRegistro },
                                                                                                {"@FactoresMedicion", seguimientolarval.FactoresMedicion },
                                                                                                {"@IdMortalidad", seguimientolarval.Nombre },
                                                                                                {"A",seguimientolarval }
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

        public bool setEliminaSeguimientoLarval(int id)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("CRUD_SeguimientoLarval", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"Id", id},


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