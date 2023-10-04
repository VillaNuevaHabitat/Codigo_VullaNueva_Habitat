using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Datos;

namespace VillaNueva_Habitat.Controllers
{
    public class Obtener_regimen_FiscalController : Controller
    {
        // GET: Obtener_regimen_Fiscal
        DAL_obtener_regimen_fiscal _cat_regimen_fiscal = new DAL_obtener_regimen_fiscal();
        // GET: cat_adm_clientes

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var lst_regimen_fiscal = _cat_regimen_fiscal.Obtener_regimen_fiscal();
                if (lst_regimen_fiscal.Count == 0)
                {
                    TempData["InfoMessage"] = "No existe información en la base de datos";
                    DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), TempData["InfoMessage"].ToString(), "Cat Regimen Fiscal - List");

                }
                return View(lst_regimen_fiscal);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                DBUsuario.Insert_Usuario_Log(Convert.ToInt32(Session["IdUsuario"]), Session["_usuario"].ToString(), Session["correo"].ToString(), Convert.ToInt32(Session["RolId"]), "Error : " + ex.Message, "Cat Regimen Fiscal - List");
                return View();
            }

            // GET: Obtener_regimen_Fiscal/Details/5

        }
    }
}
