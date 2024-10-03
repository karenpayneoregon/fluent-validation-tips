using InheritanceValidationApp.Models;
using InheritanceValidationApp.Validators;
using System.Text.Json;
using static InheritanceValidationApp.Classes.SpectreConsoleHelpers;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace InheritanceValidationApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        Organisation organisation = new()
        {
            Name = "Acme",
            //Email = "Acme@gmail.com",
            Headquarters = new()
            {
                Street = "123 Main St",
                City = "Any town",
                PostCode = "12345"
            }
        };

        OrganisationValidator validator = new();
        ValidationResult result = validator.Validate(organisation);
        if (result.IsValid)
        {
            AnsiConsole.MarkupLine("[yellow]Valid[/]");
        }
        else
        {
            PresentJson(JsonSerializer.Serialize(result));
        }

        ExitPrompt();
    }
}