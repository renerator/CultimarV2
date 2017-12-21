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
      

        public List<ObjetoSeguimientoLarval> ListadoSeguimientoLarval(int id)
        {
            var ListadoSeguimientoLarval = new List<ObjetoSeguimientoLarval>();                                                                                                       
                                                                                          
            var data = new DBConector().EjecutarProcedimientoAlmacenado("SP_GET_LISTADOSEGUIMIENTOLARVAL", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"Id", id},

                                                                                            });

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoSeguimientoLarval();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.Id = validador != null ? data.Rows[i].Field<Decimal>("Id") : 1;

                    validador = data.Rows[i].Field<object>("CantidadDeLarvas");
                    resultadoListado.CantidadDeLarvas = validador != null ? data.Rows[i].Field<int>("CantidadDeLarvas"): 0 ;

                    validador = data.Rows[i].Field<object>("CosechaLarvas");
                    resultadoListado.CosechaLarvas = validador != null ? data.Rows[i].Field<int>("CosechaLarvas") :0;

                    validador = data.Rows[i].Field<object>("NumeroEstanque");
                    resultadoListado.NumeroEstanque = validador != null ? data.Rows[i].Field<int>("NumeroEstanque") :0;

                    validador = data.Rows[i].Field<object>("DensidadCultivo");
                    resultadoListado.DensidadCultivo = validador != null ? data.Rows[i].Field<int>("DensidadCultivo") : 0;

                    validador = data.Rows[i].Field<object>("FechaRegistro");
                    resultadoListado.FechaRegistro = validador != null ? data.Rows[i].Field<DateTime>("FechaRegistro") : DateTime.Today;    

                    validador = data.Rows[i].Field<object>("FactoresMedicion");
                    resultadoListado.FactoresMedicion = validador != null ? data.Rows[i].Field<String>("FactoresMedicion") :"";

                    validador = data.Rows[i].Field<object>("Nombre");
                    resultadoListado.Nombre = validador != null ? data.Rows[i].Field<string>("Nombre") :"";

       
                    
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
                                                                                            {
                                                                                                {"@CantidadDeLarvas", seguimientolarval.CantidadDeLarvas },
                                                                                                {"@CosechaLarvas", seguimientolarval.CosechaLarvas },
                                                                                                {"@NumeroEstanque", seguimientolarval.NumeroEstanque },
                                                                                                {"@DensidadCultivo", seguimientolarval.DensidadCultivo },
                                                                                                {"@FechaRegistro", seguimientolarval.FechaRegistro },
                                                                                                {"@FactoresMedicion", seguimientolarval.FactoresMedicion },
                                                                                                {"@IdMortalidad", seguimientolarval.Nombre },
                                                                                                {"true", seguimientolarval.Estado },
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