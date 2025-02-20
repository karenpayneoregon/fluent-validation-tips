using System.Runtime.CompilerServices;
using FluentValidation;
using TaxpayerLibrary.LanguageExtensions;
// ReSharper disable InvalidXmlDocComment

#pragma warning disable CA2255

namespace TaxpayerValidation.Classes;
internal class FluidSetup
{
    /// <summary>
    /// Initializes global FluentValidation options for the application.
    /// </summary>
    /// <remarks>
    /// This method sets a custom <see cref="ValidatorOptions.Global.DisplayNameResolver"/> 
    /// to resolve property names by splitting Pascal case into human-readable format.
    /// </remarks>
    [ModuleInitializer]
    public static void InitializeFluentValidation()
    {

        ValidatorOptions.Global.DisplayNameResolver = (type, memberInfo, expression) =>
            ValidatorOptions.Global.PropertyNameResolver(type, memberInfo, expression)
                .SplitPascalCase();
    }
}
