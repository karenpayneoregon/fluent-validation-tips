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
}
