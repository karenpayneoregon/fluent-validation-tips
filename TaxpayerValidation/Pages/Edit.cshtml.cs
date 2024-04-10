using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaxpayerValidation.Models;

namespace TaxpayerValidation.Pages
{
    public class EditModel : PageModel
    {
        private readonly Data.Context _context;

        public EditModel(Data.Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Taxpayer Taxpayer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxpayer =  await _context.Taxpayer.FirstOrDefaultAsync(m => m.Id == id);
            if (taxpayer == null)
            {
                return NotFound();
            }
            Taxpayer = taxpayer;
            return Page();
        }

        // To protect from over posting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Taxpayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxpayerExists(Taxpayer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TaxpayerExists(int id)
        {
            return _context.Taxpayer.Any(e => e.Id == id);
        }
    }
}
