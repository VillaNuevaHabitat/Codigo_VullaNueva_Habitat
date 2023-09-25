using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VillaNueva_Habitat.Models
{
    public class cat_admin_usuarios
    {
        [DisplayName("Id")]
        public int id_usuario { get; set; }
        [Required]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [Required]
        [DisplayName("Apellido Paterno")]
        public string Apellido_PAterno { get; set; }
        [Required]
        [DisplayName("Apellido Materno")]
        public string Apellido_MAterno { get; set; }
        [Required]
        [DisplayName("Estatus")]
        public string Estatus_Usuario { get; set; }
        [Required]
        [DisplayName("Correo")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Celular")]
        public string Celular { get; set; }
        [Required]
        [DisplayName("Contraseña")]
        public string Contrasenia { get; set; }
        [Required]
        [DisplayName("Tipo Usuario")]
        public string Tipo_Usuario { get; set; }
        [Required]
        [DisplayName("Fecha")]
        public string Fecha_Alta { get; set; }
        [Required]
        [DisplayName("Registro")]
        public string Usuario_Registra { get; set; }
    }
}