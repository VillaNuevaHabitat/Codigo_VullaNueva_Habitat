using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Datos;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Controllers
{
    public class Cat_Tipo_UsuarioController : Controller
    {
        private readonly Cat_Tipo_Usuario _Cat_Tipo_Usuario;

        public Cat_Tipo_UsuarioController(Cat_Tipo_Usuario Tipo_Usuario)
        {
            _Cat_Tipo_Usuario = Tipo_Usuario;
        }
        // GET: Cat_Tipo_Usuario

        public ActionResult Index()
        {
            var tipo_usuario = _Cat_Tipo_Usuario.Obtener_Tipo_Usuario();
            var datos = tipo_usuario.Select(p => new cat_tipo_usuario
            {
                Id_tipo_usuario = p.Id_tipo_usuario,
                Descripcion = p.Descripcion,
                Abreviatura = p.Abreviatura
            }).ToList();
            return View(datos);
        }
        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Crear(cat_tipo_usuario _cat_tipo_usuario)
        {
            if(ModelState.IsValid)
            {
                var tipo_usuario = new cat_tipo_usuario
                {
                    Descripcion = _cat_tipo_usuario.Descripcion,
                    Abreviatura = _cat_tipo_usuario.Abreviatura
                };

                _Cat_Tipo_Usuario.Agregar_Tipo_Usuario(tipo_usuario);

                RedirectToAction("Index");
            }
            return View(_cat_tipo_usuario);
        }

        public ActionResult Editar(int id)
        {
            var tipo_usuario = _Cat_Tipo_Usuario.Obtener_Tipo_Usuario().FirstOrDefault(p => p.Id_tipo_usuario == id);
           
                var _tipo_usuario = new cat_tipo_usuario
                {
                    Id_tipo_usuario = tipo_usuario.Id_tipo_usuario,
                    Descripcion     = tipo_usuario.Descripcion,
                    Abreviatura     = tipo_usuario.Abreviatura
                };
                
            
            return View(_tipo_usuario);
        }

        [HttpPost]
        public ActionResult EDitar(cat_tipo_usuario _cat_tipo_usuario)
        {
            if (ModelState.IsValid)
            {
                var tipo_usuario = new cat_tipo_usuario
                {
                    Id_tipo_usuario = _cat_tipo_usuario.Id_tipo_usuario,
                    Descripcion = _cat_tipo_usuario.Descripcion,
                    Abreviatura = _cat_tipo_usuario.Abreviatura
                };

                _Cat_Tipo_Usuario.Agregar_Tipo_Usuario(tipo_usuario);

                RedirectToAction("Index");
            }
            return View(_cat_tipo_usuario);
        }

        public ActionResult Eliminar(int id)
        {
            var tipo_usuario = _Cat_Tipo_Usuario.Obtener_Tipo_Usuario().FirstOrDefault(p => p.Id_tipo_usuario == id);

            var _tipo_usuario = new cat_tipo_usuario
            {
                Id_tipo_usuario = tipo_usuario.Id_tipo_usuario,
                Descripcion = tipo_usuario.Descripcion,
                Abreviatura = tipo_usuario.Abreviatura
            };


            return View(_tipo_usuario);
        }

        [HttpPost, ActionName("Eliminar")]

        public ActionResult EliminarConfirmar(int id)
        {
            _Cat_Tipo_Usuario.Eliminar_Tipo_Usuario(id);
            return RedirectToAction("Index");
        }
    }
}