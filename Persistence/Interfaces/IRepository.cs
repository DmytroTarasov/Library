using Domain;

namespace Persistence.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> ListAllAsync();
        Task<TEntity> GetEntityWithSpec(ISpecification<TEntity> spec);
        Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity> spec);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}