using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaxpayerLibrary.Data;
using TaxpayerLibrary.Models;


namespace TaxpayerValidation.Pages;

public class DeleteModel(Context context) : PageModel
{
    private readonly Context _context = context;

    [BindProperty]
    public Taxpayer Taxpayer { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var taxpayer = await _context.Taxpayer.FirstOrDefaultAsync(m => m.Id == id);

        if (taxpayer == null)
        {
            return NotFound();
        }
        else
        {
            Taxpayer = taxpayer;
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var taxpayer = await _context.Taxpayer.FindAsync(id);
        if (taxpayer != null)
        {
            Taxpayer = taxpayer;
            _context.Taxpayer.Remove(Taxpayer);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}