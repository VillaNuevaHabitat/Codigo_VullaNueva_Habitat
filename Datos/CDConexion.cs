using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VillaNueva_Habitat.Datos
{
    public class CDConexion
    {
        //public readonly string Conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();

        private SqlConnection Conexion = new SqlConnection("Data Source=LAPTOP-L7GOJV94\\SQLEXPRESS; Initial Catalog=control_obra; Integrated Security=true;");

        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }

        ////private SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ToString());

        ////public SqlConnection AbrirConexion()
        ////{
        ////    if (Conexion.State == ConnectionState.Closed)
        ////        Conexion.Open();
        ////    return Conexion;
        ////}
        ////public SqlConnection CerrarConexion()
        ////{
        ////    if (Conexion.State == ConnectionState.Open)
        ////        Conexion.Close();
        ////    return Conexion;
        ////}
    }
}