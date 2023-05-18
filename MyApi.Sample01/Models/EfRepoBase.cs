using Microsoft.EntityFrameworkCore;
using MyApi.Sample01.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyApi.Sample01.Models
{

    public class EfRepoBase<TEntity, Tcontext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
   where Tcontext : DbContext, new()

    {
        public void Add(TEntity entity)
        {
            using (var context = new Tcontext())
            {
                // var deger = context.Add(entity);
                var added = context.Entry(entity);
                added.State = EntityState.Added;
                var deger = context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new Tcontext())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Deleted;
                var deger = context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var db = new Tcontext())
            {

                return db.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var db = new Tcontext())
            {
                return filter == null
                    ? db.Set<TEntity>().ToList()
                    : db.Set<TEntity>().Where(filter).ToList();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            List<TEntity> entities;
            using (var context = new Tcontext())
            {
                entities = await context.Set<TEntity>().ToListAsync();
            }
            return entities;
        }

        public void Update(TEntity entity)
        {
            using (var context = new Tcontext())
            {
                // context.Set<TEntity>().Update(entity);

                var updated = context.Entry(entity);
                updated.State = EntityState.Modified;
                var deger = context.SaveChanges();
            }
        }
    }
}

