using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class DAL_obtener_estados
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();

        public List<cat_estados> Obtener_Estados()
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_estado";
            cmd.CommandType = CommandType.StoredProcedure;



            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_estados> _obtener_cat_estados = new List<cat_estados>();
                while (dr.Read())
                {
                    cat_estados _cat_estados = new cat_estados()
                    {
                        Id_Estado = Convert.ToInt32(dr["Id_Estado"]),
                        Descripcion = dr["Descripcion"].ToString(),
                    };
                    _obtener_cat_estados.Add(_cat_estados);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_estados;

            }
        }

    }
}