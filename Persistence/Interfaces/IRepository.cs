using Domain;

namespace Persistence.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> Get(TKey id);
        Task<IEnumerable<TEntity>> GetAll();
        TEntity Add(TEntity entity);
        void Remove(TEntity entity);
    }
}