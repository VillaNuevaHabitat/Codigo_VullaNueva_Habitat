using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class DAL_provedor_contacto
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();

        public List<cat_provedor_contacto> Obtener_contacto_provedor()
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_contacto_provedor";
            cmd.CommandType = CommandType.StoredProcedure;



            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_provedor_contacto> _obtener_contacto_provedor = new List<cat_provedor_contacto>();
                while (dr.Read())
                {
                    cat_provedor_contacto _cat_contacto_provedor = new cat_provedor_contacto()
                    {
                        Id_contacto = Convert.ToInt32(dr["Id_contacto"]),
                        Nombre = dr["Nombre"].ToString(),
                        Email = dr["Email"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Comentario = dr["Comentario"].ToString(),
                        Area_Facturacion = dr["Area_Facturacion"].ToString(),
                    };
                    _obtener_contacto_provedor.Add(_cat_contacto_provedor);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_contacto_provedor;

            }
        }

        public List<cat_provedor_contacto> Obtener_Contacto_Provedor_por_id(int id_contacto)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_contacto_provedor_por_id";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_contacto", id_contacto);


            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_provedor_contacto> _obtener_contacto_provedor = new List<cat_provedor_contacto>();
                while (dr.Read())
                {
                    cat_provedor_contacto _contacto_provedor = new cat_provedor_contacto()
                    {
                        Id_contacto = Convert.ToInt32(dr["Id_contacto"]),
                        Nombre = dr["Nombre"].ToString(),
                        Email = dr["Email"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Comentario = dr["Comentario"].ToString(),
                        Area_Facturacion = dr["Area_Facturacion"].ToString(),
                    };
                    _obtener_contacto_provedor.Add(_contacto_provedor);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_contacto_provedor;
            }

        }

        public bool Actualizar_Contacto_Provedor(cat_provedor_contacto _cat_provedor_contacto)
        {
            int i = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_actualiza_contacto_provedor";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_contacto", _cat_provedor_contacto.Id_contacto);
            cmd.Parameters.AddWithValue("@Nombre", _cat_provedor_contacto.Nombre);
            cmd.Parameters.AddWithValue("@Email", _cat_provedor_contacto.Email);
            cmd.Parameters.AddWithValue("@Telefono", _cat_provedor_contacto.Telefono);
            cmd.Parameters.AddWithValue("@Comentario", _cat_provedor_contacto.Comentario);
            cmd.Parameters.AddWithValue("@Area_Facturacion", _cat_provedor_contacto.Area_Facturacion);

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

        public bool Agregar_Contacto_Provedor(cat_provedor_contacto _cat_provedor_contacto)
        {
            int respuesta = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_inserta_contacto_provedor";
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@Nombre", _cat_provedor_contacto.Nombre);
            cmd.Parameters.AddWithValue("@Email", _cat_provedor_contacto.Email);
            cmd.Parameters.AddWithValue("@Telefono", _cat_provedor_contacto.Telefono);
            cmd.Parameters.AddWithValue("@Comentario", _cat_provedor_contacto.Comentario);
            cmd.Parameters.AddWithValue("@Area_Facturacion", _cat_provedor_contacto.Area_Facturacion);

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

        public string Eliminar_Contacto_Provedor(int id)
        {
            string respuesta = string.Empty;
            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_eliminar_contacto_provedor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_contacto", id);
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