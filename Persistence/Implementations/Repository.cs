using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;

namespace Persistence.Implementations
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected readonly DataContext Context;
        protected Repository(DataContext context) {
            Context = context;
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetEntityWithSpec(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> ListAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public TEntity Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            return entity;
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity oldEntity, TEntity newEntity)
        {
            // Context.Set<TEntity>().Update(entity);

            Context.Set<TEntity>().Entry(oldEntity).CurrentValues.SetValues(newEntity);
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec) {
            return SpecificationEvaluator<TEntity, TKey>.GetQuery(Context.Set<TEntity>().AsQueryable(), spec);
        }
    }
}