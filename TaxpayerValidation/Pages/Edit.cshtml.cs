using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TaxpayerValidation.LanguageExtensions;
using TaxpayerValidation.Models;

namespace TaxpayerValidation.Pages
{
    public class EditModel : PageModel
    {
        private readonly Data.Context _context;
        private IValidator<Taxpayer> _validator;

        /*
         * Use Dependency Injection to inject the context and the validator into the page model.
         */
        public EditModel(Data.Context context, IValidator<Taxpayer> validator)
        {
            _context = context;
            _validator = validator;
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

        public async Task<IActionResult> OnPostAsync()
        {
            
            // Validate the model
            ValidationResult result = await _validator.ValidateAsync(Taxpayer);

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
            _context.Attach(Taxpayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
            return _context.Taxpayer.Any(e => e.Id == id);
        }
    }
}
