using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VillaNueva_Habitat.Models;
using VillaNueva_Habitat.Permisos;

namespace VillaNueva_Habitat.Permisos
{
    public class PermisosRolAtribute:ActionFilterAttribute
    {
        private Roles IdRol;

        public PermisosRolAtribute(Roles _IdRol)
        {
            IdRol = _IdRol;
        }
            public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(HttpContext.Current.Session["_usuario"] !=null)
            {
                UsuarioDTO usuario_ = HttpContext.Current.Session["_usuario"] as UsuarioDTO;

                ////if (usuario_.RolId != this.IdRol)
                ////{
                ////    filterContext.Result = new RedirectResult("~/Home/SinPermiso");
                    
                ////}
            }

            base.OnActionExecuting(filterContext);
        }
    }
}