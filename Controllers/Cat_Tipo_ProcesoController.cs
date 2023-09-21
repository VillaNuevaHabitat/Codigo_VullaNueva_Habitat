using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Datos;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Controllers
{
    public class Cat_Tipo_ProcesoController : Controller
    {
       
        Db_Cat_Tipo_Proceso _Cat_Tipo_Proceso = new Db_Cat_Tipo_Proceso();



        // GET: Cat_Tipo_Proceso
     
        public ActionResult Index()
        {
          
               try
               {
                  var lst_tipo_proceso = _Cat_Tipo_Proceso.Obtener_Tipo_Proceso();
                   if (lst_tipo_proceso.Count == 0)
                   {
                       TempData["InfoMessage"] = "No existe información en la base de datos";
                       DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Tipo proceso - List");

                   }
                    return View(lst_tipo_proceso);
                }
               catch (Exception ex)
               {
                   TempData["ErrorMessage"] = ex.Message;
                   DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Tipo Proceso - List");
                   return View();
               }

              
        }

        // GET: Cat_Tipo_Proceso/Details/5
        public ActionResult Details(int id)
        {
            var tipo_usuario = _Cat_Tipo_Proceso.Obtener_Tipo_Proceso_por_id(id).FirstOrDefault();
            try
            {
                if (tipo_usuario == null)
                {
                    TempData["InfoMessage"] = "Proceso no encontrado con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Tipo Usuario - Actualizar");

                    return RedirectToAction("Index");
                }
                return View(tipo_usuario);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Tipo Usuario - Actualizar");
                return View();
            }
        }

        // GET: Cat_Tipo_Proceso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cat_Tipo_Proceso/Create
        [HttpPost]
        public ActionResult Create(Cat_Tipo_Proceso Tipo_Proceso)
        {
            bool EsInsertado = false;
            try
            {
                if (ModelState.IsValid)
                {
                    EsInsertado = _Cat_Tipo_Proceso.Agregar_Tipo_Proceso(Tipo_Proceso);
                    if (EsInsertado)
                    {
                        TempData["SuccessMessage"] = "El Ususrio fue insertado correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Tipo Proceso - Insertar");

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo insertar el Proceso correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Tipo Proceso - Insertar");

                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMesage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Tipo Proceso - Insertar");

                return View();
            }
        }

        // GET: Cat_Tipo_Proceso/Edit/5
        public ActionResult Edit(int id)
        {
            var _tipo_proceso = _Cat_Tipo_Proceso.Obtener_Tipo_Proceso_por_id(id).FirstOrDefault();

            if (_tipo_proceso == null)
            {
                TempData["InfoMessage"] = "Proceso no encontrado con el id " + id.ToString();
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Tipo Proceso - Actualizar");

                return RedirectToAction("Index");
            }
            return View(_tipo_proceso);
        }

        // POST: Cat_Tipo_Proceso/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult Actualiza_Tipo_Proceso(Cat_Tipo_Proceso tipo_Proceso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool EsActualizado = _Cat_Tipo_Proceso.Actualizar_Tipo_Proceso(tipo_Proceso);
                    if (EsActualizado)
                    {
                        TempData["SuccessMessage"] = "El tipo de usuario fue catualizado correctamente...!";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Tipo Proceso - Actualizar");

                    }
                    else
                    {
                        TempData["InfoMessage"] = "El proceso no fue catualizado correctamente.";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Tipo Proceso - Actualizar");

                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Tipo Proceso - Actualizar");
                return View();
            }
        }

        // GET: Cat_Tipo_Proceso/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
       
                var _tipo_usuario = _Cat_Tipo_Proceso.Obtener_Tipo_Proceso_por_id(id).FirstOrDefault();
                if (_tipo_usuario == null)
                {
                    TempData["InfoMessage"] = "No se encontro el tipo de proceso con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Tipo Proceso - Eliminar");
                    return RedirectToAction("Index");
                }
                return View(_tipo_usuario);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Tipo Proceso - Eliminar");
                return View();
            }
        }

        // POST: Cat_Tipo_Proceso/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {


                string result = _Cat_Tipo_Proceso.Eliminar_Tipo_Proceso(id);

                if (result.Contains("eliminado"))
                {
                    TempData["SuccessMessage"] = result;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Tipo Proceso - Eliminar");

                }
                else
                {
                    TempData["ErrorMessage"] = result;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Tipo Proceso - Eliminar");

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Tipo Proceso - Eliminar");
                return View();
            }
        }
    }
}
