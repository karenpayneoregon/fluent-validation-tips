using FluentValidation;
using ValidationLibrary.Models;

namespace ValidationLibrary.Validators;

public class UserNameValidator : AbstractValidator<Person>
{
    public UserNameValidator()
    {
        RuleFor(person => person.UserName)
            .NotEmpty()
            .MinimumLength(3);
    }
}

