using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class DAL_cat_area_contacto
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();

        public List<cat_area_contacto> Obtener_cat_area_contacto()
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_cat_area_contacto";
            cmd.CommandType = CommandType.StoredProcedure;



            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_area_contacto> _obtener_cat_area_contacto = new List<cat_area_contacto>();
                while (dr.Read())
                {
                    cat_area_contacto _cat_area_contacto = new cat_area_contacto()
                    {
                        id = Convert.ToInt32(dr["id"]),
                        descripcion = dr["Descripcion"].ToString()
                       
                    };
                    _obtener_cat_area_contacto.Add(_cat_area_contacto);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_area_contacto;

            }

        }

        public List<cat_area_contacto> Obtener_cat_area_contacto_por_id(int id)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_cat_area_contacto_por_id";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);


            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_area_contacto> _obtener_cat_area_contacto = new List<cat_area_contacto>();
                while (dr.Read())
                {
                    cat_area_contacto _cat_area_contacto = new cat_area_contacto()
                    {
                        id = Convert.ToInt32(dr["id"]),
                        descripcion = dr["descripcion"].ToString(),
                       
                    };
                    _obtener_cat_area_contacto.Add(_cat_area_contacto);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_area_contacto;
            }

        }

        public bool Actualizar_cat_area_contacto(cat_area_contacto _cat_area_contacto)
        {
            int i = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_actualiza_cat_area_contacto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", _cat_area_contacto.id);
            cmd.Parameters.AddWithValue("@descripcion", _cat_area_contacto.descripcion);
            i = cmd.ExecuteNonQuery();
            cmd.Connection = cn.CerrarConexion();
            //}
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Agregar_cat_area_contacto(cat_area_contacto _cat_area_contacto)
        {
            int respuesta = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_inserta_cat_area_contacto";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@descripcion", _cat_area_contacto.descripcion);
           

            respuesta = cmd.ExecuteNonQuery();
            cmd.Connection = cn.CerrarConexion();
            if (respuesta > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public string Eliminar_cat_area_contacto(int id)
        {
            string respuesta = string.Empty;
            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_eliminar_cat_area_contacto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.Add("@OutputMessage", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                respuesta = cmd.Parameters["@OutputMessage"].Value.ToString();
                cmd.Connection = cn.CerrarConexion();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return respuesta;
        }
    }
}