using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VillaNueva_Habitat.Models
{
    public class Cat_Tipo_Proceso
    {
      
        [DisplayName("Id Proceso")]
        public int IdProceso { get; set; }
        [Required]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [Required]
        [DisplayName("Clave")]
        public string Clave { get; set; }
    }
}