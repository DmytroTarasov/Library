using System.Linq.Expressions;
using Persistence.Interfaces;

namespace Persistence.Implementations
{
    public class BaseSpecification<TEntity> : ISpecification<TEntity>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<TEntity, bool>> Criteria { get; }

        public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();

        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }

        public int Take { get; set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression) {
            Includes.Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression) {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescExpression) {
            OrderByDescending = orderByDescExpression;
        }
        protected void ApplyPaging(int skip, int take) {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}