using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EFRepository : IRepository
    {
        DbContext Context;
        public EFRepository(DbContext context )
        {
            this.Context = context;
        }

        public TEntity Create<TEntity>(TEntity toCreate) where TEntity : class
        {
            TEntity Result = default(TEntity);
            try
            {
                Context.Set<TEntity>().Add(toCreate);
                Context.SaveChanges();
                Result = toCreate;
            }
            catch { }
            return Result;
        }

    }
}
