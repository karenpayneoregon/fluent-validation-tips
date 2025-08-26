using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TaxpayerLibrary.Data;
using TaxpayerLibrary.LanguageExtensions;
using TaxpayerLibrary.Models;
// ReSharper disable PreferConcreteValueOverDefault


namespace TaxpayerValidation.Pages;

public class EditModel(Context context, IValidator<Taxpayer> validator) : PageModel
{

    [BindProperty]
    public Taxpayer Taxpayer { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {

        if (id == null)
        {
            return NotFound();
        }

        var taxpayer =  await context.Taxpayer.FirstOrDefaultAsync(m => m.Id == id);
        if (taxpayer == null)
        {
            return NotFound();
        }

        Taxpayer = taxpayer;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
            
        // Validate the model
        ValidationResult result = await validator.ValidateAsync(Taxpayer);

        // If the model is not valid, add the errors to the model state
        if (!result.IsValid)
        {

            result.AddToModelState(ModelState);
            return Page();

        }

        /*
         * The DbContext does not know the state of the entity, so we need to attach it
         * and mark its state to Modified.
         */
        context.Attach(Taxpayer).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException dce)
        {
            Log.Error(dce, $"Concurrency error when attempting to update a taxpayer with id " +
                           $"{Taxpayer.Id}");

            if (!TaxpayerExists(Taxpayer.Id))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool TaxpayerExists(int id)
    {
        return context.Taxpayer.Any(e => e.Id == id);
    }
}