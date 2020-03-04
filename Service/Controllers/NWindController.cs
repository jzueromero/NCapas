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
        public EntitiesStandart.Categories CreateCategory(EntitiesStandart.Categories newCategory)
        {
            throw new NotImplementedException();
        }

        public Products CreateProduct(Products newProduct)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Products> FilterProductByCategoryID(int ID)
        {
            throw new NotImplementedException();
        }

        public Products RetrieveProductById(int ID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Products ProductToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
