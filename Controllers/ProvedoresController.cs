using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Datos;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Controllers
{
    public class ProvedoresController : Controller
    {
        // GET: Provedores
        [HttpGet]
        public ActionResult InsertProvedor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertProvedor(Provedores objProvedor)
        {

            //objProvedor.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            if (ModelState.IsValid) //checking model is valid or not    
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertData(objProvedor);
                //ViewData["result"] = result;    
                TempData["result1"] = result;
                ModelState.Clear(); //clearing model    
                                    //return View();    
                return RedirectToAction("ShowAllCustomerDetails");
            }

            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult ShowAllProvedorDetails()
        {
            Provedores objProvedor = new Provedores();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
            //objProvedor.ShowallProvedor = objDB.Selectalldata();
            return View(objProvedor);
        }
        [HttpGet]
        public ActionResult Details(string ID)
        {
            //Customer objCustomer = new Customer();    
            //DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
            //objCustomer.ShowallCustomer = objDB.Selectalldata();    
            //return View(objCustomer);    
            Provedores objProvedor = new Provedores();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
            return View(objDB.SelectDatabyID(ID));
        }
        [HttpGet]
        public ActionResult Edit(string ID)
        {
            Provedores objProvedor = new Provedores();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
            return View(objDB.SelectDatabyID(ID));
        }

        [HttpPost]
        public ActionResult Edit(Provedores objProvedor)
        {
            //objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            if (ModelState.IsValid) //checking model is valid or not    
            {
                DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
                string result = objDB.UpdateData(objProvedor);
                //ViewData["result"] = result;    
                TempData["result2"] = result;
                ModelState.Clear(); //clearing model    
                //return View();    
                return RedirectToAction("ShowAllCustomerDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(String ID)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            int result = objDB.DeleteData(ID);
            TempData["result3"] = result;
            ModelState.Clear(); //clearing model    
                                //return View();    
            return RedirectToAction("ShowAllCustomerDetails");
        }
    }
}