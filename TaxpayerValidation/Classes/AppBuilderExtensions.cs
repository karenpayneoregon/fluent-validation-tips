using FluentValidation;

namespace TaxpayerValidation.Classes;

public static class AppBuilderExtensions
{
    /// <summary>
    /// Lists all registered FluentValidation validators in the dependency injection container.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="WebApplicationBuilder"/> instance used to configure the application and its services.
    /// </param>
    /// <remarks>
    /// This method identifies all services registered for <see cref="FluentValidation.IValidator{T}"/> 
    /// and displays their associated model types and implementation types in the console output.
    /// </remarks>
    public static void GetRegisteredValidators(this WebApplicationBuilder builder)
    {
        // List all registered FluentValidation validators (services registered for IValidator<>)
        // Build a temporary provider so we can resolve implementations for display purposes
        var validatorServiceDescriptors = builder.Services
            .Where(sd => sd.ServiceType.IsGenericType && sd.ServiceType.GetGenericTypeDefinition() == typeof(IValidator<>))
            .ToList();

        if (validatorServiceDescriptors.Count > 0)
        {
            using var tempProvider = builder.Services.BuildServiceProvider();
            Console.WriteLine("=== Registered FluentValidation Validators (DI) ===");
            foreach (var sd in validatorServiceDescriptors)
            {
                var serviceType = sd.ServiceType; // IValidator<ModelType>
                var modelType = serviceType.GetGenericArguments().FirstOrDefault();
                var instance = tempProvider.GetService(serviceType);
                var implementationType = instance?.GetType() ?? sd.ImplementationType;
                var modelTypeName = modelType?.Name ?? "<UnknownModel>";
                var implementationName = implementationType?.Name ?? "<UnknownImplementation>";
                Console.WriteLine($"{modelTypeName} -> {implementationName}");
            }
            Console.WriteLine("====================================================");
        }
        else
        {
            Console.WriteLine("No validators registered in DI.");
        }
    }
}
