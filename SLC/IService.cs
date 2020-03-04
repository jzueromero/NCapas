using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesStandart;

namespace SLC
{
    public interface IService
    {
        Products CreateProduct(Products newProduct);
        Products RetrieveProductById(int ID);
        bool UpdateProduct(Products ProductToUpdate);
        bool DeleteProduct(int ID);
        List<Products> FilterProductByCategoryID(int ID);
        Categories CreateCategory(Categories newCategory);
    }
}
