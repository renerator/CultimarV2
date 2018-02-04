﻿using CultimarWebApp.Utils;
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

        #region

        public ActionResult SeguimientoCultivoLarval()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoSeguimientoLarval> model = _control.ListadoSeguimientoLarval(-1);
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
                return View(model);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }
        #endregion

        public ActionResult RegistroProduccion()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoRegistroProduccion> model = _control.ListadoRegistroProduccion(-1);
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
            var datosUsuario = new ObjetoLogin();
            datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
            var seguimientoLarval = new ObjetoSeguimientoLarval();
            var validador = 0;
            switch (datosUsuario.IdPerfil)
            {
                case 3:
                    validador = 5;
                    break;
                default:
                    seguimientoLarval.Id = _idCultivoLarval;
                    seguimientoLarval.CantidadDeLarvas = _CantidadLarvas;
                    seguimientoLarval.CosechaLarvas = _CosechaLarvas;
                    seguimientoLarval.NumeroEstanque = _NumeroEstanque;
                    seguimientoLarval.DensidadCultivo = _DensidadCultivo;
                    seguimientoLarval.FactoresMedicion = _IdFactoresM;
                    seguimientoLarval.IdMortalidad = _selectTipoM;
                    seguimientoLarval.Estado = true;
                    if (_idCultivoLarval != -1)
                    {
                        if (datosUsuario.AutorizaModificacion)
                        {
                            if (_control.SetGrabaSeguimientoLarval(datosUsuario.IdUsuario, seguimientoLarval))
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
                            EnvioMail correo = new EnvioMail();
                            correo.SendCorreoSolitaModificación(correo.ModificaRegistroSeguimientoLarval(_idCultivoLarval, datosUsuario.Nombre));
                        }
                    }
                    else
                    {
                        if (_control.SetGrabaSeguimientoLarval(datosUsuario.IdUsuario, seguimientoLarval))
                        {
                            validador = 1;
                        }
                        else
                        {
                            validador = 3;
                        }
                    }
                    break;
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
                                                       string _FactoresMedicion,
                                                       int _NumeroEstanquesUtilizado,
                                                       int _DensidadSiembra)
        {
            var datosUsuario = new ObjetoLogin();
            datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
            var registoProduccion = new ObjetoRegistroProduccion();
            var validador = 0;
            switch (datosUsuario.IdPerfil)
            {
                case 3:
                    validador = 5;
                    break;
                default:
                    registoProduccion.IdRegistroProduccion = _IdProduccion;
                    registoProduccion.CantidadProductoresMachos = _CantidadProductoresMachos;
                    registoProduccion.CantidadProductoresHembras = _CantidadProductoresHembras;
                    registoProduccion.NumeroDesoveTemporada = _NumeroDesoveTemporada;
                    registoProduccion.CantidadFecundada = _CantidadFecundada;
                    registoProduccion.CantidadSembrada = _CantidadSembrada;
                    registoProduccion.FactoresMedicion = _FactoresMedicion;
                    registoProduccion.NumeroEstanquesUtilizado = _NumeroEstanquesUtilizado;
                    registoProduccion.DensidadSiembra = _DensidadSiembra;
                    if (_IdProduccion != -1)
                    {
                        if (datosUsuario.AutorizaModificacion)
                        {
                            if (_control.SetGrabaRegistroProduccion(datosUsuario.IdUsuario, registoProduccion))
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
                            EnvioMail correo = new EnvioMail();
                            correo.SendCorreoSolitaModificación(correo.ModificaSeguimientoRegistroProduccion(_IdProduccion, datosUsuario.Nombre));
                        }
                    }
                    else
                    {
                        if (_control.SetGrabaRegistroProduccion(datosUsuario.IdUsuario, registoProduccion))
                        {
                            validador = 1;
                        }
                        else
                        {
                            validador = 3;
                        }
                    }
                    break;
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
                IEnumerable<ObjetoSeguimientoSemilla> model = _control.ListadoSeguimientoSemilla(-1);


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
            var datosUsuario = new ObjetoLogin();
            datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
            var seguimientoSemilla = new ObjetoSeguimientoSemilla();
            var validador = 0;

            switch (datosUsuario.IdPerfil)
            {
                case 3:
                    validador = 5;
                    break;
                default:
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
                    if (int.Parse(_IdSemilla.ToString()) != -1)
                    {
                        if (datosUsuario.AutorizaModificacion)
                        {
                            if (_control.SetGrabaSeguimientoSemilla(datosUsuario.IdUsuario, seguimientoSemilla))
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
                            EnvioMail correo = new EnvioMail();
                            correo.SendCorreoSolitaModificación(correo.ModificaRegistroSeguimientoSemilla(int.Parse(_IdSemilla.ToString()), datosUsuario.Nombre));
                        }
                    }
                    else
                    {
                        if (_control.SetGrabaSeguimientoSemilla(datosUsuario.IdUsuario, seguimientoSemilla))
                        {
                            validador = 1;
                        }
                        else
                        {
                            validador = 3;
                        }
                    }
                    break;
            }
            return (Json(validador));
        }


        public ActionResult SeguimientoFijacion()
        {
            try
            {


                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoSeguimientoFijacion> model = _control.ListadoSeguimientoFijacion(-1);


                IEnumerable<SelectListItem> items2 = _control.ListadoParametrosDestino().Select(c => new SelectListItem()
                {
                    Text = c.NombreDestino,
                    Value = c.IdDestino.ToString()
                }).ToList();

                ViewBag.ContenedorDestino = items2;


                IEnumerable<SelectListItem> TipoMortalidad = _control.ListadoTipoMortalidad().Select(c => new SelectListItem()
                {
                    Text = c.NombreMortalidad,
                    Value = c.IdMortalidad.ToString()
                }).ToList();

                ViewBag.selectTipoM = TipoMortalidad;


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




        public JsonResult GrabaSeguimientoFijacion(int _IdSeguimientoFijacion,
                                            int _LarvasCalibre,
                                            int _LarvasCantidad,
                                            int _CosechaCalibre,
                                            int _CosechaCantidad,
                                            int _NumeroEstanque,
                                            int _DensidadSiembra,
                                            int _IdMortalidad,
                                            int _CantidadMortalidad,
                                            string _FactoresMedicion,
                                            string _FechaRegistro)
        {

            var datosUsuario = new ObjetoLogin();
            datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
            var  seguimientoFijnacion = new ObjetoSeguimientoFijacion();
            var validador = 0;
            switch (datosUsuario.IdPerfil)
            {
                case 3:
                    validador = 5;
                    break;
                default:
                    seguimientoFijnacion.IdSeguimientoFijacion = _IdSeguimientoFijacion;
                    seguimientoFijnacion.LarvasCalibre = _LarvasCalibre;
                    seguimientoFijnacion.LarvasCantidad = _LarvasCantidad;
                    seguimientoFijnacion.CosechaCalibre = _CosechaCalibre;
                    seguimientoFijnacion.NumeroEstanque = _NumeroEstanque;
                    seguimientoFijnacion.DensidadSiembra = _DensidadSiembra;
                    seguimientoFijnacion.IdMortalidad = _IdMortalidad;
                    seguimientoFijnacion.CantidadMortalidad = _CantidadMortalidad;
                    seguimientoFijnacion.FactoresMedicion = _FactoresMedicion;
                    seguimientoFijnacion.FechaRegistro = _FechaRegistro;
                    if (_IdSeguimientoFijacion != -1)
                    {
                        if (datosUsuario.AutorizaModificacion)
                        {
                            if (_control.SetGrabaSeguimientoFijacion(datosUsuario.IdUsuario, seguimientoFijnacion))
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
                            EnvioMail correo = new EnvioMail();
                            correo.SendCorreoSolitaModificación(correo.ModificaRegistroSeguimientoFijacion(_IdSeguimientoFijacion, datosUsuario.Nombre));
                        }
                    }
                    else
                    {
                        if (_control.SetGrabaSeguimientoFijacion(datosUsuario.IdUsuario, seguimientoFijnacion))
                        {
                            validador = 1;
                        }
                        else
                        {
                            validador = 3;
                        }
                    }
                    break;
            }

            //if (_control.setGrabaSeguimientoFijacion(seguimientoFijnacion))
            //{
            //    validador = 1;
            //}

            return (Json(validador));


        }

        public ActionResult RegistroInicialMar()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoRegistroInicialMar> model = _control.ListadoRegistroInicialMar(-1);

                IEnumerable<SelectListItem> parametrosOrigen = _control.ListadoParametrosOrigen().Select(c => new SelectListItem()
                {
                    Text = c.NombreOrigen,
                    Value = c.IdOrigen.ToString()
                }).ToList();
                
                ViewBag.ParametrosOrigen = parametrosOrigen;

                    IEnumerable<SelectListItem> parametrosTipoMortalidad = _control.ListadoTipoMortalidad().Select(c => new SelectListItem()
                    {
                        Text = c.NombreMortalidad,
                        Value = c.IdMortalidad.ToString()
                    }).ToList();


                ViewBag.ParametrosTipoMortalidad = parametrosTipoMortalidad;

                IEnumerable<SelectListItem> parametrosTipoSistema = _control.ListadoTipoSistema().Select(c => new SelectListItem()
                {
                    Text = c.NombreSistema,
                    Value = c.IdTipoSistema.ToString()
                }).ToList();

                ViewBag.ParametrosTipoSistema = parametrosTipoSistema;

                return View(model);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }

        public JsonResult GrabaRegistroInicialMar(int idRegistro, string fechaIngreso, string fechaFuturo, int cantidadOrigen, int calibreOrigen, int idOrigen, int cantidad, int idTipoSistema, int idMortalidad)
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
                    var registroInicialMar = new ObjetoRegistroInicialMar()
                    {
                        IdRegistro = idRegistro,
                        FechaIngreso = Convert.ToDateTime(fechaIngreso),
                        FechaFuturoDesdoble = Convert.ToDateTime(fechaFuturo),
                        CantidadOrigen = cantidadOrigen,
                        CalibreOrigen = calibreOrigen,
                        IdOrigen = idOrigen,
                        Cantidad = cantidad,
                        IdTipoSistema = idTipoSistema,
                        IdMortalidad = idMortalidad
                    };
                    if (idRegistro != -1)
                    {
                        if (datosUsuario.AutorizaModificacion)
                        {
                            if (_control.SetGrabaRegistroInicialMar(datosUsuario.IdUsuario, registroInicialMar))
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
                            EnvioMail correo = new EnvioMail();
                            correo.SendCorreoSolitaModificación(correo.ModificaRegistroInicialMar(idRegistro, datosUsuario.Nombre));
                        }
                    }
                    else
                    {
                        if (_control.SetGrabaRegistroInicialMar(datosUsuario.IdUsuario, registroInicialMar))
                        {
                            validador = 1;
                        }
                        else
                        {
                            validador = 3;
                        }
                    }
                    break;
            }
            
            return (Json(validador));
        }


        public ActionResult PreparacionDespacho()
        {
            try
            {

                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoPreparadoDespacho> model = _control.ListadoPreparadoDespachado(-1);


                IEnumerable<SelectListItem> items2 = _control.ListadoParametrosOrigen().Select(c => new SelectListItem()
                {
                    Text = c.NombreOrigen,
                    Value = c.IdOrigen.ToString()
                }).ToList();

                ViewBag.selectOrigen = items2;


                IEnumerable<SelectListItem> items3 = _control.ListadoParametrosDestino().Select(d => new SelectListItem()
                {
                    Text = d.NombreDestino,
                    Value = d.IdDestino.ToString()
                }).ToList();

                ViewBag.selectDestino = items3;



                return View(model);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }
        public JsonResult GrabaPdespacho(int _IdPreparoDespacho,
                                       string _FechaEnvio,
                                       string _FechaPreparado,
                                       int _IdOrigen,
                                       int _IdDestino,
                                       int _PesoNeto,
                                       int _PesoBruto,
                                       int _Cantidad,
                                       int _Calibre,
                                       string _cliente)
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
                    var pdespacho = new ObjetoPreparadoDespacho();
                    pdespacho.IdPreparoDespacho = _IdPreparoDespacho;
                    pdespacho.FechaEnvio = _FechaEnvio;
                    pdespacho.FechaPreparado = _FechaPreparado;
                    pdespacho.IdOrigen = _IdOrigen;
                    pdespacho.IdDestino = _IdDestino;
                    pdespacho.PesoNeto = _PesoNeto;
                    pdespacho.PesoBruto = _PesoBruto;
                    pdespacho.Cantidad = _Cantidad;
                    pdespacho.Calibre = _Calibre;
                    pdespacho.Cliente = _cliente;

                    if (_IdPreparoDespacho != -1)
                    {
                        if (datosUsuario.AutorizaModificacion)
                        {
                            if (_control.SetGrabaPreparacionDespacho(datosUsuario.IdUsuario, pdespacho))
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
                            EnvioMail correo = new EnvioMail();
                            correo.SendCorreoSolitaModificación(correo.ModificaRegistroPreparadoDespacho(_IdPreparoDespacho, datosUsuario.Nombre));
                        }
                    }
                    else
                    {
                        if (_control.SetGrabaPreparacionDespacho(datosUsuario.IdUsuario, pdespacho))
                        {
                            validador = 1;
                        }
                        else
                        {
                            validador = 3;
                        }
                    }

                    break;
            }
            return (Json(validador));
        }
        public ActionResult ErrorPage(int error)
        {
            return Redirect(Url.Content("~/Error/Index?error=" + error));
        }
    }
}