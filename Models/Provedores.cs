using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VillaNueva_Habitat.Models
{
    public class Provedores
    {
		[Required(ErrorMessage = "Introduzca el Código de Provedor")]
		[StringLength(7, ErrorMessage = "El código de Provedor debe ser menor o igual a 7 caracteres.")]
		public string Codigo_proveedor { get; set; }
		[Required(ErrorMessage = "Introduzca la Raón Social")]
		[StringLength(15, ErrorMessage = "La razón social debe ser menor o igual a 15 caracteres.")]
		public string Razon_social { get; set; }
		[Required(ErrorMessage = "Introduzca el RFC")]
		[StringLength(22, ErrorMessage = "El RFC debe ser menor o igual a 22 caracteres.")]
		public string RFC { get; set; }
		[Required(ErrorMessage = "Introduzca el Teléfono")]
		[StringLength(20, ErrorMessage = "El Teléfono debe ser menor o igual a 20 caracteres.")]
		public string Telefono { get; set; }
		[Required(ErrorMessage = "Introduzca el nombre de la calle")]
		[StringLength(30, ErrorMessage = "El nombre de la calle debe ser menor o igual a 30 caracteres.")]
		public string Calle { get; set; }
		[Required(ErrorMessage = "Introduzca el Número Exterior")]
		[StringLength(3, ErrorMessage = "El Número Exterior debe ser menor o igual a 3 caracteres.")]
		public string Numero_Exterior { get; set; }
		[Required(ErrorMessage = "Introduzca el nombre de la colonia")]
		[StringLength(30, ErrorMessage = "El nombre de la colonia debe ser menor o igual a 30 caracteres.")]
		public string Colonia { get; set; }
		[Required(ErrorMessage = "Introduzca el nombre de la entidad")]
		[StringLength(50, ErrorMessage = "El nombre de la entidad debe ser menor o igual a 50 caracteres.")]
		public string Entidad { get; set; }

		public estatus Esattus { get; set; }

		public enum estatus
		{
			Activo,
			Inactivo
		}

	}
}