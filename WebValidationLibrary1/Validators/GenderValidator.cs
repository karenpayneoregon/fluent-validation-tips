using FluentValidation;
using WebValidationLibrary1.Interfaces;
using WebValidationLibrary1.Models;

namespace WebValidationLibrary1.Validators;
/// <summary>
/// Provides validation rules for objects implementing the <see cref="IGender"/> interface.
/// </summary>
/// <remarks>
/// This validator ensures that the <see cref="IGender.Gender"/> property is not null and contains
/// a valid value, such as <see cref="Gender.Male"/>, <see cref="Gender.Female"/>, or <see cref="Gender.Unspecified"/>.
/// </remarks>
public class GenderValidator : AbstractValidator<IGender>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GenderValidator"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor sets up validation rules for objects implementing the <see cref="IGender"/> interface.
    /// It ensures that the <see cref="IGender.Gender"/> property is not null and contains a valid value,
    /// such as <see cref="Gender.Male"/>, <see cref="Gender.Female"/>, or <see cref="Gender.Unspecified"/>.
    /// </remarks>
    public GenderValidator()
    {
        RuleFor(x => x.Gender)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull().WithMessage("Please select Male or Female.")
            .Must(g => g is Gender.Male or Gender.Female or Gender.Unspecified)
            .WithMessage("Please select Male or Female.");
    }
}
