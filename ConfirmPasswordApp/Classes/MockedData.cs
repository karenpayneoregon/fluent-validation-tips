using ConfirmPasswordApp.Interfaces;
using ConfirmPasswordApp.Models;

namespace ConfirmPasswordApp.Classes;

/// <summary>
/// Provides a collection of mocked data for testing purposes.
/// </summary>
public static class MockedData
{
    /// <summary>
    /// Retrieves a list of mocked user data for testing purposes.
    /// </summary>
    /// <returns>
    /// A list of <see cref="IUser"/> objects, each representing a user with predefined properties.
    /// </returns>
    public static List<IUser> Users() =>
    [
        new User { Id = 1, UserName = "Alice", Password = "Password123!", ConfirmPassword = "Password123!" },
        new User { Id = 2, UserName = "Bob", Password = "Secure*45", ConfirmPassword = "Secure*456" },
        new User { Id = 3, Password = "MyPass789@", ConfirmPassword = "MyPass789@" }
    ];
}