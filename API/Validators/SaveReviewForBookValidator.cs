using Application.DTOs;
using FluentValidation;

namespace API.Validators
{
    public class SaveReviewForBookValidator : AbstractValidator<ReviewDTO<int>>
    {
        public SaveReviewForBookValidator()
        {
            RuleFor(r => r.Message).NotEmpty()
                .WithMessage("Message is required");   

            RuleFor(r => r.Reviewer).NotEmpty()
                .WithMessage("Reviewer is required");  
        } 
    }
}