using FluentValidation;

namespace InlineValidationSample.Validators;

public class ManagerValidator : AbstractValidator<Manager>
{
    public ManagerValidator()
    {
        Include(new FirstLastNameValidator());
        Include(new IdentifierValidator());

        //RuleForEach(x => x.Employees).SetValidator(new EmployeeValidator());

        RuleForEach(manager => manager.Employees)
            .Must(employee => !string.IsNullOrWhiteSpace(employee.FirstName))
            .WithMessage((manager, employee) =>
                $"Manager '{manager.FirstName}' '{manager.LastName}' employee with '{employee.Id}'" +
                $" has an empty {nameof(Employee.FirstName)}.")

            .Must(employee => !string.IsNullOrWhiteSpace(employee.LastName))
            .WithMessage((manager, employee) =>
                $"Manager '{manager.FirstName}' '{manager.LastName}' employee with '{employee.Id}'" +
                $" has an empty {nameof(Employee.LastName)}.");


    }
}