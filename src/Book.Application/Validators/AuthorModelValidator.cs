using FluentValidation;

namespace Book.Application.Validators;

public class AuthorModelValidator : AbstractValidator<AuthorModel>
{
    public AuthorModelValidator()
    {
        RuleFor(a => a.Name).MaximumLength(60).WithMessage("Author name must contain a maximum of 60 characters");
        RuleFor(a => a.Age).GreaterThan(0).WithMessage("Author age must greater than 0");
    }
}
