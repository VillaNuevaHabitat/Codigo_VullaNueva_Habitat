using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class DAL_Cat_Adm_Usuarios
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();


        public List<cat_admin_usuarios> Obtener_Adm_Usuario()
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_cat_adm_usuario";
            cmd.CommandType = CommandType.StoredProcedure;



            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_admin_usuarios> _obtener_cat_adm_usuario = new List<cat_admin_usuarios>();
                while (dr.Read())
                {
                    cat_admin_usuarios _cat_adm_usuario = new cat_admin_usuarios()
                    {
                         id_usuario       = Convert.ToInt32(dr["Id_Usuario"]),
                         Nombre           = dr["Nombre"].ToString(),
                         Apellido_PAterno = dr["Apellido_Paterno"].ToString(),
                         Apellido_MAterno = dr["Apellido_MAterno"].ToString(),
                          Tipo_Usuario = dr["Tipo_Usuario"].ToString(),
                        /*  Estatus_Usuario = dr["Estatus_Usuario"].ToString()
                             Email            = dr["Email"].ToString(),
                             Celular          = dr["Celular"].ToString(),
                             Contrasenia      = dr["Contrasenia"].ToString(),

                             Fecha_Alta       = dr["Fecha_Alta"].ToString(),
                             Usuario_Registra = dr["Usuario_Registra"].ToString()*/
                    };
                    _obtener_cat_adm_usuario.Add(_cat_adm_usuario);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_adm_usuario;

            }
        }

        public List<cat_admin_usuarios> Obtener_Adm_Usuario_por_id(int Id_usuario)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_get_adm_usuario_por_id";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_usuario", Id_usuario);


            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_admin_usuarios> _obtener_cat_adm_usuario = new List<cat_admin_usuarios>();
                while (dr.Read())
                {
                    cat_admin_usuarios _cat_adm_usuario = new cat_admin_usuarios()
                    {
                        id_usuario = Convert.ToInt32(dr["Id_Usuario"]),
                        Nombre = dr["Nombre"].ToString(),
                        Apellido_PAterno = dr["Apellido_Paterno"].ToString(),
                        Apellido_MAterno = dr["Apellido_MAterno"].ToString(),
                        Tipo_Usuario     = dr["Tipo_Usuario"].ToString(),
                        Estatus_Usuario  = dr["Estatus_Usuario"].ToString(),
                        Email            = dr["Email"].ToString(),
                        Celular          = dr["Celular"].ToString(),
                        Contrasenia      = dr["Contrasenia"].ToString(),
                        Usuario_Registra = dr["Usuario_Registra"].ToString()
                    };
                    _obtener_cat_adm_usuario.Add(_cat_adm_usuario);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_adm_usuario;
            }
        }

        public bool Actualizar_Tipo_Usuario(cat_admin_usuarios _cat_adm_usuario)
        {
            int i = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "Usp_actualizar_cat_adm_usuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Usuario", _cat_adm_usuario.id_usuario);
            cmd.Parameters.AddWithValue("@Nombre", _cat_adm_usuario.Nombre);
            cmd.Parameters.AddWithValue("@Apellido_PAterno", _cat_adm_usuario.Apellido_PAterno);
            cmd.Parameters.AddWithValue("@Apellido_Materno", _cat_adm_usuario.Apellido_MAterno);
            cmd.Parameters.AddWithValue("@Tipo_Usuario", _cat_adm_usuario.Tipo_Usuario);
            cmd.Parameters.AddWithValue("@Estatus_Usuario", _cat_adm_usuario.Estatus_Usuario);
            cmd.Parameters.AddWithValue("@Email", _cat_adm_usuario.Email);
            cmd.Parameters.AddWithValue("@Celular", _cat_adm_usuario.Celular);
            cmd.Parameters.AddWithValue("@Contrasenia", _cat_adm_usuario.Contrasenia);
            cmd.Parameters.AddWithValue("@Usuario_Registra", _cat_adm_usuario.Usuario_Registra);

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
        public bool Agregar_Adm_Usuario(cat_admin_usuarios cat_admin_usuarios)
        {
            int respuesta = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_agregar_cat_adm_usuario";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nombre", cat_admin_usuarios.Nombre);
            cmd.Parameters.AddWithValue("@Apellido_PAterno", cat_admin_usuarios.Apellido_PAterno);
            cmd.Parameters.AddWithValue("@Apellido_Materno", cat_admin_usuarios.Apellido_MAterno);
            cmd.Parameters.AddWithValue("@Tipo_Usuario", cat_admin_usuarios.Tipo_Usuario);
            cmd.Parameters.AddWithValue("@Estatus_Usuario", cat_admin_usuarios.Estatus_Usuario);
            cmd.Parameters.AddWithValue("@Email", cat_admin_usuarios.Email);
            cmd.Parameters.AddWithValue("@Celular", cat_admin_usuarios.Celular);
            cmd.Parameters.AddWithValue("@Contrasenia", cat_admin_usuarios.Contrasenia);
            cmd.Parameters.AddWithValue("@Usuario_Registra", cat_admin_usuarios.Usuario_Registra);


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

        public string Eliminar_Tipo_Usuario(int id)
        {
            string respuesta = string.Empty;
            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_eliminar_cat_adm_usuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_usuario", id);
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