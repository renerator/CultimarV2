using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.DAO
{
    public class FactorySeguimientoFijacion
    {
        /// <summary>
        /// Metodo para listar el seguimiento Fijacion
        /// </summary>


        public List<ObjetoSeguimientoFijacion> ListadoFijacion()
        {
            var ListadoSeguimientoFijacion = new List<ObjetoSeguimientoFijacion>();
            var data = new DBConector().EjecutarProcedimientoAlmacenado("[SP_GET_LISTADOSEGUIMIENTOFIJACION]", new System.Collections.Hashtable());

            if (data.Rows.Count > 0)
            {
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    var validador = new object();
                    var resultadoListado = new ObjetoSeguimientoFijacion();
                    validador = data.Rows[i].Field<object>("Id");
                    resultadoListado.Id = validador != null ? data.Rows[i].Field<int>("Id") : -1;

                    validador = data.Rows[i].Field<object>("Fecha Registro");
                    resultadoListado.FechaRegistro = validador != null ? data.Rows[i].Field<DateTime>("FechaRegistro") : Convert.ToDateTime(2017-12-19);

                    validador = data.Rows[i].Field<object>("LarvasCalibre");
                    resultadoListado.LarvasCalibre = validador != null ? data.Rows[i].Field<int>("LarvasCalibre") : 0;

                    validador = data.Rows[i].Field<object>("Cosecha Calibre");
                    resultadoListado.CosechaCalibre = validador != null ? data.Rows[i].Field<int>("CosechaCalibre") : 0;

                    validador = data.Rows[i].Field<object>("Cosecha Cantidad");
                    resultadoListado.CosechaCantidad = validador != null ? data.Rows[i].Field<int>("CosechaCantidad") : 0;

                    validador = data.Rows[i].Field<object>("Numero Estanque");
                    resultadoListado.NumeroEstanque = validador != null ? data.Rows[i].Field<int>("NumeroEstanque") : 0;

                    validador = data.Rows[i].Field<object>("Densidad Siembra");
                    resultadoListado.DensidadSiembra = validador != null ? data.Rows[i].Field<int>("DensidadSiembra") :0;

                    validador = data.Rows[i].Field<object>("Mortalidad");
                    resultadoListado.IdMortalidad = validador != null ? data.Rows[i].Field<int>("Nombre") : 0;
             
                    validador = data.Rows[i].Field<object>("Factores Medicion");
                    resultadoListado.FactoresMedicion = validador != null ? data.Rows[i].Field<string>("FactoresMedicion") : "";

                    validador = data.Rows[i].Field<object>("Fecha Sistema");
                    resultadoListado.FechaSistema = validador != null ? data.Rows[i].Field<DateTime>("FechaSistema") :DateTime.Today;

                    validador = data.Rows[i].Field<object>("Estado");
                    resultadoListado.Estado = validador != null ? data.Rows[i].Field<bool>("Estado") : true;

                    ListadoSeguimientoFijacion.Add(resultadoListado);
                }
            }
            return ListadoSeguimientoFijacion;
        }

        /// <summary>
        /// Metodo para grabar seguimiento larval
        /// </summary>

        public bool setGrabasegimientoFijacion(ObjetoSeguimientoFijacion seguimientofijacion)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("CRUD_SeguimientoFijacion", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"FechaRegistro", seguimientofijacion.FechaRegistro },
                                                                                                {"LarvasCalibre", seguimientofijacion.LarvasCalibre },
                                                                                                {"LarvasCantidad", seguimientofijacion.LarvasCantidad },
                                                                                                {"CosechaCalibre", seguimientofijacion.CosechaCalibre },
                                                                                                {"CosechaCantidad", seguimientofijacion.CosechaCantidad },
                                                                                                {"NumeroEstanque", seguimientofijacion.NumeroEstanque },
                                                                                                {"DensidadSiembra", seguimientofijacion.DensidadSiembra },
                                                                                                {"IdMortalidad", seguimientofijacion.IdMortalidad },
                                                                                                {"FactoresMedicion", seguimientofijacion.FactoresMedicion },
                                                                                                {"FechaSistema", seguimientofijacion.FechaSistema },
                                                                                                {"Estado", seguimientofijacion.Estado },
                                                                                                {"A",seguimientofijacion }
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

        public bool setEditarsegimientoFijacion(ObjetoSeguimientoFijacion seguimientofijacion)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("[CRUD_SeguimientoFijacion]", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"FechaRegistro", seguimientofijacion.FechaRegistro },
                                                                                                {"LarvasCalibre", seguimientofijacion.LarvasCalibre },
                                                                                                {"LarvasCantidad", seguimientofijacion.LarvasCantidad },
                                                                                                {"CosechaCalibre", seguimientofijacion.CosechaCalibre },
                                                                                                {"CosechaCantidad", seguimientofijacion.CosechaCantidad },
                                                                                                {"NumeroEstanque", seguimientofijacion.NumeroEstanque },
                                                                                                {"DensidadSiembra", seguimientofijacion.DensidadSiembra },
                                                                                                {"IdMortalidad", seguimientofijacion.IdMortalidad },
                                                                                                {"FactoresMedicion", seguimientofijacion.FactoresMedicion },
                                                                                                {"FechaSistema", seguimientofijacion.FechaSistema },
                                                                                                {"Estado", seguimientofijacion.Estado },
                                                                                                {"A",seguimientofijacion }
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

        public bool setQuitaSeguimientoFijacion(int id, ObjetoSeguimientoFijacion seguimientofijacion)
        {
            var respuesta = false;
            try
            {
                var data = new DBConector().EjecutarProcedimientoAlmacenado("[CRUD_SeguimientoFijacion]", new System.Collections.Hashtable()
                                                                                            {
                                                                                                {"Id", id},
                                                                                                {"FechaRegistro", seguimientofijacion.FechaRegistro },
                                                                                                {"LarvasCalibre", seguimientofijacion.LarvasCalibre },
                                                                                                {"LarvasCantidad", seguimientofijacion.LarvasCantidad },
                                                                                                {"CosechaCalibre", seguimientofijacion.CosechaCalibre },
                                                                                                {"CosechaCantidad", seguimientofijacion.CosechaCantidad },
                                                                                                {"NumeroEstanque", seguimientofijacion.NumeroEstanque },
                                                                                                {"DensidadSiembra", seguimientofijacion.DensidadSiembra },
                                                                                                {"IdMortalidad", seguimientofijacion.IdMortalidad },
                                                                                                {"FactoresMedicion", seguimientofijacion.FactoresMedicion },
                                                                                                {"FechaSistema", seguimientofijacion.FechaSistema },
                                                                                                {"Estado", seguimientofijacion.Estado },
                                                                                                {"E",seguimientofijacion }
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