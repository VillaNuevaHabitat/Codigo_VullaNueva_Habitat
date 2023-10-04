using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Datos;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Controllers
{
    public class cat_adm_clientesController : Controller
    {
        DAL_cat_adm_clientes _cat_adm_clientes = new DAL_cat_adm_clientes();
        // GET: cat_adm_clientes

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var lst_adm_usuarios = _cat_adm_clientes.Obtener_cat_adm_clientes();
                if (lst_adm_usuarios.Count == 0)
                {
                    TempData["InfoMessage"] = "No existe información en la base de datos";
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Adm Clientes - List");

                }
                return View(lst_adm_usuarios);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Cat Adm Clientes - List");
                return View();
            }
        }

        
        // GET: cat_adm_clientes/Details/5
        public ActionResult Details(int id)
        {
            var tipo_usuario = _cat_adm_clientes.Obtener_Adm_Clientes_por_id(id).FirstOrDefault();
            try
            {
                if (tipo_usuario == null)
                {
                    TempData["InfoMessage"] = "Cliente no encontrado con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Adm Clientes - Actualizar");

                    return RedirectToAction("Index");
                }
                return View(tipo_usuario);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Cat Adm Clientes - Actualizar");
                return View();
            }
        }

        // GET: cat_adm_clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cat_adm_clientes/Create
        [HttpPost]
        public ActionResult Create(cat_adm_clientes adm_clientes)
        {
            bool EsInsertado = false;
            try
            {
                if (ModelState.IsValid)
                {
                    EsInsertado = _cat_adm_clientes.Agregar_Adm_Clientes(adm_clientes);
                    if (EsInsertado)
                    {
                        TempData["SuccessMessage"] = "El Cliente fue insertado correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Cat Adm Clientes - Insertar");

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No se pudo insertar el Documento correctamente";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Cat Adm Clientes - Insertar");

                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMesage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Cat Adm Clientes - Insertar");

                return View();
            }
        }

        // GET: cat_adm_clientes/Edit/5
        public ActionResult Edit(int id)
        {
            var _tipo_proceso = _cat_adm_clientes.Obtener_Adm_Clientes_por_id(id).FirstOrDefault();

            if (_tipo_proceso == null)
            {
                TempData["InfoMessage"] = "Cliente no encontrado con el id " + id.ToString();
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Adm Clientes - Actualizar");

                return RedirectToAction("Index");
            }
            return View(_tipo_proceso);
        }

        // POST: cat_adm_clientes/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(cat_adm_clientes adm_clientes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool EsActualizado = _cat_adm_clientes.Actualizar_Adm_Clientes(adm_clientes);
                    if (EsActualizado)
                    {
                        TempData["SuccessMessage"] = "El usuario fue catualizado correctamente...!";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Cat Adm Clientes - Actualizar");

                    }
                    else
                    {
                        TempData["InfoMessage"] = "El usuario no fue catualizado correctamente.";
                        DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Adm Clientes - Actualizar");

                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Cat Adm Clientes - Catalogos");
                return View();
            }
        }

        // GET: cat_adm_clientes/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {

                var _tipo_usuario = _cat_adm_clientes.Obtener_Adm_Clientes_por_id(id).FirstOrDefault();
                if (_tipo_usuario == null)
                {
                    TempData["InfoMessage"] = "No se encontro el cliente con el id " + id.ToString();
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Adm Clientes - Eliminar");
                    return RedirectToAction("Index");
                }
                return View(_tipo_usuario);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Cat Adm Clientes - Eliminar");
                return View();
            }
        }

        // POST: cat_adm_clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {


                string result = _cat_adm_clientes.Eliminar_Adm_Clientes(id);

                if (result.Contains("eliminado"))
                {
                    TempData["SuccessMessage"] = result;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["SuccessMessage"].ToString(), "Cat Adm Clientes - Eliminar");

                }
                else
                {
                    TempData["ErrorMessage"] = result;
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Cat Adm Clientes - Eliminar");

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["ErrorMessage"].ToString(), "Cat Adm Clientes - Eliminar");
                return View();
            }
        }
    }
}
