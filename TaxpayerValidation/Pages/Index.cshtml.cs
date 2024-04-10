using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaxpayerValidation.Data;
using TaxpayerValidation.LanguageExtensions;
using TaxpayerValidation.Models;

namespace TaxpayerValidation.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Context _context;

        public IndexModel(Context context)
        {
            _context = context;


        }

        public IList<Taxpayer> Taxpayer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Taxpayer = await _context.Taxpayer.ToListAsync();
        }
    }
}
