﻿using System;
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
        // GET: Tipo_Usuario
        [HttpGet]
        public ActionResult Index()
        {
            List<cat_tipo_usuario> lst_tipo_usuario = new List<cat_tipo_usuario>();

            Cat_Tipo_Usuario _tipo_usuario = new Cat_Tipo_Usuario();

            try
            {
                lst_tipo_usuario = _tipo_usuario.Obtener_Tipo_Usuario();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }

            return View(lst_tipo_usuario);
        }

        public ActionResult InsertaProvedor()
        {
            return View();
        }

        public ActionResult InsertaProvedores(Provedores provedores)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DbProvedores _provedores = new DbProvedores();
                    if (_provedores.Insertar_Provedores(provedores))
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