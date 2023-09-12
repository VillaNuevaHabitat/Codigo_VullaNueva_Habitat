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
      
         private SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["VillaNuevaConn"].ToString());

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
    }
}