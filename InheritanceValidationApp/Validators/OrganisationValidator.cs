using FluentValidation;
using InheritanceValidationApp.Models;

namespace InheritanceValidationApp.Validators;

/// <summary>
/// Provides validation rules for the <see cref="Organisation"/> model.
/// </summary>
public class OrganisationValidator : AbstractValidator<Organisation>
{
    public OrganisationValidator()
    {
        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.Email).NotNull();
        RuleFor(x => x.Headquarters).SetValidator(new AddressValidator());
    }
}