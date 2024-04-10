using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TaxpayerValidation.LanguageExtensions;

//#pragma warning disable CS8618

/// <summary>
/// Provides an extension to set up view for validation errors
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