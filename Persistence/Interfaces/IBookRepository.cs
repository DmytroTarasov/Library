using Domain;

namespace Persistence.Interfaces
{
    public interface IBookRepository : IRepository<Book, int>
    {
        // Task<IEnumerable<Book>> GetAllBooks(string orderBy);
        // Task<IEnumerable<Book>> GetHighRatedBooksWithManyReviews(string genre);
    }
}