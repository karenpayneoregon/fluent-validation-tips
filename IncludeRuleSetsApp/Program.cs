using FluentValidation;
using IncludeRuleSetsApp.Classes;
using IncludeRuleSetsApp.Models;
using IncludeRuleSetsApp.Validators;

namespace IncludeRuleSetsApp;

internal partial class Program
{
    private static void Main(string[] args)
    {

        ValidatePersonWithRuleSetsWildcard();
        ValidatePersonWithRuleSetsSpecific();

        AnsiConsole.Write(new Rule("[yellow]Continue[/]"));

        Console.ReadLine();
    }
    /// <summary>
    /// Validates a <see cref="Person"/> instance using specific rule sets.
    /// </summary>
    /// <remarks>
    /// This method utilizes the <see cref="PersonValidator"/> to validate a mocked <see cref="Person"/> object
    /// against the following rule sets:
    /// <list type="bullet">
    /// <item>
    /// <description><c>Names</c>: Ensures that the person's first and last names are not null.</description>
    /// </item>
    /// <item>
    /// <description><c>Identifier</c>: Ensures that the person's identifier is not zero.</description>
    /// </item>
    /// <item>
    /// <description><c>Birth</c>: Validates the person's birthdate using a custom rule.</description>
    /// </item>
    /// </list>
    /// If validation fails, the method outputs the validation errors to the console.
    /// Docs by JetBrains ReSharper IntelliCode
    /// </remarks>
    private static void ValidatePersonWithRuleSetsSpecific()
    {

        AnsiConsole.MarkupLine($"[cyan]{nameof(ValidatePersonWithRuleSetsSpecific)}[/]");

        var validator = new PersonValidator();

        var result = validator.Validate(MockedData.InvalidPerson, options => options.IncludeRuleSets(
                "Names",
                "Identifier",
                "Birth"));


        if (result.IsValid)
        {
            Console.WriteLine("Validation succeeded.");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                AnsiConsole.MarkupLine($"{error.PropertyName,-14} [red]Error:[/] {error.ErrorMessage}");
            }
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Validates a person object using all available rule sets.
    /// </summary>
    /// <remarks>This method demonstrates how to use a wildcard ("*") to include all rule sets during
    /// validation. It validates a predefined person object and outputs the validation results to the console.</remarks>
    /// <remarks>
    /// Docs by Visual Studio IntelliCode
    /// </remarks>
    private static void ValidatePersonWithRuleSetsWildcard()
    {
        
        AnsiConsole.MarkupLine($"[cyan]{nameof(ValidatePersonWithRuleSetsWildcard)}[/]");

        var validator = new PersonValidator();

        // Use wildcard to include all rule sets
        var result = validator.Validate(MockedData.InvalidPerson, options => options.IncludeRuleSets("*"));

        if (result.IsValid)
        {
            Console.WriteLine("Validation succeeded.");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                AnsiConsole.MarkupLine($"{error.PropertyName, -14} [red]Error:[/] {error.ErrorMessage}");
            }
        }

        Console.WriteLine();

    }
}