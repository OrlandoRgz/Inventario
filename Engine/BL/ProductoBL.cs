using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Engine.BO;
using Engine.BO.Constans;
using Engine.DAL;
using Inventario.BO.Producto;


namespace Engine.BL
{
    public class ProductoBL
    {
        ProductoDAL objDAL = new ProductoDAL();

        public Result GET_DATA_PRODUCT()
        {
            Result response = new Result();

            response = objDAL.GET_DATA_PRODUCT();

            return response;
        }

        public Result SEARCH_DATA_PRODUCT(int inpNumPro, string inpNombre)
        {
            Result response = new Result();

            response = objDAL.SEARCH_DATA_PRODUCT(inpNumPro, inpNombre);

            return response;
        }

        public Result UPDATE_DATA_PRODUCT(List<Producto> rows)
        {
            Result response = new Result();

            foreach(Producto item in rows)
            {
                response = objDAL.UPDATE_DATA_PRODUCT(item);
            }
            return response;
        }

        public Result DELETE_PRODUCT(List<Producto> rows)
        {
            Result response = new Result();

            foreach (Producto item in rows)
            {
                response = objDAL.DELETE_PRODUCT(item);
            }
            return response;
        }

        public Result ADD_DATA_PRODUCT(string inpCodMod, string inpDescMod, decimal inpPrecioMod, decimal inpCantidadMod)
        {
            Result response = new Result();

            response = objDAL.ADD_DATA_PRODUCT(inpCodMod, inpDescMod, inpPrecioMod, inpCantidadMod);

            return response;
        }
    }
}