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

        #region

        public ActionResult SeguimientoCultivoLarval()
        {
            try
            {
                ViewBag.showSuccessAlert = true;
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

                //_control.ListadoRegistroProduccion(-1)
                IEnumerable<SelectListItem> seleccionRegistroInicial = _control.ListadoRegistroProduccion(-1).Select(d => new SelectListItem()
                {
                    Text = d.NombreRegistro,
                    Value = d.IdRegistroProduccion.ToString()
                }).ToList();
                ViewBag.RegistroInicial = seleccionRegistroInicial;

                IEnumerable<SelectListItem> parametroCalibre = _control.ListadoCalibre().Where(item => item.DescripcionCalibre == "Larvas").Select(c => new SelectListItem()
                {
                    Text = c.NombreCalibre,
                    Value = c.IdCalibre.ToString()
                }).ToList();
                ViewBag.ParametroCalibre = parametroCalibre;

                IEnumerable<SelectListItem> parametrosOrigen = _control.ListadoTipoContenedor().Where(item => item.TipoContenedor == "Larvas").Select(c => new SelectListItem()
                {
                    Text = c.NombreContenedor,
                    Value = c.IdContenedor.ToString()
                }).ToList();
                ViewBag.ParametrosOrigen = parametrosOrigen;
                IEnumerable<SelectListItem> parametrosDestino = _control.ListadoTipoContenedor().Where(item => item.TipoContenedor == "Larvas").Select(c => new SelectListItem()
                {
                    Text = c.NombreContenedor,
                    Value = c.IdContenedor.ToString()
                }).ToList();
                ViewBag.ParametrosDestino = parametrosDestino;



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

                
                IEnumerable<SelectListItem> identificacionLarvas = _control.ListadoTipoIdentificacion().Select(d => new SelectListItem()
                {
                    Text = d.NombreIdentificacion,
                    Value = d.IdIdentificacion.ToString()
                }).ToList();
                ViewBag.RegistroInicial = identificacionLarvas;

                IEnumerable<SelectListItem> parametroEstanqueLarvas = _control.ListadoTipoContenedor().Where(item => item.TipoContenedor == "Larvas").Select(c => new SelectListItem()
                {
                    Text = c.NombreContenedor,
                    Value = c.IdContenedor.ToString()
                }).ToList();
                ViewBag.EstanqueLarvas = parametroEstanqueLarvas;


                return View(model);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }
        /*
          var calibre = $("#selectCalibre").val();
        var estanqueOrigen = $("#selectOrigen").val();
        var estanqueDestino = $("#selectDestino").val();
        var cantidadMortalidad = $("#cantidadMortalidad").val();
        var obs = $("#txtObservaciones").val();
             */

        public JsonResult GrabaDatosLarval(int _idCultivoLarval,
                                            int _idRegistro,
                                           int _CantidadLarvas,
                                           int _CosechaLarvas,
                                           int _NumeroEstanque,
                                           int _DensidadCultivo,
                                           string _IdFactoresM,
                                           int _selectTipoM,
                                           int _idCalibre,
                                           int _idEstanqueOrigen,
                                           int _idEstanqueDestino,
                                           int _cantidadMortalidad,
                                           string _observaciones)
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
                    seguimientoLarval.IdRegistro = _idRegistro;
                    seguimientoLarval.CantidadDeLarvas = _CantidadLarvas;
                    seguimientoLarval.CosechaLarvas = _CosechaLarvas;
                    seguimientoLarval.DensidadCultivo = _DensidadCultivo;
                    seguimientoLarval.FactoresMedicion = _IdFactoresM;
                    seguimientoLarval.IdMortalidad = _selectTipoM;
                    seguimientoLarval.Estado = true;
                    seguimientoLarval.IdCalibre = _idCalibre;
                    seguimientoLarval.NumeroEstanque = _idEstanqueOrigen;
                    seguimientoLarval.NumeroEstanqueDestino = _idEstanqueDestino;
                    seguimientoLarval.CantidadMortalidad = _cantidadMortalidad;
                    seguimientoLarval.Observaciones = _observaciones;
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
                                                        int _idTipoIdentificacion,
                                                        int _CantidadProductoresMachos,
                                                       int _CantidadProductoresHembras,
                                                       int _CantidadFecundada,
                                                       int _NumeroDesoveTemporada,
                                                       int _CantidadSembrada,
                                                       string[] _FactoresMedicion,
                                                       int _NumeroEstanquesUtilizado,
                                                       int _DensidadSiembra,
                                                       string _Observaciones)
        {
            var datosUsuario = new ObjetoLogin();
            datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
            var registoProduccion = new ObjetoRegistroProduccion();
            var validador = 0;
            var factores = string.Empty;

            foreach (var expression in _FactoresMedicion)
            {
                factores += expression + ",";
            }

            factores = factores.TrimEnd(',');

            switch (datosUsuario.IdPerfil)
            {
                case 3:
                    validador = 5;
                    break;
                default:
                    registoProduccion.IdRegistroProduccion = _IdProduccion;
                    registoProduccion.IdTipoIdentificacion = _idTipoIdentificacion;
                    registoProduccion.CantidadProductoresMachos = _CantidadProductoresMachos;
                    registoProduccion.CantidadProductoresHembras = _CantidadProductoresHembras;
                    registoProduccion.NumeroDesoveTemporada = _NumeroDesoveTemporada;
                    registoProduccion.CantidadFecundada = _CantidadFecundada;
                    registoProduccion.CantidadSembrada = _CantidadSembrada;
                    registoProduccion.FactoresMedicion = factores;
                    registoProduccion.NumeroEstanquesUtilizado = _NumeroEstanquesUtilizado;
                    registoProduccion.DensidadSiembra = _DensidadSiembra;
                    registoProduccion.Observaciones = _Observaciones;
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

               

                IEnumerable<SelectListItem> items = _control.ListadoRegistroInicialSemillas(-1).Select(c => new SelectListItem()
                {
                    Text = c.NombreRegistroLarval,
                    Value = c.IdRegistroInicialSemilla.ToString()
                }).ToList();

                ViewBag.NombreCultivo = items;


                IEnumerable<SelectListItem> parametroZona = _control.ListadoTipoContenedor().Where(item => item.TipoContenedor == "Semillas").Select(c => new SelectListItem()
                {
                    Text = c.NombreContenedor,
                    Value = c.IdContenedor.ToString()
                }).ToList();
                ViewBag.ZonaCultivo = parametroZona;

                var item3 = _control.ListadoFactorMedicion();
                ViewBag.FactorM = new MultiSelectList(item3, "IdFactor", "NombreFactor");

                IEnumerable<SelectListItem> parametroCalibre = _control.ListadoCalibre().Where(item => item.DescripcionCalibre == "Semilla").Select(c => new SelectListItem()
                {
                    Text = c.NombreCalibre,
                    Value = c.IdCalibre.ToString()
                }).ToList();
                ViewBag.CalibreOrigen = parametroCalibre;

                IEnumerable<SelectListItem> parametroCalibre2 = _control.ListadoCalibre().Where(item => item.DescripcionCalibre == "Semilla").Select(c => new SelectListItem()
                {
                    Text = c.NombreCalibre,
                    Value = c.IdCalibre.ToString()
                }).ToList();
                ViewBag.CalibreDestino = parametroCalibre2;


                IEnumerable<SelectListItem> TipoMortalidad = _control.ListadoTipoMortalidad().Select(c => new SelectListItem()
                {
                    Text = c.NombreMortalidad,
                    Value = c.IdMortalidad.ToString()
                }).ToList();

                ViewBag.selectTipoM = TipoMortalidad;


                return View(model);


            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }


        public JsonResult GrabaDatosSeguimientoSemilla(
                                                        int _ID,
                                                        int _batch,
                                                        string _zonaCultivo,
                                                        int _contenedorOrigen,
                                                        string _fechaRegistro,
                                                        int _tipoMortalidad,
                                                        string[] _factoresMedicion,
                                                        int _cantidadOrigen,
                                                        int _calibreOrigen,
                                                        int _cantidadDestino,
                                                        int _calibreDestino,
                                                        int _contenedorDestino,
                                                        int _cantidadMuestra,
                                                        int _volumenMuestra,
                                                        int _volumenTotal,
                                                        string _observaciones)

        {
            var datosUsuario = new ObjetoLogin();
            datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
            var validador = 0;
            var factores = string.Empty;

            foreach (var expression in _factoresMedicion)
            {
                factores += expression + ",";
            }

            factores = factores.TrimEnd(',');
            var seguimientoSemilla = new ObjetoSeguimientoSemilla()
            {
                IdSeguimientoSemilla = _ID,
                IdRegistroLarval = _batch,
                ZonaCultivo = _zonaCultivo,
                IdTipoContenedorOrigen = _contenedorOrigen,
                FechaRegistro1 = Convert.ToDateTime(_fechaRegistro),
                IdMortalidad = _tipoMortalidad,
                FactoresMedicion = factores,
                CantidadOrigen = _cantidadOrigen,
                idOrigen = _calibreOrigen,
                CantidadDestino = _cantidadDestino,
                IdDestino = _calibreDestino,
                IdTipoContenedorDestino = _contenedorDestino,
                CantidadMuestra = _cantidadMuestra,
                VolumenMuestra = _volumenMuestra,
                VolumenTotal = _volumenTotal,
                Observaciones = _observaciones
            };
            switch (datosUsuario.IdPerfil)
            {
                case 3:
                    validador = 5;
                    break;
                default:
                    
                    if (_ID != -1)
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
                            correo.SendCorreoSolitaModificación(correo.ModificaRegistroSeguimientoSemilla(_ID, datosUsuario.Nombre));
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


                IEnumerable<SelectListItem> parametroContenedor = _control.ListadoTipoContenedor().Where(item => item.TipoContenedor == "Fijación").Select(c => new SelectListItem()
                {
                    Text = c.NombreContenedor,
                    Value = c.IdContenedor.ToString()
                }).ToList();
                ViewBag.Contenedor = parametroContenedor;


                IEnumerable<SelectListItem> TipoMortalidad = _control.ListadoTipoMortalidad().Select(c => new SelectListItem()
                {
                    Text = c.NombreMortalidad,
                    Value = c.IdMortalidad.ToString()
                }).ToList();

                ViewBag.selectTipoM = TipoMortalidad;

                IEnumerable<SelectListItem> seleccionRegistroInicial = _control.ListadoRegistroProduccion(-1).Select(d => new SelectListItem()
                {
                    Text = d.NombreRegistro,
                    Value = d.IdRegistroProduccion.ToString()
                }).ToList();
                ViewBag.RegistroCultivo = seleccionRegistroInicial;

                IEnumerable<SelectListItem> parametroCalibre = _control.ListadoCalibre().Where(item => item.DescripcionCalibre == "Larvas").Select(c => new SelectListItem()
                {
                    Text = c.NombreCalibre,
                    Value = c.IdCalibre.ToString()
                }).ToList();
                ViewBag.ParametroCalibreLarvas = parametroCalibre;

                IEnumerable<SelectListItem> parametroCalibreFijacion = _control.ListadoCalibre().Where(item => item.DescripcionCalibre == "Fijación").Select(c => new SelectListItem()
                {
                    Text = c.NombreCalibre,
                    Value = c.IdCalibre.ToString()
                }).ToList();
                ViewBag.ParametroCalibreFijacion = parametroCalibreFijacion;

                IEnumerable<SelectListItem> parametroCalibreSemilla = _control.ListadoCalibre().Where(item => item.DescripcionCalibre == "Semilla").Select(c => new SelectListItem()
                {
                    Text = c.NombreCalibre,
                    Value = c.IdCalibre.ToString()
                }).ToList();
                ViewBag.ParametroCalibreSemillas = parametroCalibreSemilla;





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
        
        public JsonResult GrabaSeguimientoFijacion(
                                            int _IdSeguimientoFijacion,
                                            int _idCultivo,
                                            string _FechaRegistro,
                                            int _LarvasCalibre,
                                            int _LarvasCantidad,
                                            int _CantidadFijacion,
                                            int _CalibreFijacion,
                                            int _CosechaSemillas,
                                            int _CalibreSemillas,
                                            int _CantidadSemillas,
                                            int _NumeroEstanque,
                                            int _DensidadSiembra,
                                            int _IdMortalidad,
                                            int _CantidadMortalidad,
                                            string[] _FactoresMedicion,
                                            string _Observaciones
                                                        )
        {

            var datosUsuario = new ObjetoLogin();
            datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
            var factores = string.Empty;

            foreach (var expression in _FactoresMedicion)
            {
                factores += expression + ",";
            }

            factores = factores.TrimEnd(',');

            var validador = 0;
            switch (datosUsuario.IdPerfil)
            {
                case 3:
                    validador = 5;
                    break;
                default:
                    var seguimientoFijacion = new ObjetoSeguimientoFijacion() {
                        IdSeguimientoFijacion = _IdSeguimientoFijacion,
                        IdCultivo = _idCultivo,
                        FechaRegistro = _FechaRegistro,
                        LarvasCalibre = _LarvasCalibre,
                        LarvasCantidad = _LarvasCantidad,
                        FijacionCantidad = _CantidadFijacion,
                        FijacionCalibre = _CalibreFijacion,
                        CosechaSemilla = _CosechaSemillas,
                        SemillaCalibre = _CalibreSemillas,
                        CosechaCantidad = _CantidadSemillas,
                        NumeroEstanque = _NumeroEstanque,
                        DensidadSiembra = _DensidadSiembra,
                        IdMortalidad = _IdMortalidad,
                        CantidadMortalidad = _CantidadMortalidad,
                        FactoresMedicion = factores,
                        Observaciones = _Observaciones
                    };


                    if (_IdSeguimientoFijacion != -1)
                    {
                        if (datosUsuario.AutorizaModificacion)
                        {
                            if (_control.SetGrabaSeguimientoFijacion(datosUsuario.IdUsuario, seguimientoFijacion))
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
                        if (_control.SetGrabaSeguimientoFijacion(datosUsuario.IdUsuario, seguimientoFijacion))
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

        public ActionResult RegistroInicialMar()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoRegistroInicialMar> model = _control.ListadoRegistroInicialMar(-1);
                IEnumerable<SelectListItem> items = _control.ListadoTipoIdentificacion().Select(c => new SelectListItem()
                {
                    Text = c.NombreIdentificacion,
                    Value = c.IdIdentificacion.ToString()
                }).ToList();

                ViewBag.NombreCultivo = items;

                IEnumerable<SelectListItem> parametrosTipoMortalidad = _control.ListadoTipoMortalidad().Select(c => new SelectListItem()
                {
                    Text = c.NombreMortalidad,
                    Value = c.IdMortalidad.ToString()
                }).ToList();
                ViewBag.ParametrosTipoMortalidad = parametrosTipoMortalidad;

                IEnumerable<SelectListItem> parametroCalibre = _control.ListadoCalibre().Select(c => new SelectListItem()
                {
                    Text = c.DescripcionCalibre + "  "  + c.NombreCalibre,
                    Value = c.IdCalibre.ToString()
                }).ToList();
                ViewBag.ParametroCalibre = parametroCalibre;


               

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

        public JsonResult GrabaRegistroInicialMar(int idRegistro, int idCultivo, string fechaIngreso, string fechaFuturo, int cantidadOrigen, int calibreOrigen, int cantidad, int idTipoSistema, int idMortalidad, string observaciones)
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
                        IdRegistroLarval = idCultivo,
                        FechaIngreso = Convert.ToDateTime(fechaIngreso),
                        FechaFuturoDesdoble = Convert.ToDateTime(fechaFuturo),
                        CantidadOrigen = cantidadOrigen,
                        IdOrigen = calibreOrigen,
                        Cantidad = cantidad,
                        IdTipoSistema = idTipoSistema,
                        IdMortalidad = idMortalidad,
                        Observaciones = observaciones
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

        public ActionResult SeguimientoProduccionMar()
        {
            var datosUsuario = new ObjetoLogin();
            datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
            ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;

            IEnumerable<ObjetoSeguimientoMar> model = _control.ListadoSeguimientoMar(-1);

            IEnumerable<SelectListItem> items = _control.ListadoRegistroInicialMar(-1).Select(c => new SelectListItem()
            {
                Text = c.NombreCultivo,
                Value = c.IdRegistroLarval.ToString()
            }).ToList();

            ViewBag.NombreCultivo = items;

            IEnumerable<SelectListItem> parametrosTipoMortalidad = _control.ListadoTipoMortalidad().Select(c => new SelectListItem()
            {
                Text = c.NombreMortalidad,
                Value = c.IdMortalidad.ToString()
            }).ToList();
            ViewBag.ParametrosTipoMortalidad = parametrosTipoMortalidad;

            IEnumerable<SelectListItem> parametroCalibre = _control.ListadoCalibre().Select(c => new SelectListItem()
            {
                Text = c.DescripcionCalibre + "  " + c.NombreCalibre,
                Value = c.IdCalibre.ToString()
            }).ToList();
            ViewBag.ParametroCalibre = parametroCalibre;


            IEnumerable<SelectListItem> parametrosTipoSistema = _control.ListadoTipoSistema().Select(c => new SelectListItem()
            {
                Text = c.NombreSistema,
                Value = c.IdTipoSistema.ToString()
            }).ToList();

            ViewBag.ParametrosTipoSistema = parametrosTipoSistema;

            IEnumerable<SelectListItem> parametrosUbicacionOceanica = _control.ListadoUbicacionOceanica().Select(c => new SelectListItem()
            {
                Text = c.NombreUbicacion,
                Value = c.IdUbicacion.ToString()
            }).ToList();

            ViewBag.ParametroUbicacionOceanica = parametrosUbicacionOceanica;

            return View(model);
        }

        public JsonResult GrabaSeguimientoMar(
              int _IdSeguimiento
            , int _IdRegistroInicial
            , int _IdMortalidad
            , string _FechaDesdoble
            , int _CantidadOrigen
            , int _IdCalibreOrigen
            , int _IdUbicacionOrigen
            , int _CantidadSistemaOrigen
            , int _IdSistemaOrigen
            , int _CantidadDestino
            , int _IdCalibreDestino
            , int _IdUbicacionDestino
            , int _CantidadSistemaDestino
            , int _IdSistemaDestino
            , string _Observaciones)
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
                    var seguimientoMar = new ObjetoSeguimientoMar()
                    {
                        IdSeguimiento = _IdSeguimiento
                        ,IdRegistroInicial = _IdRegistroInicial
                        ,IdMortalidad = _IdMortalidad
                        ,FechaDesdoble = Convert.ToDateTime(_FechaDesdoble)
                        ,CantidadOrigen = _CantidadOrigen
                        ,IdCalibreOrigen = _IdCalibreOrigen
                        ,IdUbicacionOrigen = _IdUbicacionOrigen
                        ,CantidadSistemaOrigen = _CantidadSistemaOrigen
                        ,IdSistemaOrigen = _IdSistemaOrigen
                        ,CantidadDestino = _CantidadDestino
                        ,IdCalibreDestino = _IdCalibreDestino
                        ,IdUbicacionDestino = _IdUbicacionDestino
                        ,CantidadSistemaDestino = _CantidadSistemaDestino
                        ,IdSistemaDestino = _IdSistemaDestino
                        ,Observaciones = _Observaciones
                    };
                    if (_IdSeguimiento != -1)
                    {
                        if (datosUsuario.AutorizaModificacion)
                        {
                            if (_control.SetGrabaSeguimientoMar(datosUsuario.IdUsuario, seguimientoMar))
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
                            correo.SendCorreoSolitaModificación(correo.ModificaRegistroSeguimientoMar(_IdSeguimiento, datosUsuario.Nombre));
                        }
                    }
                    else
                    {
                        if (_control.SetGrabaSeguimientoMar(datosUsuario.IdUsuario, seguimientoMar))
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
        
        public JsonResult GrabaRegistroInicialSemillas(
                                         int IdRegistroInicial
                                        ,int idCultivo
                                        ,int IdCalibre
                                        , string FechaRegistro
                                        , string FechaDesdoble
                                        , string Ploidia
                                        , string Muestreo
                                        , string Observaciones
                                      )
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
                    var semilla = new ObjetoSeguimientoSemilla() {
                        IdRegistroInicialSemilla = IdRegistroInicial,
                        IdRegistroLarval = idCultivo,
                        IdCalibre = IdCalibre,
                        FechaRegistroInicial = Convert.ToDateTime(FechaRegistro),
                        FechaDesdobleInicial = Convert.ToDateTime(FechaDesdoble),
                        Ploidia = Ploidia,
                        Muestreo = Muestreo,
                        Observaciones = Observaciones
                    };

                    if (IdRegistroInicial != -1)
                    {
                        if (datosUsuario.AutorizaModificacion)
                        {
                            if (_control.SetGrabaRegistroInicialSemilla(datosUsuario.IdUsuario, semilla))
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
                            //validador = 4;
                            //EnvioMail correo = new EnvioMail();
                            //correo.SendCorreoSolitaModificación(correo.ModificaRegistroPreparadoDespacho(IdRegistroInicial, datosUsuario.Nombre));
                        }
                    }
                    else
                    {
                        if (_control.SetGrabaRegistroInicialSemilla(datosUsuario.IdUsuario, semilla))
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

        
        public ActionResult RegistroInicialSemillas()
        {
            var datosUsuario = new ObjetoLogin();
            datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
            ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
            IEnumerable<ObjetoSeguimientoSemilla> model = _control.ListadoRegistroInicialSemillas(-1);

            IEnumerable<SelectListItem> seleccionRegistroInicial = _control.ListadoRegistroProduccion(-1).Select(d => new SelectListItem()
            {
                Text = d.NombreRegistro,
                Value = d.IdRegistroProduccion.ToString()
            }).ToList();
            ViewBag.RegistroCultivo = seleccionRegistroInicial;

            IEnumerable<SelectListItem> parametroCalibre = _control.ListadoCalibre().Where(item => item.DescripcionCalibre == "Semilla").Select(c => new SelectListItem()
            {
                Text = c.NombreCalibre,
                Value = c.IdCalibre.ToString()
            }).ToList();
            ViewBag.ParametroCalibre = parametroCalibre;




            return View(model);
        }

        public ActionResult ErrorPage(int error)
        {
            return Redirect(Url.Content("~/Error/Index?error=" + error));
        }
    }
}