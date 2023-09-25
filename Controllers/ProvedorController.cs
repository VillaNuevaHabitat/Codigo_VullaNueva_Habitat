using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Models;
using VillaNueva_Habitat.Datos;

namespace VillaNueva_Habitat.Controllers
{
    public class ProvedorController : Controller
    {
       
        // GET: Provedor
        [HttpGet]
        public ActionResult Index()
        {
          
            List<Provedores> provedores = new List<Provedores>();
            DbProvedores _provedores = new DbProvedores();
       
            try
            {
               // provedores = _provedores.GetAll();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }

            return View(provedores);
        }

        public ActionResult InsertaProvedor()
        {
            return View();
        }

        public ActionResult InsertaProvedores(Provedores provedores)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    DbProvedores _provedores = new DbProvedores();
                    if(_provedores.Insertar_Provedores(provedores))
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}