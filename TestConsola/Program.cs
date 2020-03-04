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
            AddCategoryAndProduct();
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
    }
}
