using FluentValidation;
using FluentValidation.AspNetCore;
using FluentWebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FluentWebApplication1.Pages;
public class IndexModel(IValidator<Customer> validator) : PageModel
{
    [BindProperty]
    public Customer Customer { get; set; } = new();

    public IActionResult OnGet()
    {
        Customer = new Customer();
        return Page();
    }
    
    public PageResult OnPostSubmit()
    {
        // Perform validation
        var result = validator.Validate(Customer);
        if (!result.IsValid)
        {
            // not for production use
            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            
            result.AddToModelState(ModelState);
            return Page();
        }

        // If valid, proceed 
        return Page();
    }

}
