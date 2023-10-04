using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class DAL_Adm_Empresas
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();

        public List<Cat_Administrador_Empresa> Obtener_Adm_Empresas()
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_cat_Adm_Empresas";
            cmd.CommandType = CommandType.StoredProcedure;



            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<Cat_Administrador_Empresa> _obtener_cat_Adm_Empresas = new List<Cat_Administrador_Empresa>();
                while (dr.Read())
                {
                    Cat_Administrador_Empresa _cat_Adm_Empresas = new Cat_Administrador_Empresa()
                    {
                        Id_Empresa = Convert.ToInt32(dr["Id_Empresa"]),
                        Estado = dr["Estado"].ToString(),
                        Municipio = dr["Municipio"].ToString(),
                        Colonia = dr["Colonia"].ToString(),
                        Calle = dr["Calle"].ToString(),
                        Codigo_Postal = Convert.ToInt32(dr["Codigo_Postal"]),
                        Num_Exterior = dr["Num_Exterior"].ToString(),
                        Num_Interior = dr["Num_Interior"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Razon_Social = dr["Razon_Social"].ToString(),
                        Regimen_Fiscal = dr["Regimen_Fiscal"].ToString(),
                        Estatus = Convert.ToBoolean(dr["Estatus"]),
                        Usuario_Creo = dr["Usuario_Creo"].ToString()
                    };
                    _obtener_cat_Adm_Empresas.Add(_cat_Adm_Empresas);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_Adm_Empresas;

            }
        }

        public List<Cat_Administrador_Empresa> Obtener_Adm_Empresas_por_id(int id_empresa)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_cat_Adm_Empresas_por_id";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_cliente", id_empresa);


            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<Cat_Administrador_Empresa> _obtener_cat_adm_empresas = new List<Cat_Administrador_Empresa>();
                while (dr.Read())
                {
                    Cat_Administrador_Empresa _cat_adm_empresas = new Cat_Administrador_Empresa()
                    {
                        Id_Empresa = Convert.ToInt32(dr["Id_Empresa"]),
                        Estado = dr["Estado"].ToString(),
                        Municipio = dr["Municipio"].ToString(),
                        Colonia = dr["Colonia"].ToString(),
                        Calle = dr["Calle"].ToString(),
                        Codigo_Postal = Convert.ToInt32(dr["Codigo_Postal"]),
                        Num_Exterior = dr["Num_Exterior"].ToString(),
                        Num_Interior = dr["Num_Interior"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Razon_Social = dr["Razon_Social"].ToString(),
                        Regimen_Fiscal = dr["Regimen_Fiscal"].ToString(),
                        Estatus = Convert.ToBoolean(dr["Estatus"]),
                    };
                    _obtener_cat_adm_empresas.Add(_cat_adm_empresas);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_adm_empresas;
            }

        }
        public bool Actualizar_Adm_Empresas(Cat_Administrador_Empresa _Cat_Administrador_Empresa)
        {
            int i = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_actualiza_Adm_Empresas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Empresa", _Cat_Administrador_Empresa.Id_Empresa);
            cmd.Parameters.AddWithValue("@RFC", _Cat_Administrador_Empresa.RFC);
            cmd.Parameters.AddWithValue("@Id_Estado", _Cat_Administrador_Empresa.Estado);
            cmd.Parameters.AddWithValue("@Id_Municipio", _Cat_Administrador_Empresa.Municipio);
            cmd.Parameters.AddWithValue("@cve_regimen_fiscal", _Cat_Administrador_Empresa.Regimen_Fiscal);
            cmd.Parameters.AddWithValue("@Colonia", _Cat_Administrador_Empresa.Colonia);
            cmd.Parameters.AddWithValue("@Colonia", _Cat_Administrador_Empresa.Colonia);
            cmd.Parameters.AddWithValue("@Calle", _Cat_Administrador_Empresa.Calle);
            cmd.Parameters.AddWithValue("@Codigo_Postal", _Cat_Administrador_Empresa.Codigo_Postal);
            cmd.Parameters.AddWithValue("@Num_Exterior", _Cat_Administrador_Empresa.Num_Exterior);
            cmd.Parameters.AddWithValue("@Num_Interior", _Cat_Administrador_Empresa.Num_Interior);
            cmd.Parameters.AddWithValue("@Correo", _Cat_Administrador_Empresa.Correo);
            cmd.Parameters.AddWithValue("@Razon_Social", _Cat_Administrador_Empresa.Razon_Social);
            cmd.Parameters.AddWithValue("@Regimen_Fiscal", _Cat_Administrador_Empresa.Regimen_Fiscal);
            cmd.Parameters.AddWithValue("@Estatus", _Cat_Administrador_Empresa.Estatus);
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

       /* public string Agregar_Adm_Empresas(Cat_Administrador_Empresa _Cat_Administrador_Empresa)
        {
            string respuesta = string.Empty; ;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_inserta_Adm_Empresas";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Empresa", _Cat_Administrador_Empresa.Id_Empresa);
            cmd.Parameters.AddWithValue("@RFC", _Cat_Administrador_Empresa.RFC);
            cmd.Parameters.AddWithValue("@Id_Estado", _Cat_Administrador_Empresa.Estado);
            cmd.Parameters.AddWithValue("@Id_Municipio", _Cat_Administrador_Empresa.Municipio);
            cmd.Parameters.AddWithValue("@cve_regimen_fiscal", _Cat_Administrador_Empresa.Regimen_Fiscal);
            cmd.Parameters.AddWithValue("@Colonia", _Cat_Administrador_Empresa.Colonia);
            cmd.Parameters.AddWithValue("@Colonia", _Cat_Administrador_Empresa.Colonia);
            cmd.Parameters.AddWithValue("@Calle", _Cat_Administrador_Empresa.Calle);
            cmd.Parameters.AddWithValue("@Codigo_Postal", _Cat_Administrador_Empresa.Codigo_Postal);
            cmd.Parameters.AddWithValue("@Num_Exterior", _Cat_Administrador_Empresa.Num_Exterior);
            cmd.Parameters.AddWithValue("@Num_Interior", _Cat_Administrador_Empresa.Num_Interior);
            cmd.Parameters.AddWithValue("@Correo", _Cat_Administrador_Empresa.Correo);
            cmd.Parameters.AddWithValue("@Razon_Social", _Cat_Administrador_Empresa.Razon_Social);
            cmd.Parameters.AddWithValue("@Regimen_Fiscal", _Cat_Administrador_Empresa.Regimen_Fiscal);
            cmd.Parameters.AddWithValue("@Estatus", _Cat_Administrador_Empresa.Estatus);
            cmd.Parameters.Add("@OutputMessage", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            respuesta = cmd.Parameters["@OutputMessage"].Value.ToString();
            cmd.Connection = cn.CerrarConexion();
        }*/

        public string Eliminar_Adm_Empresas(int id)
        {
            string respuesta = string.Empty;
            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_eliminar_Adm_Empresas";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_empresa", id);
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