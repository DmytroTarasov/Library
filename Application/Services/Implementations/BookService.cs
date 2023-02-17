using Application.Books;
using Application.Core;
using Application.Services.Interfaces;
using AutoMapper;
using Domain;
using Persistence.Implementations;
using Persistence.Interfaces;

namespace Application.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public BookService(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<BookDTO<int>>>> GetAllBooks(string orderBy)
        {
            var spec = new BooksWithReviewsAndRatingsSpecification(orderBy);
            var books = await _uof.BookRepository.ListAsync(spec);
            var booksDTO = _mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO<int>>>(books);

            return Result<IEnumerable<BookDTO<int>>>.Success(booksDTO);
        }

        public async Task<Result<IEnumerable<BookDTO<int>>>> GetHighRatedBooks(string genre)
        {
            var spec = new HighRatedBooksWithManyReviewsSpecification(genre) { Take = 10 };
            var books = await _uof.BookRepository.ListAsync(spec);
            var booksDTO = _mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO<int>>>(books);

            return Result<IEnumerable<BookDTO<int>>>.Success(booksDTO.OrderByDescending(bd => bd.Rating));
        }
    }
}