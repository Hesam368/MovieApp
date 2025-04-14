using FluentValidation;
using MovieApp.Models;

namespace MovieApp.Validators
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(movie => movie.Title)
                .NotEmpty()
                .WithMessage("Please enter a title!")
                .MaximumLength(60)
                .WithMessage("The title must be at most 60 characters!");
        }
    }
}
