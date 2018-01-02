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

        public ActionResult ErrorPage(int error)
        {
            return Redirect(Url.Content("~/Error/Index?error=" + error));
        }
    }
}