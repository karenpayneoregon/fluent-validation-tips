using FluentValidation;
using UsingIncludeInValidationLibrary.Interfaces;

namespace UsingIncludeInValidationLibrary.Validators;

public class AddressValidator : AbstractValidator<IPerson>
{
    public AddressValidator()
    {
        RuleFor(item => item.Address.Line1).NotNull()
            .WithName("Street")
            .WithMessage("Please ensure you have entered your {PropertyName}");
        RuleFor(item => item.Address.Town).NotNull();
        RuleFor(item => item.Address.Country).NotNull();
        RuleFor(item => item.Address.Postcode).NotNull();
    }
}