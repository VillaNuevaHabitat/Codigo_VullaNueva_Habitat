using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using VillaNueva_Habitat.Datos;

namespace VillaNueva_Habitat.Datos
{
    public class DBUsuario
    {
        

        public static bool registrar(UsuarioDTO usuario)
        {
            CDConexion cn = new CDConexion();
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;

               try
               {
                   cmd.Connection = cn.AbrirConexion();
                   cmd.CommandText = "usp_insertar_usuarios";
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@nombre", usuario.nombre);
                   cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                   cmd.Parameters.AddWithValue("@clave", usuario.Clave);
                   cmd.Parameters.AddWithValue("@Confirmarclave", usuario.ConfirmarClave);
                   cmd.Parameters.AddWithValue("@restablecer", usuario.Restablecer);
                   cmd.Parameters.AddWithValue("@confirmado", usuario.Confirmado);
                   cmd.Parameters.AddWithValue("@token", usuario.Token);
                   cmd.Parameters.AddWithValue("@IdRol", usuario.RolId);
                   cmd.Parameters.AddWithValue("@Estatus", 1);
                   int filasAfectadas = cmd.ExecuteNonQuery();
                   if (filasAfectadas > 0) respuesta = true;
                   cmd.Connection = cn.CerrarConexion();
                   return respuesta;
               }

               catch
               {
                   throw;
               }
         
        }

        public static UsuarioDTO validar(string correo,string clave)
        {
            UsuarioDTO usuario = null;
            CDConexion cn = new CDConexion();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_seleccionar_usuarios";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@clave", clave);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                        if(dr.Read())
                        {
                            usuario = new UsuarioDTO()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                nombre = dr["nombre"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["clave"].ToString(),
                                ConfirmarClave = dr["ConfirmarClave"].ToString(),
                                RolId = Convert.ToInt32(dr["IdRol"])
                                //Restablecer = (bool)dr["restablecer"],
                                //Confirmado = (bool)dr["confirmado"]
                            };
                        }
                    
                }
                cn.CerrarConexion();
            }

            catch(Exception ex)
            {
                ex.Message.ToString();
            }
            return usuario;
        }

        public static UsuarioDTO obtener(string correo)
        {
            UsuarioDTO usuario = null;
            CDConexion cn = new CDConexion();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_obtener_usuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo", correo);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        usuario = new UsuarioDTO()
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString()),
                            nombre = dr["nombre"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Clave = dr["Clave"].ToString(),
                            Restablecer = (bool)dr["Restablecer"],
                            Confirmado = (bool)dr["confirmado"],
                            Token = dr["Token"].ToString(),
                            RolId = Convert.ToInt32(dr["IdRol"]),
                            Estatus = (bool)dr["Estatus"]
                        };
                    }
                }
                cmd.Connection = cn.CerrarConexion();
            }

            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return usuario;
        }

        public static bool RestablecerActualizar(bool Restablecer,string Clave, string Token)
        {
            CDConexion cn = new CDConexion();
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;

            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_RestablecerActualizar_usuarios";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@restablecer", Restablecer);
                cmd.Parameters.AddWithValue("@Clave", Clave);
                cmd.Parameters.AddWithValue("@token", Token);
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0) respuesta = true;
                cmd.Connection = cn.CerrarConexion();
                return respuesta;
            }

            catch
            {
                throw;
            }
        }

        public static bool Confirmar(string Token)
        {
            CDConexion cn = new CDConexion();
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;

            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_Confirmar_usuarios";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@token", Token);
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0) respuesta = true;
                cmd.Connection = cn.CerrarConexion();
                return respuesta;
            }

            catch
            {
                throw;
            }
        }

        public static void Insert_Usuario_Log(int IdUsuario,string Nombre,string Correo,int RolId,string Mensaje,string Tipo_Pagina)
        {
            CDConexion cn = new CDConexion();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_VillaNueva_Log";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Correo", Correo);
                cmd.Parameters.AddWithValue("@RolId", RolId);
                cmd.Parameters.AddWithValue("@Mensaje", Mensaje);
                cmd.Parameters.AddWithValue("@Tipo_Pagina", Tipo_Pagina);
                cmd.ExecuteNonQuery();
 
                cmd.Connection = cn.CerrarConexion();
            }

            catch(Exception ex)
            {
                ex.Message.ToString();
            }
        }

        public List<cat_tipo_usuario> usp_Obtener_Tipo_Usuario()
        {
            CDConexion cn = new CDConexion();
            SqlCommand cmd = new SqlCommand();

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