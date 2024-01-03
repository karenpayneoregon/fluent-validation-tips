﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FluentWebApplication.Models;

namespace FluentWebApplication.Pages;

public class EditModel : PageModel
{
    private readonly Data.Context _context;

    public EditModel(Data.Context context)
    {
        _context = context;
    }
    
    [BindProperty]
    public Person Person { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Person == null)
        {
            return NotFound();
        }

        var person =  await _context.Person.FirstOrDefaultAsync(m => m.PersonId == id);
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

        _context.Attach(Person).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PersonExists(Person.PersonId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./List");
    }

    private bool PersonExists(int id)
    {
        return (_context.Person?.Any(e => e.PersonId == id)).GetValueOrDefault();
    }
}