using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VillaNueva_Habitat.Models
{
    public class cat_provedor_contacto
    {
		public int Id_contacto { get; set; }
		public string Nombre { get; set; }
		public string Email { get; set; }
		public string Telefono { get; set; }
		public string Comentario { get; set; }
		public string Area_Facturacion { get; set; }

	}
}