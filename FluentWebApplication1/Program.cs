using FluentValidation;
using FluentValidation.AspNetCore;
using FluentWebApplication1.Models;
using FluentWebApplication1.Validators;
using Serilog;
using Serilog.Events;

using static System.DateTime;

namespace FluentWebApplication1;

/// <summary>
/// Represents the entry point of the FluentWebApplication1 application.
/// </summary>
/// <remarks>
/// This class is responsible for configuring and running the ASP.NET Core web application. 
/// It sets up services, middleware, and logging using Serilog and FluentValidation.
/// </remarks>
public class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        
        // Add FluentValidation services
        builder.Services.AddScoped<IValidator<Customer>, CustomerValidator>();
        builder.Services.AddFluentValidationAutoValidation();

        builder.Host.UseSerilog((context, configuration) =>
        {

            configuration.WriteTo.File(Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles"), $"{Now.Year}-{Now.Month:D2}-{Now.Day:D2}", "Log.txt"),
                rollingInterval: RollingInterval.Infinite,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}");

            configuration.MinimumLevel.Information();
            configuration.MinimumLevel.Override("Microsoft", LogEventLevel.Warning);
            configuration.MinimumLevel.Override("System", LogEventLevel.Warning);

        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
