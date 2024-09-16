using FluentValidation;
using UsingIncludeInValidationLibrary.Classes;
using UsingIncludeInValidationLibrary.Interfaces;
using UsingIncludeInValidationLibrary.Models;

namespace UsingIncludeInValidationLibrary.Validators;

public class AddressValidator : AbstractValidator<IPerson>
{
    public AddressValidator()
    {
        RuleFor(item => item.Address.Line1).NotNull()
            .WithName("Street")
            .WithMessage("Please ensure you have entered your {PropertyName}");
        RuleFor(item => item.Address.Town).NotNull();
        RuleFor(item => item.Address.Country)
            .Length(2)
            .Must(ValidateCountry)
            .WithMessage($"Country must be {_countries.JoinWithLastSeparator(" or ")}")
            .NotNull();
        RuleFor(item => item.Address.Postcode).NotNull();
    }

    /// <summary>
    /// Acceptable country codes for <see cref="Address.Country"/>
    /// </summary>
    private readonly string[] _countries = ["US", "CA", "MX"];

    /// <summary>
    /// Validate <see cref="Address.Country"/> has a valid country code
    /// </summary>
    /// <param name="countrycode">country code</param>
    private bool ValidateCountry(string countrycode) 
        => _countries.Contains(countrycode, StringComparer.OrdinalIgnoreCase);
}