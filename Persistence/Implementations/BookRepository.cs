using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;

namespace Persistence.Implementations
{
    public class BookRepository : Repository<Book, int>, IBookRepository
    {
        public BookRepository(DataContext context) : base(context)
        {
        }
        // public async Task<IEnumerable<Book>> GetAllBooks(string orderBy)
        // {
        //     var query = Context.Books
        //         .Include(b => b.Reviews)
        //         .Include(b => b.Ratings)
        //         .AsQueryable();
            
        //     if (orderBy == "author") {
        //         query = query.OrderBy(b => b.Author);
        //     }
        //     if (orderBy == "title") {
        //         query = query.OrderBy(b => b.Title);
        //     }

        //     return await query.ToListAsync();
        // }

        // public Task<IEnumerable<Book>> GetHighRatedBooksWithManyReviews(string genre)
        // {
        //     var query = Context.Books
        //         .Include(b => b.Reviews)
        //         .Include(b => b.Ratings)
        //         .AsQueryable();
        // }
    }
}