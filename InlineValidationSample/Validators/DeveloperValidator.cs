using FluentValidation;
using InlineValidationSample.LanguageExtensions;

using static InlineValidationSample.Classes.ValidationHelpers;

namespace InlineValidationSample.Validators;

/// <summary>
/// Provides validation rules for the <see cref="Developer"/> model.
/// </summary>
/// <remarks>
/// This validator includes rules for validating the first and last name
/// using <see cref="FirstLastNameValidator"/> and ensures that the 
/// <see cref="Developer.Type"/> property matches one of the predefined 
/// developer types.
/// </remarks>
public class DeveloperValidator : AbstractValidator<Developer>
{
    public DeveloperValidator()
    {
        Include(new FirstLastNameValidator());
        RuleFor(x => x.Type).In(DeveloperTypes);
    }
}