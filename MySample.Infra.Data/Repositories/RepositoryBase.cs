using MySample.Domain.Interfaces.Repositories;
using MySample.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MySample.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected SampleContext Db;
        protected DbSet<TEntity> DbSet;

        public RepositoryBase()
        {
            Db = new SampleContext();
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
            Db.SaveChanges();
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()//(int s, int t)
        {
            return DbSet.ToList(); //Take(t).Skip(s).ToList();
        }

        public virtual void Update(TEntity obj)
        {
            var entry = Db.Entry(obj);
            //DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            Db.SaveChanges();
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
            Db.SaveChanges();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
