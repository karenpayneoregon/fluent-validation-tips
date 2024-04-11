using System.Runtime.CompilerServices;
using FluentValidation;
using TaxpayerLibrary.LanguageExtensions;

#pragma warning disable CA2255

namespace TaxpayerValidation.Classes;
internal class FluidSetup
{
    [ModuleInitializer]
    public static void InitializeFluentValidation()
    {

        ValidatorOptions.Global.DisplayNameResolver = (type, memberInfo, expression) =>
            ValidatorOptions.Global.PropertyNameResolver(type, memberInfo, expression)
                .SplitPascalCase();
    }
}
