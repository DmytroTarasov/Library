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

        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetBookById(int bookId) {
            return HandleResult(await _bookService.GetBookByIdWithReviews(bookId));
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBookById([FromQuery] DeleteBookParams deleteBookParams, int bookId) {
            return HandleResult(await _bookService.DeleteBookById(bookId, deleteBookParams.SecretKey));
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveBook([FromForm] SaveBookDTO<int> bookDTO) {
            return HandleResult(await _bookService.SaveBook(bookDTO));
        }
    }
}