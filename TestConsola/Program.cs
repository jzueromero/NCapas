using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EntitiesStandart;

namespace TestConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            // AddCategoryAndProduct();
            //AddProduct();
            //RetriveAndUpdate();
            //List();
            SearchAndDelete();
            Console.WriteLine("Presione para continuar");
            Console.ReadKey();
        }
        
        static void AddCategoryAndProduct()
        {
            Categories c = new Categories()
            {
                CategoryName = "Cereales"
            };

            Products Cereal = new Products()
            {
                ProductName = "Choco Kripys",
                UnitPrice = 15,
                UnitsInStock = 0
            };
            c.Products.Add(Cereal);

            using (var r = RepositoryFactory.CreateRepository())
            {
                r.Create(c);
            }
            Console.WriteLine($"Categoria:{c.CategoryID}, " +
                $"Producto:{Cereal.ProductID}");

        }

        static void AddProduct()
        {
            Products Avena = new Products
            {
                CategoryID = 1,
                UnitsInStock = 100,
                ProductName = "Avena",
                UnitPrice = 10
            };
            using (var r = RepositoryFactory.CreateRepository())
            {
                r.Create(Avena);
            }
            Console.WriteLine($"Producto: {Avena.ProductID}");
        }

        static void RetriveAndUpdate()
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                //buscar el ultimo agregado
                var P = r.Retrieve<Products>(p => p.ProductID == 2);
                if (P != null)
                {
                    Console.WriteLine(P.ProductName);
                    P.ProductName = P.ProductName + "***";
                    r.Update(P);
                    Console.WriteLine("Nombre modificado");
                }
                else
                {
                    Console.WriteLine("Producto no encontrado");
                }
            }
        }

        static void List()
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                var Productos = r.Filter<Products>(p => p.CategoryID == 1);
                foreach (var p in Productos)
                {
                    Console.WriteLine($"{p.ProductName}");
                }
            }
        }

        static void SearchAndDelete()
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                var P = r.Retrieve<Products>(p => p.ProductID == 2);
                if (P != null)
                {
                    Console.WriteLine(P.ProductName);
                    r.Delete(P);
                    Console.WriteLine("Producto Eliminado");
                }
                else
                {
                    Console.WriteLine("Producto no encontrado");
                }
            }
        }
    }
}
