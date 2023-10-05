using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Datos;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Controllers
{
    public class Expediente_ProyectoController : Controller
    {
        DAL_cat_exp_proyecto _Cat_Exp_Proyecto = new DAL_cat_exp_proyecto();

        // GET: Expediente_Proyecto
        public ActionResult Index()
        {
            try
            {
                var lst_Exp_Proyecto = _Cat_Exp_Proyecto.Obtener_exp_proyecto();
                if (lst_Exp_Proyecto.Count == 0)
                {
                    TempData["InfoMessage"] = "No existe información en la base de datos";
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Expediente Proyecto - List");

                }
                return View(lst_Exp_Proyecto);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Expediente Proyecto - List");
                return View();
            }
        }

        // GET: Expediente_Proyecto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Expediente_Proyecto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expediente_Proyecto/Create
        [HttpPost]
        public ActionResult Create(cat_exp_proyecto _cat_exp_proyecto)
        {
            bool EsInsertado = false;
            try
            {
                if (ModelState.IsValid)
                {
                    EsInsertado = _Cat_Exp_Proyecto.Agregar_exp_proyecto(_cat_exp_proyecto);
                    if (EsInsertado)
                    {
                        TempData["SuccessMessage"] = "El Subproceso fue insertado correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Sub Proceso Sistema - Insertar");

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo insertar el Proceso correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Sub Proceso Sistema - Insertar");

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

        // GET: Expediente_Proyecto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Expediente_Proyecto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Expediente_Proyecto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Expediente_Proyecto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
