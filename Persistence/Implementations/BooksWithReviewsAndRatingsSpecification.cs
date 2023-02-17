using Domain;

namespace Persistence.Implementations
{
    public class BooksWithReviewsAndRatingsSpecification : BaseSpecification<Book>
    {
        public BooksWithReviewsAndRatingsSpecification(string orderBy) : base()
        {    
            AddInclude(b => b.Reviews);
            AddInclude(b => b.Ratings);
            if (!string.IsNullOrEmpty(orderBy)) {
                switch(orderBy) {
                    case "title":
                        AddOrderBy(b => b.Title);
                        break;
                    case "author":
                        AddOrderBy(b => b.Author);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}