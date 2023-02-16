using Application.Books;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BooksController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllDishes([FromQuery] string orderBy) {
            return HandleResult(await Mediator.Send(new List.Query { OrderBy = orderBy }));
        }
    }
}