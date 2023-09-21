using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class DAL_Admin_Empresas
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();


        public List<Cat_Administrador_Empresa> usp_Obtener_Empresas()
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_cat_tipo_usuario";
            cmd.CommandType = CommandType.StoredProcedure;



            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_tipo_usuario> _obtener_cat_tipo_usuario = new List<cat_tipo_usuario>();
                while (dr.Read())
                {
                    cat_tipo_usuario _cat_tipo_usuario = new cat_tipo_usuario()
                    {
                        Id_tipo_usuario = Convert.ToInt32(dr["Id_tipo_usuario"]),
                        Descripcion = dr["Descripcion"].ToString(),
                        Abreviatura = dr["Abreviatura"].ToString()
                    };
                    _obtener_cat_tipo_usuario.Add(_cat_tipo_usuario);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_tipo_usuario;

            }



        }
    }
}