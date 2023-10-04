using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Datos;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Controllers
{
    public class Cat_Adm_ProvedoresController : Controller
    {
        DAL_cat_adm_provedor _Cat_adm_provedor = new DAL_cat_adm_provedor();
        // GET: Cat_Adm_Provedores
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Provedores()
        {
            cat_adm_provedores provedor = new cat_adm_provedores();
            provedor.rfc_provedor = "JOLG201025KU4";
            provedor.regimen_fiscal = "601 General de Ley Personas Morales";
            provedor.razon_social = "RAZON SOCIAL";
            provedor.Estado = "1 AGUAS CALIENTES";
            provedor.Municipio = "1 AGUAS CALIENTES";
            provedor.Colonia = "SAN PEDRO";
            provedor.Calle = "EL ARENAL";
            provedor.Codigo_Postal = "1234";
            provedor.Forma_Pago = "Efectivo";
            provedor.CFDI = "G01 Adquisición de mercancías.";
            provedor.Instrucciones = "INSTRUCCIONES";
            provedor.Dias_Recepcion_Facturas = "28/09/2023";
            provedor.Dias_Credito = "28/09/2023";
            provedor.Estatus = true;
            provedor.Usuario_Creo = "Admin";


            return View();
        }

        public ActionResult SelectElements(string Pais)
        {
            return View("Provedores");
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(cat_adm_provedores _cat_adm_provedores)
        {
            bool EsInsertado = false;
            EsInsertado = _Cat_adm_provedor.Agregar_Adm_Clientes(_cat_adm_provedores);
            return View();
        }
    }
}