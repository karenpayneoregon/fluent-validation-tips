using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FluentWebApplication.Data;
using FluentWebApplication.Models;

namespace FluentWebApplication.Pages;

public class ListModel : PageModel
{
    private readonly Context _context;

    public ListModel(Context context)
    {
        _context = context;
    }

    public IList<Person> Person { get;set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Person != null)
        {
            Person = await _context.Person.ToListAsync();
        }
    }
}