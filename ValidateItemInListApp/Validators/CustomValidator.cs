using FluentValidation;
using ValidateItemInListApp.Models;

namespace ValidateItemInListApp.Validators;
public class CustomValidator : AbstractValidator<Master>
{
    public CustomValidator()
    {
        RuleFor(x => x.FamilyName)
            .NotEmpty()
            .WithMessage($"{nameof(Master.FamilyName)} can not be empty");

        RuleForEach(m => m.Children)
            .SetValidator(m => new ChildValidator(m.ValidNames));
    }
}

public class ChildValidator : AbstractValidator<Child>
{
    public ChildValidator(List<string> validNames)
    {
        RuleFor(c => c.Name)
            .Must(validNames.Contains)
            .WithMessage("Name does not exist in ValidNames");
    }
}
