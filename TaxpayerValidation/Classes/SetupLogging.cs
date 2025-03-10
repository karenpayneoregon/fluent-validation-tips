using Serilog;
using static System.DateTime;
using SeriLogThemesLibrary;

namespace TaxpayerValidation.Classes;
/// <summary>
/// Provides functionality to configure logging using Serilog for the application.
/// </summary>
/// <remarks>
/// This class is designed to simplify the setup of Serilog logging, keeping the 
/// <c>Program.Main</c> method clean and maintainable. It allows for easy reuse 
/// of logging configuration across different projects.
/// </remarks>
public class SetupLogging
{
    /// <summary>
    /// Configures Serilog for development environments.
    /// </summary>
    /// <remarks>
    /// This method sets up Serilog to log messages to both the console and a file. 
    /// The console output uses a custom theme, while the file logs are stored in a 
    /// directory named "LogFiles" under the application's base directory, with a 
    /// separate file for each day.
    /// </remarks>
    public static void Development()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Console(theme: SeriLogCustomThemes.Theme1())
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now.Year}-{Now.Month:d2}-{Now.Day}", "Log.txt"),
                rollingInterval: RollingInterval.Infinite,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();
    }
}


