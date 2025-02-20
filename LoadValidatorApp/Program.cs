using LoadValidatorApp.Models;
using LoadValidatorApp.Validators;
using System.Text.Json;
using LoadValidatorApp.Classes;
using LoadValidatorApp.Converters;

namespace LoadValidatorApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        Original();
        Console.WriteLine();
        WithCorrectJson();

        Console.ReadLine();
    }

    /// <summary>
    /// JSON as taken from the original Stack Overflow question.
    /// DateTime format is not in the correct format which means a converter is required.
    /// </summary>
    private static void Original()
    {
        SpectreConsoleHelpers.PrintCyan();

        /*
         * Setup to not validate as the second stop is out of order.
         */
        var json =
            /* lang=json*/
            """
            {
              "Load": {
                "Stops": [
                  { 
                    "Name": "Stop 1",
                    "AppointmentDateTime": "02/25/2025T13:00:00"
                  },
                  { 
                    "Name": "Stop 2",
                    "AppointmentDateTime": "02/25/2025T16:00:00"
                  },
                  { 
                    "Name": "Stop 3",
                    "AppointmentDateTime": "02/25/2025T15:30:00"
                  }
                ]
              }
            }

            """;
 
        var result = JsonSerializer.Deserialize<Route>(json, Options).Load;

        LoadValidator validator = new();
        var validate = validator.Validate(result);

        if (!validate.IsValid)
        {
            AnsiConsole.MarkupLine($"[red]Invalid[/] {validate.Errors[0]}");
        }

        foreach (var stop in result.Stops)
        {
            Console.WriteLine($"Name: {stop.Name,-5}{stop.AppointmentDateTime}");
        }
    }

    /// <summary>
    /// JSON with the correct DateTime format.
    /// </summary>
    private static void WithCorrectJson()
    {
        SpectreConsoleHelpers.PrintCyan();

        /*
         * Setup to not validate as the second stop is out of order.
         */
        var json =
            /* lang=json*/
            """
            {
              "Load": {
                "Stops": [
                  {
                    "Name": "Stop 1",
                    "AppointmentDateTime": "2025-02-25T13:00:00"
                  },
                  {
                    "Name": "Stop 2",
                    "AppointmentDateTime": "2025-02-25T16:00:00"
                  },
                  {
                    "Name": "Stop 3",
                    "AppointmentDateTime": "2025-02-25T15:30:00"
                  }
                ]
              }
            }

            """;

        var result = JsonSerializer.Deserialize<Route>(json).Load;

        LoadValidator validator = new();
        var validate = validator.Validate(result);

        if (!validate.IsValid)
        {
            AnsiConsole.MarkupLine($"[red]Invalid[/] {validate.Errors[0]}");
        }

        foreach (var stop in result.Stops)
        {
            Console.WriteLine($"Name: {stop.Name,-5}{stop.AppointmentDateTime}");
        }
    }

    public static JsonSerializerOptions Options => new() {
        PropertyNameCaseInsensitive = true,
        Converters = { new CustomDateTimeConverter() }
    };
}