using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VillaNueva_Habitat.Models
{
    public class Cat_Administrador_Empresa
    {
        public int Id_Empresa { get; set; }
        public string RFC { get; set; }
        public string Razon_Social { get; set; }
        public string Calle { get; set; }
        public string Num_Exterior { get; set; }
        public string Num_Interior { get; set; }
        public string Colonia { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public int Codigo_Postal { get; set; }
        public string Regimen_Fiscal { get; set; }
        public bool Estatus { get; set; }
        public string Telefono_1 { get; set; }
        public string Telefono_2 { get; set; }
        public string Correo { get; set; }
        public string WebSite { get; set; }
        public string Logotipo { get; set; }
    }
}