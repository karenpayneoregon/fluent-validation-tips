using System.Text.Json;

namespace InlineValidationSample.Classes;
internal static class ValidationHelpers
{
    private static ValidationContainer _container => 
        JsonSerializer.Deserialize<ValidationContainer>(
            File.ReadAllText("Validation.json"));

    public static string[] Titles => _container.Titles.ToArray();
    public static string[] ContactTypes = _container.ContactTypes.ToArray();
    
}