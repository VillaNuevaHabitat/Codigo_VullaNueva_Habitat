using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VillaNueva_Habitat.Models
{
    public class cat_estatus_proyecto
    {
        public int id { get; set; }
        [Required]
        [DisplayName("Estatus del Proyecto")]
        public string estatus { get; set; }
    }
}