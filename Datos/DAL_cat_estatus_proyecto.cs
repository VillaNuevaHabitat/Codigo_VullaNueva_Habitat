using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class DAL_cat_estatus_proyecto
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();

        public List<cat_estatus_proyecto> Obtener_Estatus_Proyecto()
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_cat_estatus_proyecto";
            cmd.CommandType = CommandType.StoredProcedure;



            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_estatus_proyecto> _obtener_cat_estatus_proyecto = new List<cat_estatus_proyecto>();
                while (dr.Read())
                {
                    cat_estatus_proyecto _cat_estatus_proyecto = new cat_estatus_proyecto()
                    {
                        id = Convert.ToInt32(dr["id"]),
                        estatus = dr["estatus"].ToString(),

                    };
                    _obtener_cat_estatus_proyecto.Add(_cat_estatus_proyecto);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_estatus_proyecto;

            }
        }

            public List<cat_estatus_proyecto> usp_Obtener_Estatus_Proyecto_por_id(int id)
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_obtener_cat_estatus_proyecto_por_id";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);


                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    List<cat_estatus_proyecto> _obtener_cat_estatus_proyecto = new List<cat_estatus_proyecto>();
                    while (dr.Read())
                    {
                    cat_estatus_proyecto _cat_estatus_proyecto = new cat_estatus_proyecto()
                        {
                            id = Convert.ToInt32(dr["id"]),
                            estatus = dr["estatus"].ToString(),
                          
                        };
                    _obtener_cat_estatus_proyecto.Add(_cat_estatus_proyecto);

                    }
                    cmd.Connection = cn.CerrarConexion();
                    return _obtener_cat_estatus_proyecto;
                }

            }
        public bool Actualizar_Estatus_Proyecto(cat_estatus_proyecto _cat_estatus_proyecto)
        {
            int i = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_actualiza_cat_estatus_Proyecto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", _cat_estatus_proyecto.id);
            cmd.Parameters.AddWithValue("@estatus", _cat_estatus_proyecto.estatus);
           

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

        public bool Agregar_Estatus_Proyecto(cat_estatus_proyecto _cat_estatus_proyecto)
        {
            int respuesta = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_inserta_cat_estatus_proyecto";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@estatus", _cat_estatus_proyecto.estatus);
         
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

        public string Eliminar_estatua_proyecto(int id)
        {
            string respuesta = string.Empty;
            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_eliminar_cat_estatus_proyecto";
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