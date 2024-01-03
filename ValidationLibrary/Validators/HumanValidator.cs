#nullable disable
using FluentValidation;
using ValidationLibrary.Models;
using static System.DateTime;

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

public class BirthDateValidator : AbstractValidator<Human>
{

    public BirthDateValidator()
    {
        int minYear = Now.AddYears(-100).Year;
        RuleFor(x => x.BirthDate)
            .Must(x => x.Year > minYear && x.Year <= Now.Year)
            .WithMessage($"Birth date must be greater than {minYear} " +
                         $"year and less than or equal to {Now.Year} ");
    }
}