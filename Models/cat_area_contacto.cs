using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VillaNueva_Habitat.Models
{
    public class cat_area_contacto
    {
        public int id { get; set; }
        [Required]
        [DisplayName("Descripción del Area de Contacto")]
        public string descripcion {get;set;}
    }
}