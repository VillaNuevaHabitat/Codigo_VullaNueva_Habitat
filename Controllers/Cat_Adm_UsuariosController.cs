using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Datos;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Controllers
{
    public class Cat_Adm_UsuariosController : Controller
    {
        DAL_Cat_Adm_Usuarios _Cat_Adm_Usuarios = new DAL_Cat_Adm_Usuarios();
        // GET: Cat_Adm_Usuarios
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var lst_adm_usuarios = _Cat_Adm_Usuarios.Obtener_Adm_Usuario();
                if (lst_adm_usuarios.Count == 0)
                {
                    TempData["InfoMessage"] = "No existe información en la base de datos";
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Adm Usuarios - List");

                }
                return View(lst_adm_usuarios);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Adm Usuarios - List");
                return View();
            }
        }

        // GET: Cat_Adm_Usuarios/Details/5
        public ActionResult Details(int id)
        {
            var tipo_usuario = _Cat_Adm_Usuarios.Obtener_Adm_Usuario_por_id(id).FirstOrDefault();
            try
            {
                if (tipo_usuario == null)
                {
                    TempData["InfoMessage"] = "Usuario no encontrado con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Adm Usuarios - Actualizar");

                    return RedirectToAction("Index");
                }
                return View(tipo_usuario);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Cat Adm Usuarios - Actualizar");
                return View();
            }
        }

        // GET: Cat_Adm_Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cat_Adm_Usuarios/Create
        [HttpPost]
        public ActionResult Create(cat_admin_usuarios Adm_Usuarios)
        {
            bool EsInsertado = false;
            try
            {
                if (ModelState.IsValid)
                {
                    EsInsertado = _Cat_Adm_Usuarios.Agregar_Adm_Usuario(Adm_Usuarios);
                    if (EsInsertado)
                    {
                        TempData["SuccessMessage"] = "El Ususrio fue insertado correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Adm Usuarios - Insertar");

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo insertar el Documento correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Adm Usuarios - Insertar");

                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMesage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Adm Usuarios - Insertar");

                return View();
            }
        }

        // GET: Cat_Adm_Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            var _tipo_proceso = _Cat_Adm_Usuarios.Obtener_Adm_Usuario_por_id(id).FirstOrDefault();

            if (_tipo_proceso == null)
            {
                TempData["InfoMessage"] = "Usuario no encontrado con el id " + id.ToString();
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Adm Usuarios - Actualizar");

                return RedirectToAction("Index");
            }
            return View(_tipo_proceso);
        }

        // POST: Cat_Adm_Usuarios/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(cat_admin_usuarios adm_usuarios)
        {
            try
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        bool EsActualizado = _Cat_Adm_Usuarios.Actualizar_Tipo_Usuario(adm_usuarios);
                        if (EsActualizado)
                        {
                            TempData["SuccessMessage"] = "El usuario fue catualizado correctamente...!";
                            DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Adm Usuarios - Actualizar");

                        }
                        else
                        {
                            TempData["InfoMessage"] = "El usuario no fue catualizado correctamente.";
                            DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Adm Usuarios - Actualizar");

                        }
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    TempData["ErrorMessage"] = ex.Message;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Adm Usuarios - Catalogos");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Cat_Adm_Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {

                var _tipo_usuario = _Cat_Adm_Usuarios.Obtener_Adm_Usuario_por_id(id).FirstOrDefault();
                if (_tipo_usuario == null)
                {
                    TempData["InfoMessage"] = "No se encontro el tipo de Sub proceso con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Adm Usuarios - Eliminar");
                    return RedirectToAction("Index");
                }
                return View(_tipo_usuario);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Adm Usuarios - Eliminar");
                return View();
            }
        }

        // POST: Cat_Adm_Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {


                string result = _Cat_Adm_Usuarios.Eliminar_Tipo_Usuario(id);

                if (result.Contains("eliminado"))
                {
                    TempData["SuccessMessage"] = result;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Adm Usuarios - Eliminar");

                }
                else
                {
                    TempData["ErrorMessage"] = result;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Adm Usuarios - Eliminar");

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
