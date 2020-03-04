using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntitiesStandart;
using BLL;
using SLC;

namespace Service.Controllers
{
    public class NWindController : ApiController, IService
    {
        [HttpPost]
        public EntitiesStandart.Categories CreateCategory(EntitiesStandart.Categories newCategory)
        {
            var BL = new BLL.Categories();
            var NewCategory = BL.Create(newCategory);
            return NewCategory;
        }

        [HttpPost]
        public Products CreateProduct(Products newProduct)
        {
            var BL = new BLL.Product();
            var NewProduct = BL.Create(newProduct);
            return NewProduct;
        }
        [HttpGet]
        public bool DeleteProduct(int ID)
        {
            var BL = new Product();
            var resul = BL.Delete(ID);
            return resul;
        }
        [HttpGet]
        public List<Products> FilterProductByCategoryID(int ID)
        {
            var BL = new BLL.Product();
            var result = BL.FilterByCategoryID(ID);
            return result;
        }
        [HttpGet]
        public Products RetrieveProductById(int ID)
        {
            var BL = new BLL.Product();
            var Result = BL.RetrieveById(ID);
            return Result;
        }
        [HttpPost]
        public bool UpdateProduct(Products ProductToUpdate)
        {
            var BL = new BLL.Product();
            var Result = BL.Update(ProductToUpdate);
            return Result;
        }
    }
}
