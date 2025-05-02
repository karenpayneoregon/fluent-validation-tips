using ConfirmPasswordApp.Classes;
using ConfirmPasswordApp.Interfaces;
using ConfirmPasswordApp.Validators;
using FluentValidation;

namespace ConfirmPasswordApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        // if there are multiple errors only the first one will be shown
        ValidatorOptions.Global.CascadeMode = CascadeMode.Stop;

        List<IUser> list = MockedData.Users();

        foreach (var result in from user in list let validator = new UserValidator() select validator.Validate(user))
        {

            AnsiConsole.MarkupLine(result.IsValid ? 
                "[green]Is valid[/]" : 
                $"[red]{result.ToString(" - ")}[/]");

            Console.WriteLine();

        }

        Console.ReadLine();

    }
}