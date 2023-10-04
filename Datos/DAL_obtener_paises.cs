using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class DAL_obtener_paises
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();

        public List<cat_paises> Obtener_Paises()
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_Pais";
            cmd.CommandType = CommandType.StoredProcedure;



            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_paises> _obtener_cat_paises = new List<cat_paises>();
                while (dr.Read())
                {
                    cat_paises _cat_paises = new cat_paises()
                    {
                        Id_Pais = Convert.ToInt32(dr["Id_Pais"]),
                        Descripcion = dr["Descripcion"].ToString(),
                    };
                    _obtener_cat_paises.Add(_cat_paises);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_paises;

            }
        }
    }
}