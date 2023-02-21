using Application.Core;
using Application.DTOs;
using MediatR;

namespace Application.Services.Interfaces
{
    public interface IBookService
    {
        Task<Result<IEnumerable<BookDTO<int>>>> GetAllBooks(string orderBy);
        Task<Result<IEnumerable<BookDTO<int>>>> GetHighRatedBooks(string genre);
        Task<Result<BookDetailsDTO<int>>> GetBookByIdWithReviews(int bookId);
        Task<Result<Unit>> DeleteBookById(int bookId, string secretKey);
        Task<Result<EntityIdResponse>> SaveBook(BaseBookDTO<int> bookDTO);
        Task<Result<EntityIdResponse>> SaveReviewForBook(ReviewDTO<int> reviewDTO, int bookId);
        Task<Result<EntityIdResponse>> RateBook(RatingDTO<int> ratingDTO, int bookId);
    }
}