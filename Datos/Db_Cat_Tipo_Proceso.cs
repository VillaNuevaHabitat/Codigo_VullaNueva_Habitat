using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class Db_Cat_Tipo_Proceso
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();

       
        public List<Cat_Tipo_Proceso> Obtener_Tipo_Proceso()
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_cat_tipo_proceso";
            cmd.CommandType = CommandType.StoredProcedure;



            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<Cat_Tipo_Proceso> _obtener_cat_tipo_proceo = new List<Cat_Tipo_Proceso>();
                while (dr.Read())
                {
                    Cat_Tipo_Proceso _cat_tipo_proceso = new Cat_Tipo_Proceso()
                    {
                        IdProceso = Convert.ToInt32(dr["Id_proceso"]),
                        Nombre = dr["Descripcion"].ToString(),
                        Clave = dr["Clave"].ToString()
                    };
                    _obtener_cat_tipo_proceo.Add(_cat_tipo_proceso);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_tipo_proceo;

            }
        }

        public bool Actualizar_Tipo_Proceso(Cat_Tipo_Proceso _cat_tipo_proceso)
        {
            int i = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_actualizar_cat_tipo_proceso";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProceso", _cat_tipo_proceso.IdProceso);
            cmd.Parameters.AddWithValue("@Descripcion", _cat_tipo_proceso.Nombre);
            cmd.Parameters.AddWithValue("@Clave", _cat_tipo_proceso.Clave);

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

        public List<Cat_Tipo_Proceso> Obtener_Tipo_Proceso_por_id(int Id_proceso)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_get_tipo_proceso_por_id";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Proceso", Id_proceso);


            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<Cat_Tipo_Proceso> _obtener_cat_tipo_proceso = new List<Cat_Tipo_Proceso>();
                while (dr.Read())
                {
                    Cat_Tipo_Proceso _cat_tipo_proceso = new Cat_Tipo_Proceso()
                    {
                        IdProceso = Convert.ToInt32(dr["Id_Proceso"]),
                        Nombre = dr["Descripcion"].ToString(),
                        Clave = dr["Clave"].ToString()
                    };
                    _obtener_cat_tipo_proceso.Add(_cat_tipo_proceso);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_tipo_proceso;
            }

        }

        public bool Agregar_Tipo_Proceso(Cat_Tipo_Proceso _cat_tipo_proceso)
        {
            int respuesta = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_inserta_tipo_proceso";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Descripcion", _cat_tipo_proceso.Nombre);
            cmd.Parameters.AddWithValue("@Clave", _cat_tipo_proceso.Clave);

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

        public string Eliminar_Tipo_Proceso(int id)
        {
            string respuesta = string.Empty;
            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_eliminar_cat_tipo_proceso";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProceso", id);
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