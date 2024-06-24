using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Engine.BO.Constans
{
    public class SqlConexion
    {
        SqlConnection con = null;

        public SqlConnection conectar()
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                con.Open();
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
            return con;
        }

        public void desconectar()
        {
            if (con.State == ConnectionState.Open) con.Close();
        }
    }
}