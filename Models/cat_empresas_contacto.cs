using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VillaNueva_Habitat.Models
{
    public class cat_empresas_contacto
    {
		public int Id_Contacto { get; set; }
		public string Numero_Telefonico_1 { get; set; }
		public string Numero_Telefonico_2 { get; set; }
		public string WebSite { get; set; }
		public byte[] img { get; set; }
		public bool Estatus { get; set; }
		public string Usuario_Creo { get; set; }

	}
}