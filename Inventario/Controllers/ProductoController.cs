using Engine.BL;
using Inventario.BO.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.Controllers
{
    public class ProductoController : Controller
    {
        ProductoBL _bl = new ProductoBL();
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GET_DATA_PRODUCT() { return Json(_bl.GET_DATA_PRODUCT(), JsonRequestBehavior.AllowGet); }

        [HttpGet]
        public JsonResult SEARCH_DATA_PRODUCT(int inpNumPro, string inpNombre) { return Json(_bl.SEARCH_DATA_PRODUCT(inpNumPro, inpNombre), JsonRequestBehavior.AllowGet); }

        [HttpPost]
        public JsonResult UPDATE_DATA_PRODUCT(List<Producto> rows) { return Json(_bl.UPDATE_DATA_PRODUCT(rows), JsonRequestBehavior.AllowGet); }

        [HttpPost]
        public JsonResult DELETE_PRODUCT(List<Producto> rows) { return Json(_bl.DELETE_PRODUCT(rows), JsonRequestBehavior.AllowGet); }

        [HttpPost]
        public JsonResult ADD_DATA_PRODUCT(string inpCodMod, string inpDescMod, decimal inpPrecioMod, decimal inpCantidadMod) { return Json(_bl.ADD_DATA_PRODUCT(inpCodMod, inpDescMod, inpPrecioMod, inpCantidadMod), JsonRequestBehavior.AllowGet); }
    }
}