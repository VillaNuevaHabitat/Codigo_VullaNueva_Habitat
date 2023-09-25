using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Datos;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Controllers
{
    public class cat_estatus_proyectoController : Controller
    {
        DAL_cat_estatus_proyecto _Cat_estatus_proyecto = new DAL_cat_estatus_proyecto();
        // GET: cat_estatus_proyecto
        public ActionResult Index()
        {
            try
            {
                var lst_adm_usuarios = _Cat_estatus_proyecto.Obtener_Estatus_Proyecto();
                if (lst_adm_usuarios.Count == 0)
                {
                    TempData["InfoMessage"] = "No existe información en la base de datos";
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Estatus Proyecto - List");

                }
                return View(lst_adm_usuarios);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Cat Estatus Proyecto - List");
                return View();
            }
        }

        // GET: cat_estatus_proyecto/Details/5
        public ActionResult Details(int id)
        {
            var tipo_proyecto = _Cat_estatus_proyecto.usp_Obtener_Estatus_Proyecto_por_id(id).FirstOrDefault();
            try
            {
                if (tipo_proyecto == null)
                {
                    TempData["InfoMessage"] = "Usuario no encontrado con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Estatus Proyecto - Actualizar");

                    return RedirectToAction("Index");
                }
                return View(tipo_proyecto);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Cat Estatus Proyecto - Actualizar");
                return View();
            }
        }

        // GET: cat_estatus_proyecto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cat_estatus_proyecto/Create
        [HttpPost]
        public ActionResult Create(cat_estatus_proyecto _cat_estatus_proyecto)
        {
            bool EsInsertado = false;
            try
            {
                if (ModelState.IsValid)
                {
                    EsInsertado = _Cat_estatus_proyecto.Agregar_Estatus_Proyecto(_cat_estatus_proyecto);
                    if (EsInsertado)
                    {
                        TempData["SuccessMessage"] = "El Ususrio fue insertado correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Cat Estatus Proyecto - Insertar");

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo insertar el Documento correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Cat Estatus Proyecto - Insertar");

                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMesage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Cat Estatus Proyecto - Insertar");

                return View();
            }
        }

        // GET: cat_estatus_proyecto/Edit/5
        public ActionResult Edit(int id)
        {
            var _tipo_proceso = _Cat_estatus_proyecto.usp_Obtener_Estatus_Proyecto_por_id(id).FirstOrDefault();

            if (_tipo_proceso == null)
            {
                TempData["InfoMessage"] = "Usuario no encontrado con el id " + id.ToString();
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Estatus Proyecto - Actualizar");

                return RedirectToAction("Index");
            }
            return View(_tipo_proceso);
        }

        // POST: cat_estatus_proyecto/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(cat_estatus_proyecto _cat_estatus_proyecto)
        {
            try
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        bool EsActualizado = _Cat_estatus_proyecto.Actualizar_Estatus_Proyecto(_cat_estatus_proyecto);
                        if (EsActualizado)
                        {
                            TempData["SuccessMessage"] = "El usuario fue catualizado correctamente...!";
                            DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Cat Estatus Proyecto - Actualizar");

                        }
                        else
                        {
                            TempData["InfoMessage"] = "El usuario no fue catualizado correctamente.";
                            DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Estatus Proyecto - Actualizar");

                        }
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    TempData["ErrorMessage"] = ex.Message;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Cat Estatus Proyecto - Catalogos");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: cat_estatus_proyecto/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {

                var _tipo_usuario = _Cat_estatus_proyecto.usp_Obtener_Estatus_Proyecto_por_id(id).FirstOrDefault();
                if (_tipo_usuario == null)
                {
                    TempData["InfoMessage"] = "No se encontro el tipo de Sub proceso con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Estatus Proyecto - Eliminar");
                    return RedirectToAction("Index");
                }
                return View(_tipo_usuario);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Cat Estatus Proyecto - Eliminar");
                return View();
            }
        }

        // POST: cat_estatus_proyecto/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {


                string result = _Cat_estatus_proyecto.Eliminar_estatua_proyecto(id);

                if (result.Contains("eliminado"))
                {
                    TempData["SuccessMessage"] = result;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Cat Estatus Proyecto - Eliminar");

                }
                else
                {
                    TempData["ErrorMessage"] = result;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Cat Estatus Proyecto - Eliminar");

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Adm Usuarios - Eliminar");
                return View();
            }
        }
    }
}
