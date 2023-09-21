using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class Cat_Tipo_Usuario
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();


        public List<cat_tipo_usuario> usp_Obtener_Tipo_Usuario()
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

        public List<cat_tipo_usuario> usp_Obtener_Tipo_Usuario_por_id(int Id_tipo_usuario)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_get_tipo_usuario_por_id";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_tipo_usuario", Id_tipo_usuario);
            

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
        public bool usp_Actualizar_Tipo_Usuario(cat_tipo_usuario _cat_tipo_usuario)
        {
            int i = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "Usp_actualizar_cat_tipo_usuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_tipo_usuario", _cat_tipo_usuario.Id_tipo_usuario);
            cmd.Parameters.AddWithValue("@Descripcion", _cat_tipo_usuario.Descripcion);
            cmd.Parameters.AddWithValue("@Abreviatura", _cat_tipo_usuario.Abreviatura);
               
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

        public bool usp_Agregar_Tipo_Usuario(cat_tipo_usuario _cat_tipo_usuario)
        {
            int respuesta = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_agregar_cat_tipo_usuario";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Descripcion", _cat_tipo_usuario.Descripcion);
            cmd.Parameters.AddWithValue("@Abreviatura", _cat_tipo_usuario.Abreviatura);
          
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

        public string usp_Eliminar_Tipo_Usuario(int id)
        {
            string respuesta = string.Empty;
            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_eliminar_cat_tipo_usuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_tipo_usuario", id);
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