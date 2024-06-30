using FluentValidation;

#nullable disable

namespace InlineValidationSample1.Models;
public class Customers
{
    public int CustomerIdentifier { get; set; }
    public string CompanyName { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }

    public static readonly InlineValidator<Customers> Validator = new()
    {
        v => v.RuleFor(x => x.CompanyName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required"),

        v => v.RuleFor(x => x.Street)
            .NotEmpty()
            .WithMessage("{PropertyName} is required"),

        v => v.RuleFor(x => x.City)
            .NotEmpty()
            .WithMessage("{PropertyName} is required"),

        v => v.RuleFor(x => x.PostalCode)
            .NotEmpty()
            .WithMessage("{PropertyName} is required"),

    };

}