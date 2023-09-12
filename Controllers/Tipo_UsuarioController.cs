﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Datos;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Controllers
{
    public class Tipo_UsuarioController : Controller
    {
        // GET: Tipo_Usuario
        [HttpGet]
        public ActionResult Index()
        {
            List<cat_tipo_usuario> lst_tipo_usuario = new List<cat_tipo_usuario>();

            Cat_Tipo_Usuario _tipo_usuario = new Cat_Tipo_Usuario();

            try
            {
                lst_tipo_usuario = _tipo_usuario.Obtener_Tipo_Usuario();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }

            return View(lst_tipo_usuario);
        }

        public ActionResult InsertaProvedores()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            Cat_Tipo_Usuario tipo_usuario = new Cat_Tipo_Usuario();
            var _tipo_usuario = tipo_usuario.Obtener_Tipo_Usuario_por_id(id).FirstOrDefault();

            if (_tipo_usuario == null)
            {
                TempData["InfoMessage"] = "Usuario no encontrado con el id " + id.ToString();
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Tipo Usuario - Actualizar");

                return RedirectToAction("Index");
            }
            return View(_tipo_usuario);
        }

        [HttpPost,ActionName("Edit")]
        public ActionResult Actualiza_Tipo_Usuario(cat_tipo_usuario tipo_Usuario)
        {
            Cat_Tipo_Usuario _Tipo_Usuario = new Cat_Tipo_Usuario();
            try
            {
                if (ModelState.IsValid)
                {
                    bool EsActualizado = _Tipo_Usuario.Actualizar_Tipo_Usuario(tipo_Usuario);
                    if (EsActualizado)
                    {
                        TempData["SuccessMesage"] = "El tipo de usuario fue catualizado correctamente...!";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMesage"].ToString(), "Tipo Usuario - Actualizar");

                    }
                    else
                    {
                        TempData["InfoMessage"] = "El tipo de usuario no fue catualizado correctamente.";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Tipo Usuario - Actualizar");

                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(),Convert.ToInt32(Session["RolId"]),"Error : "  + ex.Message,"Tipo Usuario - Actualizar");
                return View();
            }
        }

        [HttpPost]
        public ActionResult InsertaProvedores(cat_tipo_usuario TIPO_USUARIO)
        {
            bool EsInsertado = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Cat_Tipo_Usuario _Tipo_Usuario  = new Cat_Tipo_Usuario();
                    EsInsertado = _Tipo_Usuario.Agregar_Tipo_Usuario(TIPO_USUARIO);
                    if(EsInsertado)
                    {
                        TempData["SuccessMessage"] = "El Ususrio fue insertado correctamente";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo insertar el Usuario correctamente";
                    }
                    if (_Tipo_Usuario.Agregar_Tipo_Usuario(TIPO_USUARIO))
                    {
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["ErrorMesage"] = ex.Message;
                return View();
            }
        }

       public ActionResult Delete(int id)
        {
            try
            {
                Cat_Tipo_Usuario tipo_usuario = new Cat_Tipo_Usuario();
                var _tipo_usuario = tipo_usuario.Obtener_Tipo_Usuario_por_id(id).FirstOrDefault();
                if (_tipo_usuario == null)
                {
                    TempData["InfoMessage"] = "No se encontro el tipo de usuario con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Tipo Usuario - Eliminar");
                    return RedirectToAction("Index");
                }
                return View(_tipo_usuario);
            }
            catch (Exception ex) 
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Tipo Usuario - Eliminar");
                return View();
            }
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {
                Cat_Tipo_Usuario tipo_usuario = new Cat_Tipo_Usuario();

                string result = tipo_usuario.Eliminar_Tipo_Usuario(id);

                if (result.Contains("eliminado"))
                {
                    TempData["SuccessMessage"] = result;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Tipo Usuario - Eliminar");

                }
                else
                {
                    TempData["ErrorMessage"] = result;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Tipo Usuario - Eliminar");

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Tipo Usuario - Eliminar");
                return View();
            }
        }
    }
}