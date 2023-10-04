using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class DAL_cat_contacto_cliente
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();

        public List<cat_cliente_contacto> Obtener_contacto_cliente()
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_contacto_cliente";
            cmd.CommandType = CommandType.StoredProcedure;



            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_cliente_contacto> _obtener_contacto_cliente = new List<cat_cliente_contacto>();
                while (dr.Read())
                {
                    cat_cliente_contacto _cat_contacto_cliente = new cat_cliente_contacto()
                    {
                        Id_contacto = Convert.ToInt32(dr["Id_contacto"]),
                        Nombre = dr["Nombre"].ToString(),
                        Email = dr["Email"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Comentario = dr["Comentario"].ToString(),
                        Area_Facturacion = dr["Area_Facturacion"].ToString(),
                    };
                    _obtener_contacto_cliente.Add(_cat_contacto_cliente);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_contacto_cliente;

            }
        }

        public List<cat_cliente_contacto> Obtener_Contacto_Cliente_por_id(int id_contacto)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_contacto_cliente_por_id";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_contacto", id_contacto);


            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_cliente_contacto> _obtener_contacto_cliente = new List<cat_cliente_contacto>();
                while (dr.Read())
                {
                    cat_cliente_contacto _contacto_cliente = new cat_cliente_contacto()
                    {
                        Id_contacto = Convert.ToInt32(dr["Id_contacto"]),
                        Nombre = dr["Nombre"].ToString(),
                        Email = dr["Email"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Comentario = dr["Comentario"].ToString(),
                        Area_Facturacion = dr["Area_Facturacion"].ToString(),
                    };
                    _obtener_contacto_cliente.Add(_contacto_cliente);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_contacto_cliente;
            }

        }

        public bool Actualizar_Contacto_Cliente(cat_cliente_contacto _cat_cliente_contacto)
        {
            int i = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_actualiza_contacto_cliente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_contacto", _cat_cliente_contacto.Id_contacto);
            cmd.Parameters.AddWithValue("@Nombre", _cat_cliente_contacto.Nombre);
            cmd.Parameters.AddWithValue("@Email", _cat_cliente_contacto.Email);
            cmd.Parameters.AddWithValue("@Telefono", _cat_cliente_contacto.Telefono);
            cmd.Parameters.AddWithValue("@Comentario", _cat_cliente_contacto.Comentario);
            cmd.Parameters.AddWithValue("@Area_Facturacion", _cat_cliente_contacto.Area_Facturacion);
            
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

        public bool Agregar_Contacto_Cliente(cat_cliente_contacto _cat_cliente_contacto)
        {
            int respuesta = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_inserta_contacto_cliente";
            cmd.CommandType = CommandType.StoredProcedure;

            
            cmd.Parameters.AddWithValue("@Nombre", _cat_cliente_contacto.Nombre);
            cmd.Parameters.AddWithValue("@Email", _cat_cliente_contacto.Email);
            cmd.Parameters.AddWithValue("@Telefono", _cat_cliente_contacto.Telefono);
            cmd.Parameters.AddWithValue("@Comentario", _cat_cliente_contacto.Comentario);
            cmd.Parameters.AddWithValue("@Area_Facturacion", _cat_cliente_contacto.Area_Facturacion);

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

        public string Eliminar_Contacto_Cliente(int id)
        {
            string respuesta = string.Empty;
            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_eliminar_contacto_cliente";
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