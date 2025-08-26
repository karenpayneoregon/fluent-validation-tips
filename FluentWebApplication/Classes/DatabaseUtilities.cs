namespace FluentWebApplication.Classes;

using ConsoleConfigurationLibrary.Classes;
using static ConsoleConfigurationLibrary.Classes.ApplicationConfiguration;

/// <summary>
/// Provides utility methods for database-related operations within the application.
/// </summary>
/// <remarks>
/// This class contains methods to configure and initialize services required for database interactions.
/// It is designed to streamline the setup process and ensure proper dependency injection for database utilities.
/// </remarks>
public class DatabaseUtilities
{
    /// <summary>
    /// Configures and initializes the necessary services for the application.
    /// </summary>
    /// <remarks>
    /// This method sets up the dependency injection container by configuring services,
    /// building a service provider, and invoking the required initialization logic
    /// through the <see cref="SetupServices"/> class.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the required service <see cref="SetupServices"/> cannot be resolved.
    /// </exception>
    public static void Setup()
    {
        var services = ConfigureServices();
        using var provider = services.BuildServiceProvider();
        var setup = provider.GetService<SetupServices>();
        setup!.GetEntitySettings();
    }
}
