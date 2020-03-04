using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EntitiesStandart;

namespace BLL
{
    public class Categories
    {
        public EntitiesStandart.Categories Create(EntitiesStandart.Categories newCategories)
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                newCategories = r.Create(newCategories);
            }
            return newCategories;
        }
    }
}
