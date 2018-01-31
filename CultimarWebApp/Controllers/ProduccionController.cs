using CultimarWebApp.Utils;
using CultimarWebApp.Utils.DAO;
using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CultimarWebApp.Controllers
{
    public class ProduccionController : Controller
    {
        // GET: Produccion
        Control _control = new Control();
        public ActionResult SeguimientoCultivoLarval()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoSeguimientoLarval> model = _control.ListadoSeguimientoLarval();



                IEnumerable<SelectListItem> TipoMortalidad = _control.ListadoTipoMortalidad().Select(c => new SelectListItem()
                {
                    Text = c.NombreMortalidad,
                    Value = c.IdMortalidad.ToString()
                }).ToList();

                ViewBag.selectTipoM = TipoMortalidad;

                 
                


                IEnumerable<SelectListItem> seleccionMedicion = _control.ListaFactoresMedicion().Select(d => new SelectListItem()
                {
                    Text = d.NombreFactor,
                    Value = d.IdFactor.ToString()
                }).ToList();

                ViewBag.FactorM = seleccionMedicion;



 

                ViewBag.FactorM = seleccionMedicion;


                return View(model);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }

        public ActionResult RegistroProduccion()
        {
            try
            {


                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoRegistroProduccion> model = _control.ListadoRegistroProduccion();



                var item3 = _control.ListadoFactorMedicion();
                ViewBag.FactorM = new MultiSelectList(item3, "IdFactor", "NombreFactor");


                return View(model);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }


        public JsonResult GrabaDatosLarval(int _idCultivoLarval,
                                           int _CantidadLarvas,
                                           int _CosechaLarvas,
                                           int _NumeroEstanque,
                                           int _DensidadCultivo,
                                           string _IdFactoresM,
                                           int _selectTipoM)
        {


            var seguimientoLarval = new ObjetoSeguimientoLarval();
            var validador = 0;

            seguimientoLarval.Id = _idCultivoLarval;
            seguimientoLarval.CantidadDeLarvas = _CantidadLarvas;
            seguimientoLarval.CosechaLarvas = _CosechaLarvas;
            seguimientoLarval.NumeroEstanque = _NumeroEstanque;
            seguimientoLarval.DensidadCultivo = _DensidadCultivo; 
            seguimientoLarval.FactoresMedicion = _IdFactoresM;
            seguimientoLarval.IdMortalidad = _selectTipoM;
            seguimientoLarval.Estado = true;

            if (_control.setGrabaSeguimientoLarval(seguimientoLarval))
            {
                validador = 1;
            }


            return (Json(validador));


        }


        public JsonResult GrabaDatosRegistroProduccion(int _IdProduccion,
                                                        int _CantidadProductoresMachos,
                                                       int _CantidadProductoresHembras,
                                                       string _FechaInicioCultivo,
                                                       int _CantidadFecundada,
                                                       int _NumeroDesoveTemporada,
                                                       int _CantidadSembrada,
                                                       int _FactoresMedicion,
                                                       int _NumeroEstanquesUtilizado,
                                                       int _DensidadSiembra)
        {

            var registoProduccion = new ObjetoRegistroProduccion();
            var validador = 0;
            registoProduccion.IdRegistroProduccion = _IdProduccion;
            registoProduccion.CantidadProductoresMachos = _CantidadProductoresMachos;
            registoProduccion.CantidadProductoresHembras = _CantidadProductoresHembras; 
            registoProduccion.NumeroDesoveTemporada = _NumeroDesoveTemporada;
            registoProduccion.CantidadFecundada = _CantidadFecundada;
            registoProduccion.CantidadSembrada = _CantidadSembrada;
            registoProduccion.FactoresMedicion = _FactoresMedicion;
            registoProduccion.NumeroEstanquesUtilizado = _NumeroEstanquesUtilizado;
            registoProduccion.DensidadSiembra = _DensidadSiembra;

            if (_control.SetGrabaRegistroProduccion(registoProduccion))
            {
                validador = 1;
            }
            return (Json(validador));

        }


        public ActionResult SeguimientoSemilla()
       {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoSeguimientoSemilla> model = _control.ListadoSeguimientoSemilla();


                IEnumerable<SelectListItem> items = _control.ListadoParametrosOrigen().Select(c => new SelectListItem()
                {
                    Text = c.NombreOrigen,
                    Value = c.IdOrigen.ToString()
                }).ToList();

                ViewBag.ContenedorOrigen = items;



                IEnumerable<SelectListItem> items2 = _control.ListadoParametrosDestino().Select(c => new SelectListItem()
                {
                    Text = c.NombreDestino,
                    Value = c.IdDestino.ToString()
                }).ToList();

                ViewBag.ContenedorDestino = items2;

       

                var item3 = _control.ListadoFactorMedicion();
                ViewBag.FactorM = new MultiSelectList(item3, "IdFactor", "NombreFactor");


                return View(model);


            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }


        public JsonResult GrabaDatos(string _IdSemilla, string _IdTipoContenedorOrigen, string _FechaRegistro,
                                     int _IdFactoresMedicion, int _CantidadOrigen, int _CalibreOrigen,
                                       int _IdTipoContenedorDestino, int _CantidadCosechado, int _CantidadCalibre)
        {




          
            var seguimientoSemilla = new ObjetoSeguimientoSemilla();
            var validador = 0;
            seguimientoSemilla.IdSeguimientoSemilla = int.Parse(_IdSemilla.ToString());
            seguimientoSemilla.IdTipoContenedorOrigen = int.Parse(_IdTipoContenedorOrigen);
            seguimientoSemilla.FechaRegistro = _FechaRegistro.ToString();
            seguimientoSemilla.IdFactoresMedicion = _IdFactoresMedicion;
            seguimientoSemilla.CantidadOrigen = _CantidadOrigen;
            seguimientoSemilla.CalibreOrigen = _CalibreOrigen;
            seguimientoSemilla.IdTipoContenedorDestino = _IdTipoContenedorDestino;
            seguimientoSemilla.CantidadCosechado = _CantidadCosechado;
            seguimientoSemilla.CantidadCalibre = _CantidadCalibre;
            seguimientoSemilla.Estado = true;


            if (_control.SetGrabaSeguimientoSemilla(seguimientoSemilla))
            {
                validador = 1;
            }

            return (Json(validador));


        }

        public ActionResult ErrorPage(int error)
        {
            return Redirect(Url.Content("~/Error/Index?error=" + error));
        }
    }
}