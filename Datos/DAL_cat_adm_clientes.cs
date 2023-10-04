using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class DAL_cat_adm_clientes
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();

        public List<cat_adm_clientes> Obtener_cat_adm_clientes()
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_cat_adm_clientes";
            cmd.CommandType = CommandType.StoredProcedure;



            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_adm_clientes> _obtener_cat_adm_clientes = new List<cat_adm_clientes>();
                while (dr.Read())
                {
                    cat_adm_clientes _cat_adm_clientes = new cat_adm_clientes()
                    {
                        id_cliente               = Convert.ToInt32(dr["id_cliente"]),
                        rfc_cliente              = dr["rfc_cliente"].ToString(),
                        regimen_fiscal           = dr["cve_regimen_fiscal"].ToString(),
                        razon_social             = dr["razon_social"].ToString(),
                        Estado                   = dr["Estado"].ToString(),
                        Municipio                = dr["Municipio"].ToString(),
                        Colonia                  = dr["Colonia"].ToString(),
                        Calle                    = dr["Calle"].ToString(),
                        Codigo_Postal            = dr["Codigo_Postal"].ToString(),
                        Forma_Pago               = dr["Forma_Pago"].ToString(),
                        CFDI                     = dr["CFDI"].ToString(),
                        Instrucciones            = dr["Instrucciones"].ToString(),
                        Dias_Recepcion_Facturas  = dr["Dias_Recepcion_Facturas"].ToString(),
                        Dias_Credito             = dr["Dias_Credito"].ToString(),
                        Estatus                  = Convert.ToBoolean(dr["Estatus"]),
                        Num_Ext                  = dr["Num_Ext"].ToString(),
                        Num_Int                  = dr["Num_Int"].ToString(),
                        Pais                     = dr["Num_Int"].ToString(),
                    };
                    _obtener_cat_adm_clientes.Add(_cat_adm_clientes);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_adm_clientes;

            }
        }

        public List<cat_adm_clientes> Obtener_Adm_Clientes_por_id(int id_cliente)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_cat_adm_clientes_por_id";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_cliente", id_cliente);


            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_adm_clientes> _obtener_cat_adm_clientes = new List<cat_adm_clientes>();
                while (dr.Read())
                {
                    cat_adm_clientes _cat_adm_clientes = new cat_adm_clientes()
                    {
                        id_cliente                = Convert.ToInt32(dr["id_cliente"]),
                        rfc_cliente               = dr["rfc_cliente"].ToString(),
                        regimen_fiscal            = dr["cve_regimen_fiscal"].ToString(),
                        razon_social              = dr["razon_social"].ToString(),
                        Estado                    = dr["Estado"].ToString(),
                        Municipio                 = dr["Municipio"].ToString(),
                        Colonia                   = dr["Colonia"].ToString(),
                        Calle                     = dr["Calle"].ToString(),
                        Codigo_Postal             = dr["Codigo_Postal"].ToString(),
                        Forma_Pago                = dr["Forma_Pago"].ToString(),
                        CFDI                      = dr["CFDI"].ToString(),
                        Instrucciones             = dr["Instrucciones"].ToString(),
                        Dias_Recepcion_Facturas   = dr["Dias_Recepcion_Facturas"].ToString(),
                        Dias_Credito              = dr["Dias_Credito"].ToString(),
                        Num_Ext                   = dr["Num_Ext"].ToString(),
                        Num_Int                   = dr["Num_Int"].ToString(),
                        Pais                      = dr["Pais"].ToString(),
                    };
                    _obtener_cat_adm_clientes.Add(_cat_adm_clientes);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_adm_clientes;
            }

        }

        public bool Actualizar_Adm_Clientes(cat_adm_clientes _cat_adm_clientes)
        {
            int i = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_actualiza_cat_adm_clientes";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_cliente", _cat_adm_clientes.id_cliente);
            cmd.Parameters.AddWithValue("@rfc_cliente", _cat_adm_clientes.rfc_cliente);
            cmd.Parameters.AddWithValue("@cve_regimen_fiscal", _cat_adm_clientes.regimen_fiscal);
            cmd.Parameters.AddWithValue("@razon_social", _cat_adm_clientes.razon_social);
            cmd.Parameters.AddWithValue("@Estado", _cat_adm_clientes.Estado);
            cmd.Parameters.AddWithValue("@Municipio", _cat_adm_clientes.Municipio);
            cmd.Parameters.AddWithValue("@Colonia", _cat_adm_clientes.Colonia);
            cmd.Parameters.AddWithValue("@Calle", _cat_adm_clientes.Calle);
            cmd.Parameters.AddWithValue("@Codigo_Postal", _cat_adm_clientes.Codigo_Postal);
            cmd.Parameters.AddWithValue("@Forma_Pago", _cat_adm_clientes.Forma_Pago);
            cmd.Parameters.AddWithValue("@CFDI", _cat_adm_clientes.CFDI);
            cmd.Parameters.AddWithValue("@Instrucciones", _cat_adm_clientes.Instrucciones);
            cmd.Parameters.AddWithValue("@Dias_Recepcion_Facturas", _cat_adm_clientes.Dias_Recepcion_Facturas);
            cmd.Parameters.AddWithValue("@Dias_Credito", _cat_adm_clientes.Dias_Credito);

            cmd.Parameters.AddWithValue("@Num_Ext", _cat_adm_clientes.Instrucciones);
            cmd.Parameters.AddWithValue("@Num_Int", _cat_adm_clientes.Dias_Recepcion_Facturas);
            cmd.Parameters.AddWithValue("@Pais", _cat_adm_clientes.Dias_Credito);

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

        public bool Agregar_Adm_Clientes(cat_adm_clientes _cat_adm_clientes)
        {
            int respuesta = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_inserta_cat_adm_clientes";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@rfc_cliente", _cat_adm_clientes.rfc_cliente);
            cmd.Parameters.AddWithValue("@regimen_fiscal", _cat_adm_clientes.regimen_fiscal);
            cmd.Parameters.AddWithValue("@razon_social", _cat_adm_clientes.razon_social);
            cmd.Parameters.AddWithValue("@Estado", _cat_adm_clientes.Estado);
            cmd.Parameters.AddWithValue("@Municipio", _cat_adm_clientes.Municipio);
            cmd.Parameters.AddWithValue("@Colonia", _cat_adm_clientes.Colonia);
            cmd.Parameters.AddWithValue("@Calle", _cat_adm_clientes.Calle);
            cmd.Parameters.AddWithValue("@Codigo_Postal", _cat_adm_clientes.Codigo_Postal);
            cmd.Parameters.AddWithValue("@Forma_Pago", _cat_adm_clientes.Forma_Pago);
            cmd.Parameters.AddWithValue("@CFDI", _cat_adm_clientes.CFDI);
            cmd.Parameters.AddWithValue("@Instrucciones", _cat_adm_clientes.Instrucciones);
            cmd.Parameters.AddWithValue("@Dias_Recepcion_Facturas", _cat_adm_clientes.Dias_Recepcion_Facturas);
            cmd.Parameters.AddWithValue("@Dias_Credito", _cat_adm_clientes.Dias_Credito);
            cmd.Parameters.AddWithValue("@Estatus", _cat_adm_clientes.Estatus);
            cmd.Parameters.AddWithValue("@Usuario_Creo", _cat_adm_clientes.Usuario_Creo);

            cmd.Parameters.AddWithValue("@Num_Ext", _cat_adm_clientes.Instrucciones);
            cmd.Parameters.AddWithValue("@Num_Int", _cat_adm_clientes.Dias_Recepcion_Facturas);
            cmd.Parameters.AddWithValue("@Pais", _cat_adm_clientes.Dias_Credito);

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

        public string Eliminar_Adm_Clientes(int id)
        {
            string respuesta = string.Empty;
            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_eliminar_cat_adm_clientes";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_cliente", id);
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