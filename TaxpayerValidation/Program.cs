using System.Diagnostics;
using EntityCoreFileLogger;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TaxpayerLibrary.Data;
using TaxpayerLibrary.Models;
using TaxpayerLibrary.Validators;
using TaxpayerValidation.Classes;

namespace TaxpayerValidation;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        
        builder.Services.AddScoped<IValidator<Taxpayer>, TaxpayerValidator>();
        builder.Services.AddFluentValidationAutoValidation();
        
        // setup logging
        SetupLogging.Development();

        // Setup EF Core - note that the sql will be outputted to the console window 
        // and a text file, one per day under the project folder while for production
        // the log file would go where it should.
        builder.Services.AddDbContextPool<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging()
                .LogTo(new DbContextToFileLogger().Log, new[]
                    {
                        DbLoggerCategory.Database.Command.Name
                    },
                    LogLevel.Information));

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
