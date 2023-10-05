using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;

namespace VillaNueva_Habitat.Datos
{
    public class DAL_cat_exp_proyecto
    {
        CDConexion cn = new CDConexion();
        SqlCommand cmd = new SqlCommand();


        public List<cat_exp_proyecto> Obtener_exp_proyecto()
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_exp_proyecto_generales";
            cmd.CommandType = CommandType.StoredProcedure;



            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_exp_proyecto> _obtener_cat_exp_proyecto = new List<cat_exp_proyecto>();
                while (dr.Read())
                {
                    cat_exp_proyecto _cat_exp_proyecto = new cat_exp_proyecto()
                    {
                        Id_exp = Convert.ToInt32(dr["Id_exp"]),
                        Nombre = dr["Nombre Cliente"].ToString(),
                        Nombre_Proyecto = dr["Nombre_Proyecto"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        Fecha_inicial = dr["Fecha_inicial"].ToString(),
                        Fecha_Final = dr["Fecha_Final"].ToString(),
                        Responsable = dr["Responsable"].ToString(),
                        Supervisor = dr["Supervisor"].ToString(),
                        Residente = dr["Residente"].ToString(),
                        Estatus = dr["Estatus"].ToString(),
                        Comentarios = dr["Comentarios"].ToString()
                       
                    };
                    _obtener_cat_exp_proyecto.Add(_cat_exp_proyecto);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_exp_proyecto;

            }

        }

        public List<cat_exp_proyecto> Obtener_exp_proyecto_por_id(int Id_expediente)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_obtener_exp_proyecto_generales_por_id";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_expediente", Id_expediente);


            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<cat_exp_proyecto> _obtener_cat_exp_proyecto = new List<cat_exp_proyecto>();
                while (dr.Read())
                {
                    cat_exp_proyecto _cat_exp_proyecto = new cat_exp_proyecto()
                    {
                        Id_exp = Convert.ToInt32(dr["Id_exp"]),
                        Nombre = dr["Nombre"].ToString(),
                        Nombre_Proyecto = dr["Nombre_Proyecto"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        Fecha_inicial = dr["Fecha_inicial"].ToString(),
                        Fecha_Final = dr["Fecha_Final"].ToString(),
                        Responsable = dr["Responsable"].ToString(),
                        Supervisor = dr["Supervisor"].ToString(),
                        Residente = dr["Residente"].ToString(),
                        Estatus = dr["Estatus"].ToString(),
                        Comentarios = dr["Comentarios"].ToString(),
                        Usuario_Creo = dr["Usuario_Creo"].ToString()
                    };
                    _obtener_cat_exp_proyecto.Add(_cat_exp_proyecto);

                }
                cmd.Connection = cn.CerrarConexion();
                return _obtener_cat_exp_proyecto;
            }

        }

        public bool Actualizar_exp_proyecto(cat_exp_proyecto _cat_exp_proyecto)
        {
            int i = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_actualiza_exp_proyecto_generales";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_exp", _cat_exp_proyecto.Id_exp);
            cmd.Parameters.AddWithValue("@Nombre", _cat_exp_proyecto.Nombre);
            cmd.Parameters.AddWithValue("@Nombre_Proyecto", _cat_exp_proyecto.Nombre_Proyecto);
            cmd.Parameters.AddWithValue("@Descripcion", _cat_exp_proyecto.Descripcion);
            cmd.Parameters.AddWithValue("@Fecha_inicial", _cat_exp_proyecto.Fecha_inicial);
            cmd.Parameters.AddWithValue("@Fecha_Final", _cat_exp_proyecto.Fecha_Final);
            cmd.Parameters.AddWithValue("@Responsable", _cat_exp_proyecto.Responsable);
            cmd.Parameters.AddWithValue("@Supervisor", _cat_exp_proyecto.Supervisor);
            cmd.Parameters.AddWithValue("@Residente", _cat_exp_proyecto.Residente);
            cmd.Parameters.AddWithValue("@Estatus", _cat_exp_proyecto.Estatus);
            cmd.Parameters.AddWithValue("@Comentarios", _cat_exp_proyecto.Comentarios);
            cmd.Parameters.AddWithValue("@Usuario_Creo", _cat_exp_proyecto.Usuario_Creo);

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

        public bool Agregar_exp_proyecto(cat_exp_proyecto _cat_exp_proyecto)
        {
            int respuesta = 0;

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "usp_inserta_exp_proyecto_generales";
            cmd.CommandType = CommandType.StoredProcedure;

           // cmd.Parameters.AddWithValue("@Id_exp", _cat_exp_proyecto.Id_exp);
            cmd.Parameters.AddWithValue("@Id_contacto", _cat_exp_proyecto.Id_contacto);
            cmd.Parameters.AddWithValue("@Nombre_Proyecto", _cat_exp_proyecto.Nombre_Proyecto);
            cmd.Parameters.AddWithValue("@Descripcion", _cat_exp_proyecto.Descripcion);
            cmd.Parameters.AddWithValue("@Fecha_inicial", _cat_exp_proyecto.Fecha_inicial);
            cmd.Parameters.AddWithValue("@Fecha_Final", _cat_exp_proyecto.Fecha_Final);
            cmd.Parameters.AddWithValue("@Responsable", _cat_exp_proyecto.Responsable);
            cmd.Parameters.AddWithValue("@Supervisor", _cat_exp_proyecto.Supervisor);
            cmd.Parameters.AddWithValue("@Residente", _cat_exp_proyecto.Residente);
            cmd.Parameters.AddWithValue("@Estatus", _cat_exp_proyecto.Estatus);
            cmd.Parameters.AddWithValue("@Comentarios", _cat_exp_proyecto.Comentarios);
            cmd.Parameters.AddWithValue("@Usuario_Creo", _cat_exp_proyecto.Usuario_Creo);

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

        public string Eliminar_exp_proyecto(int id)
        {
            string respuesta = string.Empty;
            try
            {
                cmd.Connection = cn.AbrirConexion();
                cmd.CommandText = "usp_eliminar_exp_proyecto_generales";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_exp", id);
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