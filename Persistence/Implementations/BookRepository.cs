using Domain;
using Persistence.Interfaces;

namespace Persistence.Implementations
{
    public class BookRepository : Repository<Book, int>, IBookRepository
    {
        public BookRepository(DataContext context) : base(context)
        {
        }
    }
}