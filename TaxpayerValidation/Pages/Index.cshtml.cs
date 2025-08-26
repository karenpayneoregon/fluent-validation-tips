using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TaxpayerLibrary.Data;
using TaxpayerLibrary.Models;


namespace TaxpayerValidation.Pages;

public class IndexModel : PageModel
{
    private readonly Context _context;

    public IndexModel(Context context)
    {
        _context = context;

        Log.Information("IndexModel constructor");
    }

    public IList<Taxpayer> Taxpayer { get; set; } = null!;

    public async Task OnGetAsync()
    {
        Taxpayer = await _context.Taxpayer.ToListAsync();
    }
}