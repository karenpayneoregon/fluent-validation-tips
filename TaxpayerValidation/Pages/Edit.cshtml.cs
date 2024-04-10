using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaxpayerValidation.Data;
using TaxpayerValidation.Models;

namespace TaxpayerValidation.Pages
{
    public class EditModel : PageModel
    {
        private readonly TaxpayerValidation.Data.Context _context;

        public EditModel(TaxpayerValidation.Data.Context context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
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
