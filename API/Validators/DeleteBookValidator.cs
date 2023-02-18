using API.Helpers;
using FluentValidation;

namespace API.Validators
{
    public class DeleteBookValidator : AbstractValidator<DeleteBookParams>
    {
        private readonly IConfiguration _config;

        public DeleteBookValidator(IConfiguration config)
        {
            _config = config;

            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(o => o.Secret)
                .NotEmpty()
                .WithMessage("Secret key is required")
                .Equal(_config["SecretKey"])
                .WithMessage("Please, provide a valid secret key in order to delete a book");
        }  
    }
}