using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PMS.DAL
{
  public interface IGenericRepository<TEntity> where TEntity : class
  {
    IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate = null);
    TEntity Get(Func<TEntity, bool> predicate = null);
    TEntity Insert(TEntity entity);
    void Update(TEntity entity);
    void Update(TEntity oldEntity, TEntity newEntity);
    void Delete(TEntity entity);
    void DeleteRange(IQueryable<TEntity> entities);
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        bool Any(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,

             bool disableTracking = false);
        int GetRecordCount(Expression<Func<TEntity, bool>> predicate);
    IEnumerable<TEntity> GetDistinct(IEqualityComparer<TEntity> Comparer);
    void Delete(Expression<Func<TEntity, bool>> predicate);
  }
}
