using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class DbProvedores
    {
        public List<Provedores> GetAll()
        {
            List<Provedores> leadListEntity = new List<Provedores>();
            CDConexion cn = new CDConexion();
            SqlCommand cmd = new SqlCommand();

            try
            {

                // SqlDataAdapter dataAdapter = new SqlDataAdapter("usp_seleccionar_provedores", cn);
                // con.Open();
                //DataTable dt = new DataTable();

                // dataAdapter.Fill(dt);

                //foreach(DataRow dr in dt.Rows)
                cmd.Connection = cn.AbrirConexion();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    leadListEntity.Add(
                        new Provedores
                        {
                            Codigo_proveedor = dr["Codigo_proveedor"].ToString(),
                            Razon_social = dr["Razon_social"].ToString(),
                            RFC = dr["RFC"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Calle = dr["calle"].ToString(),
                            Numero_Exterior = dr["Numero_Exterior"].ToString(),
                            Colonia = dr["Colonia"].ToString(),
                            Entidad = dr["Entidad"].ToString()
                        }


                    );
                }
                                
                cmd.Connection = cn.CerrarConexion();
                

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return leadListEntity;
        }

        public bool Insertar_Provedores(Provedores provedores)
        {
            CDConexion cn = new CDConexion();
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;

            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_insertar_provedores";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo_proveedor", provedores.Codigo_proveedor);
                cmd.Parameters.AddWithValue("@Razon_social", provedores.Razon_social);
                cmd.Parameters.AddWithValue("@RFC", provedores.RFC);
                cmd.Parameters.AddWithValue("@Telefono", provedores.Telefono);
                cmd.Parameters.AddWithValue("@Calle", provedores.Calle);
                cmd.Parameters.AddWithValue("@Numero_Exterior", provedores.Numero_Exterior);
                cmd.Parameters.AddWithValue("@Colonia", provedores.Colonia);
                cmd.Parameters.AddWithValue("@Entidad", provedores.Entidad);
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0) 
                    respuesta = true;
                else
                    respuesta = false;
                cmd.Connection = cn.CerrarConexion();
                return respuesta;
            }

            catch
            {
                throw;
            }
        }
    }
}