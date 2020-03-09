using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//referencias
//using NWindProxyService;
using EntitiesStandart;

namespace NWind.MVCCPLS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            //aqui para obtener productos de la categoria
            var Proxy = new BLL.Product();
            var Products = Proxy.FilterByCategoryID(id);
            return View("ProductList", Products);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            //var Proxy = new Proxy();
            var Proxy = new BLL.Product();
            var Model = Proxy.RetrieveById(id);
            return View(Model);
        }

        public ActionResult CUD(int id = 0)
        {
            var Proxy = new BLL.Product();
            var Model = new Products();
            if (id != 0)
            {
                Model = Proxy.RetrieveById(id);
            }
            return View(Model);
        }

        [HttpPost]
        public ActionResult CUD(Products newProduct,
            string CreateBtn, string UpdateBtn, string DeleteBtn)
        {
            Products Producto;
            //var Proxy = new Proxy();
            var Proxy = new BLL.Product();
            ActionResult Result = View();

            if (CreateBtn != null)
            {
                Producto = Proxy.Create(newProduct);
                if (Producto != null)
                {
                    Result = RedirectToAction("CUD", new { id = Producto.ProductID });
                }
            }
            else if (UpdateBtn != null) //modificacion de producto
            {
                var IsUpdate = Proxy.Update(newProduct);
                if (IsUpdate)
                {
                    Result = Content("El producto se ha actualizado");
                }
            }
            else if (DeleteBtn != null) //eliminar producto
            {
                var DeletedProduct = Proxy.Delete(newProduct.ProductID);
                if (DeletedProduct)
                {
                    Result = Content("El producto se ha eliminado");
                }
            }
            return Result;
        }
    }
}