using FluentValidation.Results;
using InlineValidationSample.Validators;
using static InlineValidationSample.Classes.SpectreConsoleHelpers;

namespace InlineValidationSample;

internal partial class Program
{
    static void Main()
    {
        ValidatePersonWithInlineValidator();
        Console.WriteLine();
        ValidateDeveloperWithRegularValidator();
        Console.WriteLine();
        ValidateManagerWithEmployeesSample();

        Console.ReadLine();
    }


    /// <summary>
    /// Setup as an invalid <see cref="Person"/> as
    /// FirstName, LastName, Gender and Title are required.
    /// </summary>
    private static void ValidatePersonWithInlineValidator()
    {

        PrintCyan();

        Person person = new Person
        {
            //FirstName = "Jane", 
            LastName = "Adams", 
            //Gender = Gender.Female, 
            //Title = "Miss"
        };

        var validator = Person.Validator.Validate(person);
        if (validator.IsValid == false)
        {
            foreach (var error in validator.Errors)
            {
                Console.WriteLine($"   {error.ErrorMessage}");
            }
        }
        else
        {
            Console.WriteLine("Valid person");
        }
    }

    /// <summary>
    /// Setup with an invalid <see cref="Developer"/> as <see cref="Developer.Type"/>
    /// is required.
    /// </summary>
    private static void ValidateDeveloperWithRegularValidator()
    {

        PrintCyan();

        Developer developer = new Developer
        {
            FirstName = "John",
            LastName = "Doe",
            //Type = "C#"
        };

        DeveloperValidator validator = new DeveloperValidator();
        var validate = validator.Validate(developer);
        if (validate.IsValid == false)
        {
            foreach (var error in validate.Errors)
            {
                Console.WriteLine($"   {error.ErrorMessage}");
            }
        }
        else
        {
            Console.WriteLine("Valid developer");
        }
    }

    private static void ValidateManagerWithEmployeesSample()
    {

        PrintCyan();

        var manager = Manager;
        manager.Employees.FirstOrDefault().FirstName = "";

        ManagerValidator managerValidator = new();
        var validate = managerValidator.Validate(manager);

        if (validate.IsValid == false)
        {
            foreach (ValidationFailure error in validate.Errors)
            {
                Console.WriteLine($"   {error.ErrorMessage}");

            }
        }
        else
        {
            Console.WriteLine("Valid manager");
        }
    }
}