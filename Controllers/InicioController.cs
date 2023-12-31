﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Models;
using VillaNueva_Habitat.Datos;
using VillaNueva_Habitat.Servicios;
using System.Web.Security;

namespace VillaNueva_Habitat.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string correo,string clave)
        {
            bool res = RegexUtilities.IsValidEmail(correo);
            var _clave = UtilidadServicio.GetSHA256(clave);
            if (res)
            {
                UsuarioDTO usuario = DBUsuario.validar(correo,_clave);
                if (usuario != null)
                {
                    FormsAuthentication.SetAuthCookie(usuario.Correo, false);
                    Session["_usuario"]  = usuario.nombre;
                    Session["IdUsuario"] = usuario.IdUsuario;
                    Session["Correo"]    = usuario.Correo;
                    Session["RolId"]     = usuario.RolId;
                    if (usuario.Confirmado)
                    {
                        ViewBag.Mensaje = $"Falta confirmar su cuenta. Se le envio un correo a {correo}";
                    }
                    else if (usuario.Restablecer)
                    {
                        ViewBag.Mensaje = $"Se ha solicitado restablecer su cuenta, favor revise su bandeja del correo {correo}";
                    }
                    else
                    {
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["Correo"].ToString(), Convert.ToInt32(Session["RolId"]),"Bienvenido !" + Session["_usuario"].ToString(),"Usuario Autenticado en Login");
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.Mensaje = "El correo no se encuentra registrado";
                }
            }
            else
            {
                ViewBag.Mensaje = "El correo no es valido";
            }

            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(UsuarioDTO usuario)
        {
            if (usuario.Clave != usuario.ConfirmarClave)
            {
                ViewBag.Nombre = usuario.nombre;
                ViewBag.Correo = usuario.Correo;
                ViewBag.Mensaje = "Las contraseñas no coinciden";
                return View();
            }

            bool res = RegexUtilities.IsValidEmail(usuario.Correo);
            if (res)
           
            {
                if (DBUsuario.obtener(usuario.Correo) == null)
                {
                    usuario.Clave = UtilidadServicio.GetSHA256(usuario.Clave);
                    usuario.ConfirmarClave = UtilidadServicio.GetSHA256(usuario.ConfirmarClave);
                    usuario.Token = UtilidadServicio.GenerarToken();
                    usuario.Restablecer = false;
                    usuario.Confirmado = false;
                    bool respuesta = DBUsuario.registrar(usuario);

                    if (respuesta)
                    {
                        string path = HttpContext.Server.MapPath("~/Plantilla/Confirmar.html");
                        string content = System.IO.File.ReadAllText(path);
                        string url = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Headers["Host"], "/Inicio!Confirmar?Token=" + usuario.Token);

                        string htmlBody = string.Format(content, usuario.nombre, Url);

                        CorreoDTO correoDTO = new CorreoDTO()
                        {
                            Para = usuario.Correo,
                            Asunto = "Correo confirmación",
                            Contenido = htmlBody
                        };

                        bool enviado = CorreoServicio.Enviar(correoDTO);
                        ViewBag.Creado = true;
                        ViewBag.Mensaje = $"Su cuenta ha sido creada. Hemos enviado un mensaje al correo {usuario.Correo} para confirmar su cuenta";

                    }
                    else
                    {
                        ViewBag.Mensaje = "No se pudo crear su cuenta";
                    }
                }
                else
                {
                    ViewBag.Mensaje = "El correo ya esta registrado";
                }
            }
            else
            {
                ViewBag.Mensaje = "El correo esta mal elaborado";
            }

            return View();
        }

        public ActionResult Confirmar(string Token)
        {
            ViewBag.Respuesta = DBUsuario.Confirmar(Token);
            return View();
        }

        public ActionResult Restablecer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Restablecer(string correo)
        {
            UsuarioDTO usuario = DBUsuario.obtener(correo);
            ViewBag.Correo = correo;
            if(usuario != null)
            {
                bool respuesta = DBUsuario.RestablecerActualizar(usuario.Restablecer,usuario.Clave,usuario.Token);

                if (respuesta)
                {

                    string path = HttpContext.Server.MapPath("~/Plantilla/Restablecer.html");
                    string content = System.IO.File.ReadAllText(path);
                    string url = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Headers["Host"], "/Inicio!Actualizar?Token=" + usuario.Token);
                    //string url = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Headers["Host"], "/Inicio!Confirmar?Token=" + usuario.Token);

                    string htmlBody = string.Format(content, usuario.nombre, Url);

                    CorreoDTO correoDTO = new CorreoDTO()
                    {
                        Para = usuario.Correo,
                        Asunto = "Restablecer Cuenta",
                        Contenido = htmlBody
                    };

                    bool enviado = CorreoServicio.Enviar(correoDTO);
                    ViewBag.Creado = true;
                    ViewBag.Mensaje = $"Hemos enviado un mensaje al correo {usuario.Correo} para cambiar su contraseña..";

                       
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo restablecer la cuenta";
                }
            }
            else
            {
                ViewBag.Mensaje = "No se encontraron coincidencias con el correo";
            }
            return View();
        }

        public ActionResult Actualizar(string token)
        {
            ViewBag.Token = token;
            return View();
        }

        [HttpPost]
        public ActionResult Actualizar(string token,string clave,string confirmarclave)
        {
            ViewBag.Token = token;
            if (clave != confirmarclave)
            {
                ViewBag.Mensaje = "Las contraseñas mo coinciden";
                return View();
            }

            bool respuesta = DBUsuario.RestablecerActualizar(false,UtilidadServicio.GetSHA256(clave), token);

            if (respuesta)
                ViewBag.Restablecido = true;
            else
                ViewBag.Mensaje = "No se pudo actualizar";
            return View();
        }

        private void FillDropDownList(int? CountryId = 0)
        {
            Cat_Tipo_Usuario _tipo_usuario = new Cat_Tipo_Usuario();


            List<SelectListItem> tipo_usuario = new List<SelectListItem>();

            foreach (var lst_tipo_usuario in _tipo_usuario.usp_Obtener_Tipo_Usuario())
            {
                tipo_usuario.Add(new SelectListItem()
                { Value = "0", Text = "-", Selected = false });

                tipo_usuario.Add(

                    new SelectListItem()
                    {
                        Value = lst_tipo_usuario.Id_tipo_usuario.ToString(),
                        Text = lst_tipo_usuario.Descripcion.ToString(),
                        Selected = Convert.ToBoolean(lst_tipo_usuario.Id_tipo_usuario)
                    }) ;
            }

            ViewData["Tipo_Usuario"] = tipo_usuario;


           /* try
            {
                var lst_tipo_usuario = _tipo_usuario.usp_Obtener_Tipo_Usuario();
                if (lst_tipo_usuario.Count == 0)
                {
                    TempData["InfoMessage"] = "No existe información en la base de datos";
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Tipo Usuario - List");

                }
                return View(lst_tipo_usuario);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Tipo Usuario - List");
                return View();
            }
           */

        }
    }


}