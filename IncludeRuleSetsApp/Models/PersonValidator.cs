#nullable disable
using FluentValidation;

namespace IncludeRuleSetsApp.Models;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleSet("Names", () =>
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
        });

        RuleSet("Identifiers", () =>
        {
            RuleFor(x => x.PersonId).NotEqual(0);
        });
        
    }
}