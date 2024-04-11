using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using TaxpayerValidation.Classes;
using TaxpayerValidation.LanguageExtensions;
using TaxpayerValidation.Models;

namespace TaxpayerValidation.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Data.Context _context;
        private IValidator<Taxpayer> _validator;

        /*
         * Use Dependency Injection to inject the context and the validator into the page model.
         */
        public CreateModel(Data.Context context, IValidator<Taxpayer> validator)
        {
            _context = context;
            _validator = validator;
            Log.Information("Done in create page constructor");

        }

        public IActionResult OnGet()
        {

            Taxpayer = DataService.BogusTaxpayer();

            return Page();
        }

        [BindProperty]
        public Taxpayer Taxpayer { get; set; } = new Taxpayer();

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

            // The model is valid, add the model to the context and save changes
            _context.Taxpayer.Add(Taxpayer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");

        }
    }
}
