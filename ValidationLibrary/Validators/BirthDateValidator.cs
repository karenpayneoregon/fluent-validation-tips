using FluentValidation;
using ValidationLibrary.Models;

namespace ValidationLibrary.Validators;

public class BirthDateValidator : AbstractValidator<Human>
{

    public BirthDateValidator()
    {
        int minYear = DateTime.Now.AddYears(-100).Year;
        RuleFor(x => x.BirthDate)
            .Must(x => x.Year > minYear && x.Year <= DateTime.Now.Year)
            .WithMessage($"Birth date must be greater than {minYear} " +
                         $"year and less than or equal to {DateTime.Now.Year} ");
    }
}