using FluentValidation;
using ValidationLibrary.Models;
// ReSharper disable RedundantVerbatimStringPrefix

namespace ValidationLibrary.Validators;

public class PasswordValidator : AbstractValidator<Person>
{

    public PasswordValidator()
    {

        RuleFor(person => person.Password.Length)
            .GreaterThan(7);

        RuleFor(person => person.Password)
            .Equal(p => p.PasswordConfirmation)
            .WithState(x => StatusCodes.PasswordsMisMatch);

    }
}

public class PassWordValidator : AbstractValidator<Person>
{
    public PassWordValidator()
    {
        RuleFor(p => p.Password).NotEmpty().WithMessage("Your password cannot be empty")
            .MinimumLength(8).WithMessage("Your password length must be at least 8.")
            .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
            .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
            .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");
    }
}