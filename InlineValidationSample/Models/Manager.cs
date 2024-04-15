using InlineValidationSample.Interfaces;

namespace InlineValidationSample.Models;

public class Manager : Person, IEmployee
{
    public List<Employee> Employees { get; set; }
}