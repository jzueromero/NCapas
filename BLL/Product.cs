using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EntitiesStandart;

namespace BLL
{
    public class Product
    {
        public Products Create(Products newProduct)
        {
            Products Result = null;
            using (var r = RepositoryFactory.CreateRepository() )
            {
                //Buscar si el nombre del producto existe
                Products res = r.Retrieve<Products>(p => p.ProductName ==
                newProduct.ProductName);
                if (res == null)
                {
                    //No existe, podemos crearlo
                    Result = r.Create(newProduct);
                }
                else
                {
                    // Podríamos aquí lanzar una excepción
                    // para notificar que el producto ya existe.
                    // Podríamos incluso crear una capa de Excepciones
                    // personalizadas y consumirla desde otras
                    // capas. 
                }
                return Result;
            }
        }

        public Products RetrieveById(int ID)
        {
            Products Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Retrieve<Products>(p => p.ProductID == ID);
            }
            return Result;
        }

        public bool Update(Products productToUpdate)
        {
            bool Result = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                //validar que el nombre de producto exista
                Products temp = r.Retrieve<Products>
                    (p => p.ProductName == productToUpdate.ProductName);
                if (temp == null)
                {
                    //no existe
                    Result = r.Update(productToUpdate);
                }
                else
                {
                    // Podemos implementar alguna lógica para
                    // indicar que no se pudo modificar
               }
            }
            return Result;
        }

        public bool Delete(int ID)
        {
            bool Result = false;
            //Buscar el producto para ver si tiene existencias
            var Producto = RetrieveById(ID);
            if (Producto != null)
            {
                if (Producto.UnitsInStock == 0)
                {
                    using (var r = RepositoryFactory.CreateRepository())
                    {
                        Result = r.Delete(Producto);
                    }
                }
                else
                {
                    // Podemos implementar alguna lógica adicional
                    // para indicar que no se pudo eliminar el producto
                }
            }
            else
            {
                // Podemos implementar alguna lógica
                // para indicar que el producto no existe

            }
            return Result;
        }

        public List<Products> FilterByCategoryID(int categoryId)
        {
            List<Products> Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Filter<Products>
                    (p => p.CategoryID == categoryId);
            }
            return Result;
        }
    }
}
