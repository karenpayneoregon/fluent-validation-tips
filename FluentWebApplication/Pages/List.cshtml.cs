using ConsoleConfigurationLibrary.Classes;
using FluentWebApplication.Classes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FluentWebApplication.Data;
using FluentWebApplication.Models;
using Serilog;

namespace FluentWebApplication.Pages;

public class ListModel : PageModel
{
    private readonly Context _context;

    public ListModel(Context context)
    {
        _context = context;

        if (EntitySettings.Instance.CreateNew)
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            Log.Information("Database created");
        }
        else
        {
            Log.Information("Database not created");
        }
    }


    public IList<Person> Person { get;set; } = null!;

    public async Task OnGetAsync()
    {
        if (_context.Person != null)
        {
            Person = await _context.Person.ToListAsync();
        }
    }
}