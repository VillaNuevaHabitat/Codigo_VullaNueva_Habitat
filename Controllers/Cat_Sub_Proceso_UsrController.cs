using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Datos;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Controllers
{
    public class Cat_Sub_Proceso_UsrController : Controller
    {
        DAL_Cat_Sub_Proceso_Usr _Cat_Sub_Proceso_Usr = new DAL_Cat_Sub_Proceso_Usr();

        // GET: Cat_Sub_Proceso_Usr
        public ActionResult Index()
        {
            try
            {
                var lst_sub_proceso_usr = _Cat_Sub_Proceso_Usr.Obtener_Tipo_Sub_Proceso_Usr();
                if (lst_sub_proceso_usr.Count == 0)
                {
                    TempData["InfoMessage"] = "No existe información en la base de datos";
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Tipo proceso - List");

                }
                return View(lst_sub_proceso_usr);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Tipo Proceso - List");
                return View();
            }
        }

        // GET: Cat_Sub_Proceso_Usr/Details/5
        public ActionResult Details(int id)
        {
            var tipo_usuario = _Cat_Sub_Proceso_Usr.Obtener_SUB_Proceso_usr_por_id(id).FirstOrDefault();
            try
            {
                if (tipo_usuario == null)
                {
                    TempData["InfoMessage"] = "Sub Proceso no encontrado con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Sub Proceso Usuario - Actualizar");

                    return RedirectToAction("Index");
                }
                return View(tipo_usuario);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Sub Proceso Usuario - Actualizar");
                return View();
            }
        }

        // GET: Cat_Sub_Proceso_Usr/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cat_Sub_Proceso_Usr/Create
        [HttpPost]
        public ActionResult Create(Cat_Sub_Proceso_Usr Sub_Proceso_usr)
        {
            bool EsInsertado = false;
            try
            {
                if (ModelState.IsValid)
                {
                    EsInsertado = _Cat_Sub_Proceso_Usr.Agregar_Sub_Proceso_Usr(Sub_Proceso_usr);
                    if (EsInsertado)
                    {
                        TempData["SuccessMessage"] = "El Subproceso fue insertado correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Sub Proceso Usuario - Insertar");

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo insertar el Proceso correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Sub Proceso Usuario - Insertar");

                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMesage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Sub Proceso Usuario - Insertar");

                return View();
            }
        }

        // GET: Cat_Sub_Proceso_Usr/Edit/5
        public ActionResult Edit(int id)
        {
            var _tipo_proceso = _Cat_Sub_Proceso_Usr.Obtener_SUB_Proceso_usr_por_id(id).FirstOrDefault();

            if (_tipo_proceso == null)
            {
                TempData["InfoMessage"] = "Sub Proceso no encontrado con el id " + id.ToString();
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Sub Proceso Usuario - Actualizar");

                return RedirectToAction("Index");
            }
            return View(_tipo_proceso);
        }

        // POST: Cat_Sub_Proceso_Usr/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(Cat_Sub_Proceso_Usr Sub_Proceso_usr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool EsActualizado = _Cat_Sub_Proceso_Usr.Actualizar_sub_Proceso_usr(Sub_Proceso_usr);
                    if (EsActualizado)
                    {
                        TempData["SuccessMessage"] = "El tipo de subproceso de usuario fue catualizado correctamente...!";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Sub Proceso Usuario - Actualizar");

                    }
                    else
                    {
                        TempData["InfoMessage"] = "El subproceso de sistema no fue catualizado correctamente.";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Sub Proceso Usuario - Actualizar");

                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Sub Proceso Usuario - Actualizar");
                return View();
            }
        }

        // GET: Cat_Sub_Proceso_Usr/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {

                var _tipo_usuario = _Cat_Sub_Proceso_Usr.Obtener_SUB_Proceso_usr_por_id(id).FirstOrDefault();
                if (_tipo_usuario == null)
                {
                    TempData["InfoMessage"] = "No se encontro el tipo de Sub proceso con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "SUb Proceso Usuario - Eliminar");
                    return RedirectToAction("Index");
                }
                return View(_tipo_usuario);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Sub Proceso Usuario - Eliminar");
                return View();
            }
        }


        // POST: Cat_Sub_Proceso_Usr/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {


                string result = _Cat_Sub_Proceso_Usr.Eliminar_Sub_Proceso_Usr(id);

                if (result.Contains("eliminado"))
                {
                    TempData["SuccessMessage"] = result;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Sub Proceso Usuario - Eliminar");

                }
                else
                {
                    TempData["ErrorMessage"] = result;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Sub Proceso Usuario - Eliminar");

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Sub Proceso Eliminado - Eliminar");
                return View();
            }
        }
    }
}
