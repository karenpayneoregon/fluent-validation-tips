using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FluentWebApplication.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

#pragma warning disable CS8618

namespace FluentWebApplication.Pages;

public class CreateModel : PageModel
{
    private readonly Data.Context _context;
    private IValidator<Person> _validator;

    public CreateModel(Data.Context context, IValidator<Person> validator)
    {
        _context = context;
        _validator = validator;
    }
    

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Person Person { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        ValidationResult result = await _validator.ValidateAsync(Person);
        if (!result.IsValid)
        {

            result.AddToModelState(ModelState);
            return Page();
  
        }


        _context.Person.Add(Person);
        await _context.SaveChangesAsync();

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