using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.BO.Producto
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string CodigoBarra { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}