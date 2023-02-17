using Application.DTOs;
using FluentValidation;

namespace API.Validators
{
    public class SaveBookValidator : AbstractValidator<SaveBookDTO<int>>
    {
        public SaveBookValidator()
        {
            RuleFor(b => b.Title).NotEmpty()
                .WithMessage("Title is required");   

            RuleFor(b => b.Cover).NotEmpty()
                .WithMessage("Cover is required");  

            RuleFor(b => b.Content).NotEmpty()
                .WithMessage("Content is required");   
            
            RuleFor(b => b.Genre).NotEmpty()
                .WithMessage("Genre is required");   
            
            RuleFor(b => b.Author).NotEmpty()
                .WithMessage("Author is required");   
        } 
    }
}