#nullable disable
using FluentValidation;
using IncludeRuleSetsApp.Interfaces;
using IncludeRuleSetsApp.LanguageExtensions;
using IncludeRuleSetsApp.Models;

namespace IncludeRuleSetsApp.Validators;

/// <summary>
/// Provides validation rules for the <see cref="Person"/> model.
/// </summary>
/// <remarks>
/// This validator includes multiple rule sets:
/// <list type="bullet">
/// <item>
/// <description><c>Names</c>: Ensures that <see cref="Person.FirstName"/> and <see cref="Person.LastName"/> are not null.</description>
/// </item>
/// <item>
/// <description><c>Identifier</c>: Ensures that <see cref="Person.PersonId"/> is not equal to 0.</description>
/// </item>
/// <item>
/// <description><c>Birth</c>: Validates <see cref="Person.BirthDate"/> using a custom rule defined in <see cref="RuleBuilderExtensions.BirthDateRule{T}"/>.</description>
/// </item>
/// </list>
/// </remarks>
public class PersonValidator : AbstractValidator<IPerson>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PersonValidator"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor defines validation rules for the <see cref="Person"/> model using multiple rule sets:
    /// <list type="bullet">
    /// <item>
    /// <description><c>Names</c>: Ensures that <see cref="Person.FirstName"/> and <see cref="Person.LastName"/> are not null.</description>
    /// </item>
    /// <item>
    /// <description><c>Identifier</c>: Ensures that <see cref="Person.PersonId"/> is not equal to 0.</description>
    /// </item>
    /// <item>
    /// <description><c>Birth</c>: Validates <see cref="Person.BirthDate"/> using a custom rule defined in <see cref="RuleBuilderExtensions.BirthDateRule{T}"/>.</description>
    /// </item>
    /// </list>
    /// </remarks>
    public PersonValidator()
    {
        RuleSet("Names", () =>
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
        });

        RuleSet("Identifier", () =>
        {
            RuleFor(x => x.PersonId).NotEqual(0);
        });

        RuleSet("Birth", () =>
        {
            RuleFor(x => x.BirthDate).BirthDateRule();
        });

        RuleSet("Email", () =>
        {
            RuleFor(x => x.EmailAddress).NotEmpty().EmailAddress();
        });
    }
}