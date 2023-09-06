using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VillaNueva_Habitat.Permisos;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [PermisosRolAtribute(Models.Roles.Administrador)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SinPermiso()
        {
            ViewBag.Message = "Usted no cuenta con permisos para ver esta pagina.";

            return View();
        }
        public ActionResult Salir()
        {
            FormsAuthentication.SignOut();
            Session["_usuario"] = null;
            return RedirectToAction("Login", "Inicio");
        }
        public ActionResult Tipo_Usuario()
        {
            ViewBag.Message = "Tipo de Usuario";

            return View();
        }
    }
}