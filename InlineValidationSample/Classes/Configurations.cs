using System.Text.Json;

namespace InlineValidationSample.Classes;
internal class Configurations
{
    public static JsonSerializerOptions Indented => new() { WriteIndented = true };
    public static void Read()
    {
        ValidationContainer container = new()
        {
            Titles = ValidationHelpers.Titles.ToList(),
            ContactTypes = ValidationHelpers.ContactTypes.ToList(),
            DeveloperTypes = ValidationHelpers.DeveloperTypes.ToList()
        };

        var json = JsonSerializer.Serialize(container, Indented);
        Console.WriteLine(json);


    }
}
