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
        [Route("[controller]")]
        public async Task<IActionResult> GetAllBooks([FromQuery] string order) {
            // return HandleResult(await Mediator.Send(new List.Query { OrderBy = order }));
            return HandleResult(await _bookService.GetAllBooks(order));
        }

        [HttpGet]
        [Route("recommended")]
        public async Task<IActionResult> GetHighRatedBooks([FromQuery] string genre) {
            return HandleResult(await _bookService.GetHighRatedBooks(genre));
        }
    }
}