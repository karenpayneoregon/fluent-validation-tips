#nullable disable
using FluentValidation;
using ValidationLibrary.Models;

namespace ValidationLibrary.Validators;

public class HumanValidator : AbstractValidator<Human>
{
    public HumanValidator()
    {
        

        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        Include(new BirthDateValidator());

    }
}