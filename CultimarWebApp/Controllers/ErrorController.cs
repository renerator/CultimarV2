using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CultimarWebApp.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(int error = 0)
        {
            switch (error)
            {
                case 101:
                    ViewBag.Title = "Error de Validación";
                    ViewBag.MyMessageToUsers = error.ToString();
                    ViewBag.Description = "Ha ocurrido un error de validación con los datos ingresados.";
                    break;
                case 1001:
                    ViewBag.Title = "Sesión Expirada";
                    ViewBag.MyMessageToUsers = error.ToString();
                    ViewBag.Description = "Su sesión ha caducado, debes ingresar al sistema nuevamente.";
                    break;
                case 901:
                    ViewBag.Title = "Inicio de Sesión Incorrecto";
                    ViewBag.MyMessageToUsers = error.ToString();
                    ViewBag.Description = "Ha ocurrido un error en el inicio de sesión, intentalo nuevamente, si el problema persiste, ponte en contácto con nosotros.";
                    break;

                case 505:
                    ViewBag.Title = "Ocurrio un error inesperado";
                    ViewBag.MyMessageToUsers = error.ToString();
                    ViewBag.Description = "Ha ocurrido un error inesperado de servidor interno, si el problema persiste, ponte en contácto con nosotros.";
                    break;

                case 403:
                    ViewBag.Title = "Acceso Denegado";
                    ViewBag.MyMessageToUsers = error.ToString();
                    ViewBag.Description = "No tienes permiso para acceder a este contenido. ";
                    break;
                case 404:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.MyMessageToUsers = error.ToString();
                    ViewBag.Description = "La URL que está intentando ingresar no existe";
                    break;

                default:
                    ViewBag.Title = "Error: ";
                    ViewBag.MyMessageToUsers = error.ToString();
                    ViewBag.Description = "Esta intentando acceder a una página que por alguna razón el sistema no reconoce, si el problema persiste, ponte en contácto con nosotros.";
                    break;
            }

            return View("~/Views/Shared/Error.cshtml");
        }
    }
}