using Domain;

namespace Persistence.Implementations
{
    public class BookByIdWithReviewsSpecification : BaseSpecification<Book>
    {
        public BookByIdWithReviewsSpecification(int bookId)
            : base(b => b.Id == bookId)
        {
            AddInclude(b => b.Reviews);
            AddInclude(b => b.Ratings);
        }
    }
}