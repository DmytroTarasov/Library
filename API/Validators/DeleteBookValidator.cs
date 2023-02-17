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

            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(o => o.SecretKey).NotEmpty()
                .WithMessage("Secret key is required");

            RuleFor(o => o.SecretKey).Equal(_config["SecretKey"])
                .WithMessage("Please, provide a valid secret key in order to delete a book");
        }  
    }
}