using FluentWebApplication.Classes;
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
        CancellationTokenSource cancellationTokenSource = new(TimeSpan.FromSeconds(1));
        _context = context;
        var success = context.CanConnectAsync(cancellationTokenSource.Token);
        if (success == false)
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }
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