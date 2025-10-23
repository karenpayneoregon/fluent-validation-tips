using FluentValidation;
using FluentValidation.AspNetCore;
using FluentWebApplication1.Classes;
using FluentWebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using WebValidationLibrary1.LanguageExtensions;

namespace FluentWebApplication1.Pages;

/// <summary>
/// Represents the model for the Index page in the FluentWebApplication1 application.
/// </summary>
/// <remarks>
/// This class is responsible for handling the logic and data binding for the Index page.
/// It utilizes FluentValidation to validate the <see cref="Customer"/> model. 
/// The class inherits from <see cref="PageModel"/>, which provides the base functionality 
/// for Razor Pages in ASP.NET Core.
/// </remarks>
public class IndexModel(IValidator<Customer> validator) : PageModel
{

    /// <summary>
    /// Gets or sets the customer information.
    /// </summary>
    [BindProperty]
    public Customer Customer { get; set; } = new();
    
    

    /// <summary>
    /// Initializes a new instance of the <see cref="IndexModel"/> class.
    /// </summary>
    /// <returns></returns>
    public IActionResult OnGet()
    {
        Customer = new Customer() { SocialSecurityNumber = "106823302" };
        return Page();
    }

    /// <summary>
    /// Handles the submission of the form by validating the <see cref="Customer"/> model.
    /// </summary>
    /// <returns>
    /// A <see cref="PageResult"/> indicating the result of the operation. 
    /// If validation fails, the page is re-rendered with validation errors added to the model state.
    /// If validation succeeds, the page is re-rendered for further processing.
    /// </returns>
    /// <remarks>
    /// This method uses FluentValidation to validate the <see cref="Customer"/> object. 
    /// Validation errors are logged to the console (not recommended for production use) 
    /// and added to the model state for display on the page.
    /// </remarks>
    public PageResult OnPostSubmit()
    {
        // Perform validation
        var result = validator.Validate(Customer);
        if (!result.IsValid)
        {
            Log.Information("Validation failure on page {PageName} {@errors}", 
                PageHelpers.GetCurrentPageName(HttpContext.Request), result.ToJson());
            result.AddToModelState(ModelState);
        }

        return Page();
    }

}
