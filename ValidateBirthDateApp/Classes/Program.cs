using FluentValidation;
using System.Runtime.CompilerServices;
using ValidateBirthDateApp.LanguageExtensions;

// ReSharper disable once CheckNamespace
namespace ValidateBirthDateApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "FluentValidation Code sample";

        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);

        // Set up FluentValidation for .WithName
        ValidatorOptions.Global.DisplayNameResolver = (type, memberInfo, expression) =>
            ValidatorOptions.Global.PropertyNameResolver(type, memberInfo, expression)
                .SplitPascalCase();
    }
}
