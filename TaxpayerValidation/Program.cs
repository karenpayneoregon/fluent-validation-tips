using System.Diagnostics;
using EntityCoreFileLogger;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TaxpayerLibrary.Data;
using TaxpayerLibrary.Models;
using TaxpayerLibrary.Validators;
using TaxpayerValidation.Classes;
#pragma warning disable ASP0000

namespace TaxpayerValidation;
public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        
        builder.Services.AddScoped<IValidator<Taxpayer>, TaxpayerValidator>();
        builder.Services.AddFluentValidationAutoValidation();
        
        builder.GetRegisteredValidators();
 

        // setup logging
        SetupLogging.Development();


        RegisterDbContextServices(builder);


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

    /// <summary>
    /// Configures and registers the Entity Framework Core DbContext services for the application.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="WebApplicationBuilder"/> used to configure the application's services and environment.
    /// </param>
    /// <remarks>
    /// This method sets up the DbContext services differently based on the application's environment:
    /// <list type="bullet">
    /// <item>
    /// <description>In development mode, it enables sensitive data logging for debugging purposes.</description>
    /// </item>
    /// <item>
    /// <description>In non-development environments, sensitive data logging is disabled for security reasons.</description>
    /// </item>
    /// </list>
    /// The database connection string is retrieved from the application's configuration.
    /// </remarks>
    private static void RegisterDbContextServices(WebApplicationBuilder builder)
    {
        if (builder.Environment.IsDevelopment())
        {

            builder.Services.AddDbContextPool<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging()
                    .LogTo(new DbContextToFileLogger().Log, [
                            DbLoggerCategory.Database.Command.Name
                        ],
                        LogLevel.Information));
        }
        else
        {
            builder.Services.AddDbContextPool<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                    .LogTo(new DbContextToFileLogger().Log, [
                            DbLoggerCategory.Database.Command.Name
                        ],
                        LogLevel.Information));
        }
    }
}
