namespace FluentWebApplication1.Classes;

/// <summary>
/// Represents a collection of constants and utilities related to the United States.
/// </summary>
/// <remarks>
/// This class provides a predefined set of allowed U.S. states, which can be used for validation
/// or other operations requiring a standardized list of states.
/// </remarks>
public class UnitedStates
{

    /// <summary>
    /// A static, read-only collection of U.S. state names and the District of Columbia.
    /// </summary>
    /// <remarks>
    /// This collection is case-insensitive and is intended for use in validation or operations
    /// requiring a standardized list of U.S. states.
    /// </remarks>

    public static readonly HashSet<string> AllowedStates = new(StringComparer.OrdinalIgnoreCase)
    {
        "Alabama","Alaska","Arizona","Arkansas","California","Colorado","Connecticut","District of Columbia",
        "Delaware","Florida","Georgia","Hawaii","Idaho","Illinois","Indiana","Iowa","Kansas","Kentucky",
        "Louisiana","Maine","Maryland","Massachusetts","Michigan","Minnesota","Mississippi","Missouri",
        "Montana","Nebraska","Nevada","New Hampshire","New Jersey","New Mexico","New York",
        "North Carolina","North Dakota","Ohio","Oklahoma","Oregon","Pennsylvania","Rhode Island",
        "South Carolina","South Dakota","Tennessee","Texas","Utah","Virginia","Vermont","Washington",
        "Wisconsin","West Virginia","Wyoming"
    };
}