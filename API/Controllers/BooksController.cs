using API.Helpers;
using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BooksController : BaseApiController
    {
        private IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;    
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks([FromQuery] OrderBookByParams orderBookParams) {
            return HandleResult(await _bookService.GetAllBooks(orderBookParams.Order));
        }

        [HttpGet("recommended")]
        public async Task<IActionResult> GetHighRatedBooks([FromQuery] string genre) {
            return HandleResult(await _bookService.GetHighRatedBooks(genre));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id) {
            return HandleResult(await _bookService.GetBookByIdWithReviews(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookById([FromQuery] DeleteBookParams deleteBookParams, int id) {
            return HandleResult(await _bookService.DeleteBookById(id, deleteBookParams.Secret));
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveBook([FromBody] BaseBookDTO<int> bookDTO) {
            return HandleResult(await _bookService.SaveBook(bookDTO));
        }

        [HttpPut("{id}/review")]
        public async Task<IActionResult> SaveReviewForBook([FromBody] ReviewDTO<int> reviewDTO, int id) {
            return HandleResult(await _bookService.SaveReviewForBook(reviewDTO, id));
        }

        [HttpPut("{id}/rate")]
        public async Task<IActionResult> RateBook([FromBody] RatingDTO<int> ratingDTO, int id) {
            return HandleResult(await _bookService.RateBook(ratingDTO, id));
        }
    }
}