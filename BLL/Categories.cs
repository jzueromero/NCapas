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
        public Categories Create(Categories newCategories)
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                newCategories = r.Create(newCategories);
            }
            return newCategories;
        }
    }
}
