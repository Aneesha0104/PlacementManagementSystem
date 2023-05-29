using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PMS.DAL.Models;

namespace PMS.DAL
{
    public abstract class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : class
    {
        public PmsdbContext _dbContext;
        protected DbSet<Tentity> _Dbset;

        public GenericRepository(PmsdbContext Context)
        {
            _dbContext = Context;
            _Dbset = _dbContext.Set<Tentity>();
        }
        public IEnumerable<Tentity> GetAll(Func<Tentity, bool> predicate = null, params Expression<Func<Tentity, object>>[] includeProperties)
        {
            IQueryable<Tentity> query = _Dbset.AsQueryable();
            foreach (var include in includeProperties)
            {
                query=query.Include(include);
            }
            if (predicate == null)
            {
                return query ==null ?_Dbset.AsQueryable() :query.AsQueryable();
            }
            return query.Where(predicate).AsQueryable();
        }
        public Tentity Get(Func<Tentity, bool> predicate = null, params Expression<Func<Tentity, object>>[] includeProperties)
        {
            IQueryable<Tentity> query = _Dbset;
            foreach (var include in includeProperties)
            {
                query = _Dbset.Include(include);
            }
            return query.SingleOrDefault();
        }
        public void Delete(Tentity entity)
        {
            _dbContext.Set<Tentity>().Remove(entity);
            _dbContext.SaveChanges();
        }
       

        public void Update(Tentity entity)
        {
            _dbContext.Set<Tentity>().Update(entity);
            _dbContext.SaveChanges();
        }
        public void Update(Tentity oldEntity, Tentity newEntity)
        {
            _dbContext.Entry<Tentity>(oldEntity).CurrentValues.SetValues(newEntity);
            _dbContext.SaveChanges();
        }
        public IQueryable<Tentity> Find(Expression<Func<Tentity, bool>> predicate)
        {
            IQueryable<Tentity> query = _Dbset.Where(predicate);
            return query;
        }

        public Tentity FirstOrDefault(Expression<Func<Tentity, bool>> predicate = null,
            Func<IQueryable<Tentity>, IOrderedQueryable<Tentity>> orderBy = null,
            Func<IQueryable<Tentity>, IIncludableQueryable<Tentity, object>> include = null,
            bool disableTracking = false)
        {

            IQueryable<Tentity> query = _Dbset;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).FirstOrDefault();
            }
            else
            {
                return query.FirstOrDefault();
            }
        }

        public int GetRecordCount(Expression<Func<Tentity, bool>> predicate)
        {
            return _Dbset.Count(predicate);
        }

        public IEnumerable<Tentity> GetDistinct(IEqualityComparer<Tentity> Comparer)
        {
            IEnumerable<Tentity> query = _Dbset.AsEnumerable().Distinct(Comparer);
            return query;
        }
        public void Delete(Expression<Func<Tentity, bool>> predicate)
        {
            IQueryable<Tentity> records = from x in _Dbset.Where(predicate) select x;
            foreach (Tentity record in records)
            {
                _Dbset.Remove(record);
            }
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
            _dbContext = null;
            GC.SuppressFinalize(this);
        }

        public Tentity Insert(Tentity entity)
        {
            _dbContext.Set<Tentity>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void DeleteRange(IQueryable<Tentity> entities)
        {
            _dbContext.Set<Tentity>().RemoveRange(entities);
            _dbContext.SaveChanges();
        }

        public bool Any(Expression<Func<Tentity, bool>> predicate)
        {
            bool query = _Dbset.Any(predicate);
            return query;
        }
    }
}
