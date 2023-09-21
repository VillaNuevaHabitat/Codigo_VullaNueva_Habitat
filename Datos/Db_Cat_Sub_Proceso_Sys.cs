using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class Db_Cat_Sub_Proceso_Sys
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();

        public List<Cat_Tipo_Sub_Proceso_Sys> Obtener_Tipo_Sub_Proceso_Sys()
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_Cat_Sub_proceso_Sys";
            cmd.CommandType = CommandType.StoredProcedure;



            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<Cat_Tipo_Sub_Proceso_Sys> _obtener_cat_sub_proceo_Sys = new List<Cat_Tipo_Sub_Proceso_Sys>();
                while (dr.Read())
                {
                    Cat_Tipo_Sub_Proceso_Sys _cat_sub_proceso_sys = new Cat_Tipo_Sub_Proceso_Sys()
                    {
                        IdSubProceso = Convert.ToInt32(dr["Id_Subproceso"]),
                        //IdProceso = Convert.ToInt32(dr["Id_Proceso"]),
                        Nombre       = dr["Nombre"].ToString(),
                        Descripcion  = dr["Descripcion"].ToString(),
                        Clave        = dr["Clave"].ToString()
                    };
                    _obtener_cat_sub_proceo_Sys.Add(_cat_sub_proceso_sys);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_sub_proceo_Sys;

            }
        }

        public bool Actualizar_sub_Proceso_sys(Cat_Tipo_Sub_Proceso_Sys _cat_sub_proceso_sys)
        {
            int i = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_actualiza_Sub_proceso_sys";
            cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.AddWithValue("@IdProceso", _cat_sub_proceso_sys.IdProceso);
            cmd.Parameters.AddWithValue("@IdSubProceso", _cat_sub_proceso_sys.IdSubProceso);
            cmd.Parameters.AddWithValue("@Nombre", _cat_sub_proceso_sys.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", _cat_sub_proceso_sys.Descripcion);
            cmd.Parameters.AddWithValue("@Clave", _cat_sub_proceso_sys.Clave);

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

        public List<Cat_Tipo_Sub_Proceso_Sys> Obtener_SUB_Proceso_SYS_por_id(int Id_SubProceso)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_get_sub_proceso_por_id_sys";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Subproceso", Id_SubProceso);


            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<Cat_Tipo_Sub_Proceso_Sys> _obtener_cat_sub_proceso_sys = new List<Cat_Tipo_Sub_Proceso_Sys>();
                while (dr.Read())
                {
                    Cat_Tipo_Sub_Proceso_Sys _cat_sub_proceso_sys = new Cat_Tipo_Sub_Proceso_Sys()
                    {
                       // IdProceso    = Convert.ToInt32(dr["IdProceso"]),
                        IdSubProceso = Convert.ToInt32(dr["Id_SubProceso"]),
                        Nombre       = dr["Nombre"].ToString(),
                        Descripcion  = dr["Descripcion"].ToString(),
                        Clave        = dr["Clave"].ToString()
                    };
                    _obtener_cat_sub_proceso_sys.Add(_cat_sub_proceso_sys);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_sub_proceso_sys;
            }

        }
        public bool Agregar_Sub_Proceso_Sys(Cat_Tipo_Sub_Proceso_Sys _cat_sub_proceso_sys)
        {
            int respuesta = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_inserta_SUB_proceso_sys";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nombre", _cat_sub_proceso_sys.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", _cat_sub_proceso_sys.Descripcion);
            cmd.Parameters.AddWithValue("@Clave", _cat_sub_proceso_sys.Clave);

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

        public string Eliminar_Sub_Proceso_Sys(int id)
        {
            string respuesta = string.Empty;
            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_eliminar_cat_sub_proceso_sys";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Subproceso", id);
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