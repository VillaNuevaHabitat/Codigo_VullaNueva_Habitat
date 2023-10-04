using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class DAL_cat_adm_provedor
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();

        public List<cat_adm_provedores> Obtener_cat_adm_provedores()
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_cat_adm_provedores";
            cmd.CommandType = CommandType.StoredProcedure;



            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_adm_provedores> _obtener_cat_adm_clientes = new List<cat_adm_provedores>();
                while (dr.Read())
                {
                    cat_adm_provedores _cat_adm_provedores = new cat_adm_provedores()
                    {
                        id_provedor             = Convert.ToInt32(dr["id_provedor"]),
                        rfc_provedor            = dr["rfc_cliente"].ToString(),
                        regimen_fiscal          = dr["cve_regimen_fiscal"].ToString(),
                        razon_social            = dr["razon_social"].ToString(),
                        Estado                  = dr["Estado"].ToString(),
                        Municipio               = dr["Municipio"].ToString(),
                        Colonia                 = dr["Colonia"].ToString(),
                        Calle                   = dr["Calle"].ToString(),
                        Codigo_Postal           = dr["Codigo_Postal"].ToString(),
                        Forma_Pago              = dr["Forma_Pago"].ToString(),
                        CFDI                    = dr["CFDI"].ToString(),
                        Instrucciones           = dr["Instrucciones"].ToString(),
                        Dias_Recepcion_Facturas = dr["Dias_Recepcion_Facturas"].ToString(),
                        Dias_Credito            = dr["Dias_Credito"].ToString(),
                        Estatus                 = Convert.ToBoolean(dr["Estatus"])
                    };
                    _obtener_cat_adm_clientes.Add(_cat_adm_provedores);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_adm_clientes;

            }
        }

        public List<cat_adm_provedores> Obtener_Adm_Provedores_por_id(int id_provedor)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_cat_adm_provedores_por_id";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_cliente", id_provedor);


            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_adm_provedores> _obtener_cat_adm_provedores = new List<cat_adm_provedores>();
                while (dr.Read())
                {
                    cat_adm_provedores _cat_adm_provedores = new cat_adm_provedores()
                    {
                        id_provedor = Convert.ToInt32(dr["id_provedor"]),
                        rfc_provedor = dr["rfc_cliente"].ToString(),
                        regimen_fiscal = dr["cve_regimen_fiscal"].ToString(),
                        razon_social = dr["razon_social"].ToString(),
                        Estado = dr["Estado"].ToString(),
                        Municipio = dr["Municipio"].ToString(),
                        Colonia = dr["Colonia"].ToString(),
                        Calle = dr["Calle"].ToString(),
                        Codigo_Postal = dr["Codigo_Postal"].ToString(),
                        Forma_Pago = dr["Forma_Pago"].ToString(),
                        CFDI = dr["CFDI"].ToString(),
                        Instrucciones = dr["Instrucciones"].ToString(),
                        Dias_Recepcion_Facturas = dr["Dias_Recepcion_Facturas"].ToString(),
                        Dias_Credito = dr["Dias_Credito"].ToString(),
                        Estatus = Convert.ToBoolean(dr["Estatus"])
                    };
                    _obtener_cat_adm_provedores.Add(_cat_adm_provedores);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_adm_provedores;
            }

        }

        public bool Actualizar_Adm_Provedores(cat_adm_provedores _cat_adm_provedores)
        {
            int i = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_actualiza_cat_adm_provedores";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_provedor", _cat_adm_provedores.id_provedor);
            cmd.Parameters.AddWithValue("@rfc_cliente", _cat_adm_provedores.rfc_provedor);
            cmd.Parameters.AddWithValue("@cve_regimen_fiscal", _cat_adm_provedores.regimen_fiscal);
            cmd.Parameters.AddWithValue("@razon_social", _cat_adm_provedores.razon_social);
            cmd.Parameters.AddWithValue("@Estado", _cat_adm_provedores.Estado);
            cmd.Parameters.AddWithValue("@Municipio", _cat_adm_provedores.Municipio);
            cmd.Parameters.AddWithValue("@Colonia", _cat_adm_provedores.Colonia);
            cmd.Parameters.AddWithValue("@Calle", _cat_adm_provedores.Calle);
            cmd.Parameters.AddWithValue("@Codigo_Postal", _cat_adm_provedores.Codigo_Postal);
            cmd.Parameters.AddWithValue("@Forma_Pago", _cat_adm_provedores.Forma_Pago);
            cmd.Parameters.AddWithValue("@CFDI", _cat_adm_provedores.CFDI);
            cmd.Parameters.AddWithValue("@Instrucciones", _cat_adm_provedores.Instrucciones);
            cmd.Parameters.AddWithValue("@Dias_Recepcion_Facturas", _cat_adm_provedores.Dias_Recepcion_Facturas);
            cmd.Parameters.AddWithValue("@Dias_Credito", _cat_adm_provedores.Dias_Credito);
            cmd.Parameters.AddWithValue("@Estatus", _cat_adm_provedores.Estatus);
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

        public bool Agregar_Adm_Clientes(cat_adm_provedores _cat_adm_provedores)
        {
            int respuesta = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_inserta_cat_adm_provedores";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@rfc_provedor", _cat_adm_provedores.rfc_provedor);
            cmd.Parameters.AddWithValue("@cve_regimen_fiscal", _cat_adm_provedores.regimen_fiscal);
            cmd.Parameters.AddWithValue("@razon_social", _cat_adm_provedores.razon_social);
            cmd.Parameters.AddWithValue("@Estado", _cat_adm_provedores.Estado);
            cmd.Parameters.AddWithValue("@Municipio", _cat_adm_provedores.Municipio);
            cmd.Parameters.AddWithValue("@Colonia", _cat_adm_provedores.Colonia);
            cmd.Parameters.AddWithValue("@Calle", _cat_adm_provedores.Calle);
            cmd.Parameters.AddWithValue("@Codigo_Postal", _cat_adm_provedores.Codigo_Postal);
            cmd.Parameters.AddWithValue("@Forma_Pago", _cat_adm_provedores.Forma_Pago);
            cmd.Parameters.AddWithValue("@CFDI", _cat_adm_provedores.CFDI);
            cmd.Parameters.AddWithValue("@Instrucciones", _cat_adm_provedores.Instrucciones);
            cmd.Parameters.AddWithValue("@Dias_Recepcion_Facturas", _cat_adm_provedores.Dias_Recepcion_Facturas);
            cmd.Parameters.AddWithValue("@Dias_Credito", _cat_adm_provedores.Dias_Credito);
            cmd.Parameters.AddWithValue("@Estatus", _cat_adm_provedores.Estatus);
            cmd.Parameters.AddWithValue("@Usuario_Creo", _cat_adm_provedores.Usuario_Creo);

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

        public string Eliminar_Adm_Provedores(int id)
        {
            string respuesta = string.Empty;
            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_eliminar_cat_adm_provedores";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_provedor", id);
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