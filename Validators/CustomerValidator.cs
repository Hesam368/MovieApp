using FluentValidation;
using MovieApp.Models;

namespace MovieApp.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Name)
                .NotEmpty()
                .WithMessage("Please enter a name!")
                .MaximumLength(60)
                .WithMessage("The name must be at most 60 characters!");
            RuleFor(customer => customer.Birthdate)
                .NotEmpty()
                .WithMessage("Please enter a birthdate!");
            RuleFor(customer => customer.MembershipTypeId)
                .NotEmpty()
                .WithMessage("Please select a membership type!");
        }
    }
}
