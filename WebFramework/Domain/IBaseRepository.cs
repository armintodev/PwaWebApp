using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebFramework.Domain
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        DbSet<TEntity> Entities { get; }
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        TEntity GetById(params object[] ids);
        ValueTask<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);
        void Add(TEntity entity, bool saveNow = true);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
        void AddRange(IEnumerable<TEntity> entities, bool saveNow = true);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
        void Update(TEntity entity, bool saveNow = true);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
        void UpdateRange(IEnumerable<TEntity> entities, bool saveNow = true);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
        void Delete(TEntity entity, bool saveNow = true);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
        void DeleteRange(IEnumerable<TEntity> entities, bool saveNow = true);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
        Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> expression);
        bool IsExists(Expression<Func<TEntity, bool>> expression);
        Task SaveChangesAsync();
        void SaveChanges();
        void Attach(TEntity entity);
        void Detach(TEntity entity);
        void LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty) where TProperty : class;
        Task LoadCollectionAsync<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty, CancellationToken cancellationToken) where TProperty : class;
        void LoadReference<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty) where TProperty : class;
        Task LoadReferenceAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty, CancellationToken cancellationToken) where TProperty : class;
    }
}
