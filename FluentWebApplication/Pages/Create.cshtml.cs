using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FluentWebApplication.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

#pragma warning disable CS8618

namespace FluentWebApplication.Pages;

public class CreateModel(Data.Context context, IValidator<Person> validator) : PageModel
{
    private IValidator<Person> _validator = validator;

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Person Person { get; set; } = null!;

    public async Task<IActionResult> OnPostAsync()
    {
        ValidationResult result = await _validator.ValidateAsync(Person);
        if (!result.IsValid)
        {

            result.AddToModelState(ModelState);
            return Page();
  
        }
        
        context.Person.Add(Person);
        var result1 = await context.SaveChangesAsync();

        return RedirectToPage("./List");
    }
}

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