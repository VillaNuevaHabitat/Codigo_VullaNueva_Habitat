using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class DAL_Cat_Sub_Proceso_Usr
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();

        public List<Cat_Sub_Proceso_Usr> Obtener_Tipo_Sub_Proceso_Usr()
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_Cat_Sub_proceso_Usr";
            cmd.CommandType = CommandType.StoredProcedure;



            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<Cat_Sub_Proceso_Usr> _obtener_cat_sub_proceo_Usr = new List<Cat_Sub_Proceso_Usr>();
                while (dr.Read())
                {
                    Cat_Sub_Proceso_Usr _cat_sub_proceso_usr = new Cat_Sub_Proceso_Usr()
                    {
                        IdSubProceso = Convert.ToInt32(dr["Id_Subproceso"]),
                        //IdProceso = Convert.ToInt32(dr["Id_Proceso"]),
                        Nombre = dr["Nombre"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        Clave = dr["Clave"].ToString()
                    };
                    _obtener_cat_sub_proceo_Usr.Add(_cat_sub_proceso_usr);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_sub_proceo_Usr;

            }
        }

        public bool Actualizar_sub_Proceso_usr(Cat_Sub_Proceso_Usr _cat_sub_proceso_usr)
        {
            int i = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_actualiza_Sub_proceso_usr";
            cmd.CommandType = CommandType.StoredProcedure;
            // cmd.Parameters.AddWithValue("@IdProceso", _cat_sub_proceso_sys.IdProceso);
            cmd.Parameters.AddWithValue("@IdSubProceso", _cat_sub_proceso_usr.IdSubProceso);
            cmd.Parameters.AddWithValue("@Nombre", _cat_sub_proceso_usr.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", _cat_sub_proceso_usr.Descripcion);
            cmd.Parameters.AddWithValue("@Clave", _cat_sub_proceso_usr.Clave);

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

        public List<Cat_Sub_Proceso_Usr> Obtener_SUB_Proceso_usr_por_id(int Id_SubProceso)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_get_sub_proceso_usr_por_id";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Subproceso", Id_SubProceso);


            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<Cat_Sub_Proceso_Usr> _obtener_cat_sub_proceso_usr = new List<Cat_Sub_Proceso_Usr>();
                while (dr.Read())
                {
                    Cat_Sub_Proceso_Usr _cat_sub_proceso_usr = new Cat_Sub_Proceso_Usr()
                    {
                        // IdProceso    = Convert.ToInt32(dr["IdProceso"]),
                        IdSubProceso = Convert.ToInt32(dr["Id_SubProceso"]),
                        Nombre = dr["Nombre"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        Clave = dr["Clave"].ToString()
                    };
                    _obtener_cat_sub_proceso_usr.Add(_cat_sub_proceso_usr);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_sub_proceso_usr;
            }

        }

        public bool Agregar_Sub_Proceso_Usr(Cat_Sub_Proceso_Usr _cat_sub_proceso_usr)
        {
            int respuesta = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_inserta_sub_proceso_usr";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nombre", _cat_sub_proceso_usr.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", _cat_sub_proceso_usr.Descripcion);
            cmd.Parameters.AddWithValue("@Clave", _cat_sub_proceso_usr.Clave);

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

        public string Eliminar_Sub_Proceso_Usr(int id)
        {
            string respuesta = string.Empty;
            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "eliminar_cat_sub_proceso_usr";
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