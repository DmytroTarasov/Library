using Application.DTOs;
using FluentValidation;

namespace API.Validators
{
    public class RateBookValidator : AbstractValidator<RatingDTO<int>>
    {
        public RateBookValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(r => r.Score)
                .NotNull()
                .WithMessage("Score is required")
                .InclusiveBetween(1, 5)
                .WithMessage("Score must be from 1 to 5");          
        }
    }
}