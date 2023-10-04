using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class DAL_obtener_regimen_fiscal
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();

        public List<cat_regimen_fiscal> Obtener_regimen_fiscal()
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "cat_regimen_fiscal";
            cmd.CommandType = CommandType.StoredProcedure;



            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_regimen_fiscal> _obtener_cat_regimen_fiscal = new List<cat_regimen_fiscal>();
                while (dr.Read())
                {
                    cat_regimen_fiscal _cat_regimen_fiscal = new cat_regimen_fiscal()
                    {
                        c_RegimenFiscal = Convert.ToInt32(dr["c_RegimenFiscal"]),
                        Descripcion = dr["Descripcion"].ToString(),
                    };
                    _obtener_cat_regimen_fiscal.Add(_cat_regimen_fiscal);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_regimen_fiscal;

            }
        }
    }
}