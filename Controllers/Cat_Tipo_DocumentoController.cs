using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Datos;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Controllers
{
    public class Cat_Tipo_DocumentoController : Controller
    {
        Db_Cat_Tipo_Documento _Cat_Tipo_Documento = new Db_Cat_Tipo_Documento();

        // GET: Cat_Tipo_Documento
        [HttpGet]
        public ActionResult Index()
        {
          

               try
               {
                   var lst_tipo_documento = _Cat_Tipo_Documento.Obtener_Tipo_Documento();
                   if (lst_tipo_documento.Count == 0)
                   {
                       TempData["InfoMessage"] = "No existe información en la base de datos";
                       DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Tipo Documento - List");

                   }
                   return View(lst_tipo_documento);
               }
               catch (Exception ex)
               {
                   TempData["ErrorMessage"] = ex.Message;
                   DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Tipo Documento - List");
                   return View();
               }
        }

        // GET: Cat_Tipo_Documento/Details/5
        public ActionResult Details(int id)
        {
            var tipo_usuario = _Cat_Tipo_Documento.Obtener_Tipo_Documento_por_id(id).FirstOrDefault();
            try
            {
                if (tipo_usuario == null)
                {
                    TempData["InfoMessage"] = "Documento no encontrado con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Tipo Documento - Actualizar");

                    return RedirectToAction("Index");
                }
                return View(tipo_usuario);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Tipo Documento - Actualizar");
                return View();
            }
        }

        // GET: Cat_Tipo_Documento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cat_Tipo_Documento/Create
        [HttpPost]
        public ActionResult Create(Cat_Tipo_Documento Tipo_Documento)
        {
            bool EsInsertado = false;
            try
            {
                if (ModelState.IsValid)
                {
                    EsInsertado = _Cat_Tipo_Documento.Agregar_Tipo_Documento(Tipo_Documento);
                    if (EsInsertado)
                    {
                        TempData["SuccessMessage"] = "El Ususrio fue insertado correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Tipo Documento - Insertar");

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo insertar el Documento correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Tipo Documento - Insertar");

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

        // GET: Cat_Tipo_Documento/Edit/5
        public ActionResult Edit(int id)
        {
            var _tipo_documento = _Cat_Tipo_Documento.Obtener_Tipo_Documento_por_id(id).FirstOrDefault();

            if (_tipo_documento == null)
            {
                TempData["InfoMessage"] = "Documento no encontrado con el id " + id.ToString();
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Tipo Documento - Actualizar");

                return RedirectToAction("Index");
            }
            return View(_tipo_documento);
        }

        // POST: Cat_Tipo_Documento/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(Cat_Tipo_Documento tipo_Documento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool EsActualizado = _Cat_Tipo_Documento.Actualizar_Tipo_Documento(tipo_Documento);
                    if (EsActualizado)
                    {
                        TempData["SuccessMessage"] = "El tipo de Documento fue catualizado correctamente...!";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Tipo Proceso - Actualizar");

                    }
                    else
                    {
                        TempData["InfoMessage"] = "El Documento no fue catualizado correctamente.";
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

        // GET: Cat_Tipo_Documento/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {

                var _tipo_dccumento = _Cat_Tipo_Documento.Obtener_Tipo_Documento_por_id(id).FirstOrDefault();
                if (_tipo_dccumento == null)
                {
                    TempData["InfoMessage"] = "No se encontro el tipo de documento con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Tipo Proceso - Eliminar");
                    return RedirectToAction("Index");
                }
                return View(_tipo_dccumento);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Tipo Proceso - Eliminar");
                return View();
            }
        }

        // POST: Cat_Tipo_Documento/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {


                string result = _Cat_Tipo_Documento.Eliminar_Tipo_Documento(id);

                if (result.Contains("eliminado"))
                {
                    TempData["SuccessMessage"] = result;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Tipo Documento - Eliminar");

                }
                else
                {
                    TempData["ErrorMessage"] = result;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Tipo Documento - Eliminar");

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Tipo Documento - Eliminar");
                return View();
            }
        }
    }
}
