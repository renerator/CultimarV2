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
        public ActionResult SeguimientoMicroAlgas()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoMicroAlga> model = _control.ListadoSeguimientoMicroAlgas();

                IEnumerable<SelectListItem> parametrosEspecies = _control.ListadoParametrosEspecies().Select(c => new SelectListItem() {
                    Text = c.NombreEspecies,
                    Value = c.IdEspecies.ToString()
                }).ToList();
                ViewBag.ParametrosEspecies = parametrosEspecies;
                IEnumerable<SelectListItem> parametrosTipoContenedor = _control.ListadoTipoContenedor().Select(c => new SelectListItem()
                {
                    Text = c.TipoContenedor,
                    Value = c.IdContenedor.ToString()
                }).ToList();
                ViewBag.ParametrosTipoContenedor = parametrosTipoContenedor;
                IEnumerable<SelectListItem> parametrosTipoIdentificacion = _control.ListadoTipoIdentificacion().Select(c => new SelectListItem()
                {
                    Text = c.NombreIdentificacion,
                    Value = c.IdIdentificacion.ToString()
                }).ToList();
                ViewBag.ParametrosTipoIdentificacion = parametrosTipoIdentificacion;

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
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                var validador = 0;
                switch (datosUsuario.IdPerfil)
                {
                    case 3:
                        validador = 5;
                        break;
                    default:
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
                            if (idMicroAlga != -1)
                            {
                                if (datosUsuario.AutorizaModificacion)
                                {
                                    if (_control.SetGrabaMicroAlga(datosUsuario.IdUsuario, microAlga))
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
                                    validador = 4;
                                }
                            }
                            else
                            {
                                if (_control.SetGrabaMicroAlga(datosUsuario.IdUsuario, microAlga))
                                {
                                    validador = 1;
                                }
                                else
                                {
                                    validador = 3;
                                }
                            }
                        }
                        else
                        {
                            validador = 2;
                        }
                        break;
                }
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