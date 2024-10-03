using FluentValidation;
using InheritanceValidationApp.Models;

namespace InheritanceValidationApp.Validators;

/// <summary>
/// Provides validation rules for the <see cref="Address"/> model.
/// </summary>
public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(x => x.Street).NotNull();
        RuleFor(x => x.City).NotNull();
        RuleFor(x => x.PostCode).NotNull();
    }
}