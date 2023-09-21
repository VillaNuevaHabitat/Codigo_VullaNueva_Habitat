using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class Db_Cat_Tipo_Documento
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();

        public List<Cat_Tipo_Documento> Obtener_Tipo_Documento()
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_cat_tipo_documento";
            cmd.CommandType = CommandType.StoredProcedure;



            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<Cat_Tipo_Documento> _obtener_cat_tipo_documento = new List<Cat_Tipo_Documento>();
                while (dr.Read())
                {
                    Cat_Tipo_Documento _cat_tipo_documento = new Cat_Tipo_Documento()
                    {
                        Id_Tipo_Documento = Convert.ToInt32(dr["Id_Tipo_Documento"]),
                        Descripcion = dr["Descripcion"].ToString()
                    };
                    _obtener_cat_tipo_documento.Add(_cat_tipo_documento);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_tipo_documento;

            }
        }

        public bool Agregar_Tipo_Documento(Cat_Tipo_Documento _cat_tipo_documento)
        {
            int respuesta = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_insertarar_cat_tipo_documento";
            cmd.CommandType = CommandType.StoredProcedure;

          //  cmd.Parameters.AddWithValue("@Id_Tipo_Documento", _cat_tipo_documento.Id_Tipo_Documento);
            cmd.Parameters.AddWithValue("@Descripcion", _cat_tipo_documento.Descripcion);

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

        public bool Actualizar_Tipo_Documento(Cat_Tipo_Documento _cat_tipo_documento)
        {
            int i = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_actualizar_cat_tipo_documento";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Tipo_Documento", _cat_tipo_documento.Id_Tipo_Documento);
            cmd.Parameters.AddWithValue("@Descripcion", _cat_tipo_documento.Descripcion);

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

        public List<Cat_Tipo_Documento> Obtener_Tipo_Documento_por_id(int Id_documento)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_get_tipo_documento_por_id";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Tipo_Documento", Id_documento);


            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<Cat_Tipo_Documento> _obtener_cat_tipo_documento = new List<Cat_Tipo_Documento>();
                while (dr.Read())
                {
                    Cat_Tipo_Documento _cat_tipo_documento = new Cat_Tipo_Documento()
                    {
                        Id_Tipo_Documento = Convert.ToInt32(dr["Id_Tipo_Documento"]),
                        Descripcion = dr["Descripcion"].ToString()
                    };
                    _obtener_cat_tipo_documento.Add(_cat_tipo_documento);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_tipo_documento;
            }

        }

        public string Eliminar_Tipo_Documento(int id)
        {
            string respuesta = string.Empty;
            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_eliminar_cat_tipo_documento";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Tipo_Documento", id);
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