using FluentValidation;
using ValidationLibrary.Models;

namespace ValidationLibrary.Validators;

public class ManagerValidator : AbstractValidator<Employee>
{
    public ManagerValidator()
    {
        /*
         * Mocked although data could come from a database or json file
         * see https://github.com/karenpayneoregon/teaching-simple-validation/blob/master/SampleFormApp1/Classes/Operations.cs
         */
        List<string> managers = new List<string>() { "Jim Adams", "Mary Jones" };

        RuleFor(emp => emp.Manager)
            .Must((employee, name) => managers.Contains(employee.Manager))
            .WithMessage("Invalid manager name");

    }
}