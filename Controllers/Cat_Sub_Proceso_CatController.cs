using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Datos;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Controllers
{
    public class Cat_Sub_Proceso_CatController : Controller
    {
        DAL_Cat_Sub_Proceso_Cat _Cat_Sub_Proceso_Cat = new DAL_Cat_Sub_Proceso_Cat();

        // GET: Cat_Sub_Proceso_Cat
        public ActionResult Index()
        {
            try
            {
                var lst_sub_proceso_cat = _Cat_Sub_Proceso_Cat.Obtener_Tipo_Sub_Proceso_Cat();
                if (lst_sub_proceso_cat.Count == 0)
                {
                    TempData["InfoMessage"] = "No existe información en la base de datos";
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Sub proceso Cat - List");

                }
                return View(lst_sub_proceso_cat);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Sub proceso Cat  - List");
                return View();
            }
        }

        // GET: Cat_Sub_Proceso_Cat/Details/5
        public ActionResult Details(int id)
        {
            var tipo_usuario = _Cat_Sub_Proceso_Cat.Obtener_Sub_Proceso_cat_por_id(id).FirstOrDefault();
            try
            {
                if (tipo_usuario == null)
                {
                    TempData["InfoMessage"] = "Sub Proceso no encontrado con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Sub Proceso Catalogos - Actualizar");

                    return RedirectToAction("Index");
                }
                return View(tipo_usuario);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Sub Proceso Catalogos - Actualizar");
                return View();
            }
        }

        // GET: Cat_Sub_Proceso_Cat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cat_Sub_Proceso_Cat/Create
        [HttpPost]
        public ActionResult Create(Cat_Sub_Proceso_Cat Sub_Proceso_Cat)
        {
            bool EsInsertado = false;
            try
            {
                if (ModelState.IsValid)
                {
                    EsInsertado = _Cat_Sub_Proceso_Cat.Agregar_Sub_Proceso_cat(Sub_Proceso_Cat);
                    if (EsInsertado)
                    {
                        TempData["SuccessMessage"] = "El Subproceso fue insertado correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Sub Proceso Catalogos - Insertar");

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo insertar el Proceso correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Sub Proceso Catalogos - Insertar");

                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMesage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Sub Proceso Sistema - Insertar");

                return View();
            }
        }

        // GET: Cat_Sub_Proceso_Cat/Edit/5
        public ActionResult Edit(int id)
        {
            var _tipo_proceso = _Cat_Sub_Proceso_Cat.Obtener_Sub_Proceso_cat_por_id(id).FirstOrDefault();

            if (_tipo_proceso == null)
            {
                TempData["InfoMessage"] = "Sub Proceso no encontrado con el id " + id.ToString();
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Sub Proceso Catalogos - Actualizar");

                return RedirectToAction("Index");
            }
            return View(_tipo_proceso);
        }

        // POST: Cat_Sub_Proceso_Cat/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(Cat_Sub_Proceso_Cat Sub_Proceso_cat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool EsActualizado = _Cat_Sub_Proceso_Cat.Actualizar_sub_Proceso_cat(Sub_Proceso_cat);
                    if (EsActualizado)
                    {
                        TempData["SuccessMessage"] = "El tipo de subproceso de sistema fue catualizado correctamente...!";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Sub Proceso Catalogos - Actualizar");

                    }
                    else
                    {
                        TempData["InfoMessage"] = "El subproceso de sistema no fue catualizado correctamente.";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Sub Proceso Catalogos - Actualizar");

                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Sub Proceso Sistema - Catalogos");
                return View();
            }
        }

        // GET: Cat_Sub_Proceso_Cat/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {

                var _tipo_usuario = _Cat_Sub_Proceso_Cat.Obtener_Sub_Proceso_cat_por_id(id).FirstOrDefault();
                if (_tipo_usuario == null)
                {
                    TempData["InfoMessage"] = "No se encontro el tipo de Sub proceso con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "SUb Proceso Catalogo - Eliminar");
                    return RedirectToAction("Index");
                }
                return View(_tipo_usuario);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Sub Proceso Catalogo - Eliminar");
                return View();
            }
        }

        // POST: Cat_Sub_Proceso_Cat/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {


                string result = _Cat_Sub_Proceso_Cat.Eliminar_Sub_Proceso_cat(id);

                if (result.Contains("eliminado"))
                {
                    TempData["SuccessMessage"] = result;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Sub Proceso Catalogos - Eliminar");

                }
                else
                {
                    TempData["ErrorMessage"] = result;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Sub Proceso Catalogos - Eliminar");

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Sub Proceso Catalogos - Eliminar");
                return View();
            }
        }
    }
}
