using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VillaNueva_Habitat.Models
{
    public class Cat_Tipo_Documento
    {
       
        public int Id_Tipo_Documento { get; set; }
        [Required]
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }
    }
}