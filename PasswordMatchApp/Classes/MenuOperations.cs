using PasswordMatchApp.Models;

namespace PasswordMatchApp.Classes;

/// <summary>
/// Provides operations for creating and managing menu interactions
/// within the application, including generating menus and handling
/// menu items.
/// </summary>
public class MenuOperations
{
    // Style for menu
    private static Style HighLightStyle =>
        new(Color.LightGreen, Color.Black, Decoration.None);

    // Create menu with mocked items
    public static SelectionPrompt<MenuItem> MainMenu()
    {
        SelectionPrompt<MenuItem> menu = new()
        {
            HighlightStyle = HighLightStyle
        };

        menu.Title("Select a [B]fuel type[/]");
        menu.AddChoices(MockedItems());

        return menu;
    }
    // For a real app, load items from a file
    public static List<MenuItem> MockedItems() =>
    [
        new() { Id = 0, Text = "A100", Price = 3.99 },
        new() { Id = 1, Text = "B234", Price = 3.45 },
        new() { Id = 2, Text = "X378", Price = 2.99 },
        new() { Id = 3, Text = "E333", Price = 4.23 },
        new() { Id = -1, Text = "Exit" }
    ];
}

