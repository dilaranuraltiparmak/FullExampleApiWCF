using MyApi.Sample01.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyApi.Sample01.Models
{
    public interface IEntityRepository<TEntity>
     where TEntity : class, IEntity, new()
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> filter = null);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Update(TEntity entity);
    }
}
