﻿using System;
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
                                nombre = dr["nombre"].ToString(),
                                Clave = dr["clave"].ToString(),
                                ConfirmarClave = dr["ConfirmarClave"].ToString(),
                                //RolId = (object)dr["IdRol"]
                                //Restablecer = (bool)dr["restablecer"],
                                //Confirmado = (bool)dr["confirmado"]
                            };
                        }
                    
                }
                cmd.Connection = cn.CerrarConexion();
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
                cmd.CommandText = "usp_obtener_usuarios";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo", correo);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        usuario = new UsuarioDTO()
                        {
                            nombre = dr["nombre"].ToString(),
                            Clave = dr["Clave"].ToString(),
                            Restablecer = (bool)dr["Restablecer"],
                            Confirmado = (bool)dr["confirmado"],
                            Token = dr["Token"].ToString()
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
    }
}