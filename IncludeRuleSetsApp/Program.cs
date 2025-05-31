using FluentValidation;
using IncludeRuleSetsApp.Classes;
using IncludeRuleSetsApp.Models;

namespace IncludeRuleSetsApp;

internal partial class Program
{
    private static void Main(string[] args)
    {

        var validator = new PersonValidator();
        
        var result = validator.Validate(
            MockedData.InvalidPerson, options => options.IncludeRuleSets(
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
                AnsiConsole.MarkupLine($"{error.PropertyName, -10} [red]Error:[/] {error.ErrorMessage}");
            }
        }

        AnsiConsole.MarkupLine("[yellow]Continue[/]");

        Console.ReadLine();
    }


}