using PasswordMatchApp.Classes;
using PasswordMatchApp.Models;
using ValidationLibrary.Models;
// ReSharper disable LoopVariableIsNeverChangedInsideLoop

namespace PasswordMatchApp;

internal partial class Program
{
    static void Main()
    {

        bool breakFlag = false;


        while (!breakFlag)
        {
            Console.Clear();
            var (person, valid, tryAgain) = Login.GetCredentials();
            if (valid)
            {
                breakFlag = true;
                PresentMenu(person);

                break;
            }
            else if (tryAgain) // re-prompt for credentials
            {
                continue;
            }
            {
                return; // exit the program
            }
        }

        
        Console.ReadLine();
    }

    private static void PresentMenu(Person person)
    {
        Console.Clear();
        AnsiConsole.MarkupLine($"[yellow]Welcome {person.UserName}[/]");
        MenuItem menuItem = AnsiConsole.Prompt(MenuOperations.MainMenu());
        AnsiConsole.MarkupLine(menuItem.Id > -1
            ? $"Fuel type [cyan]{menuItem.Text}[/] at " +
              $"[cyan]{menuItem.Price:C}[/] Press a key to exit"
            : "[yellow]Nothing selected[/] Press a key to exit");
    }
}