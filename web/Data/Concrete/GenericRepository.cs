using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.Data.Abstract;

namespace web.Data.Concrete
{
    public class GenericRepository<TEntity, TContext> : InterfaceRepository<TEntity>
    where TEntity : class
    where TContext : DbContext, new()
    {

        public List<TEntity> GetAll()
        {
            using (var db = new TContext())
            {
                return db.Set<TEntity>().ToList();
            }
        }
        public TEntity GetById(int id)
        {
            using (var db = new TContext())
            {
                return db.Set<TEntity>().Find(id);
            }
        }

        public TEntity GetByName(string name)
        {
            using (var db = new TContext())
            {
                return db.Set<TEntity>().Find(name);
            }
        }

        public TEntity Create(TEntity entity)
        {
            using (var db = new TContext())
            {
                db.Set<TEntity>().Add(entity);
                db.SaveChanges();
                return entity;
            }
        }
        public void Delete(TEntity entity)
        {
            using (var db = new TContext())
            {
                db.Set<TEntity>().Remove(entity);
                db.SaveChanges();
            }
        }
        public virtual void Update(TEntity entity)
        {
            using (var db = new TContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}