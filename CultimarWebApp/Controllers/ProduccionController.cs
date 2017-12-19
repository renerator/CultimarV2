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
        public ActionResult SeguimientoCultivoLarval()
        {
            ViewBag.Message = "Bienvenido: Usuario";
            return View();
        }
    }
}