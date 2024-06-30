using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace InlineValidationSample;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "FluentValidation InlineValidator sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    private static Manager Manager
    {
        get
        {
            Manager manager = new()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Title = "Owner",
                Employees =
                [
                    new()
                    {
                        Id = 1,
                        FirstName = "Jane",
                        LastName = "Adams",
                        Title = "Sales Agent"
                    },

                    new()
                    {
                        Id = 2,
                        FirstName = "Phil",
                        LastName = "Doe",
                        Title = "Marketing Manager"
                    }
                ]
            };

            return manager;
        }
    }
}
