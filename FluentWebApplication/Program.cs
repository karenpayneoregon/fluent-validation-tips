using FluentValidation;
using FluentValidation.AspNetCore;
using FluentWebApplication.Classes;
using FluentWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Diagnostics;
using System.Reflection;
using static System.DateTime;

namespace FluentWebApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        // Add FluentValidation services
        //builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        // Alternatively, you can register a specific validator
        //builder.Services.AddSingleton<IValidator<Person>, PersonValidator>();

        // Enable FluentValidation's automatic validation
        builder.Services.AddFluentValidationAutoValidation();


        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("System", LogEventLevel.Warning)
            .MinimumLevel.Information()
            .WriteTo.File(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles",
                    $"{Now.Year}-{Now.Month:d2}-{Now.Day:d2}", "Log.txt"),
                rollingInterval: RollingInterval.Infinite,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();

        builder.Host.UseSerilog();

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
