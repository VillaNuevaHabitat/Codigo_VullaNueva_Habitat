using System;
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
        Cat_Tipo_Usuario _tipo_usuario = new Cat_Tipo_Usuario();

        // GET: Tipo_Usuario
        [HttpGet]
        public ActionResult Index()
        {
          
            try
            {
               var lst_tipo_usuario = _tipo_usuario.usp_Obtener_Tipo_Usuario();
                if(lst_tipo_usuario.Count == 0)
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

           
        }

        public ActionResult Details(int id)
        {
            var tipo_usuario = _tipo_usuario.usp_Obtener_Tipo_Usuario_por_id(id).FirstOrDefault();
            try
            {
                if (tipo_usuario == null)
                {
                    TempData["InfoMessage"] = "Usuario no encontrado con el id " + id.ToString();
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
        public ActionResult InsertaProvedores()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            
            var tipo_usuario = _tipo_usuario.usp_Obtener_Tipo_Usuario_por_id(id).FirstOrDefault();

            if (tipo_usuario == null)
            {
                TempData["InfoMessage"] = "Usuario no encontrado con el id " + id.ToString();
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Tipo Usuario - Actualizar");

                return RedirectToAction("Index");
            }
            return View(tipo_usuario);
        }

        [HttpPost,ActionName("Edit")]
        public ActionResult Actualiza_Tipo_Usuario(cat_tipo_usuario tipo_Usuario)
        {
          //  Cat_Tipo_Usuario _Tipo_Usuario = new Cat_Tipo_Usuario();
            try
            {
                if (ModelState.IsValid)
                {
                    bool EsActualizado = _tipo_usuario.usp_Actualizar_Tipo_Usuario(tipo_Usuario);
                    if (EsActualizado)
                    {
                        TempData["SuccessMessage"] = "El tipo de usuario fue catualizado correctamente...!";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Tipo Usuario - Actualizar");

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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(cat_tipo_usuario Tipo_Usuario)
        {
            bool EsInsertado = false;
            try
            {
                if (ModelState.IsValid)
                {
                    EsInsertado = _tipo_usuario.usp_Agregar_Tipo_Usuario(Tipo_Usuario);
                    if(EsInsertado)
                    {
                        TempData["SuccessMessage"] = "El Ususrio fue insertado correctamente";
                       // DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Tipo Usuario - Insertar");

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo insertar el Usuario correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Tipo Usuario - Insertar");

                    }
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["ErrorMesage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Tipo Usuario - Insertar");

                return View();
            }
        }

       public ActionResult Delete(int id)
        {
            try
            {
         
                var tipo_usuario = _tipo_usuario.usp_Obtener_Tipo_Usuario_por_id(id).FirstOrDefault();
                if (_tipo_usuario == null)
                {
                    TempData["InfoMessage"] = "No se encontro el tipo de usuario con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Tipo Usuario - Eliminar");
                    return RedirectToAction("Index");
                }
                return View(tipo_usuario);
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
          

                string result = _tipo_usuario.usp_Eliminar_Tipo_Usuario(id);

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