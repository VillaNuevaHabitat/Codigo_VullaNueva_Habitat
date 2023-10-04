using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Datos;

namespace VillaNueva_Habitat.Controllers
{
    public class Obtener_EstadosController : Controller
    {
        DAL_obtener_estados _cat_paises = new DAL_obtener_estados();
        // GET: cat_adm_clientes

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var lst_estados = _cat_paises.Obtener_Estados();
                if (lst_estados.Count == 0)
                {
                    TempData["InfoMessage"] = "No existe información en la base de datos";
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Estados - List");

                }
                return View(lst_estados);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Cat Estados - List");
                return View();
            }

        }
    }
}
