using FluentValidation;
using ValidationLibrary.LanguageExtensions;
using ValidationLibrary.Models;

namespace ValidationLibrary.Validators;

public class HumanValidator : AbstractValidator<Human>
{
    public HumanValidator()
    {
        
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.BirthDate).BirthDateRule();
    }
}