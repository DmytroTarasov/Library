using Application.Core;
using Application.DTOs;
using Application.Services.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.Extensions.Configuration;
using Persistence.Implementations;
using Persistence.Interfaces;

namespace Application.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public BookService(IUnitOfWork uof, IMapper mapper, IConfiguration config)
        {
            _uof = uof;
            _mapper = mapper;
            _config = config;
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
        public async Task<Result<BookDetailsDTO<int>>> GetBookByIdWithReviews(int bookId)
        {
            var spec = new BookByIdWithReviewsSpecification(bookId);
            var book = await _uof.BookRepository.GetEntityWithSpec(spec);
            var bookDTO = _mapper.Map<Book, BookDetailsDTO<int>>(book);

            return Result<BookDetailsDTO<int>>.Success(bookDTO);
        }

        public async Task<Result<Unit>> DeleteBookById(int bookId, string secretKey)
        {
            var book = await _uof.BookRepository.GetByIdAsync(bookId);
            if (book == null) return Result<Unit>.Failure("The book with such id doesn't exist");
            
            _uof.BookRepository.Remove(book);
            var result = await _uof.Complete();

            if (!result) return Result<Unit>.Failure("Failed to create a dish");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}