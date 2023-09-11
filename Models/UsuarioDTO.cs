using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VillaNueva_Habitat.Models
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string ConfirmarClave { get; set; }
        public bool Restablecer { get; set; }
        public bool Confirmado { get; set; }
        public string Token { get; set; }
        public int RolId { get; set; }
        public bool Estatus { get; set; }
    }
}