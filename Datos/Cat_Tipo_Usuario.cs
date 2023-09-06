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
        private readonly string _conexion;

        public Cat_Tipo_Usuario(IConfiguration configuration)
        {
            _conexion = configuration.GetConnectionString("ConexionDB");
        }
        public IEnumerable<cat_tipo_usuario> Obtener_Tipo_Usuario()
        {
            using (SqlConnection conexion = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand("obtener_cat_tipo_usuario", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

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
                        return _obtener_cat_tipo_usuario;
                    }
                }
            }
            
        }

        public void Actualizar_Tipo_Usuario(cat_tipo_usuario _cat_tipo_usuario)
        {
            using (SqlConnection conexion = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand("actualizar_cat_tipo_usuario", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_tipo_usuario", _cat_tipo_usuario.Id_tipo_usuario);
                    cmd.Parameters.AddWithValue("@Descripcion", _cat_tipo_usuario.Descripcion);
                    cmd.Parameters.AddWithValue("@Abreviatura", _cat_tipo_usuario.Abreviatura);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Agregar_Tipo_Usuario(cat_tipo_usuario _cat_tipo_usuario)
        {
            using (SqlConnection conexion = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand("agregar_cat_tipo_usuario", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    cmd.Parameters.AddWithValue("@Descripcion", _cat_tipo_usuario.Descripcion);
                    cmd.Parameters.AddWithValue("@Abreviatura", _cat_tipo_usuario.Abreviatura);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar_Tipo_Usuario(int id)
        {
            using (SqlConnection conexion = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand("eliminar_cat_tipo_usuario", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_tipo_usuario", id);
                   
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}