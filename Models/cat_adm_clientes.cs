using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VillaNueva_Habitat.Models
{
    public class cat_adm_clientes
    {
		public int id_cliente { get; set; }
		[Required]
		[DisplayName("Introduzca el RFC")]
		public string rfc_cliente { get; set; }
		[Required]
		[DisplayName("Introduzca el Regimen Fiscal")]
		public string cve_regimen_fiscal { get; set; }
		[Required]
		[DisplayName("Introduzca la Razón Social")]
		public string razon_social { get; set; }
		[Required]
		[DisplayName("Seleccione el Estado")]
		public string Estado { get; set; }
		[Required]
		[DisplayName("Seleccione el Municipio")]
		public string Municipio { get; set; }
		[Required]
		[DisplayName("Introduzca la Colonia")]
		public string Colonia { get; set; }
		[Required]
		[DisplayName("Introduzca la Calle")]
		public string Calle { get; set; }
		[Required]
		[DisplayName("Introduzca el Código Postal")]
		public string Codigo_Postal { get; set; }
		[Required]
		[DisplayName("Seleccione la Forma de Pago")]
		public string Forma_Pago { get; set; }
		[Required]
		[DisplayName("Seleccione el CFDI")]
		public string CFDI { get; set; }
		[Required]
		[DisplayName("Introduzca las Instrucciones")]
		public string Instrucciones { get; set; }
		[Required]
		[DisplayName("Seleccione los dias de Recepción de Factura")]
		public string Dias_Recepcion_Facturas { get; set; }
		[Required]
		[DisplayName("Seleccione los dias de Recepción de Factura")]
		public string Dias_Credito { get; set; }

	}
}