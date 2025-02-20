using FluentValidation;
using LoadValidatorApp.Models;

namespace LoadValidatorApp.Validators;

/// <summary>
/// Represents a validator for the <see cref="Load"/> model, ensuring that its properties meet specific validation rules.
/// </summary>
/// <remarks>
/// This validator enforces the following rules:
/// <list type="bullet">
/// <item>
/// <description>Each stop in the <see cref="Load.Stops"/> collection must have a non-empty and non-null <see cref="Stop.Name"/>.</description>
/// </item>
/// <item>
/// <description>Each stop's <see cref="Stop.AppointmentDateTime"/> must be non-empty, non-null, and in the future.</description>
/// </item>
/// <item>
/// <description>The stops in the <see cref="Load.Stops"/> collection must be in chronological order based on their <see cref="Stop.AppointmentDateTime"/>.</description>
/// </item>
/// </list>
/// </remarks>
public class LoadValidator : AbstractValidator<Load>
{
    public LoadValidator()
    {
        RuleForEach(x => x.Stops).ChildRules(stop =>
        {
            stop.RuleFor(s => s.Name)
                .NotEmpty()
                .NotNull();

            stop.RuleFor(s => s.AppointmentDateTime)
                .NotEmpty()
                .NotNull()
                .Must(x => x > DateTime.Now)
                .WithMessage("AppointmentDateTime must be in the future");

        });

        RuleFor(x => x.Stops)
            .Must(BeInChronologicalOrder)
            .WithMessage("Stops must be in chronological order");
    }

    private static bool BeInChronologicalOrder(Stop[] stops)
    {
        if (stops is not { Length: > 1 })
        {
            return true;
        }

        for (int index = 1; index < stops.Length; index++)
        {
            if (stops[index].AppointmentDateTime <= stops[index - 1].AppointmentDateTime)
            {
                return false;
            }
        }

        return true;
    }
}