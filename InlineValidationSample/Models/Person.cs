using FluentValidation;
using InlineValidationSample.Interfaces;
using InlineValidationSample.LanguageExtensions;
using static InlineValidationSample.Classes.ValidationHelpers;

namespace InlineValidationSample.Models;

public class Person : IHuman
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public DateOnly BirthDate { get; set; }
    public Gender Gender { get; set; }

    public static readonly InlineValidator<Person> Validator = new()
        {
            v => v.RuleFor(x => x.Title)
                .In(Titles),
            v => v.RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("{PropertyName} is required"),

            v => v.RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("{PropertyName} is required"),

            v => v.RuleFor(x => x.Gender)
                .NotNull()

        };
}