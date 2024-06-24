using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Engine.BO.Constans;
using System.Data;
using Inventario.BO.Producto;


namespace Engine.DAL
{
    public class ProductoDAL : SqlConexion
    {
        public Result GET_DATA_PRODUCT()
        {
            Result response = new Result() { data = new List<Producto>() };

            List<Producto> listProd = new List<Producto>();

            using (conectar())
            {
                try
                {
                    using(SqlCommand cmd = new SqlCommand("SP_GET_DATA_PRODUCT", conectar()))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                listProd.Add(
                                    new Producto()
                                    {
                                        IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                        CodigoBarra = dr["CodigoBarra"].ToString(),
                                        Descripcion = dr["Descripcion"].ToString(),
                                        Precio = Convert.ToDecimal(dr["Precio"]),
                                        Cantidad = Convert.ToInt32(dr["Cantidad"])
                                    }
                                 );
                            }
                            response.data = listProd;
                            response.result = "OK";
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return response;
        }

        public Result SEARCH_DATA_PRODUCT(int inpNumPro, string inpNombre)
        {
            Result response = new Result();

            List<Producto> listProd = new List<Producto>();

            using (conectar())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_SEARCH_DATA_PRODUCT", conectar()))
                    {
                        cmd.Parameters.AddWithValue("inpNumPro", inpNumPro);
                        cmd.Parameters.AddWithValue("inpNombre", inpNombre);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                listProd.Add(
                                    new Producto()
                                    {
                                        IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                        CodigoBarra = dr["CodigoBarra"].ToString(),
                                        Descripcion = dr["Descripcion"].ToString(),
                                        Precio = Convert.ToDecimal(dr["Precio"]),
                                        Cantidad = Convert.ToInt32(dr["Cantidad"])
                                    }
                                 );
                            }
                            response.data = listProd;
                            response.result = "OK";
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return response;
        }

        public Result UPDATE_DATA_PRODUCT(Producto item)
        {
            Result response = new Result();

            using (conectar())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UPDATE_DATA_PRODUCT", conectar()))
                    {
                        cmd.Parameters.AddWithValue("IdProducto",  item.IdProducto);
                        cmd.Parameters.AddWithValue("Descripcion", item.Descripcion);
                        cmd.Parameters.AddWithValue("Precio",      item.Precio);
                        cmd.Parameters.AddWithValue("Cantidad",    item.Cantidad);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteReader();
                        response.result = "OK";
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return response;
        }

        public Result DELETE_PRODUCT(Producto item)
        {
            Result response = new Result();

            using (conectar())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DELETE_PRODUCT", conectar()))
                    {
                        cmd.Parameters.AddWithValue("IdProducto", item.IdProducto);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteReader();
                        response.result = "OK";
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return response;
        }


        public Result ADD_DATA_PRODUCT(string inpCodMod, string inpDescMod, decimal inpPrecioMod, decimal inpCantidadMod)
        {
            Result response = new Result();

            using (conectar())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ADD_DATA_PRODUCT", conectar()))
                    {
                        cmd.Parameters.AddWithValue("Codigo", inpCodMod);
                        cmd.Parameters.AddWithValue("Descripcion", inpDescMod);
                        cmd.Parameters.AddWithValue("Precio", inpPrecioMod);
                        cmd.Parameters.AddWithValue("Cantidad", inpCantidadMod);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteReader();
                        response.result = "OK";
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return response;
        }
    }
}