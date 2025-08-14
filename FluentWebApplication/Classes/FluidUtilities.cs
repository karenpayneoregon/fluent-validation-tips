using FluentValidation;
using System.Reflection;
using Serilog;

namespace FluentWebApplication.Classes;

public static class FluidUtilities
{

    /// <summary>
    /// Discovers and logs all non-abstract, non-interface types in the current assembly 
    /// that implement the <see cref="FluentValidation.IValidator{T}"/> interface.
    /// </summary>
    /// <remarks>
    /// This method uses reflection to identify and list all validators registered in the assembly.
    /// It outputs the names of the discovered validator types to the console.
    /// </remarks>
    public static void GetRegisteredValidators()
    {
        List<string> list = new();
        var validatorTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t is { IsAbstract: false, IsInterface: false })
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType &&
                          i.GetGenericTypeDefinition() == typeof(IValidator<>)))
            .ToList();

        Console.WriteLine("=== FluentValidation Validators Found by Reflection ===");
        foreach (var type in validatorTypes)
        {
            Console.WriteLine(type.Name); // or by type.FullName
            list.Add(type.Name);
        }
        Console.WriteLine("========================================================");
        Log.Information("Validators {P1}", list.ToArray());
    }
}
