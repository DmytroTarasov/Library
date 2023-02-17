using Domain;

namespace Persistence.Implementations
{
    public class HighRatedBooksWithManyReviewsSpecification : BaseSpecification<Book>
    {
        public HighRatedBooksWithManyReviewsSpecification(string genre) : base(b => 
            b.Ratings.Select(r => r.Score).DefaultIfEmpty().Average() >= 2 && b.Reviews.Count > 5 &&
            (string.IsNullOrEmpty(genre) || b.Genre == genre))
        {    
            AddInclude(b => b.Reviews);
            AddInclude(b => b.Ratings);
        }
    }
}