using Application.Books;
using Application.Core;

namespace Application.Services.Interfaces
{
    public interface IBookService
    {
        Task<Result<IEnumerable<BookDTO<int>>>> GetAllBooks(string orderBy);
        Task<Result<IEnumerable<BookDTO<int>>>> GetHighRatedBooks(string genre);
    }
}