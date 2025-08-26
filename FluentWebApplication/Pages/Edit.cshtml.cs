using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FluentWebApplication.Models;

namespace FluentWebApplication.Pages;

public class EditModel(Data.Context context) : PageModel
{

    [BindProperty]
    public Person Person { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || context.Person == null)
        {
            return NotFound();
        }

        var person =  await context.Person.FirstOrDefaultAsync(m => m.PersonId == id);
        if (person == null)
        {
            return NotFound();
        }
        Person = person;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        context.Attach(Person).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PersonExists(Person.PersonId))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("./List");
    }

    private bool PersonExists(int id)
    {
        return (context.Person?.Any(e => e.PersonId == id)).GetValueOrDefault();
    }
}