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
                        Id_Empresa     = Convert.ToInt32(dr["Id_Empresa"]),
                        Estado         = dr["Estado"].ToString(),
                        Municipio      = dr["Municipio"].ToString(),
                        Colonia        = dr["Colonia"].ToString(),
                        Calle          = dr["Calle"].ToString(),
                        Codigo_Postal  = Convert.ToInt32(dr["Codigo_Postal"]),
                        Num_Exterior   = dr["Num_Exterior"].ToString(),
                        Num_Interior   = dr["Num_Interior"].ToString(),
                        Telefono_1     = dr["Telefono_1"].ToString(),
                        Telefono_2     = dr["Telefono_2"].ToString(),
                        Correo         = dr["Correo"].ToString(),
                        WebSite        = dr["WebSite"].ToString(),
                        Logotipo       = dr["Logotip "].ToString(),
                        Razon_Social   = dr["Razon_Social"].ToString(),
                        Regimen_Fiscal = dr["Regimen_Fiscal"].ToString(),
                        Estatus        = Convert.ToBoolean(dr["Estatus"]),
                    };
                    _obtener_cat_Adm_Empresas.Add(_cat_Adm_Empresas);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_Adm_Empresas;

            }



        }

    }
}