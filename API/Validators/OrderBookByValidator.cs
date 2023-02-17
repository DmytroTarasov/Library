using API.Helpers;
using FluentValidation;

namespace API.Validators
{
    public class OrderBookByValidator : AbstractValidator<OrderBookByParams>
    {
        public OrderBookByValidator()
        {
            RuleFor(o => o.Order).Must(o => new List<string>() { "title", "author" }.Contains(o))
                .WithMessage("You can order either by title or author");   
        }
    }
}