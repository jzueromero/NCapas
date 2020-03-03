using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository : IDisposable
    {
        //Para agregar una entidad a la base de datos
        TEntity Create<TEntity>(TEntity ToCreate) where TEntity : class;

        //Para eliminar una entidad
        bool Delete<TEntity>(TEntity toDelete) where TEntity : class;

        // Para Actualizar una entidad
        bool Update<TEntity>(TEntity toUpdate) where TEntity : class;

        // Para recuperar una entidad en vase a un criterio
        TEntity Retrieve<TEntity>(Expression<Func<TEntity, bool>> criteria)
            where TEntity : class;

        //Para recuperar un conjunto de entidades
        //Que cumplan con un criterio de busqueda
        List<TEntity> Filter<TEntity>(Expression<Func<TEntity, bool>> criteria)
            where TEntity : class;
    }
}
