using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using FluentWebApplication1.Models;
using FluentWebApplication1.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using System.ComponentModel.DataAnnotations;

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
            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            result.AddToModelState(ModelState);
            return Page();
        }

        // If valid, proceed with your logic
        return Page();
    }

    //public IActionResult OnPost()
    //{
    //    var result =  _validator.Validate(Customer);
    //    if (!result.IsValid)
    //    {

    //        result.AddToModelState(ModelState);
    //        return Page();

    //    }


    //    return RedirectToPage("./List");
    //}

}
