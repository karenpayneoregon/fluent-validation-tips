using FluentValidation;
using FluentValidation.AspNetCore;
using FluentWebApplication.Classes;
using FluentWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using System.Diagnostics;
using System.Reflection;
using FluentWebApplication.Classes.Filters;
using static System.DateTime;

namespace FluentWebApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        DatabaseUtilities.Setup();

        // Add services to the container.
        builder.Services.AddRazorPages();

        // Add FluentValidation services
        //builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Enable FluentValidation's automatic validation
        builder.Services.AddFluentValidationAutoValidation();


        builder.Services.AddRazorPages(options =>
        {
            options.Conventions.ConfigureFilter(new StripQuotesPageFilter());
        });


        builder.Host.UseSerilog((context, configuration) =>
        {

            configuration.WriteTo.File(Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles"), $"{Now.Year}-{Now.Month:D2}-{Now.Day:D2}", "Log.txt"),
                rollingInterval: RollingInterval.Infinite,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}");

            configuration.MinimumLevel.Information();
            configuration.MinimumLevel.Override("Microsoft", LogEventLevel.Warning);
            configuration.MinimumLevel.Override("System", LogEventLevel.Warning);

        });

        builder.Services.AddDbContextPool<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging()
                .LogTo(message => 
                    Debug.WriteLine(message), LogLevel.Information,null));

        var app = builder.Build();

        FluidUtilities.GetRegisteredValidators(); 

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

