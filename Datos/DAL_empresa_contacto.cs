using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class DAL_empresa_contacto
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();

        /* public List<cat_empresas_contacto> Obtener_Adm_Empresas()
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_contacto_Empresas";
            cmd.CommandType = CommandType.StoredProcedure;



             using (SqlDataReader dr = cmd.ExecuteReader())
              {
                  List<cat_empresas_contacto> _obtener_Empresas_contacto = new List<cat_empresas_contacto>();
                  while (dr.Read())
                  {
                      cat_empresas_contacto _cat_Empresas_contacto = new cat_empresas_contacto()
                      {
                          Id_Contacto = Convert.ToInt32(dr["Id_Contacto"]),
                          Numero_Telefonico_1 = dr["Numero_Telefonico_1"].ToString(),
                          Numero_Telefonico_2 = dr["Numero_Telefonico_2"].ToString(),
                          WebSite = dr["WebSite"].ToString(),
                          img = dr["image"].ToString(),

                      };
                      _obtener_cat_Adm_Empresas.Add(_cat_Adm_Empresas);

                  }
                  cmd.Connection = cn.CerrarConexion();
                  return _obtener_cat_Adm_Empresas;


          } }*/
    }
}