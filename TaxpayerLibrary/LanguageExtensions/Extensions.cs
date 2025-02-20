using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TaxpayerLibrary.LanguageExtensions;

//#pragma warning disable CS8618

/// <summary>
/// Provides extension methods for handling validation results and model state in ASP.NET Core
/// applications.
/// </summary>
public static class Extensions
{
    public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
    {
        foreach (var error in result.Errors)
        {
            modelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }
    }
}