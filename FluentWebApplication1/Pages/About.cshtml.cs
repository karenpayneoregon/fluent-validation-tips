using FluentWebApplication1.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FluentWebApplication1.Pages
{
    public class AboutModel : PageModel
    {
        public string CurrentPageName { get; private set; }
        public void OnGet()
        {
 
            CurrentPageName = PageHelpers.GetCurrentPageName(HttpContext.Request);
        }
    }
}
