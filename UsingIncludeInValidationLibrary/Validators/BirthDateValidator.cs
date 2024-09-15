using FluentValidation;
using Microsoft.Extensions.Configuration;
using UsingIncludeInValidationLibrary.Interfaces;
using UsingIncludeInValidationLibrary.Models;
#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace UsingIncludeInValidationLibrary.Validators;

public class BirthDateValidator : AbstractValidator<IPerson>
{

    public BirthDateValidator()
    {

        var value = JsonRoot().GetSection(nameof(ValidationSettings)).Get<ValidationSettings>().MinYear;
        var minYear = DateTime.Now.AddYears(value).Year;

        RuleFor(x => x.BirthDate)
            .Must(x => x.Year > minYear && x.Year <= DateTime.Now.Year)
            .WithMessage($"Birth date must be greater than {minYear} " +
                         $"year and less than or equal to {DateTime.Now.Year} ");
    }
}