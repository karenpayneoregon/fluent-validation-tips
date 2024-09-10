using UsingIncludeInValidation.Classes;
using UsingIncludeInValidation.Validators;

namespace UsingIncludeInValidation;

internal partial class Program
{
    static void Main(string[] args)
    {
        
        var people = MockedData.List();

        PersonValidator validator = new();

        foreach (var person in people)
        {
            AnsiConsole.MarkupLine($"{person} [cyan]{person.GetType().Name}[/]");

            var result = validator.Validate(person);
            if (result.IsValid)
            {
                Console.WriteLine(true);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    AnsiConsole.MarkupLine($"[red]   {error.ErrorMessage}[/]");
                }
            }
        }
        
        Console.ReadLine();

    }

    
}