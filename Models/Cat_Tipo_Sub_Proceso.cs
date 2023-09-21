using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VillaNueva_Habitat.Models
{
    public class Cat_Tipo_Sub_Proceso_Sys
    {
        public int IdSubProceso { get; set; }
        [Required]
        [DisplayName("Nombre")]
        public string  Nombre { get; set; }
        [Required]
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }
        [Required]
        [DisplayName("Clave")]
        public string Clave { get; set; }
    }
}