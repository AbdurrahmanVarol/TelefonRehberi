using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities.Abstract;

namespace TelefonRehberi.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity,new()
    {
        TEntity Add(TEntity entity);
        TEntity Delete(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Get(Expression<Func<TEntity,bool>> filter);
        List<TEntity> GetAll(Expression<Func<TEntity,bool>> filter = null);

    }
}
