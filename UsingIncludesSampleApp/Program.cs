using Spectre.Console;
using UsingIncludesSampleApp.Classes;
using ValidationLibrary1.Validators;

namespace UsingIncludesSampleApp;
internal partial class Program
{
    static void Main(string[] args)
    {
        BasePersonValidator validator = new();
        var people = TestData.MockedData();
   
        foreach (var person in people)
        {
            var validate = validator.Validate(person);

            if (validate.IsValid)
            {
                AnsiConsole.MarkupLine($"{person.Id,-3}[green]Validation succeeded![/]");
            }
            else
            {
                foreach (var error in validate.Errors)
                {
                    AnsiConsole.MarkupLine($"{person.Id,-5}Property: {error.PropertyName} [red]Error: {error.ErrorMessage}[/]");
                }
            }
        }
        SpectreConsoleHelpers.ExitPrompt();
    }

}