using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Datos;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Controllers
{
    public class cat_area_contactoController : Controller
    {
        DAL_cat_area_contacto _Cat_area_contacto = new DAL_cat_area_contacto();
        // GET: cat_area_contacto
       
            // GET: Cat_Adm_Usuarios
            [HttpGet]
            public ActionResult Index()
            {
                try
                {
                    var lst_area_contacto = _Cat_area_contacto.Obtener_cat_area_contacto();
                    if (lst_area_contacto.Count == 0)
                    {
                        TempData["InfoMessage"] = "No existe información en la base de datos";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Area Contacto - List");

                    }
                    return View(lst_area_contacto);
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Cat Area Contacto - List");
                    return View();
                }
                return View();
            }

        // GET: cat_area_contacto/Details/5
        public ActionResult Details(int id)
        {
            var tipo_contacto = _Cat_area_contacto.Obtener_cat_area_contacto_por_id(id).FirstOrDefault();
            try
            {
                if (tipo_contacto == null)
                {
                    TempData["InfoMessage"] = "Contacto no encontrado con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Area Contacto - Actualizar");

                    return RedirectToAction("Index");
                }
                return View(tipo_contacto);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Cat Area Contacto - Actualizar");
                return View();
            }
        }

        // GET: cat_area_contacto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cat_area_contacto/Create
        [HttpPost]
        public ActionResult Create(cat_area_contacto area_contacto)
        {
            bool EsInsertado = false;
            try
            {
                if (ModelState.IsValid)
                {
                    EsInsertado = _Cat_area_contacto.Agregar_cat_area_contacto(area_contacto);
                    if (EsInsertado)
                    {
                        TempData["SuccessMessage"] = "El Ususrio fue insertado correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Cat Area Contacto - Insertar");

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo insertar el Documento correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Cat Area Contacto - Insertar");

                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMesage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Cat Area Contacto - Insertar");

                return View();
            }
        }

        // GET: cat_area_contacto/Edit/5
        public ActionResult Edit(int id)
        {
            var _tipo_contacto = _Cat_area_contacto.Obtener_cat_area_contacto_por_id(id).FirstOrDefault();

            if (_tipo_contacto == null)
            {
                TempData["InfoMessage"] = "Usuario no encontrado con el id " + id.ToString();
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Area Contacto - Actualizar");

                return RedirectToAction("Index");
            }
            return View(_tipo_contacto);
        }

        // POST: cat_area_contacto/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(cat_area_contacto area_contacto)
        {
            try
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        bool EsActualizado = _Cat_area_contacto.Actualizar_cat_area_contacto(area_contacto);
                        if (EsActualizado)
                        {
                            TempData["SuccessMessage"] = "El usuario fue catualizado correctamente...!";
                            DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Cat Area Contacto - Actualizar");

                        }
                        else
                        {
                            TempData["InfoMessage"] = "El usuario no fue catualizado correctamente.";
                            DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Area Contacto - Actualizar");

                        }
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    TempData["ErrorMessage"] = ex.Message;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Cat Area Contacto - Actualizar");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: cat_area_contacto/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {

                var _tipo_contacto = _Cat_area_contacto.Obtener_cat_area_contacto_por_id(id).FirstOrDefault();
                if (_tipo_contacto== null)
                {
                    TempData["InfoMessage"] = "No se encontro el tipo de Sub proceso con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Adm Usuarios - Eliminar");
                    return RedirectToAction("Index");
                }
                return View(_tipo_contacto);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Adm Usuarios - Eliminar");
                return View();
            }
        }

        // POST: cat_area_contacto/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {


                string result = _Cat_area_contacto.Eliminar_cat_area_contacto(id);

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
