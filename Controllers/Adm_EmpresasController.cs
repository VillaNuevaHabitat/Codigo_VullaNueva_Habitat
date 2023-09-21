using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Datos;

namespace VillaNueva_Habitat.Controllers
{
    public class Adm_EmpresasController : Controller
    {
        DAL_Adm_Empresas _Cat_Adm_Empresas = new DAL_Adm_Empresas();
        // GET: Adm_Empresas
        public ActionResult Index()
        {
            try
            {
                var lst_Adm_Empresas = _Cat_Adm_Empresas.Obtener_Adm_Empresas();
                if (lst_Adm_Empresas.Count == 0)
                {
                    TempData["InfoMessage"] = "No existe información en la base de datos";
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Adm Empresas - List");

                }
                return View(lst_Adm_Empresas);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Adm Empresas  - List");
                return View();
            }

            return View();
        }

        // GET: Adm_Empresas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Adm_Empresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adm_Empresas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Adm_Empresas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Adm_Empresas/Edit/5
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

        // GET: Adm_Empresas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Adm_Empresas/Delete/5
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
