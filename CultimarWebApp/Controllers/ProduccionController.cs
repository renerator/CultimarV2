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

                return View(model);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }


        public JsonResult GrabaDatosRegistroProduccion(int _CantidadProductoresMachos,
                                                       int _CantidadProductoresHembras,
                                                       string _FechaInicioCultivo,
                                                       int _NumeroDesoveTemporada,
                                                       int _CantidadFecundada,
                                                       int _CantidadSembrada,
                                                       int _FactoresMedicion,
                                                       int _NumeroEstanquesUtilizado,
                                                       int _DensidadSiembra)
        {

            var registoProduccion = new ObjetoRegistroProduccion();
            var validador = 0;

            registoProduccion.CantidadProductoresMachos = _CantidadProductoresMachos;
            registoProduccion.CantidadProductoresHembras = _CantidadProductoresHembras;
            registoProduccion.FechaInicioCultivo = DateTime.Parse(_FechaInicioCultivo.ToString());
            registoProduccion.NumeroDesoveTemporada = _NumeroDesoveTemporada;
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


                IEnumerable<SelectListItem> items = _control.ListadoTipoContenedorOrigen().Select(c => new SelectListItem()
                {
                    Text = c.NombreContenedor,
                    Value = c.IdContenedor.ToString()
                }).ToList();

                ViewBag.ContenedorOrigen = items;



                IEnumerable<SelectListItem> items2 = _control.ListadoTipoContenedorDestino().Select(c => new SelectListItem()
                {
                    Text = c.NombreContenedor,
                    Value = c.IdContenedor.ToString()
                }).ToList();

                ViewBag.ContenedorDestino = items2;

                IEnumerable<SelectListItem> items3 = _control.ListadoFactorMedicion().Select(c => new SelectListItem()
                {
                    Text = c.NombreFactor,
                    Value = c.IdFactor.ToString()
                }).ToList();

                ViewBag.FactorMedicion = items3;


                return View(model);


            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }


        public JsonResult GrabaDatos(string _IdTipoContenedorOrigen, string _FechaRegistro,
                                     int _IdFactoresMedicion, int _CantidadOrigen, int _CalibreOrigen,
                                       int _IdTipoContenedorDestino, int _CantidadCosechado, int _CantidadCalibre)
        {





            var seguimientoSemilla = new ObjetoSeguimientoSemilla();
            var validador = 0;

            seguimientoSemilla.IdTipoContenedorOrigen = int.Parse(_IdTipoContenedorOrigen);
            seguimientoSemilla.FechaRegistro = DateTime.Parse(_FechaRegistro.ToString());
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