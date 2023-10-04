using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Datos;
using VillaNueva_Habitat.Models;

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
            var tipo_usuario = _Cat_Adm_Empresas.Obtener_Adm_Empresas_por_id(id).FirstOrDefault();
            try
            {
                if (tipo_usuario == null)
                {
                    TempData["InfoMessage"] = "Cliente no encontrado con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Adm Empresas - Actualizar");

                    return RedirectToAction("Index");
                }
                return View(tipo_usuario);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Adm Empresas - Actualizar");
                return View();
            }
        }

        // GET: Adm_Empresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adm_Empresas/Create
        [HttpPost]
        public ActionResult Create(Cat_Administrador_Empresa _Cat_Administrador_Empresa)
        {
            bool EsInsertado = false;
            try
            {
                if (ModelState.IsValid)
                {
                 //   EsInsertado = _Cat_Adm_Empresas.Agregar_Adm_Empresas(_Cat_Administrador_Empresa);
                    if (EsInsertado)
                    {
                        TempData["SuccessMessage"] = "El Cliente fue insertado correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Adm Empresas - Insertar");

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo insertar el Documento correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Adm Empresas - Insertar");

                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMesage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Adm Empresas - Insertar");

                return View();
            }
        }

        // GET: Adm_Empresas/Edit/5
        public ActionResult Edit(int id)
        {
            var _tipo_proceso = _Cat_Adm_Empresas.Obtener_Adm_Empresas_por_id(id).FirstOrDefault();

            if (_tipo_proceso == null)
            {
                TempData["InfoMessage"] = "Cliente no encontrado con el id " + id.ToString();
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Adm Empresas - Actualizar");

                return RedirectToAction("Index");
            }
            return View(_tipo_proceso);
        }

        // POST: Adm_Empresas/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(Cat_Administrador_Empresa _Cat_Administrador_Empresa)
        {
            try
            {
                // TODO: Add update logic here

                try
                {
                    if (ModelState.IsValid)
                    {
                        bool EsActualizado = _Cat_Adm_Empresas.Actualizar_Adm_Empresas(_Cat_Administrador_Empresa);
                        if (EsActualizado)
                        {
                            TempData["SuccessMessage"] = "El usuario fue catualizado correctamente...!";
                            DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Cat Adm Empresas - Actualizar");

                        }
                        else
                        {
                            TempData["InfoMessage"] = "El usuario no fue catualizado correctamente.";
                            DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Adm Empresas - Actualizar");

                        }
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    TempData["ErrorMessage"] = ex.Message;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Cat Adm Empresas - Catalogos");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Adm_Empresas/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {

                var _tipo_usuario = _Cat_Adm_Empresas.Obtener_Adm_Empresas_por_id(id).FirstOrDefault();
                if (_tipo_usuario == null)
                {
                    TempData["InfoMessage"] = "No se encontro el cliente con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Adm Empresas - Eliminar");
                    return RedirectToAction("Index");
                }
                return View(_tipo_usuario);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Cat Adm Empresas - Eliminar");
                return View();
            }
        }

        // POST: Adm_Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {


                string result = _Cat_Adm_Empresas.Eliminar_Adm_Empresas(id);

                if (result.Contains("eliminado"))
                {
                    TempData["SuccessMessage"] = result;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Cat Adm Empresas - Eliminar");

                }
                else
                {
                    TempData["ErrorMessage"] = result;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Cat Adm Empresas - Eliminar");

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Cat Adm Empresas - Eliminar");
                return View();
            }
        }
    }
}
