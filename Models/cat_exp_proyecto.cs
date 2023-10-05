using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VillaNueva_Habitat.Models
{
    public class cat_exp_proyecto
    {
		public int Id_exp { get; set; }
		public int Id_contacto { get; set; }
		public string Nombre { get; set; }
		public string Nombre_Proyecto { get; set; }
		public string Descripcion { get; set; }
		public string Fecha_inicial { get; set; }
		public string Fecha_Final { get; set; }
		public string Responsable { get; set; }
		public string Supervisor { get; set; }
		public string Residente { get; set; }
		public string Estatus { get; set; }
		public string Comentarios { get; set; }
		public string Usuario_Creo { get; set; }
	}
}