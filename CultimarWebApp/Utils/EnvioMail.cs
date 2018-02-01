using CultimarWebApp.Utils.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace CultimarWebApp.Utils
{
    public class EnvioMail
    {
        const string Ur = "~/Utils/HTMLCorreos/";
        private readonly Control _control = new Control();
        private DataSet _ds = new DataSet();

        public string SendCorreoSolitaModificación(string pBody)
        {
            try
            {
                var correoUsuario = new MailMessage();
                correoUsuario.To.Add(System.Web.Configuration.WebConfigurationManager.AppSettings["correoAdmin"]);
                correoUsuario.Bcc.Add(System.Web.Configuration.WebConfigurationManager.AppSettings["correoCCO"]);
                correoUsuario.CC.Add(System.Web.Configuration.WebConfigurationManager.AppSettings["correoCC"]);
                correoUsuario.From = new MailAddress(System.Web.Configuration.WebConfigurationManager.AppSettings["sistema"], "Cultimar - Sistema Seguimiento y Gestión.");
                correoUsuario.Subject = "Solicitud de Modificación";
                correoUsuario.Body = pBody;
                correoUsuario.IsBodyHtml = true;
                if (Smtp.Send(correoUsuario))
                {
                    return "ok";
                }
                else { return "NOK"; }

            }
            catch (Exception ex)
            {
                throw (new CapturaExcepciones(ex));
            }
        }

        public string SendCorreoAutorizaQuita(string pBody, string email, string tipo)
        {
            try
            {
                var correoUsuario = new MailMessage();
                correoUsuario.To.Add(email);
                correoUsuario.Bcc.Add(System.Web.Configuration.WebConfigurationManager.AppSettings["correoAdmin"]);
                correoUsuario.CC.Add(System.Web.Configuration.WebConfigurationManager.AppSettings["correoCC"]);
                correoUsuario.From = new MailAddress(System.Web.Configuration.WebConfigurationManager.AppSettings["sistema"], "Cultimar - Sistema Seguimiento y Gestión.");
                correoUsuario.Subject = tipo;
                correoUsuario.Body = pBody;
                correoUsuario.IsBodyHtml = true;
                if (Smtp.Send(correoUsuario))
                {
                    return "ok";
                }
                else { return "NOK"; }

            }
            catch (Exception ex)
            {
                throw (new CapturaExcepciones(ex));
            }
        }
        public string ModificaRegistroInicialMar(int id, string nombreSolicita)
        {
            var salida = string.Empty;
            var reader = new StreamReader(HttpContext.Current.Server.MapPath(Ur + "SolicitudPermiso.html"));
            salida = reader.ReadToEnd();
            reader.Close();
            salida = salida.Replace("%nombreSolicita%", nombreSolicita);

            var contenido = string.Empty;
            var detalle = string.Empty;
            var datos = _control.ListadoRegistroInicialMar(id);

            if (datos.Count > 0)
            {
                contenido += "<tr>";
                contenido += "	<td>Ingreso Registro inicial Mar</td>";
                contenido += "    <td style='width:90px;'>";
                contenido += "        <span>" + datos[0].NombreOrigen + "</span>";
                contenido += "    </td>";
                contenido += "    <td style='width:90px;'>";
                contenido += "        <span>" + datos[0].FechaIngreso.ToShortDateString() + "</span>";
                contenido += "    </td>";
                contenido += "    <td>";
                contenido += "        <span>" + DateTime.Now.ToShortDateString() + "</span>";
                contenido += "    </td>";
                contenido += "</tr>";

                detalle += "<tr>";
                detalle += "	<td>" + datos[0].IdRegistro.ToString() + "</td>";
                detalle += "    <td style='width:90px;'>";
                detalle += "        <span>" + datos[0].NombreOrigen + "</span>";
                detalle += "    </td>";
                detalle += "    <td>";
                detalle += "    <table>";
                detalle += "        <tr>";
                detalle += "            <th scope='col'> Cantidad </th>";
                detalle += "            <th scope='col'> Sistema </th>";
                detalle += "            <th scope='col'> Mortalidad </th>";
                detalle += "        </tr>";
                detalle += "        <tr>";
                detalle += "            <td><span>" + datos[0].Cantidad + "</span></td>";
                detalle += "            <td><span>" + datos[0].NombreSistema + "</span></td>";
                detalle += "            <td><span>" + datos[0].NombreMortalidad + "</span></td>";
                detalle += "        </tr>";
                detalle += "    </table>";
                detalle += "    </td>";
                detalle += "</tr>";
            }
            salida = salida.Replace("%tablaContenido%", contenido);
            salida = salida.Replace("%tablaDetalle%", detalle);
            return salida;
        }
        public string ModificaMicroAlgas(int id, string nombreSolicita)
        {
            var salida = string.Empty;
            var reader = new StreamReader(HttpContext.Current.Server.MapPath(Ur + "SolicitudPermiso.html"));
            salida = reader.ReadToEnd();
            reader.Close();
            salida = salida.Replace("%nombreSolicita%", nombreSolicita);

            var contenido = string.Empty;
            var detalle = string.Empty;
            var microAlgas = _control.ListadoMicroAlgas(id);

            if (microAlgas.Count > 0)
            {
                contenido += "<tr>";
                contenido += "	<td>IngresoMicroAlgas</td>";
                contenido += "    <td style='width:90px;'>";
                contenido += "        <span>" + microAlgas[0].NombreEspecie + "</span>";
                contenido += "    </td>";
                contenido += "    <td style='width:90px;'>";
                contenido += "        <span>" + microAlgas[0].FechaRegistro.ToShortDateString() + "</span>";
                contenido += "    </td>";
                contenido += "    <td>";
                contenido += "        <span>" + DateTime.Now.ToShortDateString() + "</span>";
                contenido += "    </td>";
                contenido += "</tr>";

                detalle += "<tr>";
                detalle += "	<td>" + microAlgas[0].IdMicroAlga.ToString() + "</td>";
                detalle += "    <td style='width:90px;'>";
                detalle += "        <span>" + microAlgas[0].NombreEspecie + "</span>";
                detalle += "    </td>";
                detalle += "    <td>";
                detalle += "    <table>";
                detalle += "        <tr>";
                detalle += "            <th scope='col'> Volumen Sembrado </th>";
                detalle += "            <th scope='col'> Número de Bolsa </th>";
                detalle += "            <th scope='col'> Fecha Sistema </th>";
                detalle += "        </tr>";
                detalle += "        <tr>";
                detalle += "            <td><span>" + microAlgas[0].VolumenSembrado + "</span></td>";
                detalle += "            <td><span>" + microAlgas[0].NumeroBolsa + "</span></td>";
                detalle += "            <td><span>" + microAlgas[0].FechaSistema.ToShortDateString() + " / " + microAlgas[0].FechaSistema.ToShortTimeString() + "</span></td>";
                detalle += "        </tr>";
                detalle += "    </table>";
                detalle += "    </td>";
                detalle += "</tr>";
            }
            salida = salida.Replace("%tablaContenido%", contenido);
            salida = salida.Replace("%tablaDetalle%", detalle);
            return salida;
        }

        public string QuitaoAutorizaPersona(string nombre, string tipo)
        {
            var salida = string.Empty;
            var reader = new StreamReader(HttpContext.Current.Server.MapPath(Ur + "AutorizaPermiso.html"));
            salida = reader.ReadToEnd();
            reader.Close();
            switch (tipo)
            {
                case "autoriza":
                    salida = salida.Replace("%nombrePersona%", nombre);
                    salida = salida.Replace("%mensaje%", "Haz solicitado permiso para modificar datos en el sistema, el usuario administrador te ha concedido el permiso.");
                    salida = salida.Replace("%contenido%", "Debes ingresar al sistema y realizar la modificación en los registros, tienes un máximo de 5 minutos para realizar la modificación, pasado ese tiempo, tu permiso caducará.");
                    break;
                case "quita":
                    salida = salida.Replace("%nombrePersona%", nombre);
                    salida = salida.Replace("%mensaje%", "El usuario Administrador, ha caducado tu permiso para modificar registros.");
                    salida = salida.Replace("%contenido%", "Tu sesión en el sistema expirará y debes ingresar nuevamente al sistema para realizar ingresos y seguimiento.");
                    break;
            }
            
            
            return salida;
        }
    }
}