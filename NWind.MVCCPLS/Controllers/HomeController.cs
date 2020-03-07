﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//referencias
using NWindProxyService;
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
            var Proxy = new Proxy();
            var Products = Proxy.FilterProductByCategoryID(id);
            return View("ProductList", Products);
        }
    }
}