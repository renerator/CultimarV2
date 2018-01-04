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
    public class MicroAlgasController : Controller
    {

        Control _control = new Control();
        // GET: MicroAlgas
        public ActionResult IngresoMicroAlgas()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoMicroAlga> model = _control.ListadoMicroAlgas();
                IEnumerable<SelectListItem> items = _control.ListadoParametrosEspecies().Select(c => new SelectListItem()
                {
                    Text = c.NombreEspecies,
                    Value = c.IdEspecies.ToString()
                }).ToList();

                ViewBag.ParametrosEspecies = items;
                return View(model);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }

        public JsonResult GrabaDatosMicroAlga(int idMicroAlga,int idEspecie, string cantidadVolumen, string numeroBolsa, string fecha)
        {
            try
            {
                var validador = 0;
                if (!string.IsNullOrEmpty(cantidadVolumen) && !string.IsNullOrEmpty(numeroBolsa))
                {
                    var microAlga = new ObjetoMicroAlga()
                    {
                        IdMicroAlga = idMicroAlga,
                        IdEspecie = idEspecie,
                        VolumenSembrado = Convert.ToInt32(cantidadVolumen),
                        NumeroBolsa = Convert.ToInt32(numeroBolsa),
                        FechaRegistro = Convert.ToDateTime(fecha)
                    };
                    if (_control.SetGrabaMicroAlga(microAlga))
                    {
                        validador = 1;
                    }
                    else
                    {
                        validador = 3;
                    }
                }
                else
                {
                    validador = 2;
                }
                //, JsonRequestBehavior.AllowGet --- solo si se usa metodo GET
                return (Json(validador));
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                ErrorPage(100);
                throw;
            }
        }

        public ActionResult ErrorPage(int error)
        {
            return Redirect(Url.Content("~/Error/Index?error=" + error));
        }
    }
}