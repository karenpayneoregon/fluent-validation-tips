using FluentValidation;
using FluentWebApplication1.Models;
using WebValidationLibrary1.LanguageExtensions;
using WebValidationLibrary1.Validators;

namespace FluentWebApplication1.Validators;

/// <summary>
/// Provides validation rules for the <see cref="Customer"/> model.
/// </summary>
/// <remarks>
/// This class defines validation logic for the <see cref="Customer"/> model, ensuring that its properties
/// meet the required criteria. The validation includes:
/// <list type="bullet">
/// <item>
/// <description>Validation for the <see cref="Customer.DateOfBirth"/> property to ensure it is not null and falls within a valid date range.</description>
/// </item>
/// <item>
/// <description>Validation for the <see cref="Customer.SocialSecurityNumber"/> property to ensure it is not empty and is a valid Social Security Number.</description>
/// </item>
/// <item>
/// <description>Integration of additional validation rules from <see cref="FirstNameValidator"/>, <see cref="LastNameValidator"/>, and <see cref="GenderValidator"/>.</description>
/// </item>
/// </list>
/// </remarks>
public sealed class CustomerValidator : AbstractValidator<Customer>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerValidator"/> class.
    /// </summary>
    /// <remarks>
    /// This validator is responsible for validating the <see cref="Customer"/> model.
    /// It includes the following validation rules:
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Ensures that the <see cref="Customer.DateOfBirth"/> property is not null and falls within a valid date range.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Ensures that the <see cref="Customer.SocialSecurityNumber"/> property is not empty and is a valid Social Security Number.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Includes additional validation rules from <see cref="FirstNameValidator"/>, <see cref="LastNameValidator"/>, and <see cref="GenderValidator"/>.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    public CustomerValidator()
    {

        RuleFor(x => x.DateOfBirth).DateRangeNotNullRule();


        RuleFor(x => x.SocialSecurityNumber)
            .NotEmpty().WithMessage("Social Security Number is required.")
            .SocialSecurityNumberRule();
        
        Include(new FirstNameValidator());
        Include(new LastNameValidator());
        Include(new GenderValidator());

    }

}




