using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VillaNueva_Habitat.Models
{
    public class cat_tipo_usuario
    {
       

        public int Id_tipo_usuario {get;set;}
        [Required]
        [DisplayName("Descripción")]
	    public string Descripcion { get; set; }
        [Required]
        [DisplayName("Abreviatura")]
    	public string Abreviatura { get; set; }
    }
}