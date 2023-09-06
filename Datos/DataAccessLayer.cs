using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class DataAccessLayer
    {
        public string InsertData(Provedores provedores)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@CustomerID", 0);    
                cmd.Parameters.AddWithValue("@Codigo_proveedor", provedores.Codigo_proveedor);
                cmd.Parameters.AddWithValue("@Razon_social", provedores.Razon_social);
                cmd.Parameters.AddWithValue("@RFC", provedores.RFC);
                cmd.Parameters.AddWithValue("@Telefono", provedores.Telefono);
                cmd.Parameters.AddWithValue("@Calle", provedores.Calle);
                cmd.Parameters.AddWithValue("@Numero_Exterior", provedores.Numero_Exterior);
                cmd.Parameters.AddWithValue("@Colonia", provedores.Colonia);
                cmd.Parameters.AddWithValue("@Entidad", provedores.Entidad);
                cmd.Parameters.AddWithValue("@Query", 1);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        public string UpdateData(Provedores provedores)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo_proveedor", provedores.Codigo_proveedor);
                cmd.Parameters.AddWithValue("@Razon_social", provedores.Razon_social);
                cmd.Parameters.AddWithValue("@RFC", provedores.RFC);
                cmd.Parameters.AddWithValue("@Telefono", provedores.Telefono);
                cmd.Parameters.AddWithValue("@Calle", provedores.Calle);
                cmd.Parameters.AddWithValue("@Numero_Exterior", provedores.Numero_Exterior);
                cmd.Parameters.AddWithValue("@Colonia", provedores.Colonia);
                cmd.Parameters.AddWithValue("@Entidad", provedores.Entidad);
                cmd.Parameters.AddWithValue("@Query", 2);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        public int DeleteData(String Codigo_proveedor)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo_proveedor", Codigo_proveedor);
                cmd.Parameters.AddWithValue("@Query", 3);
                con.Open();
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return result = 0;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Provedores> Selectalldata()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<Provedores> custlist = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo_proveedor", null);
                cmd.Parameters.AddWithValue("@Razon_social", null);
                cmd.Parameters.AddWithValue("@RFC", null);
                cmd.Parameters.AddWithValue("@Telefono", null);
                cmd.Parameters.AddWithValue("@Calle", null);
                cmd.Parameters.AddWithValue("@Numero_Exterior", null);
                cmd.Parameters.AddWithValue("@Colonia", null);
                cmd.Parameters.AddWithValue("@Entidad", null);
                cmd.Parameters.AddWithValue("@Query", 4);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                custlist = new List<Provedores>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Provedores cobj = new Provedores();
                    cobj.Codigo_proveedor = ds.Tables[0].Rows[i]["Codigo_proveedor"].ToString();
                    cobj.Razon_social = ds.Tables[0].Rows[i]["Razon_social"].ToString();
                    cobj.RFC = ds.Tables[0].Rows[i]["RFC"].ToString();
                    cobj.Telefono = ds.Tables[0].Rows[i]["Telefono"].ToString();
                    cobj.Calle = ds.Tables[0].Rows[i]["Calle"].ToString();
                    cobj.Numero_Exterior = ds.Tables[0].Rows[i]["Numero_Exterior"].ToString();
                    cobj.Telefono = ds.Tables[0].Rows[i]["Colonia"].ToString();
                    cobj.Calle = ds.Tables[0].Rows[i]["Entidad"].ToString();
                    custlist.Add(cobj);
                }
                return custlist;
            }
            catch
            {
                return custlist;
            }
            finally
            {
                con.Close();
            }
        }

        public Provedores SelectDatabyID(string CustomerID)
        {
            SqlConnection con = null;
            DataSet ds = null;
            Provedores cobj = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo_proveedor", null);
                cmd.Parameters.AddWithValue("@Razon_social", null);
                cmd.Parameters.AddWithValue("@RFC", null);
                cmd.Parameters.AddWithValue("@Telefono", null);
                cmd.Parameters.AddWithValue("@Calle", null);
                cmd.Parameters.AddWithValue("@Numero_Exterior", null);
                cmd.Parameters.AddWithValue("@Colonia", null);
                cmd.Parameters.AddWithValue("@Entidad", null);
                cmd.Parameters.AddWithValue("@Query", 5);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cobj = new Provedores();
                    cobj.Codigo_proveedor = ds.Tables[0].Rows[i]["Codigo_proveedor"].ToString();
                    cobj.Razon_social = ds.Tables[0].Rows[i]["Razon_social"].ToString();
                    cobj.RFC = ds.Tables[0].Rows[i]["RFC"].ToString();
                    cobj.Telefono = ds.Tables[0].Rows[i]["Telefono"].ToString();
                    cobj.Calle = ds.Tables[0].Rows[i]["Calle"].ToString();
                    cobj.Numero_Exterior = ds.Tables[0].Rows[i]["Numero_Exterior"].ToString();
                    cobj.Telefono = ds.Tables[0].Rows[i]["Colonia"].ToString();
                    cobj.Calle = ds.Tables[0].Rows[i]["Entidad"].ToString();

                }
                return cobj;
            }
            catch
            {
                return cobj;
            }
            finally
            {
                con.Close();
            }
        }
    }
}