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
    /// <summary>
    /// Adds the validation errors from a <see cref="ValidationResult"/> 
    /// to the specified <see cref="ModelStateDictionary"/>.
    /// </summary>
    /// <param name="result">
    /// The <see cref="ValidationResult"/> containing validation errors.
    /// </param>
    /// <param name="modelState">
    /// The <see cref="ModelStateDictionary"/> to which the errors will be added.
    /// </param>
    public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
    {
        foreach (var error in result.Errors)
        {
            modelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }
    }
}