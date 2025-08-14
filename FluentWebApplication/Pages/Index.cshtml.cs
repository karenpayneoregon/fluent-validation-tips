using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace FluentWebApplication.Pages;
public class IndexModel : PageModel
{


    public IndexModel()
    {
    }

    public void OnGet()
    {
        Log.Information("Started");

    }
}
